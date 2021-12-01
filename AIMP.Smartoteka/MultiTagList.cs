using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AIMP.Smartoteka
{
    public partial class MultiTagList : UserControl
    {
        public bool AllowCreateTags { get; set; }

        public event EventHandler UpdateTags;
        public event EventHandler<string> CreateTag;

        public string[] Data
        {
            get => tagList1.Data;
            set => tagList1.Data = value;
        }

        public IEnumerable<string> Selected
        {
            get
            {
                foreach (string item in tagsListBox1.Items)
                {
                    yield return item;
                }
            }
            set
            {
                tagsListBox1.Items.Clear();

                if (value == null || !value.Any())
                    return;

                var items = Data.Where(value.Contains).Cast<object>().ToArray();

                tagsListBox1.Items.AddRange(items);
            }
        }

        public MultiTagList()
        {
            InitializeComponent();

            tagList1.SelectedTag += (s, tag) => AddTag(tag);
        }

        public void Init()
        {
            tagList1.Init();
        }

        private void tagsListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tagsListBox1.SelectedIndex >= 0)
            {
                tagsListBox1.Items.RemoveAt(tagsListBox1.SelectedIndex);

                UpdateTags?.Invoke(this, EventArgs.Empty);
            }
        }


        private void clearBtn_Click(object sender, EventArgs e)
        {
            tagsListBox1.Items.Clear();
            UpdateTags?.Invoke(this, EventArgs.Empty);
        }

        public void AddTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                return;
            if (tagsListBox1.Items.Cast<string>().Contains(tag))
                return;

            tagsListBox1.Items.Add(tag);
            Data = Data.Where(el => !tagsListBox1.Items.Contains(el)).ToArray();
            tagList1.Init();

            UpdateTags?.Invoke(this, EventArgs.Empty);
        }

        public void RemoveTag(string tag)
        {
            tagsListBox1.Items.Remove(tag);
            UpdateTags?.Invoke(this, EventArgs.Empty);
        }

        private void tagsListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                copyMenyStrip.Show(tagList1, e.X, e.Y);
            }
        }

        private void copytoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(JoinSelected);
        }

        public string JoinSelected => ";" + string.Join(";", Selected) + ";";

        private void pastetoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var text = Clipboard.GetText(TextDataFormat.UnicodeText);

            if (!string.IsNullOrEmpty(text))
            {
                Selected = Selected
                    .Union(text.Split(';').Where(el => !string.IsNullOrEmpty(el)));

                UpdateTags?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}