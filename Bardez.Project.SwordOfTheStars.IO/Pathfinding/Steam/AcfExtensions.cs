using System;
using System.Collections.Generic;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.IO.Pathfinding.Steam;

/// <summary>Extension(s) for reading Valve's ACF files</summary>
/// <remarks>Sourced from: https://stackoverflow.com/a/42876399/1375931</remarks>
public static class AcfExtensions
{
    public static int NextEndOf(this string str, char Open, char Close, int startIndex)
    {
        if (Open == Close)
        {
            throw new Exception("\"Open\" and \"Close\" char are equivalent!");
        }

        int OpenItem = 0;
        int CloseItem = 0;
        for (int i = startIndex; i < str.Length; i++)
        {
            if (str[i] == Open)
            {
                OpenItem++;
            }
            if (str[i] == Close)
            {
                CloseItem++;
                if (CloseItem > OpenItem)
                    return i;
            }
        }

        throw new Exception("Not enough closing characters!");
    }
}
