namespace AIMP.Smartoteka
{
    partial class SmartotekaForm
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
            this.components = new System.ComponentModel.Container();
            this.playBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.playTrackBar1 = new System.Windows.Forms.TrackBar();
            this.soundTrackBar = new System.Windows.Forms.TrackBar();
            this.muteBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durationLabel1 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.editTitleLabel = new System.Windows.Forms.Label();
            this.editSaveBtn = new System.Windows.Forms.Button();
            this.editGroupBox1 = new System.Windows.Forms.GroupBox();
            this._editMultiTagList = new AIMP.Smartoteka.MultiTagList();
            this.duplicateBtn = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.popularGroupBox1 = new System.Windows.Forms.GroupBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadTagsFromFiles = new System.Windows.Forms.Button();
            this.btnLoadTagsToFiles = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.clearFilterNameBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.filterTitleTagList1 = new AIMP.Smartoteka.TagList();
            this._filterMultiTagList = new AIMP.Smartoteka.MultiTagList();
            this.playedListComboBox = new System.Windows.Forms.ComboBox();
            this.playingRecordContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.найтиВТаблицеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.рашаритьЧерезВебсерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьВебсерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webServerLinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.playTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundTrackBar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.editGroupBox1.SuspendLayout();
            this.popularGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.playingRecordContextMenuStrip1.SuspendLayout();
            this.gridContextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(22, 119);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(40, 23);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(62, 119);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(40, 23);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(102, 119);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(48, 23);
            this.pauseBtn.TabIndex = 2;
            this.pauseBtn.Text = "Pause";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // playTrackBar1
            // 
            this.playTrackBar1.Location = new System.Drawing.Point(12, 71);
            this.playTrackBar1.Maximum = 100;
            this.playTrackBar1.Name = "playTrackBar1";
            this.playTrackBar1.Size = new System.Drawing.Size(264, 45);
            this.playTrackBar1.TabIndex = 3;
            this.playTrackBar1.Scroll += new System.EventHandler(this.positionTrackBar1_Scroll);
            this.playTrackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playTrackBar1_MouseUp);
            // 
            // soundTrackBar
            // 
            this.soundTrackBar.Location = new System.Drawing.Point(12, 157);
            this.soundTrackBar.Name = "soundTrackBar";
            this.soundTrackBar.Size = new System.Drawing.Size(150, 45);
            this.soundTrackBar.TabIndex = 4;
            this.soundTrackBar.Scroll += new System.EventHandler(this.volumeTrackBar2_Scroll);
            // 
            // muteBtn
            // 
            this.muteBtn.Location = new System.Drawing.Point(168, 157);
            this.muteBtn.Name = "muteBtn";
            this.muteBtn.Size = new System.Drawing.Size(43, 23);
            this.muteBtn.TabIndex = 5;
            this.muteBtn.Text = "Mute";
            this.muteBtn.UseVisualStyleBackColor = true;
            this.muteBtn.Click += new System.EventHandler(this.muteBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1324, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel1.Text = "State";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1324, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.optionsToolStripMenuItem.Text = "Настройки";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProjectToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.helpToolStripMenuItem.Text = "О проекте";
            // 
            // aboutProjectToolStripMenuItem
            // 
            this.aboutProjectToolStripMenuItem.Name = "aboutProjectToolStripMenuItem";
            this.aboutProjectToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.aboutProjectToolStripMenuItem.Text = "О проекте";
            this.aboutProjectToolStripMenuItem.Click += new System.EventHandler(this.aboutProjectToolStripMenuItem_Click);
            // 
            // durationLabel1
            // 
            this.durationLabel1.AutoSize = true;
            this.durationLabel1.Location = new System.Drawing.Point(247, 48);
            this.durationLabel1.Name = "durationLabel1";
            this.durationLabel1.Size = new System.Drawing.Size(47, 13);
            this.durationLabel1.TabIndex = 0;
            this.durationLabel1.Text = "Duration";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button8.Location = new System.Drawing.Point(6, 247);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(98, 23);
            this.button8.TabIndex = 0;
            this.button8.Text = "танцы";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 218);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(98, 23);
            this.button7.TabIndex = 0;
            this.button7.Text = "сыну";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(7, 192);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "дочке";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 163);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "отцу";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(128, 247);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(94, 23);
            this.button13.TabIndex = 0;
            this.button13.Text = "клубная";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(128, 218);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(94, 23);
            this.button12.TabIndex = 0;
            this.button12.Text = "плавная";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(128, 163);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(94, 23);
            this.button14.TabIndex = 0;
            this.button14.Text = "романтика";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(128, 189);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(94, 23);
            this.button11.TabIndex = 0;
            this.button11.Text = "активная";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // editTitleLabel
            // 
            this.editTitleLabel.AutoSize = true;
            this.editTitleLabel.Location = new System.Drawing.Point(31, 16);
            this.editTitleLabel.Name = "editTitleLabel";
            this.editTitleLabel.Size = new System.Drawing.Size(27, 13);
            this.editTitleLabel.TabIndex = 0;
            this.editTitleLabel.Text = "Title";
            // 
            // editSaveBtn
            // 
            this.editSaveBtn.Location = new System.Drawing.Point(247, 181);
            this.editSaveBtn.Name = "editSaveBtn";
            this.editSaveBtn.Size = new System.Drawing.Size(94, 23);
            this.editSaveBtn.TabIndex = 0;
            this.editSaveBtn.Text = "Сохранить";
            this.editSaveBtn.UseVisualStyleBackColor = true;
            this.editSaveBtn.Click += new System.EventHandler(this.editSaveBtn_Click);
            // 
            // editGroupBox1
            // 
            this.editGroupBox1.Controls.Add(this._editMultiTagList);
            this.editGroupBox1.Controls.Add(this.durationLabel1);
            this.editGroupBox1.Controls.Add(this.editTitleLabel);
            this.editGroupBox1.Controls.Add(this.duplicateBtn);
            this.editGroupBox1.Controls.Add(this.editSaveBtn);
            this.editGroupBox1.Location = new System.Drawing.Point(283, 411);
            this.editGroupBox1.Name = "editGroupBox1";
            this.editGroupBox1.Size = new System.Drawing.Size(613, 220);
            this.editGroupBox1.TabIndex = 18;
            this.editGroupBox1.TabStop = false;
            this.editGroupBox1.Text = "Выбрано";
            // 
            // _editMultiTagList
            // 
            this._editMultiTagList.AllowCreateTags = false;
            this._editMultiTagList.Data = null;
            this._editMultiTagList.Location = new System.Drawing.Point(23, 40);
            this._editMultiTagList.Name = "_editMultiTagList";
            this._editMultiTagList.Size = new System.Drawing.Size(218, 174);
            this._editMultiTagList.TabIndex = 1;
            // 
            // duplicateBtn
            // 
            this.duplicateBtn.Location = new System.Drawing.Point(249, 114);
            this.duplicateBtn.Name = "duplicateBtn";
            this.duplicateBtn.Size = new System.Drawing.Size(94, 23);
            this.duplicateBtn.TabIndex = 0;
            this.duplicateBtn.Text = "дубликат";
            this.duplicateBtn.UseVisualStyleBackColor = true;
            this.duplicateBtn.Click += new System.EventHandler(this.duplicateBtn_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(128, 76);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(94, 23);
            this.button10.TabIndex = 0;
            this.button10.Text = "грусть";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 134);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "маме";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(7, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "злы";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Yellow;
            this.button9.Location = new System.Drawing.Point(128, 46);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(94, 23);
            this.button9.TabIndex = 0;
            this.button9.Text = "радостная";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Plum;
            this.button1.Location = new System.Drawing.Point(7, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "любовь";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // popularGroupBox1
            // 
            this.popularGroupBox1.Controls.Add(this.button8);
            this.popularGroupBox1.Controls.Add(this.button7);
            this.popularGroupBox1.Controls.Add(this.button6);
            this.popularGroupBox1.Controls.Add(this.button5);
            this.popularGroupBox1.Controls.Add(this.button15);
            this.popularGroupBox1.Controls.Add(this.button13);
            this.popularGroupBox1.Controls.Add(this.button12);
            this.popularGroupBox1.Controls.Add(this.button14);
            this.popularGroupBox1.Controls.Add(this.button11);
            this.popularGroupBox1.Controls.Add(this.button10);
            this.popularGroupBox1.Controls.Add(this.button4);
            this.popularGroupBox1.Controls.Add(this.button3);
            this.popularGroupBox1.Controls.Add(this.button2);
            this.popularGroupBox1.Controls.Add(this.button9);
            this.popularGroupBox1.Controls.Add(this.button16);
            this.popularGroupBox1.Controls.Add(this.button1);
            this.popularGroupBox1.Location = new System.Drawing.Point(19, 373);
            this.popularGroupBox1.Name = "popularGroupBox1";
            this.popularGroupBox1.Size = new System.Drawing.Size(249, 280);
            this.popularGroupBox1.TabIndex = 17;
            this.popularGroupBox1.TabStop = false;
            this.popularGroupBox1.Text = "Популярные";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(128, 134);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(94, 23);
            this.button15.TabIndex = 0;
            this.button15.Text = "поздравлялка";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(7, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "sex";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Plum;
            this.button16.Location = new System.Drawing.Point(6, 19);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(98, 23);
            this.button16.TabIndex = 0;
            this.button16.Text = "которые любят";
            this.button16.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(282, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1030, 322);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnLoadTagsFromFiles
            // 
            this.btnLoadTagsFromFiles.Location = new System.Drawing.Point(6, 26);
            this.btnLoadTagsFromFiles.Name = "btnLoadTagsFromFiles";
            this.btnLoadTagsFromFiles.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTagsFromFiles.TabIndex = 20;
            this.btnLoadTagsFromFiles.Text = "Из файлов mp3";
            this.btnLoadTagsFromFiles.UseVisualStyleBackColor = true;
            this.btnLoadTagsFromFiles.Click += new System.EventHandler(this.btnLoadTagsFromFiles_Click);
            // 
            // btnLoadTagsToFiles
            // 
            this.btnLoadTagsToFiles.Location = new System.Drawing.Point(6, 64);
            this.btnLoadTagsToFiles.Name = "btnLoadTagsToFiles";
            this.btnLoadTagsToFiles.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTagsToFiles.TabIndex = 21;
            this.btnLoadTagsToFiles.Text = "В файлы";
            this.btnLoadTagsToFiles.UseVisualStyleBackColor = true;
            this.btnLoadTagsToFiles.Click += new System.EventHandler(this.btnLoadTagsToFiles_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(6, 106);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 21;
            this.btnExport.Text = "Экспорт";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // clearFilterNameBtn
            // 
            this.clearFilterNameBtn.Location = new System.Drawing.Point(993, 27);
            this.clearFilterNameBtn.Name = "clearFilterNameBtn";
            this.clearFilterNameBtn.Size = new System.Drawing.Size(75, 23);
            this.clearFilterNameBtn.TabIndex = 23;
            this.clearFilterNameBtn.Text = "Очистить";
            this.clearFilterNameBtn.UseVisualStyleBackColor = true;
            this.clearFilterNameBtn.Click += new System.EventHandler(this.clearFilterNameBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Фильтр по имени";
            // 
            // filterTitleTagList1
            // 
            this.filterTitleTagList1.AllowCreateTags = false;
            this.filterTitleTagList1.Data = null;
            this.filterTitleTagList1.Location = new System.Drawing.Point(398, 28);
            this.filterTitleTagList1.Name = "filterTitleTagList1";
            this.filterTitleTagList1.SelectedText = "";
            this.filterTitleTagList1.Size = new System.Drawing.Size(589, 28);
            this.filterTitleTagList1.TabIndex = 22;
            // 
            // _filterMultiTagList
            // 
            this._filterMultiTagList.AllowCreateTags = false;
            this._filterMultiTagList.Data = null;
            this._filterMultiTagList.Location = new System.Drawing.Point(12, 199);
            this._filterMultiTagList.Name = "_filterMultiTagList";
            this._filterMultiTagList.Size = new System.Drawing.Size(218, 168);
            this._filterMultiTagList.TabIndex = 19;
            // 
            // playedListComboBox
            // 
            this.playedListComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.playedListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playedListComboBox.FormattingEnabled = true;
            this.playedListComboBox.Location = new System.Drawing.Point(19, 35);
            this.playedListComboBox.Name = "playedListComboBox";
            this.playedListComboBox.Size = new System.Drawing.Size(231, 21);
            this.playedListComboBox.TabIndex = 25;
            this.playedListComboBox.SelectedIndexChanged += new System.EventHandler(this.playedListComboBox_SelectedIndexChanged);
            // 
            // playingRecordContextMenuStrip1
            // 
            this.playingRecordContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.найтиВТаблицеToolStripMenuItem});
            this.playingRecordContextMenuStrip1.Name = "playingRecordContextMenuStrip1";
            this.playingRecordContextMenuStrip1.Size = new System.Drawing.Size(166, 26);
            // 
            // найтиВТаблицеToolStripMenuItem
            // 
            this.найтиВТаблицеToolStripMenuItem.Name = "найтиВТаблицеToolStripMenuItem";
            this.найтиВТаблицеToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.найтиВТаблицеToolStripMenuItem.Text = "Найти в таблице";
            // 
            // gridContextMenuStrip1
            // 
            this.gridContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рашаритьЧерезВебсерверToolStripMenuItem,
            this.запуститьВебсерверToolStripMenuItem});
            this.gridContextMenuStrip1.Name = "gridContextMenuStrip1";
            this.gridContextMenuStrip1.Size = new System.Drawing.Size(235, 48);
            // 
            // рашаритьЧерезВебсерверToolStripMenuItem
            // 
            this.рашаритьЧерезВебсерверToolStripMenuItem.Name = "рашаритьЧерезВебсерверToolStripMenuItem";
            this.рашаритьЧерезВебсерверToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.рашаритьЧерезВебсерверToolStripMenuItem.Text = "Расшарить через веб-сервер";
            this.рашаритьЧерезВебсерверToolStripMenuItem.Click += new System.EventHandler(this.рашаритьЧерезВебсерверToolStripMenuItem_Click);
            // 
            // запуститьВебсерверToolStripMenuItem
            // 
            this.запуститьВебсерверToolStripMenuItem.Name = "запуститьВебсерверToolStripMenuItem";
            this.запуститьВебсерверToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.запуститьВебсерверToolStripMenuItem.Text = "Запустить веб-сервер";
            this.запуститьВебсерверToolStripMenuItem.Click += new System.EventHandler(this.запуститьВебсерверToolStripMenuItem_Click);
            // 
            // webServerLinkLabel1
            // 
            this.webServerLinkLabel1.AutoSize = true;
            this.webServerLinkLabel1.Location = new System.Drawing.Point(993, 612);
            this.webServerLinkLabel1.Name = "webServerLinkLabel1";
            this.webServerLinkLabel1.Size = new System.Drawing.Size(0, 13);
            this.webServerLinkLabel1.TabIndex = 28;
            this.webServerLinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.webServerLinkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(922, 612);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Веб-сервер";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnLoadTagsFromFiles);
            this.groupBox1.Controls.Add(this.btnLoadTagsToFiles);
            this.groupBox1.Location = new System.Drawing.Point(925, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 166);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Синхронизация и резервное копирование";
            // 
            // SmartotekaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 685);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.webServerLinkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.playedListComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearFilterNameBtn);
            this.Controls.Add(this.filterTitleTagList1);
            this.Controls.Add(this._filterMultiTagList);
            this.Controls.Add(this.editGroupBox1);
            this.Controls.Add(this.popularGroupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.muteBtn);
            this.Controls.Add(this.soundTrackBar);
            this.Controls.Add(this.playTrackBar1);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.playBtn);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SmartotekaForm";
            this.Text = "Smartoteka";
            this.Shown += new System.EventHandler(this.PlayerForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.playTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soundTrackBar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.editGroupBox1.ResumeLayout(false);
            this.editGroupBox1.PerformLayout();
            this.popularGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.playingRecordContextMenuStrip1.ResumeLayout(false);
            this.gridContextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.TrackBar playTrackBar1;
        private System.Windows.Forms.TrackBar soundTrackBar;
        private System.Windows.Forms.Button muteBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProjectToolStripMenuItem;
        private System.Windows.Forms.Label durationLabel1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label editTitleLabel;
        private System.Windows.Forms.Button editSaveBtn;
        private System.Windows.Forms.GroupBox editGroupBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox popularGroupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MultiTagList _editMultiTagList;
        private MultiTagList _filterMultiTagList;
        private System.Windows.Forms.Button btnLoadTagsFromFiles;
        private System.Windows.Forms.Button btnLoadTagsToFiles;
        private System.Windows.Forms.Button btnExport;
        private TagList filterTitleTagList1;
        private System.Windows.Forms.Button clearFilterNameBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.ComboBox playedListComboBox;
        private System.Windows.Forms.Button duplicateBtn;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.ContextMenuStrip playingRecordContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem найтиВТаблицеToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip gridContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem рашаритьЧерезВебсерверToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запуститьВебсерверToolStripMenuItem;
        private System.Windows.Forms.LinkLabel webServerLinkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

