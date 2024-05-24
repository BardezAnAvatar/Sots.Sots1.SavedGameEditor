using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;
using Bardez.Project.SwordOfTheStars.UI.Abstractions.TechTree.Graph;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Graph
{
    public partial class Graph : DisplayUserControl, ITechTreeGraph
    {
        protected IList<TechTreeGraphNodeBitmap> nodes;
        protected IList<GraphEdge> edges;
        protected Bitmap buffer;
        protected BufferedGraphics bufferedGraphics;
        protected BufferedGraphicsContext bufferedGraphicsContext;
        protected static Int32 margin = 30;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<TechTreeGraphNodeBitmap> Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IList<GraphEdge> Edges
        {
            get { return edges; }
            set { edges = value; }
        }

        /// <summary>Default constructor</summary>
        public Graph()
        {
            this.nodes = new List<TechTreeGraphNodeBitmap>();
            this.edges = new List<GraphEdge>();
            this.DoubleBuffered = true;
            InitializeComponent();
            this.SetStyles();
        }

        /// <summary>Destructor</summary>
        ~Graph()
        {
            //buffer
            buffer.Dispose();

            //controls
            for (Int32 i = 0; i < this.Controls.Count; ++i)
            {
                this.Controls[i].Dispose();
            }
        }

        public Boolean RearrangeOverlap()
        {
            //Try to avoid overlap
            Boolean moved = false;

            for (Int32 i = 0; i < nodes.Count; i++)
            {
                for (Int32 j = 0; j < nodes.Count; j++)
                {
                    if (i == j)
                        continue;

                    //x/y-collision
                    if (
                        //top left
                        (
                            (nodes[j].Left < (nodes[i].Left + Nodes[i].Width) && nodes[j].Left > nodes[i].Left)
                            && (nodes[j].Top < (nodes[i].Top + Nodes[i].Height) && nodes[j].Top > nodes[i].Top)
                        )
                        ||
                        //top right
                        (
                            ((nodes[j].Left + nodes[j].Width) < (nodes[i].Left + Nodes[i].Width) && (nodes[j].Left + nodes[j].Width) > nodes[i].Left)
                            && (nodes[j].Top < (nodes[i].Top + Nodes[i].Height) && nodes[j].Top > nodes[i].Top)
                        )
                      )
                    {
                        moved = true;
                        nodes[j].Left = nodes[i].Left + Nodes[i].Width + 10;
                        nodes[j].Top = nodes[i].Top + Nodes[i].Height + 10;
                    }
                }
            }

            return moved;
        }

        public void Balance()
        {
            while (RearrangeOverlap())
            {
            }
        }

        public void Scatter()
        {
            Random rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));
            for (Int32 index = 0; index < nodes.Count; index++)
            {
                nodes[index].Left = rand.Next(0, (this.Width - nodes[index].Width) - 1);
                nodes[index].Top = rand.Next(0, (this.Height - nodes[index].Height) - 1);
            }
        }

        public Double Distance(TechTreeGraphNodeBitmap A, TechTreeGraphNodeBitmap B)
        {
            return Coordinate.Distance(Center(A), Center(B));
        }

        public Coordinate Center(TechTreeGraphNodeBitmap Target)
        {
            return new Coordinate(Target.Left + (Target.Width / 2) + margin, Target.Top + (Target.Height / 2) + margin);
        }

        public Coordinate Edge(TechTreeGraphNodeBitmap Source, TechTreeGraphNodeBitmap Target)
        {
            Coordinate s = Center(Source), t = Center(Target), ret = new Coordinate();
            Double techSlope = 0.0, lineSlope = 0.0;
            try
            {
                techSlope = Convert.ToDouble(Source.Width) / Convert.ToDouble(Source.Height);
                lineSlope = Convert.ToDouble(s.X - t.X) / Convert.ToDouble(s.Y - t.Y);
            }
            catch { }    //should be handled by the equal axis statements below
            Int32 delta = 0;

            if (s.X == t.X)
            {
                if (s.Y > t.Y)
                    ret = new Coordinate(s.X, s.Y - (Source.Height / 2));
                else
                    ret = new Coordinate(s.X, s.Y + (Source.Height / 2));
            }
            else if (s.Y == t.Y)
            {
                if (s.X > t.X)
                    ret = new Coordinate(s.X - (Source.Width / 2), s.Y);
                else
                    ret = new Coordinate(s.X + (Source.Width / 2), s.Y);
            }
            else if (Math.Abs(lineSlope) > Math.Abs(techSlope))
            {
                delta = Convert.ToInt32((Source.Width / 2) / Math.Abs(lineSlope));
                if (s.X > t.X)
                {
                    if (s.Y > t.Y)
                        ret = new Coordinate(s.X - (Source.Width / 2), s.Y - delta);
                    else
                        ret = new Coordinate(s.X - (Source.Width / 2), s.Y + delta);
                }
                else
                {
                    if (s.Y > t.Y)
                        ret = new Coordinate(s.X + (Source.Width / 2), s.Y - delta);
                    else
                        ret = new Coordinate(s.X + (Source.Width / 2), s.Y + delta);
                }
            }
            //if (Math.Abs(lineSlope) < Math.Abs(techSlope))
            else
            {
                delta = Convert.ToInt32((Source.Height / 2) * Math.Abs(lineSlope));
                if (s.Y > t.Y)
                {
                    if (s.X > t.X)
                        ret = new Coordinate(s.X - delta, s.Y - (Source.Height / 2));
                    else
                        ret = new Coordinate(s.X + delta, s.Y - (Source.Height / 2));
                }
                else
                {
                    if (s.X > t.X)
                        ret = new Coordinate(s.X - delta, s.Y + (Source.Height / 2));
                    else
                        ret = new Coordinate(s.X + delta, s.Y + (Source.Height / 2));
                }
            }

            return ret;
        }

        public Coordinate AbsoluteCoordinate(Coordinate RelativeInput)
        {
            RelativeInput.X -= this.DisplayRectangle.X;
            RelativeInput.Y -= this.DisplayRectangle.Y;

            return RelativeInput;
        }

        public void AttachNodes()
        {
            Int32 maxWidth = 0, maxHeight = 0;
            for (Int32 i = 0; i < this.nodes.Count; ++i)
            {
                nodes[i].RenderBuffer();

                if (nodes[i].Top + nodes[i].Height > maxHeight)
                    maxHeight = nodes[i].Top + nodes[i].Height;

                if (nodes[i].Left + nodes[i].Width > maxHeight)
                    maxWidth = nodes[i].Left + nodes[i].Width;
            }

            this.AutoScrollMinSize = new Size(maxWidth + (margin * 2), maxHeight + (margin * 2));
            this.GenerateBuffer();
            this.Invalidate();
        }

        public void ClearNodes()
        {
            this.Controls.Clear();
            this.Nodes.Clear();

            this.AutoScrollMinSize = new Size(this.Width, this.Height);
        }

        public void ClearEdges()
        {
            this.edges.Clear();
            this.ClearBackground();
        }

        protected void ClearBackground()
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.Clear(this.BackColor);
            }
        }

        public void RenderEdges()
        {
            using (Graphics g = this.CreateGraphics())
            {
                RenderEdges(g);
            }
        }

        public void RenderEdges(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Random rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            foreach (GraphEdge edge in edges)
            {
                Coordinate CenterA, CenterB, EdgeA, EdgeB;

                //Get coordinate centers
                CenterA = Center(GetNode(edge.NodeNameA));
                CenterB = Center(GetNode(edge.NodeNameB));
                EdgeA = Edge(GetNode(edge.NodeNameA), GetNode(edge.NodeNameB));
                EdgeB = Edge(GetNode(edge.NodeNameB), GetNode(edge.NodeNameA));

                using (Brush brush = new SolidBrush(Color.FromArgb(rand.Next(0, Byte.MaxValue), rand.Next(0, 192), rand.Next(0, Byte.MaxValue))))
                {
                    using (Pen pen = new Pen(brush, 2.5F))
                    {
                        pen.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
                        //pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                        pen.EndCap = System.Drawing.Drawing2D.LineCap.Custom;
                        pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);

                        //Draw
                        g.DrawPath(pen, new System.Drawing.Drawing2D.GraphicsPath(new Point[] { EdgeA.ToPoint(), EdgeB.ToPoint() }, new Byte[] { (Byte)System.Drawing.Drawing2D.PathPointType.Line, (Byte)System.Drawing.Drawing2D.PathPointType.Line }));
                    }
                }
            }
        }

        public TechTreeGraphNodeBitmap GetNode(String Name)
        {
            TechTreeGraphNodeBitmap node = null;
            foreach (TechTreeGraphNodeBitmap n in nodes)
            {
                if (n.TechName == Name)
                {
                    node = n;
                    break;
                }
            }

            return node;
        }

        public Boolean ContainsNodeName(String Name)
        {
            Boolean found = false;
            foreach (TechTreeGraphNodeBitmap n in nodes)
            {
                if (n.TechName == Name)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public Boolean ContainsNodeNameCaseless(String Name)
        {
            Boolean found = false;
            foreach (TechTreeGraphNodeBitmap n in nodes)
            {
                if (n.TechName.ToLower() == Name.ToLower())
                {
                    found = true;
                    break;
                }
            }

            return found;
        }



        /********************************************************
        *   roughly a billion thank yous to the following URL:  *
        *   http://www.bobpowell.net/creategraphics.htm         *
        ********************************************************/
        public void HandleReRenderEdges(Object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public void HandleReRenderEdges(Object sender, PaintEventArgs e)
        {
            this.ClearBackground();
            //this.RenderEdges(e.Graphics);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            this.Invalidate(this.ClientRectangle, false);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (this.VScroll && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                this.VScroll = false;
                base.OnMouseWheel(e);
                this.VScroll = true;
            }
            else
            {
                base.OnMouseWheel(e);
            }
            this.Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.GenerateBuffer();
            this.RedrawBuffer();

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if (this.buffer == null)
                this.GenerateBuffer();

            //double buffer
            e.Graphics.DrawImageUnscaled(this.buffer, this.DisplayRectangle);
            //e.Graphics.DrawImageUnscaledAndClipped(this.buffer, this.DisplayRectangle);
            //e.Graphics.DrawImage(this.buffer, this.ClientRectangle, new Rectangle(this.ClientRectangle.X - this.DisplayRectangle.X, this.ClientRectangle.Y - this.DisplayRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height), GraphicsUnit.Pixel);
            this.HandleReRenderEdges(this, e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }

        protected void RedrawBuffer()
        {
            using (Graphics g = Graphics.FromImage(this.buffer))
            {
                g.Clear(SystemColors.Control);

                //draw edges
                this.RenderEdges(g);

                //draw controls
                for (Int32 i = 0; i < this.nodes.Count; ++i)
                {
                    g.DrawImageUnscaled(this.nodes[i].Buffer, this.nodes[i].Left + margin, this.nodes[i].Top + margin);
                    //Control temp = this.Controls[i];
                    //temp.DrawToBitmap(buffer, new Rectangle(temp.Location, temp.Size));
                }
            }
        }

        public void GenerateBuffer()
        {
            if (this.buffer != null)
                this.buffer.Dispose();

            var width = this.DisplayRectangle.Width > 0 ? this.DisplayRectangle.Width : 1;
            var height = this.DisplayRectangle.Height > 0 ? this.DisplayRectangle.Height : 1;

            this.buffer = new Bitmap(width, height);
            this.RedrawBuffer();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            String techClicked = null;
            Point clickPosition = e.Location;
            clickPosition.Offset(-this.DisplayRectangle.Left, -this.DisplayRectangle.Top);

            //offset the margin
            clickPosition.X -= margin;
            clickPosition.Y -= margin;

            //determine if the click is inside any nodes
            foreach (TechTreeGraphNodeBitmap tech in this.nodes)
            {
                if (PointInsideOrOnRectangle(clickPosition, new Rectangle(tech.Left, tech.Top, tech.Width, tech.Height)))
                {
                    techClicked = tech.TechName;
                    break;
                }
            }

            //if it is, raise a control click event, specifying the technology clicked upon
            if (techClicked != null)
                this.OnClickTech(techClicked);
        }

        protected static Boolean PointInsideRectangle(Point P, Rectangle Area)
        {
            return P.X > Area.X && P.X < (Area.X + Area.Width) && P.Y > Area.Y && P.Y < (Area.Y + Area.Height);
        }

        protected static Boolean PointInsideOrOnRectangle(Point P, Rectangle Area)
        {
            return P.X >= Area.X && P.X <= (Area.X + Area.Width) && P.Y >= Area.Y && P.Y <= (Area.Y + Area.Height);
        }


        public delegate void ClickTech(Object sender, ClickedTechEventArgs e);
        public event ClickTech ClickedTech;
        protected void OnClickTech(String TechnologyName)
        {
            if (this.ClickedTech != null)
                this.ClickedTech(this, new ClickedTechEventArgs(TechnologyName));
        }
    }

    public class ClickedTechEventArgs : EventArgs
    {
        protected String techName;

        public String TechName
        {
            get { return techName; }
            set { techName = value; }
        }

        public ClickedTechEventArgs()
            : base()
        {
            this.techName = null;
        }

        public ClickedTechEventArgs(String TechName)
            : base()
        {
            this.techName = TechName;
        }
    }
}