using System;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    //Note : CdPlayer is highly unknown 


    #region CD Data structures
    #region First (player?) CD data structure
    public class CdPlayer : ComplexSaveStruct
    {                                           //data observed
                                                //KTA   SO      WAP2    WAP35
        protected Int32SaveStruct unknown1;     //16    16      16      16
        protected BooleanSaveStruct unknown2;   //1     1       1       1
        protected FloatSaveStruct unknown3;     //2.5   9.4     1.7     1.7

        //5 Boolean/Bytes
        protected BooleanSaveStruct unknown4;   //0
        protected BooleanSaveStruct unknown5;   //0
        protected BooleanSaveStruct unknown6;   //0
        protected BooleanSaveStruct unknown7;   //0
        protected BooleanSaveStruct unknown8;   //0

        protected Int32SaveStruct unknown9;     //0
        protected Int32SaveStruct unknown10;    //0

        /// <remarks>
        ///     this is some sort of structure, as this number of records visibly follow
        ///     1-indexed id, constant value, constant value, 0
        /// </remarks>
        protected NonComplexArraySaveStruct<CdPlayerUnknown11Item> unknown11;    //0     10      5       0

        //24 ints
        protected Int32SaveStruct unknown12;    //0
        protected Int32SaveStruct unknown13;    //0
        protected Int32SaveStruct unknown14;    //0
        
        /// <remarks>single Int32 visibly follows when 1</remarks>
        protected NonComplexArraySaveStruct<Int32SaveStruct> unknown15;    //0     1

        /// <remarks>double Int32 visibly follows when 2</remarks>
        protected NonComplexArraySaveStruct<Int32SaveStruct> unknown16;    //0     2

        /// <remarks>double Int32 visibly follows when 1</remarks>
        protected NonComplexArraySaveStruct<CdPlayerUnknown17Item> unknown17;    //0     1

        /// <remarks>single Int32 visibly follows when 1</remarks>
        protected NonComplexArraySaveStruct<Int32SaveStruct> unknown18;    //0     1

        protected Int32SaveStruct unknown19;    //0
        protected Int32SaveStruct unknown20;    //0
        protected Int32SaveStruct unknown21;    //0

        /// <remarks>double Int32, boolean visibly follows when 1</remarks>
        protected NonComplexArraySaveStruct<CdPlayerUnknown22Item> unknown22;    //0     1
        protected Int32SaveStruct unknown23;    //0
        protected Int32SaveStruct unknown24;    //0
        protected Int32SaveStruct unknown25;    //0
        protected Int32SaveStruct unknown26;    //0
        protected Int32SaveStruct unknown27;    //0
        protected Int32SaveStruct unknown28;    //0
        protected Int32SaveStruct unknown29;    //0
        protected Int32SaveStruct unknown30;    //0
        protected Int32SaveStruct unknown31;    //0
        protected Int32SaveStruct unknown32;    //0
        protected Int32SaveStruct unknown33;    //0
        protected Int32SaveStruct unknown34;    //0
        protected Int32SaveStruct unknown35;    //0

        #region Properties
        public Int32SaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public BooleanSaveStruct Unknown2
        {
            get { return unknown2; }
            set { unknown2 = value; }
        }

        public FloatSaveStruct Unknown3
        {
            get { return unknown3; }
            set { unknown3 = value; }
        }

        public BooleanSaveStruct Unknown4
        {
            get { return unknown4; }
            set { unknown4 = value; }
        }

        public BooleanSaveStruct Unknown5
        {
            get { return unknown5; }
            set { unknown5 = value; }
        }

        public BooleanSaveStruct Unknown6
        {
            get { return unknown6; }
            set { unknown6 = value; }
        }

        public BooleanSaveStruct Unknown7
        {
            get { return unknown7; }
            set { unknown7 = value; }
        }

        public BooleanSaveStruct Unknown8
        {
            get { return unknown8; }
            set { unknown8 = value; }
        }

        public Int32SaveStruct Unknown9
        {
            get { return unknown9; }
            set { unknown9 = value; }
        }

        public Int32SaveStruct Unknown10
        {
            get { return unknown10; }
            set { unknown10 = value; }
        }

        public NonComplexArraySaveStruct<CdPlayerUnknown11Item> Unknown11
        {
            get { return unknown11; }
            set { unknown11 = value; }
        }

        public Int32SaveStruct Unknown12
        {
            get { return unknown12; }
            set { unknown12 = value; }
        }

        public Int32SaveStruct Unknown13
        {
            get { return unknown13; }
            set { unknown13 = value; }
        }

        public Int32SaveStruct Unknown14
        {
            get { return unknown14; }
            set { unknown14 = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Unknown15
        {
            get { return unknown15; }
            set { unknown15 = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Unknown16
        {
            get { return unknown16; }
            set { unknown16 = value; }
        }

        public NonComplexArraySaveStruct<CdPlayerUnknown17Item> Unknown17
        {
            get { return unknown17; }
            set { unknown17 = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Unknown18
        {
            get { return unknown18; }
            set { unknown18 = value; }
        }

        public Int32SaveStruct Unknown19
        {
            get { return unknown19; }
            set { unknown19 = value; }
        }

        public Int32SaveStruct Unknown20
        {
            get { return unknown20; }
            set { unknown20 = value; }
        }

        public Int32SaveStruct Unknown21
        {
            get { return unknown21; }
            set { unknown21 = value; }
        }

        public NonComplexArraySaveStruct<CdPlayerUnknown22Item> Unknown22
        {
            get { return unknown22; }
            set { unknown22 = value; }
        }

        public Int32SaveStruct Unknown23
        {
            get { return unknown23; }
            set { unknown23 = value; }
        }

        public Int32SaveStruct Unknown24
        {
            get { return unknown24; }
            set { unknown24 = value; }
        }

        public Int32SaveStruct Unknown25
        {
            get { return unknown25; }
            set { unknown25 = value; }
        }

        public Int32SaveStruct Unknown26
        {
            get { return unknown26; }
            set { unknown26 = value; }
        }

        public Int32SaveStruct Unknown27
        {
            get { return unknown27; }
            set { unknown27 = value; }
        }

        public Int32SaveStruct Unknown28
        {
            get { return unknown28; }
            set { unknown28 = value; }
        }

        public Int32SaveStruct Unknown29
        {
            get { return unknown29; }
            set { unknown29 = value; }
        }

        public Int32SaveStruct Unknown30
        {
            get { return unknown30; }
            set { unknown30 = value; }
        }

        public Int32SaveStruct Unknown31
        {
            get { return unknown31; }
            set { unknown31 = value; }
        }

        public Int32SaveStruct Unknown32
        {
            get { return unknown32; }
            set { unknown32 = value; }
        }

        public Int32SaveStruct Unknown33
        {
            get { return unknown33; }
            set { unknown33 = value; }
        }

        public Int32SaveStruct Unknown34
        {
            get { return unknown34; }
            set { unknown34 = value; }
        }

        public Int32SaveStruct Unknown35
        {
            get { return unknown35; }
            set { unknown35 = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public CdPlayer() : base()
        {
            this.unknown1 = new Int32SaveStruct();
            this.unknown2 = new BooleanSaveStruct();
            this.unknown3 = new FloatSaveStruct();
            this.unknown4 = new BooleanSaveStruct();
            this.unknown5 = new BooleanSaveStruct();
            this.unknown6 = new BooleanSaveStruct();
            this.unknown7 = new BooleanSaveStruct();
            this.unknown8 = new BooleanSaveStruct();
            this.unknown9 = new Int32SaveStruct();
            this.unknown10 = new Int32SaveStruct();
            this.unknown11 = new NonComplexArraySaveStruct<CdPlayerUnknown11Item>();
            this.unknown12 = new Int32SaveStruct();
            this.unknown13 = new Int32SaveStruct();
            this.unknown14 = new Int32SaveStruct();
            this.unknown15 = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.unknown16 = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.unknown17 = new NonComplexArraySaveStruct<CdPlayerUnknown17Item>();
            this.unknown18 = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.unknown19 = new Int32SaveStruct();
            this.unknown20 = new Int32SaveStruct();
            this.unknown21 = new Int32SaveStruct();
            this.unknown22 = new NonComplexArraySaveStruct<CdPlayerUnknown22Item>();
            this.unknown23 = new Int32SaveStruct();
            this.unknown24 = new Int32SaveStruct();
            this.unknown25 = new Int32SaveStruct();
            this.unknown26 = new Int32SaveStruct();
            this.unknown27 = new Int32SaveStruct();
            this.unknown28 = new Int32SaveStruct();
            this.unknown29 = new Int32SaveStruct();
            this.unknown30 = new Int32SaveStruct();
            this.unknown31 = new Int32SaveStruct();
            this.unknown32 = new Int32SaveStruct();
            this.unknown33 = new Int32SaveStruct();
            this.unknown34 = new Int32SaveStruct();
            this.unknown35 = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.unknown1.ReadFromStream(Data);
            this.unknown2.ReadFromStream(Data);
            this.unknown3.ReadFromStream(Data);
            this.unknown4.ReadFromStream(Data);
            this.unknown5.ReadFromStream(Data);
            this.unknown6.ReadFromStream(Data);
            this.unknown7.ReadFromStream(Data);
            this.unknown8.ReadFromStream(Data);
            this.unknown9.ReadFromStream(Data);
            this.unknown10.ReadFromStream(Data);
            this.unknown11.ReadFromStream(Data);
            this.unknown12.ReadFromStream(Data);
            this.unknown13.ReadFromStream(Data);
            this.unknown14.ReadFromStream(Data);
            this.unknown15.ReadFromStream(Data);
            this.unknown16.ReadFromStream(Data);
            this.unknown17.ReadFromStream(Data);
            this.unknown18.ReadFromStream(Data);
            this.unknown19.ReadFromStream(Data);
            this.unknown20.ReadFromStream(Data);
            this.unknown21.ReadFromStream(Data);
            this.unknown22.ReadFromStream(Data);
            this.unknown23.ReadFromStream(Data);
            this.unknown24.ReadFromStream(Data);
            this.unknown25.ReadFromStream(Data);
            this.unknown26.ReadFromStream(Data);
            this.unknown27.ReadFromStream(Data);
            this.unknown28.ReadFromStream(Data);
            this.unknown29.ReadFromStream(Data);
            this.unknown30.ReadFromStream(Data);
            this.unknown31.ReadFromStream(Data);
            this.unknown32.ReadFromStream(Data);
            this.unknown33.ReadFromStream(Data);
            this.unknown34.ReadFromStream(Data);
            this.unknown35.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
            this.unknown3.WriteToStream(Destination);
            this.unknown4.WriteToStream(Destination);
            this.unknown5.WriteToStream(Destination);
            this.unknown6.WriteToStream(Destination);
            this.unknown7.WriteToStream(Destination);
            this.unknown8.WriteToStream(Destination);
            this.unknown9.WriteToStream(Destination);
            this.unknown10.WriteToStream(Destination);
            this.unknown11.WriteToStream(Destination);
            this.unknown12.WriteToStream(Destination);
            this.unknown13.WriteToStream(Destination);
            this.unknown14.WriteToStream(Destination);
            this.unknown15.WriteToStream(Destination);
            this.unknown16.WriteToStream(Destination);
            this.unknown17.WriteToStream(Destination);
            this.unknown18.WriteToStream(Destination);
            this.unknown19.WriteToStream(Destination);
            this.unknown20.WriteToStream(Destination);
            this.unknown21.WriteToStream(Destination);
            this.unknown22.WriteToStream(Destination);
            this.unknown23.WriteToStream(Destination);
            this.unknown24.WriteToStream(Destination);
            this.unknown25.WriteToStream(Destination);
            this.unknown26.WriteToStream(Destination);
            this.unknown27.WriteToStream(Destination);
            this.unknown28.WriteToStream(Destination);
            this.unknown29.WriteToStream(Destination);
            this.unknown30.WriteToStream(Destination);
            this.unknown31.WriteToStream(Destination);
            this.unknown32.WriteToStream(Destination);
            this.unknown33.WriteToStream(Destination);
            this.unknown34.WriteToStream(Destination);
            this.unknown35.WriteToStream(Destination);
        }
    }

    public class CdPlayerUnknown11Item : ISotsStructure
    {
        protected Int32SaveStruct unknownId;
        protected Int32SaveStruct unknownConstant1;
        protected Int32SaveStruct unknownConstant2;
        protected Int32SaveStruct unknownValue1;

        public Int32SaveStruct UnknownId
        {
            get { return unknownId; }
            set { unknownId = value; }
        }

        public Int32SaveStruct UnknownConstant1
        {
            get { return unknownConstant1; }
            set { unknownConstant1 = value; }
        }

        public Int32SaveStruct UnknownConstant2
        {
            get { return unknownConstant2; }
            set { unknownConstant2 = value; }
        }

        public Int32SaveStruct UnknownValue1
        {
            get { return unknownValue1; }
            set { unknownValue1 = value; }
        }

        /// <summary>Default constructor</summary>
        public CdPlayerUnknown11Item()
        {
            this.unknownId = new Int32SaveStruct();
            this.unknownConstant1 = new Int32SaveStruct();
            this.unknownConstant2 = new Int32SaveStruct();
            this.unknownValue1 = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.unknownId.ReadFromStream(Data);
            this.unknownConstant1.ReadFromStream(Data);
            this.unknownConstant2.ReadFromStream(Data);
            this.unknownValue1.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.unknownId.WriteToStream(Destination);
            this.unknownConstant1.WriteToStream(Destination);
            this.unknownConstant2.WriteToStream(Destination);
            this.unknownValue1.WriteToStream(Destination);
        }
    }

    public class CdPlayerUnknown17Item : ISotsStructure
    {
        protected Int32SaveStruct unknown1;
        protected Int32SaveStruct unknown2;

        public Int32SaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public Int32SaveStruct Unknown2
        {
            get { return unknown2; }
            set { unknown2 = value; }
        }

        /// <summary>Default constructor</summary>
        public CdPlayerUnknown17Item()
        {
            this.unknown1 = new Int32SaveStruct();
            this.unknown2 = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.unknown1.ReadFromStream(Data);
            this.unknown2.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
        }
    }

    public class CdPlayerUnknown22Item : ISotsStructure
    {
        protected Int32SaveStruct unknown1;
        protected Int32SaveStruct unknown2;
        protected BooleanSaveStruct unknown3;

        public Int32SaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public Int32SaveStruct Unknown2
        {
            get { return unknown2; }
            set { unknown2 = value; }
        }

        public BooleanSaveStruct Unknown3
        {
            get { return unknown3; }
            set { unknown3 = value; }
        }

        /// <summary>Default constructor</summary>
        public CdPlayerUnknown22Item()
        {
            this.unknown1 = new Int32SaveStruct();
            this.unknown2 = new Int32SaveStruct();
            this.unknown3 = new BooleanSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.unknown1.ReadFromStream(Data);
            this.unknown2.ReadFromStream(Data);
            this.unknown3.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
            this.unknown3.WriteToStream(Destination);
        }
    }
    #endregion

    #region Subsequent (AI?) CD data structures
    public class CdAi : ComplexSaveStruct
    {
        protected AttributeSaveStruct aiAttr;
        protected NestedInt32SaveStruct aiTurnPris;
        protected CdAiSit aiSit;
        protected NestedInt32SaveStruct aiPlyHat;
        protected NestedInt32SaveStruct prs2;
        protected Int32SaveStruct dsh;
        protected Int32SaveStruct nbStab;
        protected Int32SaveStruct nmBlst;
        protected CdAiAidng aidng;
        protected Int32SaveStruct aiHivJ;
        protected Int32SaveStruct sdFlT;
        protected NestedInt32SaveStruct nalat;
        protected Int32SaveStruct lnat;
        protected Int32SaveStruct lat;
        protected NonComplexArraySaveStruct<CdAiSys> aiSys;
        protected NonComplexArraySaveStruct<CdAiCmbr> cmbR;
        protected NonComplexArraySaveStruct<CdAiCl> cl;
        protected NonComplexArraySaveStruct<CdAiPrv> prv;
        protected NonComplexArraySaveStruct<Int32SaveStruct> tecs;
        protected Int32SaveStruct fct;
        protected ComplexArraySaveStruct<CdAiApr> apr;

        #region Properties
        public AttributeSaveStruct AiAttr
        {
            get { return aiAttr; }
            set { aiAttr = value; }
        }

        public NestedInt32SaveStruct AiTurnPris
        {
            get { return aiTurnPris; }
            set { aiTurnPris = value; }
        }

        public CdAiSit AiSit
        {
            get { return aiSit; }
            set { aiSit = value; }
        }

        public NestedInt32SaveStruct AiPlyHat
        {
            get { return aiPlyHat; }
            set { aiPlyHat = value; }
        }

        public NestedInt32SaveStruct Prs2
        {
            get { return prs2; }
            set { prs2 = value; }
        }

        public Int32SaveStruct Dsh
        {
            get { return dsh; }
            set { dsh = value; }
        }

        public Int32SaveStruct NbStab
        {
            get { return nbStab; }
            set { nbStab = value; }
        }

        public Int32SaveStruct NmBlst
        {
            get { return nmBlst; }
            set { nmBlst = value; }
        }

        public CdAiAidng Aidng
        {
            get { return aidng; }
            set { aidng = value; }
        }

        public Int32SaveStruct AiHivJ
        {
            get { return aiHivJ; }
            set { aiHivJ = value; }
        }

        public Int32SaveStruct SdFlT
        {
            get { return sdFlT; }
            set { sdFlT = value; }
        }

        public NestedInt32SaveStruct Nalat
        {
            get { return nalat; }
            set { nalat = value; }
        }

        public Int32SaveStruct Lnat
        {
            get { return lnat; }
            set { lnat = value; }
        }

        public Int32SaveStruct Lat
        {
            get { return lat; }
            set { lat = value; }
        }

        public NonComplexArraySaveStruct<CdAiSys> AiSys
        {
            get { return aiSys; }
            set { aiSys = value; }
        }

        public NonComplexArraySaveStruct<CdAiCmbr> CmbR
        {
            get { return cmbR; }
            set { cmbR = value; }
        }

        public NonComplexArraySaveStruct<CdAiCl> Cl
        {
            get { return cl; }
            set { cl = value; }
        }

        public NonComplexArraySaveStruct<CdAiPrv> Prv
        {
            get { return prv; }
            set { prv = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Tecs
        {
            get { return tecs; }
            set { tecs = value; }
        }

        public Int32SaveStruct Fct
        {
            get { return fct; }
            set { fct = value; }
        }

        public ComplexArraySaveStruct<CdAiApr> Apr
        {
            get { return apr; }
            set { apr = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public CdAi() : base()
        {
            this.aiAttr = new AttributeSaveStruct();
            this.aiTurnPris = new NestedInt32SaveStruct();
            this.aiSit = new CdAiSit();
            this.aiPlyHat = new NestedInt32SaveStruct();
            this.prs2 = new NestedInt32SaveStruct();
            this.dsh = new Int32SaveStruct();
            this.nbStab = new Int32SaveStruct();
            this.nmBlst = new Int32SaveStruct();
            this.aidng = new CdAiAidng();
            this.aiHivJ = new Int32SaveStruct();
            this.sdFlT = new Int32SaveStruct();
            this.nalat = new NestedInt32SaveStruct();
            this.lnat = new Int32SaveStruct();
            this.lat = new Int32SaveStruct();
            this.aiSys = new NonComplexArraySaveStruct<CdAiSys>();
            this.cmbR = new NonComplexArraySaveStruct<CdAiCmbr>();
            this.cl = new NonComplexArraySaveStruct<CdAiCl>();
            this.prv = new NonComplexArraySaveStruct<CdAiPrv>();
            this.tecs = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.fct = new Int32SaveStruct();
            this.apr = new ComplexArraySaveStruct<CdAiApr>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.aiAttr.ReadFromStream(Data);
            this.aiTurnPris.ReadFromStream(Data);
            this.aiSit.ReadFromStream(Data);
            this.aiPlyHat.ReadFromStream(Data);
            this.prs2.ReadFromStream(Data);
            this.dsh.ReadFromStream(Data);
            this.nbStab.ReadFromStream(Data);
            this.nmBlst.ReadFromStream(Data);
            this.aidng.ReadFromStream(Data);
            this.aiHivJ.ReadFromStream(Data);
            this.sdFlT.ReadFromStream(Data);
            this.nalat.ReadFromStream(Data);
            this.lnat.ReadFromStream(Data);
            this.lat.ReadFromStream(Data);
            this.aiSys.ReadFromStream(Data);
            this.cmbR.ReadFromStream(Data);
            this.cl.ReadFromStream(Data);
            this.prv.ReadFromStream(Data);
            this.tecs.ReadFromStream(Data);
            this.fct.ReadFromStream(Data);
            this.apr.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.aiAttr.WriteToStream(Destination);
            this.aiTurnPris.WriteToStream(Destination);
            this.aiSit.WriteToStream(Destination);
            this.aiPlyHat.WriteToStream(Destination);
            this.prs2.WriteToStream(Destination);
            this.dsh.WriteToStream(Destination);
            this.nbStab.WriteToStream(Destination);
            this.nmBlst.WriteToStream(Destination);
            this.aidng.WriteToStream(Destination);
            this.aiHivJ.WriteToStream(Destination);
            this.sdFlT.WriteToStream(Destination);
            this.nalat.WriteToStream(Destination);
            this.lnat.WriteToStream(Destination);
            this.lat.WriteToStream(Destination);
            this.aiSys.WriteToStream(Destination);
            this.cmbR.WriteToStream(Destination);
            this.cl.WriteToStream(Destination);
            this.prv.WriteToStream(Destination);
            this.tecs.WriteToStream(Destination);
            this.fct.WriteToStream(Destination);
            this.apr.WriteToStream(Destination);
        }
    }

    public class CdAiSit : ComplexSaveStruct
    {
        protected NestedInt32SaveStruct aiSitSecs;
        protected NestedInt32SaveStruct aiSitWepFams;

        public NestedInt32SaveStruct AiSitSecs
        {
            get { return aiSitSecs; }
            set { aiSitSecs = value; }
        }

        public NestedInt32SaveStruct AiSitWepFams
        {
            get { return aiSitWepFams; }
            set { aiSitWepFams = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiSit() : base()
        {
            this.aiSitSecs = new NestedInt32SaveStruct();
            this.aiSitWepFams = new NestedInt32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.aiSitSecs.ReadFromStream(Data);
            this.aiSitWepFams.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.aiSitSecs.WriteToStream(Destination);
            this.aiSitWepFams.WriteToStream(Destination);
        }
    }

    public class CdAiSys : ISotsStructure
    {
        protected Int32SaveStruct aiSysId;
        protected CdAiSysDetails aiSys;

        public Int32SaveStruct AiSysId
        {
            get { return aiSysId; }
            set { aiSysId = value; }
        }

        public CdAiSysDetails AiSys
        {
            get { return aiSys; }
            set { aiSys = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiSys() : base()
        {
            this.aiSysId = new Int32SaveStruct();
            this.aiSys = new CdAiSysDetails();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.aiSysId.ReadFromStream(Data);
            this.aiSys.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.aiSysId.WriteToStream(Destination);
            this.aiSys.WriteToStream(Destination);
        }
    }

    public class CdAiSysDetails : ComplexSaveStruct
    {
        protected CdAiSit aiSysSit;

        public CdAiSit AiSysSit
        {
            get { return aiSysSit; }
            set { aiSysSit = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiSysDetails() : base()
        {
            this.aiSysSit = new CdAiSit();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.aiSysSit.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.aiSysSit.WriteToStream(Destination);
        }
    }

    public class CdAiPrv : ISotsStructure
    {
        protected Int32SaveStruct nPrvId;
        protected FloatSaveStruct nPrvVa;

        public Int32SaveStruct NPrvId
        {
            get { return nPrvId; }
            set { nPrvId = value; }
        }

        public FloatSaveStruct NPrvVa
        {
            get { return nPrvVa; }
            set { nPrvVa = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiPrv()
        {
            this.nPrvId = new Int32SaveStruct();
            this.nPrvVa = new FloatSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.nPrvId.ReadFromStream(Data);
            this.nPrvVa.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.nPrvId.WriteToStream(Destination);
            this.nPrvVa.WriteToStream(Destination);
        }
    }

    public class CdAiAidng : ComplexSaveStruct
    {
        protected NonComplexArraySaveStruct<CdAiAidngDn> dns;

        public NonComplexArraySaveStruct<CdAiAidngDn> Dns
        {
            get { return dns; }
            set { dns = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiAidng() : base()
        {
            this.dns = new NonComplexArraySaveStruct<CdAiAidngDn>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.dns.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.dns.WriteToStream(Destination);
        }
    }

    public class CdAiAidngDn : ISotsStructure
    {
        protected CdAiAidngDnId dnid;
        protected StringSaveStruct dnnm;

        public CdAiAidngDnId Dnid
        {
            get { return dnid; }
            set { dnid = value; }
        }

        public StringSaveStruct Dnnm
        {
            get { return dnnm; }
            set { dnnm = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiAidngDn()
        {
            this.dnid = new CdAiAidngDnId();
            this.dnnm = new StringSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.dnid.ReadFromStream(Data);
            this.dnnm.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.dnid.WriteToStream(Destination);
            this.dnnm.WriteToStream(Destination);
        }
    }

    public class CdAiAidngDnId : ComplexSaveStruct
    {
        protected Int32SaveStruct unknown1;     //0
        protected Int32SaveStruct unknown2;     //numbers

        public Int32SaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public Int32SaveStruct Unknown2
        {
            get { return unknown2; }
            set { unknown2 = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiAidngDnId() : base()
        {
            this.unknown1 = new Int32SaveStruct();
            this.unknown2 = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.unknown1.ReadFromStream(Data);
            this.unknown2.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
        }
    }

    public class CdAiCmbr : ComplexSaveStruct
    {
        protected Int32SaveStruct crTrnK;
        protected BooleanSaveStruct crPce;
        protected NestedInt32SaveStruct crSys;
        protected CdAiCmbrCrplSv2 crplSv2;

        public Int32SaveStruct CrTrnK
        {
            get { return crTrnK; }
            set { crTrnK = value; }
        }

        public BooleanSaveStruct CrPce
        {
            get { return crPce; }
            set { crPce = value; }
        }

        public NestedInt32SaveStruct CrSys
        {
            get { return crSys; }
            set { crSys = value; }
        }

        public CdAiCmbrCrplSv2 CrplSv2
        {
            get { return crplSv2; }
            set { crplSv2 = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiCmbr() : base()
        {
            this.crTrnK = new Int32SaveStruct();
            this.crPce = new BooleanSaveStruct();
            this.crSys = new NestedInt32SaveStruct();
            this.crplSv2 = new CdAiCmbrCrplSv2();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.crTrnK.ReadFromStream(Data);
            this.crPce.ReadFromStream(Data);
            this.crSys.ReadFromStream(Data);
            this.crplSv2.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.crTrnK.WriteToStream(Destination);
            this.crPce.WriteToStream(Destination);
            this.crSys.WriteToStream(Destination);
            this.crplSv2.WriteToStream(Destination);
        }
    }

    public class CdAiCmbrCrplSv2 : ComplexSaveStruct
    {
        protected Int32SaveStruct rpBon;
        protected Int32SaveStruct rpBonT;
        protected Int32SaveStruct savBonus;
        protected BooleanSaveStruct maintHf;
        protected ComplexArraySaveStruct<CdAiCmbrCrplSv2TacReport> tacReports;

        #region Properties
        public Int32SaveStruct RpBon
        {
            get { return rpBon; }
            set { rpBon = value; }
        }

        public Int32SaveStruct RpBonT
        {
            get { return rpBonT; }
            set { rpBonT = value; }
        }

        public Int32SaveStruct SavBonus
        {
            get { return savBonus; }
            set { savBonus = value; }
        }

        public BooleanSaveStruct MaintHf
        {
            get { return maintHf; }
            set { maintHf = value; }
        }

        public ComplexArraySaveStruct<CdAiCmbrCrplSv2TacReport> TacReports
        {
            get { return tacReports; }
            set { tacReports = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public CdAiCmbrCrplSv2() : base()
        {
            this.rpBon = new Int32SaveStruct();
            this.rpBonT = new Int32SaveStruct();
            this.savBonus = new Int32SaveStruct();
            this.maintHf = new BooleanSaveStruct();
            this.tacReports = new ComplexArraySaveStruct<CdAiCmbrCrplSv2TacReport>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.rpBon.ReadFromStream(Data);
            this.rpBonT.ReadFromStream(Data);
            this.savBonus.ReadFromStream(Data);
            this.maintHf.ReadFromStream(Data);
            this.tacReports.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.rpBon.WriteToStream(Destination);
            this.rpBonT.WriteToStream(Destination);
            this.savBonus.WriteToStream(Destination);
            this.maintHf.WriteToStream(Destination);
            this.tacReports.WriteToStream(Destination);
        }
    }

    public class CdAiCmbrCrplSv2TacReport : ComplexSaveStruct
    {
        protected CdAiCmbrCrplSv2TacReportTrStruct trBy;
        protected CdAiCmbrCrplSv2TacReportTrStruct trTo;
        protected CdAiCmbrCrplSv2TacReportDamage damageStruct;
        protected NonComplexArraySaveStruct<CdAiCmbrCrplSv2TacReportShips> ships;

        public CdAiCmbrCrplSv2TacReportTrStruct TrBy
        {
            get { return trBy; }
            set { trBy = value; }
        }

        public CdAiCmbrCrplSv2TacReportTrStruct TrTo
        {
            get { return trTo; }
            set { trTo = value; }
        }

        public CdAiCmbrCrplSv2TacReportDamage DamageStruct
        {
            get { return damageStruct; }
            set { damageStruct = value; }
        }

        public NonComplexArraySaveStruct<CdAiCmbrCrplSv2TacReportShips> Ships
        {
            get { return ships; }
            set { ships = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiCmbrCrplSv2TacReport() : base()
        {
            this.trBy = new CdAiCmbrCrplSv2TacReportTrStruct();
            this.trTo = new CdAiCmbrCrplSv2TacReportTrStruct();
            this.damageStruct = new CdAiCmbrCrplSv2TacReportDamage();
            this.ships = new NonComplexArraySaveStruct<CdAiCmbrCrplSv2TacReportShips>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.trBy.ReadFromStream(Data);
            this.trTo.ReadFromStream(Data);
            this.damageStruct.ReadFromStream(Data);
            this.ships.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.trBy.WriteToStream(Destination);
            this.trTo.WriteToStream(Destination);
            this.damageStruct.WriteToStream(Destination);
            this.ships.WriteToStream(Destination);
        }
    }

    public class CdAiCmbrCrplSv2TacReportTrStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct treHd;
        protected Int32SaveStruct treHi;
        protected Int32SaveStruct treD;
        protected Int32SaveStruct treDp;
        protected Int32SaveStruct treDi;
        protected Int32SaveStruct treDt;
        protected Int32SaveStruct treB;

        #region Properties
        public Int32SaveStruct TreHd
        {
            get { return treHd; }
            set { treHd = value; }
        }

        public Int32SaveStruct TreHi
        {
            get { return treHi; }
            set { treHi = value; }
        }

        public Int32SaveStruct TreD
        {
            get { return treD; }
            set { treD = value; }
        }

        public Int32SaveStruct TreDp
        {
            get { return treDp; }
            set { treDp = value; }
        }

        public Int32SaveStruct TreDi
        {
            get { return treDi; }
            set { treDi = value; }
        }

        public Int32SaveStruct TreDt
        {
            get { return treDt; }
            set { treDt = value; }
        }

        public Int32SaveStruct TreB
        {
            get { return treB; }
            set { treB = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public CdAiCmbrCrplSv2TacReportTrStruct() : base()
        {
            this.treHd = new Int32SaveStruct();
            this.treHi = new Int32SaveStruct();
            this.treD = new Int32SaveStruct();
            this.treDp = new Int32SaveStruct();
            this.treDi = new Int32SaveStruct();
            this.treDt = new Int32SaveStruct();
            this.treB = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.treHd.ReadFromStream(Data);
            this.treHi.ReadFromStream(Data);
            this.treD.ReadFromStream(Data);
            this.treDp.ReadFromStream(Data);
            this.treDi.ReadFromStream(Data);
            this.treDt.ReadFromStream(Data);
            this.treB.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.treHd.WriteToStream(Destination);
            this.treHi.WriteToStream(Destination);
            this.treD.WriteToStream(Destination);
            this.treDp.WriteToStream(Destination);
            this.treDi.WriteToStream(Destination);
            this.treDt.WriteToStream(Destination);
            this.treB.WriteToStream(Destination);
        }
    }

    public class CdAiCmbrCrplSv2TacReportDamage : ISotsStructure
    {
        protected Int32SaveStruct tRid;
        protected Int32SaveStruct tRal;
        protected Int32SaveStruct tRbal;
        protected Int32SaveStruct tRlas;
        protected Int32SaveStruct tRmis;
        protected Int32SaveStruct tRmin;
        protected Int32SaveStruct tRnrg;
        protected Int32SaveStruct tRbio;
        protected Int32SaveStruct tRbrd;
        protected BooleanSaveStruct tRsld;
        protected BooleanSaveStruct tRsldd;
        protected BooleanSaveStruct tRsldc;
        protected BooleanSaveStruct tRsldi;
        protected BooleanSaveStruct tRsldr;

        #region Properties
        public Int32SaveStruct TRid
        {
            get { return tRid; }
            set { tRid = value; }
        }

        public Int32SaveStruct TRal
        {
            get { return tRal; }
            set { tRal = value; }
        }

        public Int32SaveStruct TRbal
        {
            get { return tRbal; }
            set { tRbal = value; }
        }

        public Int32SaveStruct TRlas
        {
            get { return tRlas; }
            set { tRlas = value; }
        }

        public Int32SaveStruct TRmis
        {
            get { return tRmis; }
            set { tRmis = value; }
        }

        public Int32SaveStruct TRmin
        {
            get { return tRmin; }
            set { tRmin = value; }
        }

        public Int32SaveStruct TRnrg
        {
            get { return tRnrg; }
            set { tRnrg = value; }
        }

        public Int32SaveStruct TRbio
        {
            get { return tRbio; }
            set { tRbio = value; }
        }

        public Int32SaveStruct TRbrd
        {
            get { return tRbrd; }
            set { tRbrd = value; }
        }

        public BooleanSaveStruct TRsld
        {
            get { return tRsld; }
            set { tRsld = value; }
        }

        public BooleanSaveStruct TRsldd
        {
            get { return tRsldd; }
            set { tRsldd = value; }
        }

        public BooleanSaveStruct TRsldc
        {
            get { return tRsldc; }
            set { tRsldc = value; }
        }

        public BooleanSaveStruct TRsldi
        {
            get { return tRsldi; }
            set { tRsldi = value; }
        }

        public BooleanSaveStruct TRsldr
        {
            get { return tRsldr; }
            set { tRsldr = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public CdAiCmbrCrplSv2TacReportDamage()
        {
            this.tRid = new Int32SaveStruct();
            this.tRal = new Int32SaveStruct();
            this.tRbal = new Int32SaveStruct();
            this.tRlas = new Int32SaveStruct();
            this.tRmis = new Int32SaveStruct();
            this.tRmin = new Int32SaveStruct();
            this.tRnrg = new Int32SaveStruct();
            this.tRbio = new Int32SaveStruct();
            this.tRbrd = new Int32SaveStruct();
            this.tRsld = new BooleanSaveStruct();
            this.tRsldd = new BooleanSaveStruct();
            this.tRsldc = new BooleanSaveStruct();
            this.tRsldi = new BooleanSaveStruct();
            this.tRsldr = new BooleanSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.tRid.ReadFromStream(Data);
            this.tRal.ReadFromStream(Data);
            this.tRbal.ReadFromStream(Data);
            this.tRlas.ReadFromStream(Data);
            this.tRmis.ReadFromStream(Data);
            this.tRmin.ReadFromStream(Data);
            this.tRnrg.ReadFromStream(Data);
            this.tRbio.ReadFromStream(Data);
            this.tRbrd.ReadFromStream(Data);
            this.tRsld.ReadFromStream(Data);
            this.tRsldd.ReadFromStream(Data);
            this.tRsldc.ReadFromStream(Data);
            this.tRsldi.ReadFromStream(Data);
            this.tRsldr.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.tRid.WriteToStream(Destination);
            this.tRal.WriteToStream(Destination);
            this.tRbal.WriteToStream(Destination);
            this.tRlas.WriteToStream(Destination);
            this.tRmis.WriteToStream(Destination);
            this.tRmin.WriteToStream(Destination);
            this.tRnrg.WriteToStream(Destination);
            this.tRbio.WriteToStream(Destination);
            this.tRbrd.WriteToStream(Destination);
            this.tRsld.WriteToStream(Destination);
            this.tRsldd.WriteToStream(Destination);
            this.tRsldc.WriteToStream(Destination);
            this.tRsldi.WriteToStream(Destination);
            this.tRsldr.WriteToStream(Destination);
        }
    }

    public class CdAiCmbrCrplSv2TacReportShips : ISotsStructure
    {
        protected Int32SaveStruct tRships;
        protected Int32SaveStruct tRsldr;
        protected Int32SaveStruct tRshipL;

        public Int32SaveStruct TRships
        {
            get { return tRships; }
            set { tRships = value; }
        }

        public Int32SaveStruct TRsldr
        {
            get { return tRsldr; }
            set { tRsldr = value; }
        }

        public Int32SaveStruct TRshipL
        {
            get { return tRshipL; }
            set { tRshipL = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiCmbrCrplSv2TacReportShips()
        {
            this.tRships = new Int32SaveStruct();
            this.tRsldr = new Int32SaveStruct();
            this.tRshipL = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.tRships.ReadFromStream(Data);
            this.tRsldr.ReadFromStream(Data);
            this.tRshipL.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.tRships.WriteToStream(Destination);
            this.tRsldr.WriteToStream(Destination);
            this.tRshipL.WriteToStream(Destination);
        }
    }

    public class CdAiCl : ISotsStructure
    {
        protected Int32SaveStruct clTn;
        protected Int32SaveStruct clSyId;
        protected Int32SaveStruct clPlId;

        public Int32SaveStruct ClTn
        {
            get { return clTn; }
            set { clTn = value; }
        }

        public Int32SaveStruct ClSyId
        {
            get { return clSyId; }
            set { clSyId = value; }
        }

        public Int32SaveStruct ClPlId
        {
            get { return clPlId; }
            set { clPlId = value; }
        }

        /// <summary>Default constructor</summary>
        public CdAiCl()
        {
            this.clTn = new Int32SaveStruct();
            this.clSyId = new Int32SaveStruct();
            this.clPlId = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.clTn.ReadFromStream(Data);
            this.clSyId.ReadFromStream(Data);
            this.clPlId.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.clTn.WriteToStream(Destination);
            this.clSyId.WriteToStream(Destination);
            this.clPlId.WriteToStream(Destination);
        }
    }
    #endregion

    public class CdAiApr : ComplexSaveStruct
    {
        protected Int32SaveStruct sid;
        protected Int32SaveStruct tn0;
        protected Int32SaveStruct tn1;

        #region Properties
        public Int32SaveStruct Sid
        {
            get { return sid; }
            set { sid = value; }
        }

        public Int32SaveStruct Tn0
        {
            get { return tn0; }
            set { tn0 = value; }
        }

        public Int32SaveStruct Tn1
        {
            get { return tn1; }
            set { tn1 = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public CdAiApr() : base()
        {
            this.sid = new Int32SaveStruct();
            this.tn0 = new Int32SaveStruct();
            this.tn1 = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.sid.ReadFromStream(Data);
            this.tn0.ReadFromStream(Data);
            this.tn1.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.sid.WriteToStream(Destination);
            this.tn0.WriteToStream(Destination);
            this.tn1.WriteToStream(Destination);
        }
    }
    #endregion

    /// <summary>Final top-level data structure. This encompasses the CDT and all CD structures.</summary>
    public class CdTable : ISotsStructure
    {
        protected ComplexArraySaveStruct<StringSaveStruct> cdt;
        protected CdPlayer cdplayer;
        protected CdAi[] cdai;

        public ComplexArraySaveStruct<StringSaveStruct> Cdt
        {
            get { return cdt; }
            set { cdt = value; }
        }

        public CdPlayer Cdplayer
        {
            get { return cdplayer; }
            set { cdplayer = value; }
        }

        public CdAi[] Cdai
        {
            get { return cdai; }
            set { cdai = value; }
        }

        /// <summary>Default constructor</summary>
        public CdTable()
        {
            this.cdt = new ComplexArraySaveStruct<StringSaveStruct>();
            this.cdplayer = new CdPlayer();
            this.cdai = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.cdt.ReadFromStream(Data);
            this.cdplayer.ReadFromStream(Data);

            this.cdai = new CdAi[this.cdt.Length.Value - 1];
            for (Int32 i = 0; i < this.cdai.Length; i++)
            {
                this.cdai[i] = new CdAi();
                this.cdai[i].ReadFromStream(Data);
            }
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.cdt.WriteToStream(Destination);
            this.cdplayer.WriteToStream(Destination);

            for (Int32 i = 0; i < this.cdai.Length; i++)
                this.cdai[i].WriteToStream(Destination);
        }
    }
}