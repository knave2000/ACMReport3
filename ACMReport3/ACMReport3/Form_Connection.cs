using NLog;
using Npgsql;
using System;
using System.Windows.Forms;

namespace ACMReport3
{
    public partial class Form_Connection : Form
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        public Form_Connection()
        {
            InitializeComponent();

        }

        private void Form_Connection_Load(object sender, EventArgs e)
        {
            // Load settings from application configuration file
            tb_ACMServerIP.Text = Properties.Settings.Default["ACMServerIP"].ToString();
            tb_ACMServerPort.Text = Properties.Settings.Default["ACMServerPort"].ToString();
            tb_ACMUsername.Text = Properties.Settings.Default["ACMUsername"].ToString();
            tb_ACMPassword.Text = Properties.Settings.Default["ACMPassword"].ToString();
            tb_CommandTimeout.Text = Properties.Settings.Default["CommandTimeout"].ToString();
            tb_Timeout.Text = Properties.Settings.Default["Timeout"].ToString();
            cb_Cache.Checked = (bool)Properties.Settings.Default["Cache"];
        }

        private void Form_Connection_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form_Parent)this.Owner).ShowStatusbarMessage("");
            log.Trace("Test connection to ACM server complete successfully.");
        }

        private void Button_Hide_Click(object sender, EventArgs e)
        {
            tb_ACMPassword.UseSystemPasswordChar = !tb_ACMPassword.UseSystemPasswordChar;
        }

        private void Button_Test_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = Properties.Settings.Default["csRemote"].ToString();
                NpgsqlConnection conn = new NpgsqlConnection(connStr);
                conn.Open();
                conn.Close();
                ((Form_Parent)this.Owner).ShowStatusbarMessage("Test connection to ACM server complete succesfully.");
                log.Info("Test connection to ACM server complete successfully.");
            }
            catch (Exception ex)
            {
                // if something went wrong, and you want to know why
                ((Form_Parent)this.Owner).ShowStatusbarMessage("Test connection to ACM server failed.");
                log.Error("During the test connection to ACM server couldn't be installed: {0}", ex.Message);
                //throw;
            }
        }

        private void Button_Save_Click(object sender, EventArgs e)
        {
            // Read settings from application WinForm
            string ACMServerIP = tb_ACMServerIP.Text;
            string ACMServerPort = tb_ACMServerPort.Text;
            string ACMUsername = tb_ACMUsername.Text;
            string ACMPassword = tb_ACMPassword.Text;
            string CommandTimeout = tb_CommandTimeout.Text;
            string Timeout = tb_Timeout.Text;
            Boolean Cache = cb_Cache.Checked;

            // Write settings to application configuration file
            Properties.Settings.Default["ACMServerIP"] = ACMServerIP;
            Properties.Settings.Default["ACMServerPort"] = ACMServerPort;
            Properties.Settings.Default["ACMUsername"] = ACMUsername;
            Properties.Settings.Default["ACMPassword"] = ACMPassword;
            Properties.Settings.Default["CommandTimeout"] = CommandTimeout;
            Properties.Settings.Default["CommandTimeout"] = CommandTimeout;
            Properties.Settings.Default["Timeout"] = Timeout;
            Properties.Settings.Default["Cache"] = Cache;

            // PostgeSQL-style connection string
            // SSL encryption is required for ACM connection
            string csRemote = String.Format("Server={0};Port={1};UserId={2};Password={3};" +
                    "CommandTimeout={4};Timeout={5};" +
                    "Database=TransactionDB;SSLMode=Require;TrustServerCertificate=true;",
                    ACMServerIP, ACMServerPort, ACMUsername, ACMPassword, CommandTimeout, Timeout);
            
            // hide password in connection string for log file
            string log_csRemote = String.Format("Server={0};Port={1};UserId={2};Password=*****;" +
                "CommandTimeout={3};Timeout={4};" +
                "Database=TransactionDB;SSLMode=Require;TrustServerCertificate=true;",
                ACMServerIP, ACMServerPort, ACMUsername, CommandTimeout, Timeout);

            // connection string is ready
            log.Info("Connection settings saved.");
            log.Debug(log_csRemote);
            Properties.Settings.Default["csRemote"] = csRemote;
            ((Form_Parent)this.Owner).ShowStatusbarMessage("Connection settings saved.");
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
