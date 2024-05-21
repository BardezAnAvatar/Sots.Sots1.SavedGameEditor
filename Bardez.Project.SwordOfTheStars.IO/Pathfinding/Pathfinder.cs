using System;
using Bardez.Project.SwordOfTheStars.IO.Pathfinding.Physical;
using Bardez.Project.SwordOfTheStars.IO.Pathfinding.Steam;

namespace Bardez.Project.SwordOfTheStars.IO.Pathfinding;

/// <summary>Class that should return the path to the root Sword of the Stars directory</summary>
public class Pathfinder(SteamPathfinder steam)
{
    public string DeriveSotsPath()
    {
        //first try to fetch from the registry. Old-school disks install.
        var sotsPath = RegistryPathfinder.ReadSotsPath();
        if (string.IsNullOrEmpty(sotsPath))
        {
            sotsPath = steam.FindSteamSotsPath();
        }

        return sotsPath;
    }
}
