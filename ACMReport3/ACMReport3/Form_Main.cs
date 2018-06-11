using System;
using System.Windows.Forms;

namespace ACMReport3
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_About form_ab = new Form_About();
            form_ab.Show();
        }

        private void сетевоеПодключениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Connect form_cn = new Form_Connect();
            form_cn.Show();
        }

        private void дополнительныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Parameters form_st = new Form_Parameters();
            form_st.Show();
        }
    }
}
