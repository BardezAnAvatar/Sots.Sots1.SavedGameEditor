using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Graph
{
    public class Coordinate
    {
        protected Int32 x, y;

        public Int32 X
        {
            get { return x; }
            set { x = value; }
        }

        public Int32 Y
        {
            get { return y; }
            set { y = value; }
        }

        public Coordinate()
        {
            x = 0;
            y = 0;
        }

        public Coordinate(Int32 X, Int32 Y)
        {
            x = X;
            y = Y;
        }

        public static Double Distance(Coordinate A, Coordinate B)
        {
            Double distance = 0.0D;
            distance = Math.Sqrt(Math.Pow(Math.Abs(A.X - B.X), 2) + Math.Pow(Math.Abs(A.Y - B.Y), 2));
            
            return distance;
        }

        public Point ToPoint()
        {
            return new Point(this.x, this.y);
        }

        public static Vector_ish operator-(Coordinate A, Coordinate B)
        {
            return new Vector_ish(A, B);
        }
    }

    public class Vector_ish
    {
        protected Double angle, distance;

        #region Properties
        public Double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public Double Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        protected Coordinate start, end;

        public Coordinate Start
        {
            get { return start; }
            set { start = value; }
        }

        public Coordinate End
        {
            get { return end; }
            set { end = value; }
        } 
        #endregion

        public Vector_ish(Coordinate Start, Coordinate End)
        {
            this.start = Start;
            this.end = End;
            this.CalcThings();
        }

        protected void CalcThings()
        {
            //horizontal level
            if (this.start.X == this.end.X)
            {
                if (this.start.Y < this.end.Y)
                {
                    this.angle = 180.0;
                    this.distance = this.end.Y - this.start.Y;
                }
                else
                {
                    this.angle = 0.0;
                    this.distance = this.start.Y = this.end.Y;
                }
            }
            else if (this.start.Y == this.end.Y)
            {
                if (this.start.X < this.end.X)
                {
                    this.angle = 270.0;
                    this.distance = this.end.X - this.start.X;
                }
                else
                {
                    this.angle = 90.0;
                    this.distance = this.start.X - this.end.X;
                }
            }
            else
            {
                Double x, y;
                x = Math.Abs(this.start.X - this.end.X);
                y = Math.Abs(this.start.Y - this.end.Y);

                //soh cah toa
                this.angle = Math.Atan(y / x);
                this.distance = Math.Sqrt((x * x) + (y * y));
            }
        }
    }
}
