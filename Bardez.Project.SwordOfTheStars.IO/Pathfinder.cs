using System;
using Bardez.Project.SwordOfTheStars.IO.Steam;

namespace Bardez.Project.SwordOfTheStars.IO;

/// <summary>Class that should return the path to the root Sword of the Stars directory</summary>
public class Pathfinder
{
    public String DeriveSotsPath()
    {
        //first try to fetch from the registry. Old-school disks install.
        var sotsPath = RegistryPathfinder.ReadSotsPath();
        if (string.IsNullOrEmpty(sotsPath))
        {
            sotsPath = SteamPathfinder.FindSteamSotsPath();
        }

        return sotsPath;
    }
}
