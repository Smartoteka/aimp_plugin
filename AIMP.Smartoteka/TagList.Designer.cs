
namespace AIMP.Smartoteka
{
    partial class TagList
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tagComboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tagComboBox1
            // 
            this.tagComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagComboBox1.FormattingEnabled = true;
            this.tagComboBox1.Location = new System.Drawing.Point(0, 0);
            this.tagComboBox1.Name = "tagComboBox1";
            this.tagComboBox1.Size = new System.Drawing.Size(191, 21);
            this.tagComboBox1.TabIndex = 5;
            this.tagComboBox1.SelectedIndexChanged += new System.EventHandler(this.tagComboBox1_SelectedIndexChanged);
            this.tagComboBox1.TextUpdate += new System.EventHandler(this.tagComboBox1_TextUpdate);
            this.tagComboBox1.DropDownClosed += new System.EventHandler(this.tagComboBox1_DropDownClosed);
            this.tagComboBox1.TextChanged += new System.EventHandler(this.tagComboBox1_TextChanged);
            this.tagComboBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tagComboBox1_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TagList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tagComboBox1);
            this.Name = "TagList";
            this.Size = new System.Drawing.Size(191, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox tagComboBox1;
        private System.Windows.Forms.Timer timer1;
    }
}
