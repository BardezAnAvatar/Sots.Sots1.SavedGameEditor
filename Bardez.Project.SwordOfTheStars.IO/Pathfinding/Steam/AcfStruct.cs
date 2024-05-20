using System;
using System.Collections.Generic;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.IO.Pathfinding.Steam
{
    /// <summary>Structure of Valve's ACF files</summary>
    /// <remarks>Sourced from: https://stackoverflow.com/a/42876399/1375931</remarks>
    public class AcfStruct
    {
        public Dictionary<string, AcfStruct> SubACF { get; private set; }

        public Dictionary<string, string> SubItems { get; private set; }

        public AcfStruct()
        {
            SubACF = new Dictionary<string, AcfStruct>();
            SubItems = new Dictionary<string, string>();
        }

        public void WriteToFile(string File)
        {
        }

        public override string ToString()
        {
            return ToString(0);
        }

        private string ToString(int Depth)
        {
            StringBuilder SB = new StringBuilder();
            foreach (KeyValuePair<string, string> item in SubItems)
            {
                SB.Append('\t', Depth);
                SB.AppendFormat("\"{0}\"\t\t\"{1}\"\r\n", item.Key, item.Value);
            }

            foreach (KeyValuePair<string, AcfStruct> item in SubACF)
            {
                SB.Append('\t', Depth);
                SB.AppendFormat("\"{0}\"\n", item.Key);
                SB.Append('\t', Depth);
                SB.AppendLine("{");
                SB.Append(item.Value.ToString(Depth + 1));
                SB.Append('\t', Depth);
                SB.AppendLine("}");
            }

            return SB.ToString();
        }
    }
}
