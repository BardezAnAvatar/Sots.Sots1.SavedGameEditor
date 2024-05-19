using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.ResourceManagement
{
    public static class Registry
    {
        private static String RegPath32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Sword of the Stars";
        private static String RegPath64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Sword of the Stars";

        public static String ReadSotsPath()
        {
            String path = String.Empty;
            Microsoft.Win32.RegistryKey key;

            //try 35-bit first
            key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegPath32);

            //try 64-bit
            if (key == null)
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(RegPath64);

            //retrieve the directory from the uninstall string
            FileInfo fi = new FileInfo(key.GetValue("UninstallString") as String);
            path = fi.Directory.FullName;

            return path;
        }
    }
}