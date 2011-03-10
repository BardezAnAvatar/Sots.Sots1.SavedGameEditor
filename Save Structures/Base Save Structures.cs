using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    #region Basic Save Structures
    /// <summary>This class represents a serialized string in the save game file.</summary>
    /// <remarks>
    ///     It appears that every string is preceeded by a 32-bit integer indicating the length
    ///     of the string, followed by that many bytes representing that string.
    /// </remarks>
    public class StringStruct : ISotsStructure
    {
        /// <summary>32-bit integer indicating the length of the string.</summary>
        private Int32 length;

        /// <summary>Array of characters in the serialized string.</summary>
        private Char[] characters;

        /// <summary>32-bit integer indicating the length of the string.</summary>
        public Int32 Length
        {
            get { return length; }
            set { length = value; }
        }

        /// <summary>Exposes the serialized string as a String object.</summary>
        public String CharacterString
        {
            get { return new String(characters); }
            set { characters = value.ToCharArray(); }
        }

        /// <summary>Exposes the serialized string as a character array.</summary>
        public Char[] CharacterArray
        {
            get { return characters; }
            set { characters = value; }
        }

        /// <summary>Default constructor</summary>
        public StringStruct()
        {
            this.characters = null;
            this.length = -1;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            //stream length check
            if (Data.Length - Data.Position < sizeof(Int32))
                throw new Exception("Not enough data in stream.");

            Byte[] buffer = new Byte[sizeof(Int32)];
            Data.Read(buffer, 0, sizeof(Int32));
            this.length = BitConverter.ToInt32(buffer, 0);

            if (this.length < 0)
                throw new Exception("Expected string length too short.");
            else if (this.length > 512)
                throw new Exception("Expected string length (probably) too long. Sanity threshold of 255.");
            else
            {
                //stream length check
                if (Data.Length - Data.Position < this.length)
                    throw new Exception("Not enough data in stream.");

                //read the string
                buffer = new Byte[this.length];
                Data.Read(buffer, 0, this.length);

                //this.characters = Encoding.ASCII.GetChars(buffer);
                Encoding enc = Encoding.GetEncoding(1252);  //ANSI
                this.characters = enc.GetChars(buffer);

                //do not discard trailing 0s; that is on the basic save structure level.
            }
        }

        /// <summary>Writes the string and length to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            Byte[] buffer;

            buffer = BitConverter.GetBytes(this.length);
            Destination.Write(buffer, 0, buffer.Length);
            //buffer = Encoding.ASCII.GetBytes(this.characters);
            Encoding enc = Encoding.GetEncoding(1252);  //ANSI
            buffer = enc.GetBytes(this.characters);
            Destination.Write(buffer, 0, buffer.Length);
        }

        public override string ToString()
        {
            return this.CharacterString;
        }
    }

    /// <summary>Basic save file structure.</summary>
    /// <remarks>All .sav structs seem to have a string description, even if a non-descriptive period(".").</remarks>
    public abstract class BasicSaveStruct : ISotsStructure
    {
        /// <summary>Int32 describing the width to which data structures are padded.</summary>
        protected const Int32 PaddingSize = 4;

        /// <summary>String description of the value to come.</summary>
        /// <remarks>If non-descriptive, often "."</remarks>
        protected StringStruct description;

        /// <summary>String description of the value to come.</summary>
        public StringStruct Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>Default constructor</summary>
        public BasicSaveStruct()
        {
            this.description = new StringStruct();
            this.description.CharacterString = "."; //default value
        }

        /// <summary>Populates the data structure description from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public virtual void ReadFromStream(Stream Data)
        {
            description.ReadFromStream(Data);
        }

        /// <summary>Writes the description string and length to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public virtual void WriteToStream(Stream Destination)
        {
            description.WriteToStream(Destination);
        }

        public override string ToString()
        {
            return this.description.CharacterString;
        }
    }

    /// <summary>Save game structure containing a 32-bit integer.</summary>
    public class Int32SaveStruct : BasicSaveStruct
    {
        /// <summary>Int32 value stored in the structure</summary>
        protected Int32 value;

        /// <summary>Int32 value stored in the structure</summary>
        public Int32 Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>Default constructor</summary>
        public Int32SaveStruct() : base()
        {
            this.value = -1;
        }

        /// <summary>Populates the data structure description from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            base.ReadFromStream(Data);

            if (Data.Length - Data.Position < sizeof(Int32))
                throw new Exception("Not enough data in stream.");

            Int32 readLength = sizeof(Int32), structureLength = sizeof(Int32) + description.Length + readLength;
            //consume padding NULs
            if (structureLength % PaddingSize > 0)
                readLength += (PaddingSize - (structureLength % PaddingSize));

            Byte[] buffer = new Byte[readLength];
            Data.Read(buffer, 0, readLength);
            this.value = BitConverter.ToInt32(buffer, 0);
        }

        /// <summary>Writes the description string, its length and the Int32 value to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            base.WriteToStream(Destination);
            Byte[] buffer = BitConverter.GetBytes(this.value);
            Destination.Write(buffer, 0, buffer.Length);

            //write padding NULs
            Int32 structureLength = sizeof(Int32) + description.Length + sizeof(Int32);
            if (structureLength % PaddingSize > 0)
            {
                buffer = new Byte[(PaddingSize - (structureLength % PaddingSize))];
                //Array.Clear(buffer);    //unnecessary, but what the hell?
                Destination.Write(buffer, 0, buffer.Length);
            }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }

    /// <summary>Save game structure containing a 64-bit integer.</summary>
    public class Int64SaveStruct : BasicSaveStruct
    {
        /// <summary>Int64 value stored in the structure</summary>
        protected Int64 value;

        /// <summary>Int64 value stored in the structure</summary>
        public Int64 Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>Default constructor</summary>
        public Int64SaveStruct() : base()
        {
            this.value = -1L;
        }

        /// <summary>Populates the data structure description from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            base.ReadFromStream(Data);

            if (Data.Length - Data.Position < sizeof(Int64))
                throw new Exception("Not enough data in stream.");

            Int32 readLength = sizeof(Int64), structureLength = sizeof(Int32) + description.Length + readLength;
            //consume padding NULs
            if (structureLength % PaddingSize > 0)
                readLength += (PaddingSize - (structureLength % PaddingSize));

            Byte[] buffer = new Byte[readLength];
            Data.Read(buffer, 0, readLength);
            this.value = BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>Writes the description string, its length and the Int64 value to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            base.WriteToStream(Destination);
            Byte[] buffer = BitConverter.GetBytes(this.value);
            Destination.Write(buffer, 0, buffer.Length);

            //write padding NULs
            Int32 structureLength = sizeof(Int32) + description.Length + sizeof(Int64);
            if (structureLength % PaddingSize > 0)
            {
                buffer = new Byte[(PaddingSize - (structureLength % PaddingSize))];
                //Array.Clear(buffer);    //unnecessary, but what the hell?
                Destination.Write(buffer, 0, buffer.Length);
            }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }

    /// <summary>Save game structure containing a 32-bit floating point single precision nubmer.</summary>
    public class FloatSaveStruct : BasicSaveStruct
    {
        /// <summary>Int32 floating point value stored in the structure</summary>
        protected Single value;

        /// <summary>Int32 floating point value stored in the structure</summary>
        public Single Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>Default constructor</summary>
        public FloatSaveStruct() : base()
        {
            this.value = 0.0F;
        }

        /// <summary>Populates the data structure description from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            base.ReadFromStream(Data);

            if (Data.Length - Data.Position < sizeof(Single))
                throw new Exception("Not enough data in stream.");

            Int32 readLength = sizeof(Single), structureLength = sizeof(Int32) + description.Length + readLength;
            //consume padding NULs
            if (structureLength % PaddingSize > 0)
                readLength += (PaddingSize - (structureLength % PaddingSize));

            Byte[] buffer = new Byte[readLength];
            Data.Read(buffer, 0, readLength);
            this.value = BitConverter.ToSingle(buffer, 0);
        }

        /// <summary>Writes the description string, its length and the single precision floating point value to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            base.WriteToStream(Destination);
            Byte[] buffer = BitConverter.GetBytes(this.value);
            Destination.Write(buffer, 0, buffer.Length);

            //write padding NULs
            Int32 structureLength = sizeof(Int32) + description.Length + sizeof(Single);
            if (structureLength % PaddingSize > 0)
            {
                buffer = new Byte[(PaddingSize - (structureLength % PaddingSize))];
                //Array.Clear(buffer);    //unnecessary, but what the hell?
                Destination.Write(buffer, 0, buffer.Length);
            }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }

    /// <summary>Save game structure containing a Boolean variable.</summary>
    public class BooleanSaveStruct : BasicSaveStruct
    {
        /// <summary>Boolean value stored in the structure, taking up a byte</summary>
        /// <value>0 = False; 1 = true;</value>
        protected Byte value;

        /// <summary>Boolean value stored in the structure, taking up a byte</summary>
        /// <value>0 = False' 1 = true;</value>
        public Byte ByteValue
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>Boolean value stored in the structure, taking up a byte</summary>
        public Boolean BooleanValue
        {
            get { return Convert.ToBoolean(this.value); }
            set { this.value = Convert.ToByte(value); }
        }

        public BooleanSaveStruct() : base()
        {
            this.value = 0;
        }

        /// <summary>Populates the data structure description from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            base.ReadFromStream(Data);

            if (Data.Length - Data.Position < sizeof(Boolean))
                throw new Exception("Not enough data in stream.");

            Int32 readLength = sizeof(Boolean), structureLength = sizeof(Int32) + description.Length + readLength;
            //consume padding NULs
            if (structureLength % PaddingSize > 0)
                readLength += (PaddingSize - (structureLength % PaddingSize));

            Byte[] buffer = new Byte[readLength];
            Data.Read(buffer, 0, readLength);
            this.value = buffer[0];
        }

        /// <summary>Writes the description string, its length and the Byte value to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            base.WriteToStream(Destination);
            //Byte[] buffer = BitConverter.GetBytes(this.value);
            Byte[] buffer = new Byte[] { this.value };
            Destination.Write(buffer, 0, buffer.Length);

            //write padding NULs
            Int32 structureLength = sizeof(Int32) + description.Length + sizeof(Boolean);
            if (structureLength % PaddingSize > 0)
            {
                buffer = new Byte[(PaddingSize - (structureLength % PaddingSize))];
                //Array.Clear(buffer);    //unnecessary, but what the hell?
                Destination.Write(buffer, 0, buffer.Length);
            }
        }

        public override string ToString()
        {
            return this.BooleanValue.ToString();
        }
    }

    /// <summary>Save game structure containing a String variable.</summary>
    public class StringSaveStruct : BasicSaveStruct
    {
        /// <summary>String variable</summary>
        protected StringStruct value;

        /// <summary>String variable</summary>
        public StringStruct Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>Default constructor</summary>
        public StringSaveStruct() : base()
        {
            this.value = new StringStruct();
        }

        /// <summary>Populates the data structure description from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            base.ReadFromStream(Data);
            this.value.ReadFromStream(Data);

            //consume padding NULs
            Int32 structureLength = sizeof(Int32) + this.description.Length + sizeof(Int32) + this.value.Length;
            if (structureLength % PaddingSize > 0)
                Data.Position += (PaddingSize - (structureLength % PaddingSize));
        }

        /// <summary>Writes the description string, its length and the value string and its length to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            base.WriteToStream(Destination);
            this.value.WriteToStream(Destination);

            //write padding NULs
            Int32 structureLength = sizeof(Int32) + this.description.Length + sizeof(Int32) + this.value.Length;
            if (structureLength % PaddingSize > 0)
            {
                Byte[] buffer = new Byte[(PaddingSize - (structureLength % PaddingSize))];
                //Array.Clear(buffer);    //unnecessary, but what the hell?
                Destination.Write(buffer, 0, buffer.Length);
            }
        }

        public override string ToString()
        {
            return this.value.CharacterString;
        }
    }

    /// <summary>Save game structure containing a Byte array.</summary>
    public class ByteArraySaveStruct : BasicSaveStruct
    {
        /// <summary>String variable</summary>
        protected Byte[] value;

        /// <summary>Length of the array</summary>
        private Int32 length;

        /// <summary>String variable</summary>
        public Byte[] Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>Length of the array</summary>
        public Int32 Length
        {
            get { return length; }
            set { length = value; }
        }

        /// <summary>Default constructor</summary>
        public ByteArraySaveStruct() : base()
        {
            this.value = null;
            this.length = -1;
        }

        /// <summary>Populates the data structure description from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            base.ReadFromStream(Data);

            this.value = new Byte[length];
            Data.Read(this.value, 0, this.value.Length);

            //consume padding NULs
            Int32 structureLength = sizeof(Int32) + this.description.Length + this.value.Length;
            if (structureLength % PaddingSize > 0)
                Data.Position += (PaddingSize - (structureLength % PaddingSize));
        }

        /// <summary>Writes the description string, its length and the Byte array to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            base.WriteToStream(Destination);
            Destination.Write(this.value, 0, this.value.Length);

            //write padding NULs
            Int32 structureLength = sizeof(Int32) + this.description.Length + this.value.Length;
            if (structureLength % PaddingSize > 0)
            {
                Byte[] buffer = new Byte[(PaddingSize - (structureLength % PaddingSize))];
                //Array.Clear(buffer);    //unnecessary, but what the hell?
                Destination.Write(buffer, 0, buffer.Length);
            }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
    #endregion

    #region Complex abstract structures
    /// <summary>Complex save file structure.</summary>
    /// <remarks>
    ///     All .sav structs seem to have a string description that is NUL-padded to 4 bytes, even if a non-descriptive period.
    ///     All complex .sav structures also seem to have a common binary (U)Int32 beginning indicator (represented in hexadecimal
    ///     as 0xBEEFBEEF) and end indicator (a bitwise NOT applied to the beginning indicator).
    /// </remarks>
    public abstract class ComplexSaveStruct : BasicSaveStruct, ISotsStructure
    {
        protected const UInt32 StructureMarker = 0xBEEFBEEFU;

        /// <summary>Default constructor</summary>
        public ComplexSaveStruct() : base()
        {
        }

        /// <summary>Populates the data structure description from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            base.ReadFromStream(Data);
            this.ReadDescriptionNullPadding(Data);
            this.ConsumeStructureMarkerBegin(Data);
            this.ReadBodyFromStream(Data);
            this.ConsumeStructureMarkerEnd(Data);
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected abstract void ReadBodyFromStream(Stream Data);

        /// <summary>Writes the description string and structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            base.WriteToStream(Destination);
            this.WriteDescriptionNullPadding(Destination);
            this.WriteStructureMarkerBegin(Destination);
            this.WriteBodyToStream(Destination);
            this.WriteStructureMarkerEnd(Destination);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected abstract void WriteBodyToStream(Stream Destination);

        /// <summary>Reads the next four bytes in the stream and checks that they match the StructureMarker value</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected void ConsumeStructureMarkerBegin(Stream Data)
        {
            UInt32 valueRead = ReadUInt32(Data);

            if (valueRead != StructureMarker)
                throw new Exception(String.Format("Expected structure onset marker {0} but found {1} instead.", StructureMarker, valueRead));
        }

        /// <summary>Reads the next four bytes in the stream and checks that they match the StructureMarker value</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected void ConsumeStructureMarkerEnd(Stream Data)
        {
            UInt32 valueRead = ReadUInt32(Data);

            if (valueRead != ~StructureMarker)
                throw new Exception(String.Format("Expected structure termination marker {0} but found {1} instead.", ~StructureMarker, valueRead));
        }

        /// <summary>Writes the StructureMarker value to the next four bytes in the stream</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected void WriteStructureMarkerBegin(Stream Destination)
        {
            Byte[] buffer = BitConverter.GetBytes(StructureMarker);
            Destination.Write(buffer, 0, buffer.Length);
        }

        /// <summary>Writes the bitwise NOT of the StructureMarker value to the next four bytes in the stream</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected void WriteStructureMarkerEnd(Stream Destination)
        {
            Byte[] buffer = BitConverter.GetBytes(~StructureMarker);
            Destination.Write(buffer, 0, buffer.Length);
        }

        /// <summary>Reads the next four bytes in the stream and returns then as a UInt32 data type</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        /// <returns>A UInt32 typed representation of the next four bytes in the stream</returns>
        protected UInt32 ReadUInt32(Stream Data)
        {
            //stream length check
            if (Data.Length - Data.Position < sizeof(UInt32))
                throw new Exception("Not enough data in stream.");

            Byte[] buffer = new Byte[sizeof(UInt32)];
            Data.Read(buffer, 0, buffer.Length);
            return BitConverter.ToUInt32(buffer, 0);
        }

        /// <summary>Discards the description NULL padding from the incoming stream by incrementing 0-3 bytes.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected void ReadDescriptionNullPadding(Stream Data)
        {
            Int32 structureLength = sizeof(Int32) + description.Length;
            if (structureLength % PaddingSize > 0)
                Data.Position += (PaddingSize - (structureLength % PaddingSize));
        }

        /// <summary>Writes the description NULL padding to the Destination stream by writing 0-3 NULL (0) bytes.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected void WriteDescriptionNullPadding(Stream Destination)
        {
            Int32 structureLength = sizeof(Int32) + description.Length;
            if (structureLength % PaddingSize > 0)
            {
                Byte[] buffer = new Byte[(PaddingSize - (structureLength % PaddingSize))];
                //Array.Clear(buffer);    //unnecessary, but what the hell?
                Destination.Write(buffer, 0, buffer.Length);
            }
        }
    }

    /// <summary>
    ///     Basic save structure representing an array starting with a non-descriptive "." description following
    ///     with an array of basic types.
    /// </summary>
    public class ComplexArraySaveStruct<Structure> : ComplexSaveStruct where Structure : ISotsStructure, new()
    {
        /// <summary>Non-descriptive length of the array</summary>
        protected Int32SaveStruct length;

        /// <summary>Actual array of values being represented</summary>
        protected List<Structure> values;

        /// <summary>Non-descriptive length of the array</summary>
        public Int32SaveStruct Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        /// <summary>Actual array of values being represented</summary>
        public List<Structure> Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

        /// <summary>Default Constructor</summary>
        public ComplexArraySaveStruct() : base()
        {
            this.length = new Int32SaveStruct();
            this.values = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.length.ReadFromStream(Data);

            this.values = new List<Structure>(this.length.Value);
            for (Int32 i = 0; i < this.values.Capacity; i++)
            {
                Structure newStruct = new Structure();
                newStruct.ReadFromStream(Data);
                this.values.Add(newStruct);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.length.WriteToStream(Destination);
            for (Int32 i = 0; i < this.values.Count; i++)
                this.values[i].WriteToStream(Destination);
        }

        /// <summary>Adds a value to the array</summary>
        /// <param name="Addition">Object of Structure type to add to the array</param>
        public void Add(Structure Addition)
        {
            this.values.Add(Addition);
            this.length.Value++;
        }
    }
    

    /// <summary>
    ///     Basic save structure representing an array starting only with a count following
    ///     with an array of basic types.
    /// </summary>
    public class NonComplexArraySaveStruct<Structure> : ISotsStructure where Structure : ISotsStructure, new()
    {
        /// <summary>Non-descriptive length of the array</summary>
        protected Int32SaveStruct length;

        /// <summary>Actual array of values being represented</summary>
        protected List<Structure> values;

        /// <summary>Non-descriptive length of the array</summary>
        public Int32SaveStruct Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        /// <summary>Gets or sets actual array of values being represented</summary>
        public List<Structure> Values
        {
            get { return this.values; }
            set { this.values = value; }
        }

        /// <summary>Default Constructor</summary>
        public NonComplexArraySaveStruct() : base()
        {
            this.length = new Int32SaveStruct();
            this.values = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public virtual void ReadFromStream(Stream Data)
        {
            this.length.ReadFromStream(Data);

            this.values = new List<Structure>();
            for (Int32 i = 0; i < this.length.Value; i++)
            {
                Structure newStruct = new Structure();
                newStruct.ReadFromStream(Data);
                this.values.Add(newStruct);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public virtual void WriteToStream(Stream Destination)
        {
            this.length.WriteToStream(Destination);
            for (Int32 i = 0; i < this.values.Count; i++)
                this.values[i].WriteToStream(Destination);
        }

        /// <summary>Adds a value to the array</summary>
        /// <param name="Addition">Object of Structure type to add to the array</param>
        public void Add(Structure Addition)
        {
            this.values.Add(Addition);
            this.length.Value++;
        }
    }
    #endregion
        
    #region Same representation
    /// <summary>Int32 attribute for field</summary>
    public class AttributeSaveStruct : ComplexSaveStruct
    {
        /// <summary>ID of the object</summary>
        protected Int32SaveStruct attribute;

        /// <summary>Gets or sets the ID of the object.</summary>
        public Int32SaveStruct Attribute
        {
            get { return attribute; }
            set { attribute = value; }
        }

        /// <summary>Default constructor</summary>
        public AttributeSaveStruct() : base()
        {
            this.attribute = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.attribute.ReadFromStream(Data);

            //consume padding NULs
            //Int32 structureLength = sizeof(Int32) + this.description.Length + sizeof(Int32) + this.attribute.Value;
            //if (structureLength % PaddingSize > 0)
            //    Data.Position += (PaddingSize - (structureLength % PaddingSize));
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.attribute.WriteToStream(Destination);

            //write padding NULs
            //Int32 structureLength = sizeof(Int32) + this.description.Length + sizeof(Int32) + this.attribute.Value;
            //if (structureLength % PaddingSize > 0)
            //{
            //    Byte[] buffer = new Byte[(PaddingSize - (structureLength % PaddingSize))];
            //    //Array.Clear(buffer);    //unnecessary, but what the hell?
            //    Destination.Write(buffer, 0, buffer.Length);
            //}
        }
    }
    
    /// <summary>Nested Int32 for a certain field</summary>
    public class NestedInt32SaveStruct : ComplexSaveStruct
    {
        /// <summary>ID of the object</summary>
        protected Int32SaveStruct value;

        /// <summary>Gets or sets the ID of the object.</summary>
        public Int32SaveStruct Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>Default constructor</summary>
        public NestedInt32SaveStruct() : base()
        {
            this.value = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.value.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.value.WriteToStream(Destination);
        }
    }
    #endregion
}