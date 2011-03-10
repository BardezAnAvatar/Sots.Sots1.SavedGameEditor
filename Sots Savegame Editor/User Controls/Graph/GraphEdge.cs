using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls.Graph
{
    public class GraphEdge
    {
        protected String nodeNameA;
        protected String nodeNameB;

        public String NodeNameA
        {
            get { return nodeNameA; }
            set { nodeNameA = value; }
        }

        public String NodeNameB
        {
            get { return nodeNameB; }
            set { nodeNameB = value; }
        }

        public GraphEdge()
        {
            nodeNameA = null;
            nodeNameB = null;
        }

        public GraphEdge(String A, String B)
            : this()
        {
            nodeNameA = A;
            nodeNameB = B;
        }
    }
}
