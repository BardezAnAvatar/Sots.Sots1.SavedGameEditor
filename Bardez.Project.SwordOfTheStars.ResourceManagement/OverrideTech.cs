using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            using (StreamReader reader = new StreamReader(OverrideTechList, Encoding.GetEncoding(1252)))  //ANSI encoding
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

    public class OverrideTech
    {
        protected String name;
        protected Int32 depth;
        protected Int32 position;
        protected String family;
        protected String group;
        protected Int32 groupNumber;
        protected String friendlyName;
        protected String overrideImagePath;
        protected String description;

        #region Properties
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Int32 Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public Int32 Position
        {
            get { return position; }
            set { position = value; }
        }

        public String Family
        {
            get { return family; }
            set { family = value; }
        }

        public String Group
        {
            get { return group; }
            set { group = value; }
        }

        public Int32 GroupNumber
        {
            get { return groupNumber; }
            set { groupNumber = value; }
        }

        public String FriendlyName
        {
            get { return friendlyName; }
            set { friendlyName = value; }
        }

        public String OverrideImagePath
        {
            get { return overrideImagePath; }
            set { overrideImagePath = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        } 
        #endregion

        /// <summary>Default for Linq</summary>
        public static OverrideTech Default
        {
            get
            {
                OverrideTech defaultTech = new OverrideTech();
                defaultTech.name = null;
                defaultTech.depth = 0;
                defaultTech.position = 0;
                defaultTech.family = null;
                defaultTech.group = null;
                defaultTech.groupNumber = 0;
                defaultTech.friendlyName = null;
                defaultTech.overrideImagePath = null;
                defaultTech.description = null;

                return defaultTech;
            }
        }
    }
}