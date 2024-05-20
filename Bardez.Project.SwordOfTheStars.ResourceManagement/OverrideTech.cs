using System;

namespace Bardez.Project.SwordOfTheStars.ResourceManagement
{
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