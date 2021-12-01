
namespace AIMP.Smartoteka
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.pathCacheTagsTextBox = new System.Windows.Forms.TextBox();
            this.pathCacheTagsBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pathToExportFolderTextBox = new System.Windows.Forms.TextBox();
            this.pathToExportFolderBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.workDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.workDirectoryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к папке с кэшем тэгов";
            // 
            // pathCacheTagsTextBox
            // 
            this.pathCacheTagsTextBox.Location = new System.Drawing.Point(195, 29);
            this.pathCacheTagsTextBox.Name = "pathCacheTagsTextBox";
            this.pathCacheTagsTextBox.Size = new System.Drawing.Size(420, 20);
            this.pathCacheTagsTextBox.TabIndex = 1;
            // 
            // pathCacheTagsBtn
            // 
            this.pathCacheTagsBtn.Location = new System.Drawing.Point(639, 27);
            this.pathCacheTagsBtn.Name = "pathCacheTagsBtn";
            this.pathCacheTagsBtn.Size = new System.Drawing.Size(75, 23);
            this.pathCacheTagsBtn.TabIndex = 2;
            this.pathCacheTagsBtn.Text = "Выбрать";
            this.pathCacheTagsBtn.UseVisualStyleBackColor = true;
            this.pathCacheTagsBtn.Click += new System.EventHandler(this.pathCacheTagsBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Папка для экспорта";
            // 
            // pathToExportFolderTextBox
            // 
            this.pathToExportFolderTextBox.Location = new System.Drawing.Point(195, 71);
            this.pathToExportFolderTextBox.Name = "pathToExportFolderTextBox";
            this.pathToExportFolderTextBox.Size = new System.Drawing.Size(420, 20);
            this.pathToExportFolderTextBox.TabIndex = 2;
            // 
            // pathToExportFolderBtn
            // 
            this.pathToExportFolderBtn.Location = new System.Drawing.Point(639, 69);
            this.pathToExportFolderBtn.Name = "pathToExportFolderBtn";
            this.pathToExportFolderBtn.Size = new System.Drawing.Size(75, 23);
            this.pathToExportFolderBtn.TabIndex = 2;
            this.pathToExportFolderBtn.Text = "Выбрать";
            this.pathToExportFolderBtn.UseVisualStyleBackColor = true;
            this.pathToExportFolderBtn.Click += new System.EventHandler(this.pathToExportFolderBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(83, 180);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(195, 180);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Рабочая папка песен";
            // 
            // workDirectoryTextBox
            // 
            this.workDirectoryTextBox.Location = new System.Drawing.Point(195, 112);
            this.workDirectoryTextBox.Name = "workDirectoryTextBox";
            this.workDirectoryTextBox.Size = new System.Drawing.Size(420, 20);
            this.workDirectoryTextBox.TabIndex = 2;
            // 
            // workDirectoryBtn
            // 
            this.workDirectoryBtn.Location = new System.Drawing.Point(639, 110);
            this.workDirectoryBtn.Name = "workDirectoryBtn";
            this.workDirectoryBtn.Size = new System.Drawing.Size(75, 23);
            this.workDirectoryBtn.TabIndex = 2;
            this.workDirectoryBtn.Text = "Выбрать";
            this.workDirectoryBtn.UseVisualStyleBackColor = true;
            this.workDirectoryBtn.Click += new System.EventHandler(this.workDirectoryBtn_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 223);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.workDirectoryBtn);
            this.Controls.Add(this.workDirectoryTextBox);
            this.Controls.Add(this.pathToExportFolderBtn);
            this.Controls.Add(this.pathToExportFolderTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pathCacheTagsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathCacheTagsTextBox);
            this.Controls.Add(this.label1);
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathCacheTagsTextBox;
        private System.Windows.Forms.Button pathCacheTagsBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pathToExportFolderTextBox;
        private System.Windows.Forms.Button pathToExportFolderBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox workDirectoryTextBox;
        private System.Windows.Forms.Button workDirectoryBtn;
    }
}