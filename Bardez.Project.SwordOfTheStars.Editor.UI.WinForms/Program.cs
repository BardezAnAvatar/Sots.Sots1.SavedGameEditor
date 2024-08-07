﻿using System;
using System.Windows.Forms;
using Bardez.Project.ExceptionHandler;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms
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
        }
    }
}