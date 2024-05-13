using System;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    /// <summary>This class represents the entirety of the decompressed save game file.</summary>
    public class SaveGameData : ISotsStructure
    {
        protected SummarySaveStruct summary;
        protected CreateParametersSaveStruct createParams;
        protected SimSaveStruct sim;
        protected CdTable cdTable;

        public SummarySaveStruct Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        public CreateParametersSaveStruct CreateParams
        {
            get { return createParams; }
            set { createParams = value; }
        }

        public SimSaveStruct Sim
        {
            get { return sim; }
            set { sim = value; }
        }

        public CdTable CdTable
        {
            get { return cdTable; }
            set { cdTable = value; }
        }

        /// <summary>Default constructor</summary>
        public SaveGameData()
        {
            this.summary = new SummarySaveStruct();
            this.createParams = new CreateParametersSaveStruct();
            this.sim = new SimSaveStruct();
            this.cdTable = new CdTable();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.summary.ReadFromStream(Data);
            this.createParams.ReadFromStream(Data);
            this.sim.ReadFromStream(Data);
            this.cdTable.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.summary.WriteToStream(Destination);
            this.createParams.WriteToStream(Destination);
            this.sim.WriteToStream(Destination);
            this.cdTable.WriteToStream(Destination);
        }
    }
}