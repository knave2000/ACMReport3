using NLog;
using Npgsql;
using System;
using System.Windows.Forms;


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

            DateTime beginDate = dateTimePicker_BeginDate.Value.Date + dateTimePicker_BeginTime.Value.TimeOfDay;
            DateTime endDate = dateTimePicker_EndDate.Value.Date + dateTimePicker_EndTime.Value.TimeOfDay;

            string beginDateTime = String.Format("{0:yyyy-MM-dd} {0:HH:mm:ss}", beginDate);
            string endDateTime = String.Format("{0:yyyy-MM-dd} {0:HH:mm:ss}", endDate);

            string csRemote = Properties.Settings.Default["csRemote"].ToString();
            NpgsqlConnection connRemote = new NpgsqlConnection(csRemote);

            string csLocal = Properties.Settings.Default["csLocal"].ToString();
            NpgsqlConnection connLocal = new NpgsqlConnection(csLocal);

            log.Debug("connLocal");

            // TEST (comment after test complete)
            beginDateTime = "2018-03-30 00:00:00";
            endDateTime = "2018-03-30 23:59:59";

            // Подготовить запрос на чтение данных
            string SQLRead = String.Format(@"
                COPY (SELECT * FROM rpt_alltrx
                WHERE to_timestamp(trxdateutc) >= to_timestamp('{0}', 'YYYY-MM-DD HH24:MI:SS')
                AND to_timestamp(trxdateutc) <= to_timestamp('{1}', 'YYYY-MM-DD HH24:MI:SS')
                ) TO STDOUT " +
                "(FORMAT 'binary')",
                beginDateTime, endDateTime);

            // Подготовиь запрос на запись данных
            string SQLWrite = String.Format(@"
                COPY rpt_alltrx
                FROM STDIN BINARY
                ");

            log.Debug(SQLRead);
            ((Form_Parent)this.ParentForm).ShowStatusbarMessage("запрос на получение исходных данных подготовлен.");

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                connRemote.Open();  // Source

                try
                {
                    connLocal.Open();   // Destination
                }
                catch (Exception ex)
                {
                    ((Form_Parent)this.ParentForm).ShowStatusbarMessage("не могу подключиться к локальному серверу.");
                    log.Info("Мне могу подключиться к локальному серверу: {0}", ex.Message);
                }

                // Npgsql bulk copy: http://www.npgsql.org/doc/copy.html
                // PostgreSQL COPY command: https://www.postgresql.org/docs/current/static/sql-copy.html

                using (var reader = connRemote.BeginBinaryExport(SQLRead))
                using (var writer = connRemote.BeginBinaryImport(SQLWrite))
                {
                    //while (reader.StartRow() > 0) // читать в цикле все записи: пока не будет -1
                    //{
                    //log.Debug(reader.ReadLine()); // text export
                    reader.StartRow();
                    writer.StartRow();

                    writer.Write<string>(reader.Read<string>());

                    log.Debug(reader.Read<string>());

                    //reader.StartRow(); 
                    //log.Debug(reader.Read<string>());
                    //log.Debug(reader.Read<string>());
                    //}
                }
                connLocal.Close();
                connRemote.Close();

                ((Form_Parent)this.ParentForm).ShowStatusbarMessage("загрузка данных в кеш выполнена успешно.");
                log.Info("Запрос на кеширование данных выполнен успешно.");

            }
            catch (Exception ex)
            {
                // if something went wrong, and you want to know why
                ((Form_Parent)this.ParentForm).ShowStatusbarMessage("не могу получить данные с ACM сервера.");
                log.Error("Не могу получить данные с ACM сервера: {0}", ex.Message);
                //throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
    }
}
