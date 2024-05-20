using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bardez.Project.SwordOfTheStars.UI.Abstractions.TechTree.Graph
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
}
