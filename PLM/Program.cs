using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLM
{
    internal static class Program
    {

        static SplashScreen splashScreen = null;
        static string LogFileName;
        static string WorkPath;

        static void append_log(string log_text)
        {
            //TxtLog.AppendText(DateTime.Now.ToString("dd-MM-yyyyTHH:mm:ss") + ":" + log_text + Environment.NewLine);
            //TxtLog.SelectionStart = TxtLog.TextLength;
            //TxtLog.ScrollToCaret();

            string TextLog = DateTime.Now.ToString("dd-MM-yyyyTHH:mm:ss") + ":" + log_text + Environment.NewLine;
            System.IO.Directory.CreateDirectory(WorkPath + @"/log");
            System.IO.File.AppendAllText(WorkPath + "\\log\\" + LogFileName, TextLog);
        }
        /// <summary>
        /// Main thread exception handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs args)
        {
            if (splashScreen != null)
            {
                splashScreen.Close();
            }
            Exception e = (Exception)args.Exception;
            append_log("Application_ThreadException caught : " + e.Message);
            Console.WriteLine("Application_ThreadException caught : " + e.Message);
            MessageBox.Show(e.Message, "PLM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        /// <summary>
        /// Application domain exception handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public static void AppDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs args)
        {
            if (splashScreen != null)
            {
                splashScreen.Close();
            }
            Exception e = (Exception)args.ExceptionObject;
            append_log("caught caught : " + e.Message);
            Console.WriteLine("AppDomain_UnhandledException caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
            MessageBox.Show(e.Message, "PLM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Application.Exit();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WorkPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"/" + ConfigurationSettings.AppSettings["Appname"] + @"/";
            LogFileName = DateTime.Now.ToLongDateString() + DateTime.Now.ToLongTimeString().Replace(":", "") + ".txt";
            try
            {
                AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(AppDomain_UnhandledException);

                // Unhandled exceptions for the executing UI thread
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                splashScreen = new SplashScreen();
                Application.Run(splashScreen);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:", e.Message);
            }
        }
    }
}
