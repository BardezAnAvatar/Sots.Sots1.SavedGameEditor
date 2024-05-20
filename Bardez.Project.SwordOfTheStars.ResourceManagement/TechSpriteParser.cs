using System;
using System.Collections.Generic;
using System.IO;

namespace Bardez.Project.SwordOfTheStars.ResourceManagement
{
    public static class TechSpriteParser
    {
        private const String iconPrefix = "TECHICON_";

        public static List<TechSprite> ReadFromStream(Stream MasterTechList)
        {
            List<TechSprite> spriteList = new List<TechSprite>();
            String line = null;
            TechSprite tech = null;

            using (StreamReader reader = new StreamReader(MasterTechList))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Trim();

                    if (line.StartsWith(iconPrefix))
                    {
                        if (tech != null)
                            spriteList.Add(tech);
                        tech = new TechSprite();

                        using (StringReader sr = new StringReader(line))
                        {
                            tech.Tech = ReadCsvWord(sr).Replace(iconPrefix, String.Empty);
                            tech.ZipArchivePath = ReadCsvWord(sr);
                        }
                    }
                }
            }
            if (tech != null)
                spriteList.Add(tech);

            return spriteList;
        }

        public static List<TechSprite> ReadFromFile(String MasterTechList)
        {
            List<TechSprite> sprites;
            using (FileStream file = new FileStream(MasterTechList, FileMode.Open, FileAccess.Read))
            {
                sprites = ReadFromStream(file);
            }

            return sprites;
        }

        private static String ReadCsvWord(StringReader Reader)
        {
            Int32 temp;
            Char current;
            String word = String.Empty;

            //consume leading whitespace
            while ((temp = Reader.Peek()) > -1 && (Char.IsWhiteSpace(current = Convert.ToChar(temp)) || current == ',') )
            {
                Reader.Read();
            }

            //consume leading whitespace
            while ((temp = Reader.Peek()) > -1 && !(Char.IsWhiteSpace(current = Convert.ToChar(temp)) || current == ',') )
            {
                word += current;
                Reader.Read();
            }

            //consume trailing whitespace
            while ((temp = Reader.Peek()) > -1 && (Char.IsWhiteSpace(current = Convert.ToChar(temp)) || current == ',') )
            {
                Reader.Read();
            }

            return word;
        }
    }
}