using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bardez.Project.ExceptionHandler;

namespace Bardez.Project.SwordOfTheStars.Editor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExceptionManager.AttachManagerForWinForms();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SotsEditor());
            //Application.Run(new Form2());
        }
    }
}