using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.Editor
{
    public class AvailableTechnologyTree
    {
        protected List<AvailableTechnologyTreeNode> technologies;

        public List<AvailableTechnologyTreeNode> Technologies
        {
            get { return technologies; }
            set { technologies = value; }
        }

        public AvailableTechnologyTree()
        {
            this.technologies = new List<AvailableTechnologyTreeNode>();
        }

        public void ReadFromStream(Stream MasterTechList)
        {
            String line = null;
            Int32 braceDepth = 0;
            AvailableTechnologyTreeNode tech = null;

            using (StreamReader reader = new StreamReader(MasterTechList))
            {
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine().Trim();

                    if (line == "tech")
                    {
                        if(tech != null)
                            this.technologies.Add(tech);
                        tech = new AvailableTechnologyTreeNode();
                    }
                    else if (line == "{")
                        braceDepth++;
                    else if (line == "}")
                        braceDepth--;
                    else if (braceDepth > 0 && line != String.Empty && !line.StartsWith("//"))
                        using (StringReader s = new StringReader(line))
                        {
                            //consume leading word
                            String word = ReadWord(s).ToLower();
                            switch (word)
                            {
                                case "name":
                                    tech.Name = s.ReadToEnd().Replace("\"", String.Empty);
                                    break;
                                case "family":
                                    tech.Family = s.ReadToEnd().Replace("\"", String.Empty);
                                    break;
                                case "group":
                                    tech.Group = s.ReadToEnd().Replace("\"", String.Empty);
                                    break;
                                case "allows":
                                    tech.AddParseAllows(s.ReadToEnd().Replace("\"", String.Empty));
                                    break;
                                case "requires":
                                    tech.AddParseRequires(s.ReadToEnd().Replace("\"", String.Empty));
                                    break;
                                default:
                                    if (s.ReadToEnd().Contains("{"))
                                        braceDepth++;
                                    else if (s.ReadToEnd().Contains("}"))
                                        braceDepth--;
                                    break;
                            }
                        }
                }
            }
            if (tech != null)
                this.technologies.Add(tech);
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

        public void CalculateNodeHeights()
        {
            for (Int32 i = 0; i < this.technologies.Count; ++i)
                CalculateHeight(this.technologies[i]);
        }

        protected void CalculateHeight(AvailableTechnologyTreeNode Node)
        {
            if (Node.Height == -1)
            {
                //iterate through all nodes and find parents' height                
                List<AvailableTechnologyTreeNode> list;

                //HACK
                if (Node.Name == "CCC_NdTrkHum" || Node.Name == "CCC_NdTrkZul")
                    list = (from t in this.technologies where t.Allows.Any(p => p.NewTech == Node.Name) && t.Name != "CCC_NdTrkHum" && t.Name != "CCC_NdTrkZul" select t).ToList<AvailableTechnologyTreeNode>();
                else
                    list = (from t in this.technologies where t.Allows.Any(p => p.NewTech == Node.Name) select t).ToList<AvailableTechnologyTreeNode>();
                
                //no parents
                if (list.Count == 0)
                    Node.Height = 0;
                else    //parents
                {
                    //CCC_NdTrkHum & CCC_NdTrkZul lead to infinite loop between Zuul & Human node tracking.
                    //...so instead, just look at the first parent and calculate its height. We will balance the heights later.
                    //CalculateHeight(list[0]);
                    // no, no... just special conditioned it. maybe I should have just manually balanced it later? dunno.

                    for (Int32 i = 0; i < list.Count; ++i)
                        CalculateHeight(list[i]);


                    //find the maximum height of the parent
                    if (Node.Name == "CCC_NdTrkHum" || Node.Name == "CCC_NdTrkZul")    //HACK
                        Node.Height = (from t in this.technologies where t.Allows.Any(p => p.NewTech == Node.Name) && t.Name != "CCC_NdTrkHum" && t.Name != "CCC_NdTrkZul" select t.Height).Max() + 1;
                    else
                        Node.Height = (from t in this.technologies where t.Allows.Any(p => p.NewTech == Node.Name) select t.Height).Max() + 1;
                }
            }
        }
    }

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

    public class AvailableTechnologyConnection
    {
        protected String newTech;
        protected Int32 researchPoints;
        protected List<AvailableTechnologyConnectionSpecies> speciesSettings;

        public String NewTech
        {
            get { return newTech; }
            set { newTech = value; }
        }

        public Int32 ResearchPoints
        {
            get { return researchPoints; }
            set { researchPoints = value; }
        }

        public List<AvailableTechnologyConnectionSpecies> SpeciesSettings
        {
            get { return speciesSettings; }
            set { speciesSettings = value; }
        }

        public AvailableTechnologyConnection()
        {
            this.newTech = String.Empty;
            this.researchPoints = 0;
            this.speciesSettings = new List<AvailableTechnologyConnectionSpecies>();
        }
    }

    public class AvailableTechnologyConnectionSpecies
    {
        protected String species;
        protected Int32 probability;

        public String Species
        {
            get { return species; }
            set { species = value; }
        }

        public Int32 Probability
        {
            get { return probability; }
            set { probability = value; }
        }

        public AvailableTechnologyConnectionSpecies()
        {
            this.species = String.Empty;
            this.probability = 0;
        }

        public AvailableTechnologyConnectionSpecies(String Species, Int32 Probability)
        {
            this.species = Species;
            this.probability = Probability;
        }
    }
}
