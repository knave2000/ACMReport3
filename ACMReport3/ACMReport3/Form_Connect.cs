using NLog;
using Npgsql;
using System;
using System.Windows.Forms;

namespace ACMReport3
{
    public partial class Form_Connect : Form
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        public Form_Connect()
        {
            InitializeComponent();

            // Read settings from application configuration file
            tb_ACMServerIP.Text    = Properties.Settings.Default["ACMServerIP"].ToString();
            tb_ACMServerPort.Text  = Properties.Settings.Default["ACMServerPort"].ToString();
            tb_ACMUsername.Text    = Properties.Settings.Default["ACMUsername"].ToString();
            tb_ACMPassword.Text    = Properties.Settings.Default["ACMPassword"].ToString();
            tb_CommandTimeout.Text = Properties.Settings.Default["CommandTimeout"].ToString();
            tb_Timeout.Text        = Properties.Settings.Default["Timeout"].ToString();
        }

         private void Button_Hide_Click(object sender, EventArgs e)
        {
            tb_ACMPassword.UseSystemPasswordChar = !tb_ACMPassword.UseSystemPasswordChar;
        }

        private void Button_Test_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = Properties.Settings.Default["ConnectionString"].ToString();
                NpgsqlConnection conn = new NpgsqlConnection(connStr);
                conn.Open();
                conn.Close();
                //MessageBox.Show("Соединение с ACM сервером установлено успешно.");
                ((Form_Parent)this.MdiParent).ShowStatusbarMessage(this, "соединение ACM сервером установлено успешно.");
                log.Info("При тестрировании соединение с ACM сервером установлено успешно.");
            }
            catch (Exception ex)
            {
                // if something went wrong, and you want to know why
                //MessageBox.Show("ОШИБКА: не могу установить соединение с ACM сервером. ");
                ((Form_Parent)this.MdiParent).ShowStatusbarMessage(this, "не могу установить соединение с ACM сервером.");
                log.Error("Ошибка при тестировании соединения с сервером ACM: {0}", ex.Message);

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

            // Write settings to application configuration file
            Properties.Settings.Default["ACMServerIP"] = ACMServerIP;
            Properties.Settings.Default["ACMServerPort"] = ACMServerPort;
            Properties.Settings.Default["ACMUsername"] = ACMUsername;
            Properties.Settings.Default["ACMPassword"] = ACMPassword;
            Properties.Settings.Default["CommandTimeout"] = CommandTimeout;

            Properties.Settings.Default["Timeout"] = Timeout;

            // PostgeSQL-style connection string
            // SSL encryption is required for ACM connection
            string ConnectionString = String.Format("Server={0};Port={1};UserId={2};Password={3};" +
                    "CommandTimeout={4};Timeout={5};" +
                    "Database=TransactionDB;SSLMode=Require;TrustServerCertificate=true;",
                    ACMServerIP, ACMServerPort, ACMUsername, ACMPassword, CommandTimeout, Timeout);

            Properties.Settings.Default["ConnectionString"] = ConnectionString;

            ((Form_Parent)this.MdiParent).ShowStatusbarMessage(this, "параметры соединения сохранены.");

            string LogString = String.Format("Server={0};Port={1};UserId={2};Password=*****;" +
                "CommandTimeout={3};Timeout={4};" +
                "Database=TransactionDB;SSLMode=Require;TrustServerCertificate=true;",
                ACMServerIP, ACMServerPort, ACMUsername, CommandTimeout, Timeout);
            log.Info("Параметры соединения сохранены: {0}", LogString);
        }

        private void Form_Connect_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form_Parent)this.MdiParent).ShowStatusbarMessage(this, "");
        }
    }
}
