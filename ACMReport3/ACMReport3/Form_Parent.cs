using NLog;
using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;

namespace ACMReport3
{
    public partial class Form_Parent : Form
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        // hide selected cell in parameter form when it load first time
        private static Boolean firstTime = true;

        // plugin file name
        public String fnPlugin = Properties.Settings.Default["PluginsFileName"].ToString();

        // selected report
        public String reportName = null;

        public Form_Parent()
        {
            InitializeComponent();

            log.Info("Application started.");           
        }

        private void Form_Parent_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Info("Application closed.");
        }

        private void Form_Parent_Load(object sender, EventArgs e)
        {
            // load plugins list from XML file

            DataSet dsData = new DataSet();
            try
            {
                dsData.ReadXml(fnPlugin);
                log.Info("Read plugins file: " + fnPlugin);
                this.ShowStatusbarMessage("Plugins loaded.");
            }
            catch
            {
                log.Error("Could not read plugins file: " + fnPlugin);
                this.ShowStatusbarMessage("Couldn't load plugins.");
            }
            
            gvData.DataSource = dsData;
            gvData.DataMember = "plugin";
            gvData.Columns["name"].HeaderText = "Report list";
            gvData.Columns["query"].Visible = false;

            if (gvData.RowCount > 0 && gvData.ColumnCount > 0)
            {
                gvData.CurrentCell = gvData[0, 0];
                gvData.CurrentCell.Selected = false;
                firstTime = false;
            }

        }

        private void StripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StripMenuItem_Toolbar_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StripMenuItem_Statusbar_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        Form_About fa;

        private void StripMenuItem_About_Click(object sender, EventArgs e)
        {
            if (fa == null) // open single form copy
            {
                fa = new Form_About();
                fa.FormClosed += new FormClosedEventHandler(Fa_FormClosed);
                fa.Show(this);
            }
            else
                fa.Activate(); // activate form if it is already opened
        }

        private void Fa_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Trace("Form {0} closed.", fa.Text);
            fa = null; // set open form flag to null
        }

        Form_Connection fc;

        private void StripMenuItem_Connection_Click(object sender, EventArgs e)
        {
            if (fc == null) // open single form copy
            {
                fc = new Form_Connection();
                fc.FormClosed += new FormClosedEventHandler(Fc_FormClosed);
                fc.Show(this);
            }
            else
                fc.Activate(); // activate form if it is already opened
        }
        private void Fc_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Trace("Form {0} closed.", fc.Text);
            fc = null; // set open form flag to null
        }

        Form_Plugins fd;

        private void StripMenuItem_Plugins_Click(object sender, EventArgs e)
        {
            if (fd == null) // open single form copy
            {
                fd = new Form_Plugins();
                fd.FormClosed += new FormClosedEventHandler(Fd_FormClosed);
                fd.Show(this);
            }
            else
                fd.Activate(); // activate form if it is already opened
        }
        private void Fd_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Trace("Form {0} closed.", fd.Text);
            fd = null; // set open form flag to null
        }

        public void ShowStatusbarMessage(string message)
        {
            ToolStripStatusLabel statusStrip = this.toolStripStatusLabel1;
            string localDate = DateTime.Now.ToString();
            if (message == null || message == "") message = "";
            else message += " (" + localDate + ")";
            statusStrip.Text = message;
        }

        Form_Parameters fp;

        private void OpenParametersForm(object sender, EventArgs e)
        {
            if (fp != null) fp.Close(); // close form
            fp = new Form_Parameters();
            fp.FormClosed += new FormClosedEventHandler(Fp_FormClosed);
            fp.Text = "Parameters for " + reportName;
            fp.Show(this);

            log.Debug("Parameters input form for " + reportName + " is loaded.");
            ShowStatusbarMessage("Parameters input form for " + reportName + " is loaded.") ;
        }

        private void Fp_FormClosed(object sender, FormClosedEventArgs e)
        {
            log.Trace("Form {0} closed.", fp.Text);
            fp = null; // set open form flag to null
        }

        private void gvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!firstTime)
            {
                reportName = gvData.CurrentCell.Value.ToString();
                OpenParametersForm(sender, e);
                log.Debug("selected report: " + reportName);
            }
        }

        public NpgsqlConnection connRemote;
        public SqlConnection connLocal;

        // Open connection to ACM server with or without cache.
        // cache = true  - open local and remote connection
        // cache = false - open only remote connection
        public void OpenConnection()
        {
            Boolean cache = (Boolean)Properties.Settings.Default["cache"];
            if (cache)
            {
                // open connection to local database
                string connStr = Properties.Settings.Default["csRemote"].ToString();
            }

            // open connection to remote database
            string csRemote = Properties.Settings.Default["csRemote"].ToString();
            connRemote = new NpgsqlConnection(csRemote);

            try
            {
                connRemote.Open();
                ShowStatusbarMessage("Connection to remote ACM server installed.");
                log.Info("Connection to remote database installed: {0}.", csRemote);
            }
            catch (Exception ex)
            {
                ShowStatusbarMessage("Could not install connection to remote ACM server.");
                log.Error("Could not install connection to remote database: {0}.", ex.Message);
            }
         }

        // Close connection to ACM server with or without cache.
        // cache = true  - close local and remote connection
        // cache = false - close only remote connection
        public void CloseConnection()
        {
            Boolean cache = (Boolean)Properties.Settings.Default["cache"];
            if (cache)
            {
                // close local connection
                connLocal.Close();
            }
            // close remote connection
            connRemote.Close();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton_Connection.Image = ACMReport3.Properties.Resources.ball_green;
            // TODO: Connection
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton_Connection.Image = ACMReport3.Properties.Resources.ball_red;
            // TODO: Disconnection
        }

    }
}
