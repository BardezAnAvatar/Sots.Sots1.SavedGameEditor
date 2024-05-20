using System;

namespace Bardez.Project.SwordOfTheStars.ResourceManagement
{
    public class TechSprite
    {
        protected String tech;
        protected String zipArchivePath;

        public String Tech
        {
            get { return tech; }
            set { tech = value; }
        }

        public String ZipArchivePath
        {
            get { return zipArchivePath; }
            set { zipArchivePath = value; }
        }

        public TechSprite()
        {
            this.tech = null;
            this.zipArchivePath = null;
        }

        public TechSprite(String Name, String Path)
        {
            this.tech = Name;
            this.zipArchivePath = Path;
        }

        /// <summary>Default for Linq</summary>
        public static TechSprite Default
        {
            get
            {
                return new TechSprite();
            }
        }
    }
}