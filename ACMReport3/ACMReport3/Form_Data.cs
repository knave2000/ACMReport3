using NLog;
using Npgsql;
using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ACMReport3
{
    public partial class Form_Data : Form
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        public Form_Data()
        {
            InitializeComponent();
        }

        private void Button_Load_Click(object sender, EventArgs e)
        {

            DateTime beginDate = dateTimePicker_BeginDate.Value.Date +
                    dateTimePicker_BeginTime.Value.TimeOfDay;
            DateTime endDate = dateTimePicker_EndDate.Value.Date +
                    dateTimePicker_EndTime.Value.TimeOfDay;

            string beginDateTime = String.Format("{0:yyyy-MM-dd} {0:HH:mm:ss}", beginDate);
            string endDateTime = String.Format("{0:yyyy-MM-dd} {0:HH:mm:ss}", endDate);

            string connStr = Properties.Settings.Default["ConnectionString"].ToString();

            // Подготовить запрос данных от сервера ACM
            string SQLRemote = String.Format(
                "SELECT * FROM rpt_alltrx " +
                "WHERE to_timestamp(trxdateutc) >= to_timestamp('{0}', 'YYYY-MM-DD HH24:MI:SS') " +
                "AND to_timestamp(trxdateutc) <= to_timestamp('{1}', 'YYYY-MM-DD HH24:MI:SS')",
                beginDateTime, endDateTime);

            log.Debug(SQLRemote);
            ((Form_Parent)this.ParentForm).ShowStatusbarMessage("запрос для исходных данных подготовлен.");

            // Очистить локальную базу данных
            string acmreportConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; " +
                @"AttachDbFilename=|DataDirectory|\acmreport.mdf;
                Integrated Security = True;
                Connect Timeout = 30";
            SqlConnection sqlConn = new SqlConnection(acmreportConnectionString);

            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connStr);
                conn.Open();
                // Execute SQL Request
                NpgsqlDataAdapter da_pg = new NpgsqlDataAdapter(SQLRemote, conn);
                conn.Close();
                ((Form_Parent)this.ParentForm).ShowStatusbarMessage("запрос на получение данных выполнен.");
                log.Info("Запрос на получение данных с ACM сервера выполнен.");

                string SQLLocal = @"
                    IF EXISTS (SELECT * 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_NAME = N'rpt_alltrx')
                    BEGIN
                        -- Clean cache table
                        TRUNCATE TABLE rpt_alltrx
                    END";

                log.Debug(SQLLocal);
                ((Form_Parent)this.ParentForm).ShowStatusbarMessage("запрос для кеширования данных подготовлен.");

                try
                {
                    sqlConn.Open();
                    SqlCommand cmdSql = new SqlCommand(SQLLocal, sqlConn);
                    cmdSql.ExecuteNonQuery();
                    sqlConn.Close();
                    ((Form_Parent)this.ParentForm).ShowStatusbarMessage("загрузка данных в кеш выполнена успешно.");
                    log.Info("Запрос на кеширование данных выполнен. Ошибки в запросе не проверяются.");
                }
                catch (Exception ex)
                {
                    ((Form_Parent)this.ParentForm).ShowStatusbarMessage("не могу загрузить данные в кеш.");
                    log.Error("Не могу загрузить данные в локальную базу данных: {0}", ex.Message);
                }
            }
            catch (Exception ex)
            {
                // if something went wrong, and you want to know why
                //MessageBox.Show("ОШИБКА: не могу установить соединение с ACM сервером.\nПроверьте настройки соединения.");
                ((Form_Parent)this.ParentForm).ShowStatusbarMessage("не могу получить данные с ACM сервера.");
                log.Error("Не могу получить данные с ACM сервера: {0}", ex.Message);
                //throw;
            }

        }
    }
}
