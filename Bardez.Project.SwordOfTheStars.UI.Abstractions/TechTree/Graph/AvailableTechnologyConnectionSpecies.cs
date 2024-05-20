using System;

namespace Bardez.Project.SwordOfTheStars.UI.Abstractions.TechTree.Graph
{
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
