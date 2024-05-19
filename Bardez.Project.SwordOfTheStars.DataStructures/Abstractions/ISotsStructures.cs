using System;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    /// <summary>This public interface describes the basic methods to write out a small, basic data structure to disk and read from disk.</summary>
    public interface ISotsStructure
    {
        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        void ReadFromStream(Stream Data);

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        void WriteToStream(Stream Destination);
    }
}