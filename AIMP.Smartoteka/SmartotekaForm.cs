namespace AIMP.Smartoteka
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Windows.Forms;
    using Autocomplete;
    using Newtonsoft.Json;
    using SDK;
    using SDK.MessageDispatcher;
    using SDK.Player;
    using SDK.Playlist;

    public partial class SmartotekaForm : Form
    {
        private readonly IAimpPlayer _aimpPlayer;

        private List<Tuple<Record, IAimpPlaylistItem>> _records;
        private bool _blockEvents;
        private Options _options;
        private Process _webServer;

        Options Options
        {
            get
            {
                while (_options == null
                       || string.IsNullOrEmpty(_options.ExportPath)
                       || string.IsNullOrEmpty(_options.CacheTagsPath)
                       || string.IsNullOrEmpty(_options.WorkingDirectory))
                {
                    optionsToolStripMenuItem_Click(this, EventArgs.Empty);
                }

                return _options;
            }
        }

        public SmartotekaForm(IAimpPlayer player, MessageHook coreMessage)
        {
            _aimpPlayer = player;

            InitializeComponent();

            coreMessage.OnCoreMessage += OnOnCoreMessage();

            Load += OnActivated;

            _aimpPlayer.ServicePlaylistManager.PlaylistQueue.ContentChanged += (sender) =>
            {
                // Logger.Instance.AddInfoMessage($"[Event] PlaylistQueue.ContentChanged");
            };

            _aimpPlayer.ServicePlaylistManager.PlaylistQueue.StateChanged += (sender) =>
            {
                //Logger.Instance.AddInfoMessage($"[Event] PlaylistQueue.StateChanged");
            };

            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            dataGridView1.RowTemplate.ContextMenuStrip = gridContextMenuStrip1;

            filterTitleTagList1.SelectedTag += (s, e) => Filter();

            foreach (var tagBtn in popularGroupBox1.Controls.Cast<Control>().Where(el => el is Button).Cast<Button>())
            {
                tagBtn.Click += Tag_Click;
            }
        }

        private HookMessage OnOnCoreMessage()
        {
            return (message, param1, param2) =>
            {
                System.Diagnostics.Debug.WriteLine(
                    $"message: {message}, param1: {(AimpCoreMessageType) param1}, param2: {param2}");

                if (message == AimpCoreMessageType.EventPlayerState)
                {
                    //Logger.Instance.AddInfoMessage($"[Event] AimpPlayer.StateChanged: {param1}");

                    switch ((AimpPlayerState) param1)
                    {
                        case AimpPlayerState.Stopped:
                            toolStripStatusLabel1.Text = "State: stopped";
                            break;
                        case AimpPlayerState.Pause:
                            toolStripStatusLabel1.Text = "State: pause";
                            break;
                        case AimpPlayerState.Playing:
                            toolStripStatusLabel1.Text = "State: playing";
                            break;
                    }
                }
                else if (message == AimpCoreMessageType.EventPropertyValue)
                {
                    switch (param1)
                    {
                        case (int) AimpCoreMessageType.PropertyStayOnTop:
                        {
                            var val = Convert.ToBoolean(Marshal.ReadByte(param2));

                            toolStripStatusLabel1.Text += " " + val;
                            break;
                        }
                        case (int) AimpCoreMessageType.EventPlayerUpdatePosition:
                        {
                            var val = Convert.ToBoolean(Marshal.ReadByte(param2));
                            toolStripStatusLabel1.Text += " " + val;
                            break;
                        }
                        case (int) AimpCoreMessageType.PropertyPlayerPosition:
                        {
                            var val = Convert.ToDouble(Marshal.ReadInt32(param2));
                            toolStripStatusLabel1.Text += " " + val;
                            break;
                        }
                    }
                }
                else if (message == AimpCoreMessageType.EventPlayerUpdatePosition)
                {
                    playTrackBar1.Maximum = (int) _aimpPlayer.Duration;
                    playTrackBar1.Value = (int) _aimpPlayer.Position;
                }

                else if (message == AimpCoreMessageType.PropertyVolume)
                {
                    float volume = 0f;
                    unsafe
                    {
                        float* pointer = (float*) param2.ToPointer();

                        volume = *pointer;
                    }
                    //toolStripStatusLabel1.Text = "Volume =" + volume;

                    _blockEvents = true;
                    soundTrackBar.Value = (int) (volume * 100);
                    _blockEvents = false;
                }

                return ActionResultType.OK;
            };
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        private void AddPlayListTab(string id, string name, IAimpPlaylist playList)
        {
            LoadTracks(playList);

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[2].Width = 300;

            Filter();

            _editMultiTagList.Data = _filterMultiTagList.Data;
            _editMultiTagList.AllowCreateTags = true;
            _editMultiTagList.Init();

            _filterMultiTagList.UpdateTags += (s, e) => Filter();

            this.filterTitleTagList1.Data = _records
                .Select(el => el.Item1.Title)
                //.SelectMany(el => el.Split(';'))
                .Where(el => !string.IsNullOrEmpty(el))
                .OrderBy(el => el)
                .Distinct()
                .ToArray();

            this.filterTitleTagList1.Init();
        }

        public void LoadTracks(IAimpPlaylist playList)
        {
            var result = playList.GetFiles(PlaylistGetFilesFlag.All);
            if (result.ResultType != ActionResultType.OK)
                return;

            var loadedRecords = CacheMngr.Load(CurrentCachePath);
            _records = Records(playList, loadedRecords);

            var table = Converter.ToDataTable(_records.Select(el => el.Item1));

            dataGridView1.DataSource = table;
            dataGridView1.Update();
        }

        private string CurrentCachePath =>
            Path.Combine(Options.CacheTagsPath, playedListComboBox.SelectedValue + "") + ".json";

        private List<Tuple<Record, IAimpPlaylistItem>> Records(IAimpPlaylist playList, List<Record> loadedRecords)
        {
            var records = new List<Tuple<Record, IAimpPlaylistItem>>();
            loadedRecords = loadedRecords ?? new List<Record>();
            var recordsCache = loadedRecords.ToDictionary(el => el.FileName);

            bool isAddNew = false;
            int count = playList.GetItemCount();
            for (var i = 0; i < Math.Max(count, 10); i++)
            {
                var item = playList.GetItem(i);
                if (item.ResultType != ActionResultType.OK)
                {
                    continue;
                }

                var fileInfo = item.Result;
                recordsCache.TryGetValue(fileInfo.FileName, out var record);

                if (record == null)
                {
                    isAddNew = true;
                    record = new Record()
                    {
                        Title = fileInfo.DisplayText,
                        FileName = fileInfo.FileName,
                        Duration = TimeSpan.FromSeconds(fileInfo.FileInfo.Duration).ToString()
                    };

                    var result1 = _aimpPlayer.ServiceFileTagEditor.EditFile(fileInfo.FileName);
                    if (result1.ResultType == ActionResultType.OK)
                    {
                        var editor = result1.Result;
                        var tagCount = editor.GetTagCount();
                        var tag = editor.GetTag(tagCount > 1 ? 1 : 0);
                        if (tag.ResultType == ActionResultType.OK)
                        {
                            record.Tags = tag.Result.Comment;
                        }
                    }
                }

                records.Add(new Tuple<Record, IAimpPlaylistItem>(record, fileInfo));
            }

            if (isAddNew)
            {
                CacheMngr.ExportToFile(records.Select(el => el.Item1).ToList(), CurrentCachePath);
            }

            return records;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var records = _records.Select(el => el.Item1).ToList();

            var path =
                Path.Combine(
                    Options.ExportPath,
                    DateTime.Now.ToString("s").Replace("-", "_").Replace(":", "_")
                ) + ".json";

            CacheMngr.ExportToFile(records, path);
        }

        private void OnActivated(object sender, EventArgs eventArgs)
        {
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            var pl = _aimpPlayer.ServicePlaylistManager.GetActivePlaylist();
            _aimpPlayer.Play(pl.Result);
            _aimpPlayer.Core.SendMessage(AimpCoreMessageType.CmdShowNotification, 0, "Play Play Play");

            if (dataGridView1.SelectedRows.Count == 0)
                return;

            var fileName = dataGridView1.SelectedRows[0].Cells["FileName"].Value + "";

            PlayFile(fileName);
        }

        private void PlayFile(string fileName)
        {
            playTrackBar1.Value = 0;
            var trackItem = GetRecordByFileName(fileName).Item2;

            _aimpPlayer.Play(trackItem);
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            _aimpPlayer.Stop();
            playTrackBar1.Value = 0;
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            _aimpPlayer.Pause();
        }

        private void volumeTrackBar2_Scroll(object sender, EventArgs e)
        {
            if (_blockEvents)
                return;

            int v = soundTrackBar.Value;
            _aimpPlayer.Volume = (float) v / 100;
        }

        private void positionTrackBar1_Scroll(object sender, EventArgs e)
        {
            _aimpPlayer.Position = playTrackBar1.Value;
        }

        private void muteBtn_Click(object sender, EventArgs e)
        {
            _aimpPlayer.IsMute = !_aimpPlayer.IsMute;
        }

        private void PlayerForm_Shown(object sender, EventArgs e)
        {
            _options = OptionsMngr.Load(_aimpPlayer);

            soundTrackBar.Maximum = 100;
            soundTrackBar.Value = (int) (_aimpPlayer.Volume * 100);

            var names = new List<string>();
            var count = _aimpPlayer.ServicePlaylistManager.GetLoadedPlaylistCount();
            for (var i = 0; i < count; i++)
            {
                var result = _aimpPlayer.ServicePlaylistManager.GetLoadedPlaylist(i);

                if (result.ResultType == ActionResultType.OK)
                {
                    names.Add(result.Result.Name);
                }
            }

            _blockEvents = true;
            names = names.OrderBy(el => el).ToList();
            this.playedListComboBox.DataSource = names;

            if (!string.IsNullOrEmpty(Options.CurrentListName))
            {
                var selectedIndex = names.IndexOf(Options.CurrentListName);
                if (selectedIndex < 0)
                    this.playedListComboBox.SelectedIndex = selectedIndex;
            }

            _blockEvents = false;

            LoadSelectedList();
        }

        public void LoadSelectedList()
        {
            var selectedPlayList = this.playedListComboBox.SelectedValue + "";
            if (string.IsNullOrEmpty(selectedPlayList))
                return;

            var currentList =
                _aimpPlayer.ServicePlaylistManager.GetLoadedPlaylistByName(selectedPlayList);

            //TODO: заполнение списка выбора, затем по текущему списку загрузка.
            //запоминание текущего списка.
            if (currentList.ResultType == ActionResultType.OK)
            {
                AddPlayListTab(currentList.Result.Id, currentList.Result.Name, currentList.Result);
            }
        }

        private void Tag_Click(object sender, EventArgs e)
        {
            var button = (Button) sender;

            if (_filterMultiTagList.Selected.Contains(button.Text))
            {
                _filterMultiTagList.RemoveTag(button.Text);
            }
            else
            {
                _filterMultiTagList.AddTag(button.Text);
            }
        }

        private void Filter()
        {
            var tags = _filterMultiTagList.Selected.ToArray();
            var nameFilter = filterTitleTagList1.SelectedText;

            var filterTags = FilterByTags.BuildFilter(tags);
            var filterName = string.IsNullOrEmpty(nameFilter) ? null : $"Title like '%{nameFilter}%'";

            Table.DefaultView.RowFilter = string.Join(" and ",
                new string[] {filterTags, filterName}.Where(el => !string.IsNullOrEmpty(el)));
            dataGridView1.Update();

            var dataRows = Table.Select(Table.DefaultView.RowFilter);
            var data = dataRows
                .Select(el => el["Tags"] + "")
                .SelectMany(el => el.Split(';'))
                .Where(el => !string.IsNullOrEmpty(el))
                .OrderBy(el => el)
                .Distinct()
                .Where(el => !tags.Contains(el))
                .ToArray();

            _filterMultiTagList.Data = data; //.Union(tags).ToArray();
            _filterMultiTagList.Init();
        }


        private DataTable Table => dataGridView1.DataSource as DataTable;

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                editTitleLabel.Text = "";
                _editMultiTagList.Selected = null;

                editGroupBox1.Visible = false;

                return;
            }

            var selectedRowsCount = dataGridView1.SelectedRows.Count;
            if (selectedRowsCount == 1)
            {
                var fileName = dataGridView1.Rows[e.RowIndex].Cells["FileName"].Value + "";
                var record = GetRecordByFileName(fileName).Item1;

                editTitleLabel.Text = record.Title;
                durationLabel1.Text = record.Duration;
                _editMultiTagList.Selected = Converter.GetTags(record.Tags);
                editGroupBox1.Visible = true;
            }
            else
            {
                var rows = SelectedRows().ToArray();

                var commonTagsDict = Converter.CommonTagsDict(rows, selectedRowsCount);

                editTitleLabel.Text = "------------";
                durationLabel1.Text = "";
                _editMultiTagList.Selected = commonTagsDict.Keys;
                editGroupBox1.Visible = true;
            }
        }

        private void editSaveBtn_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dataGridView1.SelectedRows.Count;

            if (selectedRowsCount < 1)
                return;

            var rows = SelectedRows().ToArray();

            var commonTagsDict = Converter.CommonTagsDict(rows, selectedRowsCount);

            foreach (var row in rows)
            {
                var tags = Converter.GetTags(row);

                var resultTags = tags.Where(tag => !commonTagsDict.ContainsKey(tag)).Union(_editMultiTagList.Selected);
                var record = GetRecordByFileName(row["FileName"] + "").Item1;
                row["Tags"] = record.Tags = Converter.ToTagsString(resultTags);

                SaveRecordInFile(record);
            }

            var newTags = _editMultiTagList.Selected.Where(el => !_editMultiTagList.Data.Contains(el));

            _filterMultiTagList.Data = _editMultiTagList.Data = _editMultiTagList.Data.Union(newTags).ToArray();
            _filterMultiTagList.Init();
            _editMultiTagList.Init();

            CacheMngr.ExportToFile(_records.Select(el => el.Item1).ToList(), CurrentCachePath);
        }

        private void SaveRecordInFile(Record record)
        {
            try
            {
                var result = _aimpPlayer.ServiceFileTagEditor.EditFile(record.FileName);
                if (result.ResultType == ActionResultType.OK)
                {
                    var editor = result.Result;
                    var tagCount = editor.GetTagCount();

                    var tag = editor.GetTag(tagCount > 1 ? 1 : 0);
                    if (tag.ResultType == ActionResultType.OK)
                    {
                        if (tagCount > 1)
                        {
                            var prevTag = editor.GetTag(0);
                            prevTag.Result.Comment = " ";
                        }

                        tag.Result.Comment = record.Tags;
                        editor.Save();
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        private IEnumerable<DataRow> SelectedRows()
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                yield return Table.Rows.Find(dataGridView1.Rows[row.Index].Cells["FileName"].Value + "");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            playTrackBar1.Value = 0;

            var fileName = dataGridView1.Rows[e.RowIndex].Cells["FileName"].Value + "";
            PlayFile(fileName);
        }

        private Tuple<Record, IAimpPlaylistItem> GetRecordByFileName(string fileName)
        {
            return _records.Find(el => el.Item1.FileName == fileName);
        }

        private void btnLoadTagsToFiles_Click(object sender, EventArgs e)
        {
            foreach (var record in _records)
            {
                SaveRecordInFile(record.Item1);
            }
        }

        private void btnLoadTagsFromFiles_Click(object sender, EventArgs e)
        {
            PlayerForm_Shown(sender, e);
        }

        private void clearFilterNameBtn_Click(object sender, EventArgs e)
        {
            filterTitleTagList1.SelectedText = null;
            Filter();
        }

        private void aboutProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void playedListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_blockEvents)
                return;

            var selectedListName = playedListComboBox.SelectedValue + "";


            LoadSelectedList();

            if (selectedListName == _options.CurrentListName)
                return;
            _options.CurrentListName = selectedListName;

            OptionsMngr.Save(_aimpPlayer, _options);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var optionsForm = new OptionsForm();
            optionsForm.Options = _options;

            if (optionsForm.ShowDialog() == DialogResult.OK)
            {
                this._options = optionsForm.Options;

                if (string.IsNullOrEmpty(this._options.CurrentListName))
                {
                    _options.CurrentListName = playedListComboBox.SelectedValue + "";
                }

                OptionsMngr.Save(_aimpPlayer, _options);
            }
        }

        private void duplicateBtn_Click(object sender, EventArgs e)
        {
            _editMultiTagList.AddTag("дубликат");
            editSaveBtn_Click(editSaveBtn, EventArgs.Empty);
        }

        private void playTrackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            }
        }

        private void запуститьВебсерверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_webServer != null)
            {
                _webServer.Close();
            }

            _webServer = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //  startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C python -m http.server";
            startInfo.WorkingDirectory = Options.WorkingDirectory;

            _webServer.StartInfo = startInfo;

            _webServer.Start();

            try
            {
                var ip = GetLocalIPAddress();
                webServerLinkLabel1.Text = "http://" + ip + ":8000";
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void webServerLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(webServerLinkLabel1.Text);
        }

        private void рашаритьЧерезВебсерверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rows = this.SelectedRows();

            var sb = new StringBuilder();

            sb.Append("<html><head><meta charset=\"utf-8\">\n<h1>Записи</h1>\n<body>\n<ol>\n");

            var replaceDict = new Dictionary<string, string>()
            {
                {"!", "%21"},
                {"\"", "%22"},
                {"#", "%23"},
                {"$", "%24"},
                //{"%", "%25"},
                {"&", "%26"},
                {"'", "%27"},
                {"(", "%28"},
                {")", "%29"},
                {"*", "%2A"},
                {"+", "%20"},
                {",", "%2C"},
                {"-", "%2D"},
                {".", "%2E"},
                {"/", "%2F"}
            };

            foreach (var row in rows)
            {
                var ulr = webServerLinkLabel1.Text;

                var fileName = (row["FileName"] + "").Substring(Options.WorkingDirectory.Length + 1);

                var folders = fileName.Split('\\');

                var resultFolders = folders
                    .Select(el =>
                    {
                        var r = HttpUtility.UrlEncode(el);
                        foreach (var replace in replaceDict)
                        {
                            r = r.Replace(replace.Key, replace.Value);
                        }

                        return r;
                    });

                var url = String.Join("/", resultFolders);
                sb.AppendLine($"<li><a href=\"{url}\">{row["Title"]}</a>\n</li>");
                sb.AppendLine($"<div>{row["Tags"]}</div>");
            }

            sb.Append("\n</ol>\n\n</body></html>");

            using (var sw = File.Open(Path.Combine(Options.WorkingDirectory, "index.html"), FileMode.Create))
            {
                using (var w = new StreamWriter(sw))
                {
                    w.Write(sb.ToString());
                }
            }
        }
    }
}