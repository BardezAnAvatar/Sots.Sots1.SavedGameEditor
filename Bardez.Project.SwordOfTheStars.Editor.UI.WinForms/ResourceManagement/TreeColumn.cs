using System;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.ResourceManagement
{
    public class TreeColumn
    {
        protected Int32 group, position;

        public Int32 Group
        {
            get { return group; }
            set { group = value; }
        }

        public Int32 Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>Default constructor</summary>
        public TreeColumn()
        {
        }

        /// <summary>Default constructor</summary>
        public TreeColumn(Int32 Column, Int32 StartPosition)
        {
            this.group = Column;
            this.position = StartPosition;
        }
    }
}