using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIMP.Smartoteka
{
    public partial class TagList : UserControl
    {
        public bool AllowCreateTags { get; set; }

        public event EventHandler<string> CreateTag;
        public event EventHandler<string> SelectedTag;

        private bool _canUpdate = true;

        private bool _needUpdate = false;

        public string[] Data { get; set; }
        public string SelectedText
        {
            get => tagComboBox1.SelectedValue == null ? tagComboBox1.SelectedText : tagComboBox1.SelectedValue + "";
            set
            {
                
                if (string.IsNullOrEmpty(value))
                {
                    tagComboBox1.SelectedIndex = -1;
                }
                else
                {
                    tagComboBox1.SelectedText = value;
                }
            }
        }

        public TagList()
        {
            InitializeComponent();

            tagComboBox1.DataSource = Array.Empty<string>();
            tagComboBox1.SelectedIndex = -1;
        }

        public void Init()
        {
            tagComboBox1.DataSource = Data;
            tagComboBox1.SelectedIndex = -1;
        }

        private void tagComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _needUpdate = false;
        }

        private void tagComboBox1_TextUpdate(object sender, EventArgs e)
        {
            _needUpdate = true;
        }

        private void tagComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (AllowCreateTags && tagComboBox1.SelectedValue == null)
            {
                var newTag = tagComboBox1.SelectedText;
                if (!string.IsNullOrEmpty(newTag))
                {
                    SelectedTag?.Invoke(this, newTag);

                    CreateTag?.Invoke(this, newTag);
                }
            }
            else
            {
                SelectedTag?.Invoke(this, tagComboBox1.SelectedValue + "");
            }
        }

        private void tagComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (_needUpdate)
            {
                if (_canUpdate)
                {
                    _canUpdate = false;
                    UpdateData();
                }
                else
                {
                    RestartTimer();
                }
            }
        }

        private void tagComboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(tagComboBox1.SelectedValue + "")
                && !tagComboBox1.DroppedDown)
            {
                tagComboBox1.DroppedDown = true;
            }
        }


        private void UpdateData()
        {
            var findText = tagComboBox1.Text;
            if (findText.Length > 1)
            {
                List<string> searchData =
                    Data.Select(el => new
                            {str = el, lcs = LongestCommonSubsequence(el.ToLower(), findText.ToLower())})
                        .Where(el => el.lcs > 2)
                        .OrderByDescending(el => el.lcs)
                        .Take(10)
                        .Select(el => el.str)
                        .ToList();

                var indexOf = searchData.IndexOf(findText);
                if (indexOf >= 0)
                {
                    searchData.RemoveAt(indexOf);
                }

                searchData.Insert(0, findText);

                HandleTextChanged(searchData);
            }
        }

        private void HandleTextChanged(List<string> dataSource)
        {
            var text = tagComboBox1.Text;
            if (dataSource.Count > 0)
            {
                tagComboBox1.DataSource = dataSource;
                tagComboBox1.SelectionStart = text.Length;
                //var sText = tagComboBox1.Items[0].ToString();
                //tagComboBox1.SelectionStart = text.Length;
                //tagComboBox1.SelectionLength = sText.Length - text.Length;
                tagComboBox1.DroppedDown = true;


                return;
            }
            else
            {
                tagComboBox1.DroppedDown = false;
                //tagComboBox1.SelectionStart = text.Length;
            }
        }

        private static int MAX(int a, int b)
        {
            return a > b ? a : b;
        }

        public static int LongestCommonSubsequence(string s1, string s2)
        {
            int i, j, k, t;
            int s1Len = s1.Length;
            int s2Len = s2.Length;
            int[] z = new int[(s1Len + 1) * (s2Len + 1)];

            int[,] c = new int[(s1Len + 1), (s2Len + 1)];
            for (i = 0; i <= s1Len; ++i)
                c[i, 0] = z[i * (s2Len + 1)];
            for (i = 1; i <= s1Len; ++i)
            {
                for (j = 1; j <= s2Len; ++j)
                {
                    if (s1[i - 1] == s2[j - 1])
                        c[i, j] = c[i - 1, j - 1] + 1;
                    else
                        c[i, j] = MAX(c[i - 1, j], c[i, j - 1]);
                }
            }

            t = c[s1Len, s2Len];
            return t;
        }

        private void RestartTimer()
        {
            timer1.Stop();
            _canUpdate = false;
            timer1.Start();
        }

        //Update data when timer stops
        private void timer1_Tick(object sender, EventArgs e)
        {
            _canUpdate = true;
            timer1.Stop();
            UpdateData();
        }
    }
}