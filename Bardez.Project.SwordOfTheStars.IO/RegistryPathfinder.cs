using System;
using System.IO;
using Microsoft.Win32;

namespace Bardez.Project.SwordOfTheStars.IO
{
    public static class RegistryPathfinder
    {
        private const String RegPath32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Sword of the Stars";
        private const String RegPath64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Sword of the Stars";

        public static RegistryKey GetSotsRegistryKey()
        {
            //try 32-bit first
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegPath32);

            //try 64-bit
            if (key == null)
                key = Registry.LocalMachine.OpenSubKey(RegPath64);

            return key;
        }

        public static String ReadSotsPath()
        {
            String path = null;

            var key = GetSotsRegistryKey();

            if (key != null)
            {
                //retrieve the directory from the uninstall string
                FileInfo fi = new FileInfo(key.GetValue("UninstallString") as String);
                path = fi.Directory.FullName;
            }

            return path;
        }
    }
}