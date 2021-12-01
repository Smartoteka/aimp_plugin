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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            textBox1.Text =
                "Проект для быстрого поиска музыки по тэгам для себя и проведения тренинга \r\n'Пробуждение личной силы' GRC.\r\n"
                + "\r\nСделано в рамках проекта smartoteka.com\r\n"
                + "\r\nРешение opensource. Ссылка ниже.\r\n"
                + "\r\nПользуйтесь на здоровье!";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/Smartoteka/aimp_plugin");
        }
    }
}
