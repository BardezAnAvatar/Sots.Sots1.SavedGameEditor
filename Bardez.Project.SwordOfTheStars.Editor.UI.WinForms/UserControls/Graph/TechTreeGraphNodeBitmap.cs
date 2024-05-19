using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.ResourceManagement;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls;
using Bardez.Project.SwordOfTheStars.ResourceManagement;
using Paloma;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls.Graph
{
    public class TechTreeGraphNodeBitmap
    {
        protected static readonly Font renderFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        protected static readonly Int32 defaultWidth = 78;
        protected static readonly Int32 defaultHeight = 100;

        protected Bitmap buffer, techImage;
        protected String techName, drawName, techImagePath;
        protected Int32 width, height;
        protected SizeF techNameArea;
        protected Boolean isDirty;
        protected Int32 left, top;

        #region Properties
        public Bitmap Buffer
        {
            get
            {
                if (this.isDirty)
                    RenderBuffer();

                return this.buffer;
            }
            //set { this.buffer = value; }
        }

        public String TechName
        {
            get { return this.techName; }
            set { this.techName = value; }
        }

        public String DrawName
        {
            get { return this.drawName; }
            set
            {
                this.drawName = value;

                if (this.drawName.IndexOf("Communications") > -1 || this.drawName.IndexOf("MagnoCeramic") > -1 || this.drawName.IndexOf("Deconstruction") > -1)
                {
                    this.width = 100;
                    this.InstantiateBuffer();
                }

                this.CalculateTechNameArea();
                this.isDirty = true;
            }
        }

        public String TechImagePath
        {
            get { return this.techImagePath; }
            set
            {
                this.techImagePath = value;
                this.InstantiateTechImage(TechTreeManagement.LoadBitmap(this.techImagePath));
                this.isDirty = true;
            }
        }

        public Int32 Height
        {
            get { return height; }
            set
            {
                height = value;
                this.isDirty = true;
            }
        }

        public Int32 Width
        {
            get { return width; }
            set
            {
                width = value;
                this.isDirty = true;
            }
        }

        public Int32 Left
        {
            get { return left; }
            set { left = value; }
        }

        public Int32 Top
        {
            get { return top; }
            set { top = value; }
        }

        public Point Location
        {
            get { return new Point(this.left, this.top); }
            set
            {
                this.left = value.X;
                this.top = value.Y;
            }
        }
        #endregion

        #region Constructor(s)
        public TechTreeGraphNodeBitmap()
        {
            this.techName = null;
            this.drawName = "[Tech Name]";
            this.techImagePath = null;
            this.width = defaultWidth;
            this.height = defaultHeight;
            this.InstantiateBuffer();
            this.CalculateTechNameArea();
            this.techImage = new Bitmap(64, 64);
            this.isDirty = true;
            this.left = 0;
            this.top = 0;
        }

        public TechTreeGraphNodeBitmap(String Name)
            : this()
        {
            this.techName = Name;
        }

        public TechTreeGraphNodeBitmap(String Name, String Tech)
            : this(Name)
        {
            this.DrawName = Tech;
            this.CalculateTechNameArea();
        }

        public TechTreeGraphNodeBitmap(String Name, String Tech, String TechImagePath)
            : this(Name, Tech)
        {
            this.TechImagePath = TechImagePath;
        }

        public TechTreeGraphNodeBitmap(String Name, String Tech, Bitmap TechImage)
            : this(Name, Tech)
        {
            this.InstantiateTechImage(TechImage);
        }

        public TechTreeGraphNodeBitmap(AvailableTechnologyTreeNode Tech)
            : this(Tech.Name, Tech.Name)
        {
        }

        public TechTreeGraphNodeBitmap(AvailableTechnologyTreeNode Tech, String ImagePath)
            : this(Tech.Name, Tech.Name, ImagePath)
        {
        }

        public TechTreeGraphNodeBitmap(AvailableTechnologyTreeNode Tech, Bitmap TechImage)
            : this(Tech.Name, Tech.Name, TechImage)
        {
        }

        public TechTreeGraphNodeBitmap(JoinedTechnology Tech, Bitmap TechImage)
            : this(Tech.Name, Tech.FriendlyName, TechImage)
        {
        } 
        #endregion

        protected void CalculateTechNameArea()
        {
            if (this.buffer != null)
            {
                using (Graphics g = Graphics.FromImage(this.buffer))
                    this.techNameArea = g.MeasureString(this.drawName, renderFont, this.width);
            }
        }

        protected void InstantiateBuffer()
        {
            if(this.buffer != null)
                this.buffer.Dispose();

            this.buffer = new Bitmap(this.width, this.height);
        }

        protected void InstantiateTechImage(Bitmap NewVal)
        {
            if (this.techImage != null)
                this.techImage.Dispose();

            this.techImage = NewVal;
            this.isDirty = true;
        }

        public void RenderBuffer()
        {
            this.width = 12 + (this.techNameArea.Width > this.techImage.Width ? Convert.ToInt32(this.techNameArea.Width) + 1 : this.techImage.Width);
            this.height = 67 + Convert.ToInt32(this.techNameArea.Height);   //6 + 48 + 6 + Convert.ToInt32(this.techNameArea.Height) + 1 + 6;
            this.InstantiateBuffer();

            using (Graphics g = Graphics.FromImage(this.buffer))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                Int32 left;

                //background
                //using (Brush controlBackground = new SolidBrush(SystemColors.Control))
                //    g.FillRectangle(controlBackground, 0, 0, this.width, this.height);
                g.Clear(SystemColors.Control);

                //Image
                if(this.techImage != null)
                {
                    left = (this.width - 48) / 2;
                    g.DrawImage(this.techImage, left, 6, 48, 48);
                }

                //text
                left = (this.width - (Convert.ToInt32(this.techNameArea.Width) + 1)) / 2;
                RectangleF label = new RectangleF(new PointF(left, 60.0F), this.techNameArea);
                StringFormat format = new StringFormat();                
                format.LineAlignment = StringAlignment.Center;
                format.Alignment = StringAlignment.Center;

                g.DrawString(this.drawName, renderFont, Brushes.Black, label, format); //6+48+6

                //border
                g.DrawRectangle(Pens.Black, new Rectangle(0, 0, this.width - 1, this.height - 1));
            }

            this.isDirty = false;
        }
    }
}