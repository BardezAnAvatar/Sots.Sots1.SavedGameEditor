using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.Editor.Resource_Management
{
    public class JoinedTechnology
    {
        protected String description, family, friendlyName, group, imagePath, name;
        protected Int32 depth, groupNumber, position;
        protected List<AvailableTechnologyConnection> allows;
        protected List<String> requires;

        #region Properties
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Family
        {
            get { return family; }
            set { family = value; }
        }

        public String FriendlyName
        {
            get { return friendlyName; }
            set { friendlyName = value; }
        }

        public String Group
        {
            get { return group; }
            set { group = value; }
        }

        public String ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

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

        public Int32 GroupNumber
        {
            get { return groupNumber; }
            set { groupNumber = value; }
        }

        public Int32 Position
        {
            get { return position; }
            set { position = value; }
        }

        public List<AvailableTechnologyConnection> Allows
        {
            get { return allows; }
            set { allows = value; }
        }

        public List<String> Requires
        {
            get { return requires; }
            set { requires = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public JoinedTechnology()
        {
            description = null;
            family = null;
            friendlyName = null;
            group = null;
            imagePath = null;
            name = null;
            allows = new List<AvailableTechnologyConnection>();
            requires = new List<String>();
        }

        /// <summary>Full instantiation constructor</summary>
        public JoinedTechnology(String Name, String Family, String Group, Int32 GroupNumber, String FriendlyName, Int32 Depth, Int32 Position, String ImagePath, String Description, List<String> Requires, List<AvailableTechnologyConnection> Allows)
        {
            this.name = Name;
            this.family = Family;
            this.group = Group;
            this.groupNumber = GroupNumber;
            this.friendlyName = FriendlyName;
            this.depth = Depth;
            this.position = Position;
            this.imagePath = ImagePath;
            this.description = Description;
            this.requires = Requires;
            this.allows = Allows;
        }

        /// <summary>Default for Linq</summary>
        public static JoinedTechnology Default
        {
            get { return new JoinedTechnology(); }
        }
    }
}