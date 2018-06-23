using NLog;
using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace ACMReport3
{
    static class Program
    {
        // Logger
        private static Logger log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main enter point to Application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                log.Trace("OS: {0}", Environment.OSVersion.ToString());
                log.Trace("Filename: {0}", Environment.CommandLine.ToString());
                log.Trace("Machine Name: {0}", Environment.MachineName.ToString());
                log.Trace("User Domain Name: {0}", Environment.UserDomainName.ToString());
                log.Trace("CPU: {0}", Environment.ProcessorCount.ToString());
                //log.Trace("Environment Version: {0}", Environment.Version.ToString());
                //log.Trace("Working Set memory: {0}", Environment.WorkingSet.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Log file error: {0}", ex.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Parent());
        }

    }
}
