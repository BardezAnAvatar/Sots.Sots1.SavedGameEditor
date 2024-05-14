using System;
using System.IO;
using System.Text;
using Bardez.Project.SwordOfTheStars.DataStructures;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms
{
    public static class SaveFileIO
    {
        //private const String FileLocation = @"C:\Code\Tinkering\test\alter.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\another test.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\Control.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\Crap.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\Cylon Turn 2.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\Cylon.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\easy hak.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\Hack.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\kill them all.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\q.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\Space Olympics.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\teams.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\Test.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\work after play 02.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\work after play 35.sav.inflate.dat";
        //private const String FileLocation = @"C:\Code\Tinkering\test\alter.sav.inflate.dat";

        //private const String FileLocation = @"E:\Test Data\another test.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\Control.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\Crap.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\Cylon Turn 2.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\Cylon.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\easy hak.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\Hack.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\kill them all.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\q.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\Space Olympics.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\teams.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\Test.sav.inflate.dat";
        private const String FileLocation = @"E:\Test Data\work after play 02.sav.inflate.dat";
        //private const String FileLocation = @"E:\Test Data\work after play 35.sav.inflate.dat";

        //private const String FileLocation = @"D:\test\alter.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\another test.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\Control.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\Crap.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\Cylon Turn 2.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\Cylon.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\easy hak.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\Hack.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\kill them all.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\q.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\Space Olympics.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\teams.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\Test.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\work after play 02.sav.inflate.dat";
        //private const String FileLocation = @"D:\test\work after play 35.sav.inflate.dat";


        /// <summary>Reads the save game file specified statically in this class and returns a represenation of it</summary>
        /// <returns>A fully populated SaveGameData object containing data from the statically specified save file</returns>
        /// <remarks>This is a test method</remarks>
        private static SaveGameData ReadSaveFileFormat()
        {
            return ReadSaveFileFormat(FileLocation);
        }

        /// <summary>Writes a save game file already read and populated back to a (copy) save file</summary>
        /// <param name="SaveGame">SaveGameData object populated with save game data</param>
        /// <remarks>This is a test method</remarks>
        private static void WriteSaveFileFormat(SaveGameData SaveGame)
        {
            WriteSaveFileFormat(SaveGame, FileLocation + ".copy");
        }

        /// <summary>Reads the save game file specified statically in this class and returns a represenation of it</summary>
        /// <returns>A fully populated SaveGameData object containing data from the statically specified save file</returns>
        /// <param name="Source">String representing the path to the source file</param>
        public static SaveGameData ReadSaveFileFormat(String Source)
        {
            SaveGameData savegame = new SaveGameData();
            using (FileStream saveFile = new FileStream(Source, FileMode.Open, FileAccess.Read))
            {
                savegame.ReadFromStream(saveFile);
            }

            return savegame;
        }

        /// <summary>Writes a save game file already read and populated back to a (copy) save file</summary>
        /// <param name="SaveGame">SaveGameData object populated with save game data</param>
        /// <param name="Destination">String representing the path to the destination file</param>
        public static void WriteSaveFileFormat(SaveGameData SaveGame, String Destination)
        {
            using (FileStream destination = new FileStream(Destination, FileMode.Create, FileAccess.Write))
            {
                SaveGame.WriteToStream(destination);
            }
        }

        /// <summary>Reads the save game file specified statically in this class and returns a represenation of it</summary>
        /// <returns>A fully populated SaveGameData object containing data from the statically specified save file</returns>
        /// <param name="Source">Stream containing the decompressed binary stream of the source file</param>
        public static SaveGameData ReadSaveFileFormat(Stream Source)
        {
            SaveGameData savegame = new SaveGameData();
            savegame.ReadFromStream(Source);

            return savegame;
        }

        /// <summary>Writes a save game file already read and populated back to a (copy) save file</summary>
        /// <param name="SaveGame">SaveGameData object populated with save game data</param>
        /// <param name="Destination">Stream containing the decompressed binary stream of the destination file</param>
        public static void WriteSaveFileFormat(SaveGameData SaveGame, Stream Destination)
        {
            SaveGame.WriteToStream(Destination);
        }
    }
}