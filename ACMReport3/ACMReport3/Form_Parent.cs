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
    public partial class Form_Parent : Form
    {
        private int childFormNumber = 0;

        public Form_Parent()
        {
            InitializeComponent();

            if (Properties.Settings.Default["FolderModules"].ToString() == "")
                Properties.Settings.Default["FolderModules"] = AppDomain.CurrentDomain.BaseDirectory + @"modules\";

        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form
            {
                MdiParent = this,
                Text = "Отчёт " + childFormNumber++
            };
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Filter = "Запросы (*.sql)|*.sql"
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Запросы (*.sql)|*.sql"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        Form_About fa;

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fa == null) // открыть форму можно только один раз
            {
                fa = new Form_About
                {
                    MdiParent = this
                };
                fa.FormClosed += new FormClosedEventHandler(Fa_FormClosed);
                fa.Show();
            }
            else
                fa.Activate(); // если форма уже открыта, то просто переключиться на неё
        }

        private void Fa_FormClosed(object sender, FormClosedEventArgs e)
        {
            fa = null; // если форма закрыта, то установить флаг в null
            //throw new NotImplementedException();
        }

        Form_Connect fc;

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fc == null) // открыть форму можно только один раз
            {
                fc = new Form_Connect
                {
                    MdiParent = this
                };
                fc.FormClosed += new FormClosedEventHandler(Fc_FormClosed);
                fc.Show();
            }
            else
                fc.Activate(); // если форма уже открыта, то просто переключиться на неё
        }
        private void Fc_FormClosed(object sender, FormClosedEventArgs e)
        {
            fc = null; // если форма закрыта, то установить флаг в null
            //throw new NotImplementedException();
        }

        Form_Parameters fp;

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fp == null) // открыть форму можно только один раз
            {
                fp = new Form_Parameters
                {
                    MdiParent = this
                };
                fp.FormClosed += new FormClosedEventHandler(Fp_FormClosed);
                fp.Show();
            }
            else
                fp.Activate(); // если форма уже открыта, то просто переключиться на неё
        }

        private void Fp_FormClosed(object sender, FormClosedEventArgs e)
        {
            fp = null; // если форма закрыта, то установить флаг в null
            //throw new NotImplementedException();
        }

        Form_Data fd;

        private void LoadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fd == null) // открыть форму можно только один раз
            {
                fd = new Form_Data
                {
                    MdiParent = this
                };
                fd.FormClosed += new FormClosedEventHandler(Fd_FormClosed);
                fd.Show();
            }
            else
                fd.Activate(); // если форма уже открыта, то просто переключиться на неё
        }
        private void Fd_FormClosed(object sender, FormClosedEventArgs e)
        {
            fd = null; // если форма закрыта, то установить флаг в null
            //throw new NotImplementedException();
        }

        public void ShowStatusbarMessage(Form frmMdiChild, string message)
        {
            ToolStripStatusLabel statusStrip = ((Form_Parent)(frmMdiChild.MdiParent)).toolStripStatusLabel1;
            statusStrip.Text = message;
        }
    }
}
