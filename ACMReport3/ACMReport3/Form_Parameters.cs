using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACMReport3
{
    public partial class Form_Parameters : Form
    {
        public Form_Parameters()
        {
            InitializeComponent();

            // Read settings from application configuration file
            tb_CommandTimeout.Text = Properties.Settings.Default["FolderModules"].ToString();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            // Write settings to application configuration file
            Properties.Settings.Default["FolderModules"] = tb_CommandTimeout.Text;
            ((Form_Parent)this.ParentForm).ShowStatusbarMessage("параметры сохранены.");
        }

        private void Button_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Reset();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog.SelectedPath = tb_CommandTimeout.Text;

            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                tb_CommandTimeout.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Form_Parameters_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form_Parent)this.ParentForm).ShowStatusbarMessage("");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
