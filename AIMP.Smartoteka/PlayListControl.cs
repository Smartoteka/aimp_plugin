namespace AIMP.Smartoteka
{
    using System;
    using System.Data;
    using System.Windows.Forms;
    using SDK;
    using SDK.Player;
    using SDK.Playlist;

    public partial class PlayListControl : UserControl
    {
        private readonly IAimpPlayer _player;
        private readonly IAimpPlaylist _playList;

        public event EventHandler DoubleClick
        {
            add => dataGridView1.DoubleClick += value;
            remove => dataGridView1.DoubleClick -= value;
        }

        public PlayListControl(IAimpPlaylist playList, IAimpPlayer player)
        {
            InitializeComponent();

            dataGridView1.MultiSelect = false;
            //listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            //listView1.View = View.Details;

            // dataGridView1.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


            _playList = playList;
            _player = player;

            LoadTracks();

            playList.Changed += (sender, type) =>
            {
                if (type.HasFlag(PlaylistNotifyType.AIMP_PLAYLIST_NOTIFY_STATISTICS))
                {
                    RefreshTracks();
                }
            };
        }

        public void RefreshTracks()
        {
            //dataGridView1.Rows.Clear();
            //int count = _playList.GetItemCount();
            //for (var i = 0; i < count; i++)
            //{
            //    var item = _playList.GetItem(i);
            //    if (item.ResultType != ActionResultType.OK)
            //    {
            //        continue;
            //    }

            //    //listView1.Items.Add(GetTrack(item.Result));
            //}
        }

        public void Filter(string[] tags)
        {
            var view = Table.DefaultView;

            view.RowFilter = String.Format("Tags like '{0}%'", tags[0]);

            dataGridView1.Update();
        }

        private DataTable Table => dataGridView1.DataSource as DataTable;

        public void LoadTracks()
        {
            var result = _playList.GetFiles(PlaylistGetFilesFlag.All);
            if (result.ResultType != ActionResultType.OK)
                return;

            var table = DataTable();

            int count = _playList.GetItemCount();
            for (var i = 0; i < Math.Min(10, count); i++)
            {
                var item = _playList.GetItem(i);
                if (item.ResultType != ActionResultType.OK)
                {
                    continue;
                }

                AddNewRow(table, item);
            }

            dataGridView1.DataSource = table;
            dataGridView1.Update();

            dataGridView1.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
        }

        private void AddNewRow(DataTable table, AimpActionResult<IAimpPlaylistItem> item)
        {
            var row = table.NewRow();

            SetTrack(_player, row, item.Result);

            table.Rows.Add(row);
        }

        private static DataTable DataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Title");
            table.Columns.Add("Duration");
            table.Columns.Add("Tags");
            return table;
        }

        private static void SetTrack(IAimpPlayer aimpPlayer, DataRow dr, IAimpPlaylistItem item)
        {
            dr["Title"] = item.DisplayText;
            dr["Duration"] = TimeSpan.FromSeconds(item.FileInfo.Duration).ToString();

            //TODO: add cache! 
            var result = aimpPlayer.ServiceFileTagEditor.EditFile(item.FileName);
            if (result.ResultType == ActionResultType.OK)
            {
                var editor = result.Result;
                var tag = editor.GetTag(0);
                if (tag.ResultType == ActionResultType.OK)
                {
                    dr["Tags"] = tag.Result.Comment;

                    if (string.IsNullOrEmpty(tag.Result.Comment))
                    {
                        tag.Result.Comment = "1";
                        editor.Save();
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            _playList.Delete(PlaylistDeleteFlags.Physically, "test", FilterFunc);
        }

        private bool FilterFunc(IAimpPlaylistItem aimpPlaylistItem, object o)
        {
            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}