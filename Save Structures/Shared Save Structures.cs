using System;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    /// <summary>Spatial coordinates in the simulation</summary>
    /// <remarks>
    ///     It could be any particular arrangement of x/y/z, but I would estimate that it is x/y/z just due
    ///     to human nature in ordering these things. Plus it is (...probably...) irrelevant when the
    ///     spatial system is virtual anyway.
    /// </remarks>
    public class SpatialCoordinateSaveStruct : ComplexSaveStruct
    {
        /// <summary>Probably the X coordinate</summary>
        protected FloatSaveStruct x;

        /// <summary>Probably the Y coordinate</summary>
        protected FloatSaveStruct y;

        /// <summary>Probably the Z coordinate</summary>
        protected FloatSaveStruct z;

        public FloatSaveStruct X
        {
            get { return x; }
            set { x = value; }
        }

        public FloatSaveStruct Y
        {
            get { return y; }
            set { y = value; }
        }

        public FloatSaveStruct Z
        {
            get { return z; }
            set { z = value; }
        }

        /// <summary>Default constructor</summary>
        public SpatialCoordinateSaveStruct() : base()
        {
            this.x = new FloatSaveStruct();
            this.y = new FloatSaveStruct();
            this.z = new FloatSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.x.ReadFromStream(Data);
            this.y.ReadFromStream(Data);
            this.z.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.x.WriteToStream(Destination);
            this.y.WriteToStream(Destination);
            this.z.WriteToStream(Destination);
        }
    }

    public class RgbaColorFloat : ISotsStructure
    {
        protected RgbColorFloat rgb;
        protected FloatSaveStruct a;

        public RgbColorFloat Rgb
        {
            get { return rgb; }
            set { rgb = value; }
        }

        public FloatSaveStruct A
        {
            get { return a; }
            set { a = value; }
        }

        /// <summary>Default constructor</summary>
        public RgbaColorFloat()
        {
            this.rgb = new RgbColorFloat();
            this.a = new FloatSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.rgb.ReadFromStream(Data);
            this.a.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.rgb.WriteToStream(Destination);
            this.a.WriteToStream(Destination);
        }
    }

    public class RgbColorFloat : ISotsStructure
    {
        protected FloatSaveStruct r;
        protected FloatSaveStruct g;
        protected FloatSaveStruct b;

        public FloatSaveStruct R
        {
            get { return r; }
            set { r = value; }
        }

        public FloatSaveStruct G
        {
            get { return g; }
            set { g = value; }
        }

        public FloatSaveStruct B
        {
            get { return b; }
            set { b = value; }
        }

        /// <summary>Default constructor</summary>
        public RgbColorFloat()
        {
            this.r = new FloatSaveStruct();
            this.g = new FloatSaveStruct();
            this.b = new FloatSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.r.ReadFromStream(Data);
            this.g.ReadFromStream(Data);
            this.b.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.r.WriteToStream(Destination);
            this.g.WriteToStream(Destination);
            this.b.WriteToStream(Destination);
        }
    }

    public class RgbColorInt32 : ISotsStructure
    {
        protected Int32SaveStruct r;
        protected Int32SaveStruct g;
        protected Int32SaveStruct b;

        public Int32SaveStruct R
        {
            get { return r; }
            set { r = value; }
        }

        public Int32SaveStruct G
        {
            get { return g; }
            set { g = value; }
        }

        public Int32SaveStruct B
        {
            get { return b; }
            set { b = value; }
        }

        /// <summary>Default constructor</summary>
        public RgbColorInt32()
        {
            this.r = new Int32SaveStruct();
            this.g = new Int32SaveStruct();
            this.b = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.r.ReadFromStream(Data);
            this.g.ReadFromStream(Data);
            this.b.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.r.WriteToStream(Destination);
            this.g.WriteToStream(Destination);
            this.b.WriteToStream(Destination);
        }
    }
}