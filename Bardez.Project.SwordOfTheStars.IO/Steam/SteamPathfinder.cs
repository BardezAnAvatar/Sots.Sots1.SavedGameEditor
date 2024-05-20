using System.IO;
using System;
using Microsoft.Win32;

namespace Bardez.Project.SwordOfTheStars.IO.Steam;

/// <summary>
///     Attempts to derive the path to the root directory of the SotS game installation from
///     Steam metadata.
/// </summary>
public class SteamPathfinder
{
    private const string RegPath32 = @"SOFTWARE\Valve\Steam";
    private const string RegPath64 = @"SOFTWARE\Wow6432Node\Valve\Steam";
    private const int SotsManifestId = 42890;

    public static RegistryKey FindSteam()
    {
        //try 32-bit first
        RegistryKey key = Registry.LocalMachine.OpenSubKey(RegPath32);

        //try 64-bit
        if (key == null)
            key = Registry.LocalMachine.OpenSubKey(RegPath64);

        return key;
    }

    public static string FindSteamSotsPath()
    {
        string path = string.Empty;

        var key = FindSteam();

        if (key != null)
        {
            //retrieve the directory from the uninstall string
            var steamPath = key.GetValue("InstallPath", null);
            FileInfo fi = new FileInfo(steamPath as string);
            var steamRoot = fi.Directory.FullName;

            path = FindSotsPath(steamRoot);
        }

        return path;
    }

    public static string FindSotsPath(string steamRoot)
    {
        if (!Directory.Exists(steamRoot))
        {
            throw new InvalidOperationException($"Directory `{steamRoot}` does not exist.");
        }

        var path = Path.Combine(steamRoot, $@"steamapps\appmanifest_{SotsManifestId}.acf");

        //TODO: read the ACF file

        throw new NotImplementedException("I should read this file eventually.");
    }
}
