
namespace AIMP.Smartoteka
{
    partial class MultiTagList
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
            this.tagsListBox1 = new System.Windows.Forms.ListBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.copyMenyStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copytoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pastetoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tagList1 = new AIMP.Smartoteka.TagList();
            this.copyMenyStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tagsListBox1
            // 
            this.tagsListBox1.FormattingEnabled = true;
            this.tagsListBox1.Location = new System.Drawing.Point(16, 40);
            this.tagsListBox1.Name = "tagsListBox1";
            this.tagsListBox1.Size = new System.Drawing.Size(185, 95);
            this.tagsListBox1.TabIndex = 4;
            this.tagsListBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tagsListBox1_MouseDoubleClick);
            this.tagsListBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tagsListBox1_MouseUp);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(16, 141);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 6;
            this.clearBtn.Text = "Очистить";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // copyMenyStrip
            // 
            this.copyMenyStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copytoolStripMenuItem1,
            this.pastetoolStripMenuItem1});
            this.copyMenyStrip.Name = "copyMenyStrip";
            this.copyMenyStrip.Size = new System.Drawing.Size(103, 48);
            this.copyMenyStrip.Text = "Copy";
            // 
            // copytoolStripMenuItem1
            // 
            this.copytoolStripMenuItem1.Name = "copytoolStripMenuItem1";
            this.copytoolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.copytoolStripMenuItem1.Text = "Copy";
            this.copytoolStripMenuItem1.Click += new System.EventHandler(this.copytoolStripMenuItem1_Click);
            // 
            // pastetoolStripMenuItem1
            // 
            this.pastetoolStripMenuItem1.Name = "pastetoolStripMenuItem1";
            this.pastetoolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.pastetoolStripMenuItem1.Text = "Paste";
            this.pastetoolStripMenuItem1.Click += new System.EventHandler(this.pastetoolStripMenuItem1_Click);
            // 
            // tagList1
            // 
            this.tagList1.AllowCreateTags = false;
            this.tagList1.Data = null;
            this.tagList1.Location = new System.Drawing.Point(15, 6);
            this.tagList1.Name = "tagList1";
            this.tagList1.SelectedText = "";
            this.tagList1.Size = new System.Drawing.Size(191, 28);
            this.tagList1.TabIndex = 7;
            // 
            // MultiTagList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tagList1);
            this.Controls.Add(this.tagsListBox1);
            this.Controls.Add(this.clearBtn);
            this.Name = "MultiTagList";
            this.Size = new System.Drawing.Size(218, 167);
            this.copyMenyStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox tagsListBox1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.ContextMenuStrip copyMenyStrip;
        private System.Windows.Forms.ToolStripMenuItem copytoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pastetoolStripMenuItem1;
        private TagList tagList1;
    }
}
