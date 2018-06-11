using NLog;
using System;
using System.Windows.Forms;

namespace ACMReport3
{
    static class Program
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                log.Trace("Версия среды: {0}", Environment.Version.ToString());
                log.Trace("ОС: {0}", Environment.OSVersion.ToString());
                log.Trace("Файл: {0}", Environment.CommandLine.ToString());
                log.Trace("Название компьютера: {0}", Environment.MachineName.ToString());
                log.Trace("Название домена: {0}", Environment.UserDomainName.ToString());
                log.Trace("Количество процессоров: {0}", Environment.ProcessorCount.ToString());
                log.Trace("Используемая память: {0}", Environment.WorkingSet.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы с логом!\n" + ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Parent());
        }
    }
}
