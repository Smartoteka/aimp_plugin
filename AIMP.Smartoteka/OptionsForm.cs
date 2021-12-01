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
    public partial class OptionsForm : Form
    {

        public Options Options
        {
            get =>
                new Options()
                {
                    CacheTagsPath = pathCacheTagsTextBox.Text,
                    ExportPath = pathToExportFolderTextBox.Text,
                    WorkingDirectory = workDirectoryTextBox.Text
                };
            set
            {
                if (value == null)
                    return;

                pathCacheTagsTextBox.Text = value.CacheTagsPath;
                pathToExportFolderTextBox.Text = value.ExportPath;
                workDirectoryTextBox.Text = value.WorkingDirectory;
            }
        }

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void pathCacheTagsBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = pathCacheTagsTextBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pathCacheTagsTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void pathToExportFolderBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = pathToExportFolderTextBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                pathToExportFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void workDirectoryBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = workDirectoryTextBox.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                workDirectoryTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}