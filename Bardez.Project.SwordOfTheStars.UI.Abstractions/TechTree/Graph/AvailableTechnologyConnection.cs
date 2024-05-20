using System;
using System.Collections.Generic;

namespace Bardez.Project.SwordOfTheStars.ResourceManagement
{
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
}
