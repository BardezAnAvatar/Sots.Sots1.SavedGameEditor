using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.ResourceManagement
{
    public static class OverrideTechList
    {
        public static List<OverrideTech> ReadFromStream(Stream OverrideTechList)
        {
            List<OverrideTech> techList = new List<OverrideTech>();
            String line = null;
            OverrideTech tech = null;

            var enc = CodePagesEncodingProvider.Instance.GetEncoding(1252);  //windows-1252

            using (StreamReader reader = new StreamReader(OverrideTechList, enc))
            {
                //read the definition line and, frankly, discard.
                line = reader.ReadLine().Trim();

                while (!reader.EndOfStream)
                {
                    //Read the line
                    line = reader.ReadLine().Trim();

                    if (tech != null)
                        techList.Add(tech);
                    tech = new OverrideTech();

                    using (StringReader sr = new StringReader(line))
                    {
                        Int32 parse;

                        tech.Name = ReadTabDelimitedWord(sr);           //name
                        ReadTabDelimitedWord(sr);                       //original family, interpolated from name and MasterTechList.tech
                        ReadTabDelimitedWord(sr);                       //original family, as described in MasterTechList.tech
                        ReadTabDelimitedWord(sr);                       //original group, as described in MasterTechList.tech

                        Int32.TryParse(ReadTabDelimitedWord(sr), out parse);
                        tech.Depth = parse;                             //defined height/depth
                        Int32.TryParse(ReadTabDelimitedWord(sr), out parse);
                        tech.Position = parse;                          //defined width / position
                        tech.Family = ReadTabDelimitedWord(sr);         //defined family
                        tech.Group = ReadTabDelimitedWord(sr);          //defined group
                        Int32.TryParse(ReadTabDelimitedWord(sr), out parse);
                        tech.GroupNumber = parse;                       //defined group order
                        tech.FriendlyName = ReadTabDelimitedWord(sr);   //friendly name, from Strings.csv
                        tech.OverrideImagePath = ReadTabDelimitedWord(sr);  //defined override image
                        tech.Description = ReadTabDelimitedWord(sr).Replace("\"", String.Empty);    //description of tech, from Strings.csv
                    }
                }
            }
            if (tech != null)
                techList.Add(tech);

            return techList;
        }

        public static List<OverrideTech> ReadFromFile(String OverrideTechList)
        {
            List<OverrideTech> techs;
            using (FileStream file = new FileStream(OverrideTechList, FileMode.Open, FileAccess.Read))
            {
                techs = ReadFromStream(file);
            }

            return techs;
        }

        private static String ReadTabDelimitedWord(StringReader Reader)
        {
            Int32 temp;
            Char current;
            String word = String.Empty;

            //consume leading tab
            if ((temp = Reader.Peek()) > -1 && (current = Convert.ToChar(temp)) == '\t')
                Reader.Read();

            //consume leading whitespace
            while ((temp = Reader.Peek()) > -1 && (current = Convert.ToChar(temp)) != '\t')
            {
                word += current;
                Reader.Read();
            }

            return word.Trim();
        }
    }
}