using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bardez.Project.Configuration;
using Bardez.Project.ExceptionHandler.Loggers;

namespace Bardez.Project.ExceptionHandler
{
    public static class ExceptionManager
    {
        private static List<IExceptionLogger> loggers = null;
        private static Boolean isNotInitialized = true;
        private static readonly Object locker = new Object();

        public static List<IExceptionLogger> Loggers
        {
            get { return loggers; }
            set { loggers = value; }
        }

        private static void Initialize()
        {
            lock (locker)
            {
                if (isNotInitialized)
                {
                    loggers = new List<IExceptionLogger>();
                    isNotInitialized = false;

                    //if this fails, then it is for some BAD reason.
                    LoadConfig();
                }
            }
        }


        private static void LoadConfig()
        {
            lock (locker)
            {
                //read which loggers are on
                if (ConfigurationHandler.GetBoolSettingValue("ExceptionManager.Loggers.Enable.TextFile", false))
                    loggers.Add(new TextFileLogger());

                if (ConfigurationHandler.GetBoolSettingValue("ExceptionManager.Loggers.Enable.Email", false))
                    loggers.Add(new EmailLogger());

                if (ConfigurationHandler.GetBoolSettingValue("ExceptionManager.Loggers.Enable.MessageBox", false))
                    loggers.Add(new MessageBoxLogger());
            }
        }


        /// <summary>Static method designed to be a delegate to log an unhandled exception.</summary>
        /// <param name="obj">Standard System.Object used in delegate calls</param>
        /// <param name="args">System.Threading.ThreadExceptionEventArgs containing the unhandled exception</param>
        public static void LogException(System.Object obj, System.Threading.ThreadExceptionEventArgs args)
        {
            //Initialize();     //redundant
            LogException(args.Exception);
        }

        /// <summary>Static method to log an unhandled exception.</summary>
        /// <param name="ex">System.Exception to be logged</param>
        public static void LogException(System.Exception ex)
        {
            Initialize();

            foreach (IExceptionLogger logger in loggers)
                lock (locker)
                {
                    logger.LogException(ex);
                }
        }

        /// <summary>Static method designed to be a delegate to log an unhandled exception.</summary>
        /// <param name="obj">Standard System.Object used in delegate calls</param>
        /// <param name="args">System.UnhandledExceptionEventArgs containing the unhandled exception object (System.Exception?)</param>
        public static void LogException(System.Object obj, UnhandledExceptionEventArgs args)
        {
            //Initialize();     //redundant
            LogException(args.ExceptionObject as System.Exception);
        }

        public static void AttachManagerForWinForms()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(LogException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(LogException);

            // Set the unhandled exception mode to force all Windows Forms errors
            // to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        }

        public static void AttachManagerForConsole()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(LogException);
        }
    }
}