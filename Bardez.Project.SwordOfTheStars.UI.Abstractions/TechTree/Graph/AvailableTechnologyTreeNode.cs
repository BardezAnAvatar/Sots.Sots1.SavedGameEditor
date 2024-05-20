using System;
using System.Collections.Generic;
using System.IO;

namespace Bardez.Project.SwordOfTheStars.UI.Abstractions.TechTree.Graph
{
    public class AvailableTechnologyTreeNode
    {
        protected String name;
        protected String family;
        protected String group;
        protected List<String> requires;
        protected List<AvailableTechnologyConnection> allows;

        protected Int32 height;

        #region Properties
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String Family
        {
            get { return family ?? this.name.Substring(0, 3); }
            set { family = value; }
        }

        public String FamilyNoForge
        {
            get { return family; }
            set { family = value; }
        }

        public String Group
        {
            get { return group; }
            set { group = value; }
        }

        public List<String> Requires
        {
            get { return requires; }
            set { requires = value; }
        }

        public List<AvailableTechnologyConnection> Allows
        {
            get { return allows; }
            set { allows = value; }
        }

        public Int32 Height
        {
            get { return height; }
            set { height = value; }
        } 
        #endregion

        public AvailableTechnologyTreeNode()
        {
            this.name = null;
            this.family = null;
            this.group = null;
            this.requires = new List<String>();
            this.allows = new List<AvailableTechnologyConnection>();
            this.height = -1;
        }

        public void AddParseAllows(String Parse)
        {
            using (StringReader s = new StringReader(Parse))
            {
                AvailableTechnologyConnection conn = new AvailableTechnologyConnection();
                conn.NewTech = ReadWord(s);

                //research cost
                String[] split = ReadWord(s).Split(new Char[] {':'});
                conn.ResearchPoints = Int32.Parse(split[1]);

                //read species branches
                while(s.Peek() > -1)
                {
                    split = ReadWord(s).Split(new Char[] {':'});
                    conn.SpeciesSettings.Add(new AvailableTechnologyConnectionSpecies(split[0], Int32.Parse(split[1])));
                }

                this.allows.Add(conn);
            }
        }

        public void AddParseRequires(String Parse)
        {
            this.requires.Add(Parse);
        }

        protected static String ReadWord(StringReader Reader)
        {
            Int32 temp;
            Char current;
            String word = String.Empty;

            //consume leading whitespace
            while ((temp = Reader.Peek()) > -1 && Char.IsWhiteSpace(current = Convert.ToChar(temp)))
            {
                Reader.Read();
            }

            //consume leading whitespace
            while ((temp = Reader.Peek()) > -1 && !Char.IsWhiteSpace(current = Convert.ToChar(temp)))
            {
                word += current;
                Reader.Read();
            }

            //consume trailing whitespace
            while ((temp = Reader.Peek()) > -1 && Char.IsWhiteSpace(current = Convert.ToChar(temp)))
            {
                Reader.Read();
            }

            return word;
        }
    }
}
