using System.Collections.Generic;

namespace Bardez.Project.SwordOfTheStars.UI.Abstractions.TechTree.Graph
{
    public interface ITechTreeGraph
    {
        void AttachNodes();

        void Balance();

        IList<TechTreeGraphNodeBitmap> Nodes { get; }

        IList<GraphEdge> Edges { get; }
    }
}