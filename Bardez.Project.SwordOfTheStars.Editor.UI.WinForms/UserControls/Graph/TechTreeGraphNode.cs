using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Paloma;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.UserControl;
using Bardez.Project.SwordOfTheStars.ResourceManagement;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Graph
{
    public partial class TechTreeGraphNode : DisplayUserControl
    {
        protected String techName;
        protected Bitmap techImage;
        protected Point? mouseDown;


        public String TechName
        {
            get { return techName; }
            set { this.labelTechName.Text = techName = value; }
        }

        public Bitmap TechImage
        {
            get { return techImage; }
            set { this.pictureBoxTechImage.Image = techImage = value; }
        }

        public TechTreeGraphNode()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyles();
        }

        public TechTreeGraphNode(String Name) : this()
        {
            this.Name = Name;
        }

        public TechTreeGraphNode(String Name, String Tech) : this (Name)
        {
            this.TechName = Tech;
        }

        public TechTreeGraphNode(String Name, String Tech, String TechImagePath) : this(Name, Tech)
        {
            if (TechImagePath.EndsWith(".tga"))
            {
                //http://www.codeproject.com/KB/graphics/TargaImage.aspx
                this.TechImage = Paloma.TargaImage.LoadTargaImage(TechImagePath);
            }
            else
                this.TechImage = new Bitmap(TechImagePath);
        }
        
        public TechTreeGraphNode(AvailableTechnologyTreeNode Tech) : this(Tech.Name, Tech.Name)
        {
        }
        
        public TechTreeGraphNode(AvailableTechnologyTreeNode Tech, String ImagePath) : this(Tech.Name, Tech.Name, ImagePath)
        {
        }
        
        public TechTreeGraphNode(JoinedTechnology Tech, String ImagePath) : this(Tech.Name, Tech.FriendlyName, ImagePath)
        {
        }

        private void TechTreeGraphNode_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxTechImage_Click(object sender, EventArgs e)
        {

        }

        private void labelTechName_Click(object sender, EventArgs e)
        {

        }

        private void labelTechName_TextChanged(object sender, EventArgs e)
        {
            this.Width = labelTechName.Width + 6;
        }

        private void TechTreeGraphNode_SizeChanged(object sender, EventArgs e)
        {
            Point newCenter = this.pictureBoxTechImage.Location;
            newCenter.X = (((this.Width - 6) - this.pictureBoxTechImage.Width) / 2) + 2;
            this.pictureBoxTechImage.Location = newCenter;
        }

        private void labelTechName_MouseDown(object sender, MouseEventArgs e)
        {
            Point loc = e.Location;
            loc.X += this.labelTechName.Location.X;
            loc.Y += this.labelTechName.Location.Y;
            this.mouseDown = loc;
        }

        private void pictureBoxTechImage_MouseDown(object sender, MouseEventArgs e)
        {
            Point loc = e.Location;
            loc.X += this.pictureBoxTechImage.Location.X;
            loc.Y += this.pictureBoxTechImage.Location.Y;
            this.mouseDown = loc;
        }

        private void TechTreeGraphNode_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseDown = e.Location;
        }



        private void labelTechName_MouseUp(object sender, MouseEventArgs e)
        {
            this.LabelMove(e.Location);
            this.mouseDown = null;
        }

        private void pictureBoxTechImage_MouseUp(object sender, MouseEventArgs e)
        {
            this.PictureBoxMove(e.Location);
            this.mouseDown = null;
        }

        private void TechTreeGraphNode_MouseUp(object sender, MouseEventArgs e)
        {
            this.ControlMove(e.Location);
            this.mouseDown = null;
        }

        private void labelTechName_MouseMove(object sender, MouseEventArgs e)
        {
            this.LabelMove(e.Location);
        }

        private void pictureBoxTechImage_MouseMove(object sender, MouseEventArgs e)
        {
            this.PictureBoxMove(e.Location);
        }

        private void TechTreeGraphNode_MouseMove(object sender, MouseEventArgs e)
        {
            this.ControlMove(e.Location);
        }


        protected void LabelMove(Point NewLocation)
        {
            if (this.mouseDown != null)
            {
                Point newPoint = this.Location, loc = NewLocation;
                loc.X += this.labelTechName.Location.X;
                loc.Y += this.labelTechName.Location.Y;

                newPoint.X += (loc.X - this.mouseDown.Value.X);
                newPoint.Y += (loc.Y - this.mouseDown.Value.Y);
                this.Location = newPoint;

                this.OnReRenderEdges(new EventArgs());
            }
        }

        protected void PictureBoxMove(Point NewLocation)
        {
            if (this.mouseDown != null)
            {
                Point newPoint = this.Location, loc = NewLocation;
                loc.X += this.pictureBoxTechImage.Location.X;
                loc.Y += this.pictureBoxTechImage.Location.Y;

                newPoint.X += (loc.X - this.mouseDown.Value.X);
                newPoint.Y += (loc.Y - this.mouseDown.Value.Y);
                this.Location = newPoint;

                this.OnReRenderEdges(new EventArgs());
            }
        }

        protected void ControlMove(Point NewLocation)
        {
            if (this.mouseDown != null)
            {
                Point newPoint = this.Location;

                newPoint.X += (NewLocation.X - this.mouseDown.Value.X);
                newPoint.Y += (NewLocation.Y - this.mouseDown.Value.Y);
                this.Location = newPoint;

                this.OnReRenderEdges(new EventArgs());
            }
        }




        public delegate void RenderEdges(Object sender, EventArgs e);
        public event RenderEdges ReRenderEdges;
        protected void OnReRenderEdges(EventArgs e)
        {
            if (this.ReRenderEdges != null)
                this.ReRenderEdges(this, e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}