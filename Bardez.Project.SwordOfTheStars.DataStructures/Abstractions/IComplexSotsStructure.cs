using System;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    /// <summary>This public interface describes the additional complex methods to write out a larger, more complicated data structure (with onset and termination markers) to disk and read from disk.</summary>
    public interface IComplexSotsStructure : ISotsStructure
    {
        /// <summary>Reads the next four bytes in the stream and checks that they match the StructureMarker value</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        void ConsumeStructureMarkerBegin(Stream Data);

        /// <summary>Reads the next four bytes in the stream and checks that they match the bitwise NOT of the StructureMarker value</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        void ConsumeStructureMarkerEnd(Stream Data);

        /// <summary>Writes the StructureMarker value to the next four bytes in the stream</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        void WriteStructureMarkerBegin(Stream Destination);

        /// <summary>Writes the bitwise NOT of the StructureMarker value to the next four bytes in the stream</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        void WriteStructureMarkerEnd(Stream Destination);

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        void ReadBodyFromStream(Stream Data);

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        void WriteBodyToStream(Stream Destination);
    }
}