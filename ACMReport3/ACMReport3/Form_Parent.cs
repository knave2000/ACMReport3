using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.Windows.Forms;

namespace ACMReport3
{
    public partial class Form_Parent : Form
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        public Form_Parent()
        {
            InitializeComponent();

            log.Info("Приложение запущено.");
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
            log.Info("Приложение остановлено.");
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        Form_About fa;

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fa == null) // открыть форму можно только один раз
            {
                fa = new Form_About();
                fa.MdiParent = this;
                fa.FormClosed += new FormClosedEventHandler(Fa_FormClosed);
                fa.Show();
                splitContainer1.Panel2.Controls.Add(fa);
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
                fc = new Form_Connect();
                fc.MdiParent = this;
                fc.FormClosed += new FormClosedEventHandler(Fc_FormClosed);
                fc.Show();
                splitContainer1.Panel2.Controls.Add(fc);
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
                fp = new Form_Parameters();
                fp.MdiParent = this;
                fp.FormClosed += new FormClosedEventHandler(Fp_FormClosed);
                fp.Show();
                splitContainer1.Panel2.Controls.Add(fp);
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
                fd = new Form_Data();
                fd.MdiParent = this;
                fd.FormClosed += new FormClosedEventHandler(Fd_FormClosed);
                fd.Show();
                splitContainer1.Panel2.Controls.Add(fd);
            }
            else
                fd.Activate(); // если форма уже открыта, то просто переключиться на неё
        }
        private void Fd_FormClosed(object sender, FormClosedEventArgs e)
        {
            fd = null; // если форма закрыта, то установить флаг в null
            //throw new NotImplementedException();
        }

        public void ShowStatusbarMessage(string message)
        {
            ToolStripStatusLabel statusStrip = this.toolStripStatusLabel1;
            string localDate = DateTime.Now.ToString();
            statusStrip.Text = message + " " + localDate;
        }

        Form_Report fr;

        private void ReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fr == null) // открыть форму можно только один раз
            {
                fr = new Form_Report();
                fr.MdiParent = this;
                fr.FormClosed += new FormClosedEventHandler(Fr_FormClosed);
                fr.Show();
                splitContainer1.Panel2.Controls.Add(fr);
            }
            else
                fr.Activate(); // если форма уже открыта, то просто переключиться на неё
        }

        private void Fr_FormClosed(object sender, FormClosedEventArgs e)
        {
            fr = null; // если форма закрыта, то установить флаг в null
            //throw new NotImplementedException();
        }

        private void Form_Parent_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "acmreportDataSet.query". При необходимости она может быть перемещена или удалена.
            this.queryTableAdapter.Fill(this.acmreportDataSet.query);

        }
    }
}
