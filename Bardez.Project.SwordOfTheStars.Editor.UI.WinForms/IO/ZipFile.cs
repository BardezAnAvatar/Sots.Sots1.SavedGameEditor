using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zip;

namespace Bardez.Project.SwordOfTheStars.Editor
{
    public class Zip_File
    {
        protected const String path = @"D:\test\gob\sots.gob.zip";

        //public static void Unzip()
        //{
        //    //using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    using (Ionic.Zip.ZipFile zip = new ZipFile(path))
        //    {
        //        //zip.Entries;
        //        ////zip.ExtractSelectedEntries(
        //        //Ionic.Zip.ZipInputStream stream = new ZipInputStream(path);
        //        //stream.

        //        var x = from entry in zip.Entries
        //                where (entry.FileName.StartsWith("Avatars") == true || entry.FileName.StartsWith("Badges") == true || entry.FileName.StartsWith("TechTree") == true)
        //                && (entry.FileName.EndsWith(".tga") || entry.FileName.EndsWith(".tech") || entry.FileName.EndsWith(".txt"))
        //                && entry.FileName.IndexOf("ShipArt") == -1
        //                select entry;

        //        var y = from entry in zip.Entries
        //                where entry.FileName.EndsWith(".csv") || entry.FileName.EndsWith(".txt")
        //                select entry;

        //        //extract MasterTechList.tech and SpriteTable.csv
        //        List<ZipEntry> first = (from entry in zip.Entries where entry.FileName.IndexOf("MasterTechList.tech") > -1 || entry.FileName.IndexOf("SpriteTable.csv") > -1 select entry).ToList<ZipEntry>();

        //        //

        //        //zip.ExtractSelectedEntries("name = *MasterTechList.tech OR name = *SpriteTable.csv");
        //        foreach (ZipEntry entry in first)
        //        {
        //            using(FileStream file = new FileStream(
        //            //entry.FileName
        //        }
        //    }
        //}
    }
}