using System;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace Bardez.Project.SwordOfTheStars.IO.Pathfinding.Steam;

/// <summary>
///     Attempts to derive the path to the root directory of the SotS game installation from
///     Steam metadata.
/// </summary>
public class SteamPathfinder(IAcfManifestParserBuilder parserBuilder)
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

    public string FindSteamSotsPath()
    {
        string path = string.Empty;

        var key = FindSteam();

        if (key != null)
        {
            //retrieve the directory from the uninstall string
            var steamPath = key.GetValue("InstallPath", null);
            var di = new DirectoryInfo(steamPath as string);
            var steamRoot = di.FullName;

            path = FindSotsPath(di.FullName);
        }

        return path;
    }

    public string FindSotsPath(string steamRoot)
    {
        if (!Directory.Exists(steamRoot))
        {
            throw new InvalidOperationException($"Directory `{steamRoot}` does not exist.");
        }

        //Read the ACF library file
        var libraryData = ReadAcfFile(Path.Combine(steamRoot, @"steamapps\libraryfolders.vdf"));

        //Read the ACF file
        var acfStructure = ReadAcfFile(Path.Combine(steamRoot, $@"steamapps\appmanifest_{SotsManifestId}.acf"));
        var sotsPartialPath = acfStructure.SubACF.First().Value.SubItems["installdir"];

        var libraryDirectories = libraryData.SubACF.Values.Select(si => si.SubACF.First().Value.SubItems["path"].Replace(@"\\", @"\"));
        var existingDirectories = libraryDirectories
            .Select(ld => Path.Combine(ld, @"steamapps\common", sotsPartialPath))
            .Where(Directory.Exists);

        return existingDirectories.SingleOrDefault();
    }

    private AcfStruct ReadAcfFile(string path)
    {
        //read the ACF file
        var parser = parserBuilder.BuildParser(path);
        var acfStructure = parser.AcfFileToStruct();

        return acfStructure;
    }
}
