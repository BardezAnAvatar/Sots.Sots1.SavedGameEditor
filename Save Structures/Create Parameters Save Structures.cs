using System;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    public class PlanetSaveStruct : ComplexSaveStruct
    {
        /// <remarks>this is just a guess, actually...</remarks>
        protected SpatialCoordinateSaveStruct coordinates;

        /// <value>0x7FFFFFFF</value>
        protected Int32SaveStruct unknown1;

        /// <value>0x7FFFFFFF</value>
        protected Int32SaveStruct unknown2;

        /// <value>0x7F7FFFFF</value>
        protected Int32SaveStruct unknown3;

        /// <value>0x7F7FFFFF</value>
        protected Int32SaveStruct unknown4;

        public SpatialCoordinateSaveStruct Coordinates
        {
            get { return coordinates; }
            set { coordinates = value; }
        }

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

        public Int32SaveStruct Unknown3
        {
            get { return unknown3; }
            set { unknown3 = value; }
        }

        public Int32SaveStruct Unknown4
        {
            get { return unknown3; }
            set { unknown3 = value; }
        }

        /// <summary>Default constructor</summary>
        public PlanetSaveStruct() : base()
        {
            this.coordinates = new SpatialCoordinateSaveStruct();
            this.unknown1 = new Int32SaveStruct();
            this.unknown2 = new Int32SaveStruct();
            this.unknown3 = new Int32SaveStruct();
            this.unknown4 = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.coordinates.ReadFromStream(Data);
            this.unknown1.ReadFromStream(Data);
            this.unknown2.ReadFromStream(Data);
            this.unknown3.ReadFromStream(Data);
            this.unknown4.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.coordinates.WriteToStream(Destination);
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
            this.unknown3.WriteToStream(Destination);
            this.unknown4.WriteToStream(Destination);
        }
    }

    public class MapPNpc : ComplexSaveStruct
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
        public MapPNpc() : base()
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
    
    /// <summary>Map details</summary>
    /// <remarks>
    ///     starts with an unknown, followed by an array of all the planets
    ///     
    ///     I *think* next is an array of forces, players + independant colonies
    ///     it appears that the first set is a non-complex array of players, and the rest is an array of NPCs (indies?)
    /// </remarks>
    public class MapPSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct unknown1;
        protected ComplexArraySaveStruct<PlanetSaveStruct> planetArray;
        
        /// <remarks>seems to be a non-complex array of players</remarks>
        protected NonComplexArraySaveStruct<ComplexArraySaveStruct<Int32SaveStruct>> players;

        /// <summary>Seems to be number of players - 1</summary>
        protected ComplexArraySaveStruct<MapPNpc> npcArray;

        public Int32SaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public ComplexArraySaveStruct<PlanetSaveStruct> PlanetArray
        {
            get { return planetArray; }
            set { planetArray = value; }
        }

        public NonComplexArraySaveStruct<ComplexArraySaveStruct<Int32SaveStruct>> Players
        {
            get { return players; }
            set { players = value; }
        }

        public ComplexArraySaveStruct<MapPNpc> NpcArray
        {
            get { return npcArray; }
            set { npcArray = value; }
        }


        /// <summary>Default constructor</summary>
        public MapPSaveStruct() : base()
        {
            this.unknown1 = new Int32SaveStruct();
            this.planetArray = new ComplexArraySaveStruct<PlanetSaveStruct>();
            this.players = new NonComplexArraySaveStruct<ComplexArraySaveStruct<Int32SaveStruct>>();
            this.npcArray = new ComplexArraySaveStruct<MapPNpc>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.unknown1.ReadFromStream(Data);
            this.planetArray.ReadFromStream(Data);
            this.players.ReadFromStream(Data);
            this.npcArray.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.planetArray.WriteToStream(Destination);
            this.players.WriteToStream(Destination);
            this.npcArray.WriteToStream(Destination);
        }
    }

    public class ScrpSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct spc;

        public Int32SaveStruct Spc
        {
            get { return spc; }
            set { spc = value; }
        }

        /// <summary>Default constructor</summary>
        public ScrpSaveStruct() : base()
        {
            this.spc = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.spc.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.spc.WriteToStream(Destination);
        }
    }
    
    public class CreateParametersSaveStruct : ComplexSaveStruct
    {
        protected StringSaveStruct name;
        protected Int32SaveStruct id;
        protected Int32SaveStruct rSeed;

        /// <value>I have seen 0, 1 and 2 (0 twice so far)</value>
        protected Int32SaveStruct aid;

        /// <value>I have only seen 0 so far -- this is a string</value>
        protected StringSaveStruct key;

        protected MapPSaveStruct mapP;
        protected Int32SaveStruct mapS;
        protected Int32SaveStruct mapF;

        /// <summary>Number of systems</summary>
        protected Int32SaveStruct nSys;

        /// <summary>Random encounter rate</summary>
        protected FloatSaveStruct rEnc;

        protected Int32SaveStruct sDist;

        /// <remarks>I think this is a float, but not sure</remarks>
        protected FloatSaveStruct sSize;

        protected FloatSaveStruct sRes;
        protected Int32SaveStruct sSuit;
        protected Int32SaveStruct maxP;
        protected Int32SaveStruct aSpec;
        protected BooleanSaveStruct bAlly;
        protected Int32SaveStruct nTeam;
        protected BooleanSaveStruct tmgrp;

        /// <summary>Player savings?</summary>
        protected Int32SaveStruct pSav;

        /// <summary>Player colonies?</summary>
        protected Int32SaveStruct pCol;

        /// <summary>Player technologies?</summary>
        protected Int32SaveStruct pTech;

        /// <summary>Economic efficiency multiplier?</summary>
        protected FloatSaveStruct incM;

        /// <summary>Research efficiency multiplier?</summary>
        protected FloatSaveStruct resM;

        protected ScrpSaveStruct scrp;

        #region Properties
        public StringSaveStruct Name
        {
            get { return name; }
            set { name = value; }
        }

        public Int32SaveStruct Id
        {
            get { return id; }
            set { id = value; }
        }

        public Int32SaveStruct RSeed
        {
            get { return rSeed; }
            set { rSeed = value; }
        }

        public Int32SaveStruct Aid
        {
            get { return aid; }
            set { aid = value; }
        }

        public StringSaveStruct Key
        {
            get { return key; }
            set { key = value; }
        }

        public MapPSaveStruct MapP
        {
            get { return mapP; }
            set { mapP = value; }
        }

        public Int32SaveStruct MapS
        {
            get { return mapS; }
            set { mapS = value; }
        }

        public Int32SaveStruct MapF
        {
            get { return mapF; }
            set { mapF = value; }
        }

        public Int32SaveStruct NSys
        {
            get { return nSys; }
            set { nSys = value; }
        }

        public FloatSaveStruct REnc
        {
            get { return rEnc; }
            set { rEnc = value; }
        }

        public Int32SaveStruct SDist
        {
            get { return sDist; }
            set { sDist = value; }
        }

        public FloatSaveStruct SSize
        {
            get { return sSize; }
            set { sSize = value; }
        }

        public FloatSaveStruct SRes
        {
            get { return sRes; }
            set { sRes = value; }
        }

        public Int32SaveStruct SSuit
        {
            get { return sSuit; }
            set { sSuit = value; }
        }

        public Int32SaveStruct MaxP
        {
            get { return maxP; }
            set { maxP = value; }
        }

        public Int32SaveStruct ASpec
        {
            get { return aSpec; }
            set { aSpec = value; }
        }

        public BooleanSaveStruct BAlly
        {
            get { return bAlly; }
            set { bAlly = value; }
        }

        public Int32SaveStruct NTeam
        {
            get { return nTeam; }
            set { nTeam = value; }
        }

        public BooleanSaveStruct Tmgrp
        {
            get { return tmgrp; }
            set { tmgrp = value; }
        }

        public Int32SaveStruct PSav
        {
            get { return pSav; }
            set { pSav = value; }
        }

        public Int32SaveStruct PCol
        {
            get { return pCol; }
            set { pCol = value; }
        }

        public Int32SaveStruct PTech
        {
            get { return pTech; }
            set { pTech = value; }
        }

        public FloatSaveStruct IncM
        {
            get { return incM; }
            set { incM = value; }
        }

        public FloatSaveStruct ResM
        {
            get { return resM; }
            set { resM = value; }
        }

        public ScrpSaveStruct Scrp
        {
            get { return scrp; }
            set { scrp = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public CreateParametersSaveStruct() : base()
        {
            this.name = new StringSaveStruct();
            this.id = new Int32SaveStruct();
            this.rSeed = new Int32SaveStruct();
            this.aid = new Int32SaveStruct();
            this.key = new StringSaveStruct();
            this.mapP = new MapPSaveStruct();
            this.mapS = new Int32SaveStruct();
            this.mapF = new Int32SaveStruct();
            this.nSys = new Int32SaveStruct();
            this.rEnc = new FloatSaveStruct();
            this.sDist = new Int32SaveStruct();
            this.sSize = new FloatSaveStruct();
            this.sRes = new FloatSaveStruct();
            this.sSuit = new Int32SaveStruct();
            this.maxP = new Int32SaveStruct();
            this.aSpec = new Int32SaveStruct();
            this.bAlly = new BooleanSaveStruct();
            this.nTeam = new Int32SaveStruct();
            this.tmgrp = new BooleanSaveStruct();
            this.pSav = new Int32SaveStruct();
            this.pCol = new Int32SaveStruct();
            this.pTech = new Int32SaveStruct();
            this.incM = new FloatSaveStruct();
            this.resM = new FloatSaveStruct();
            this.scrp = new ScrpSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.name.ReadFromStream(Data);
            this.id.ReadFromStream(Data);
            this.rSeed.ReadFromStream(Data);
            this.aid.ReadFromStream(Data);
            this.key.ReadFromStream(Data);
            this.mapP.ReadFromStream(Data);
            this.mapS.ReadFromStream(Data);
            this.mapF.ReadFromStream(Data);
            this.nSys.ReadFromStream(Data);
            this.rEnc.ReadFromStream(Data);
            this.sDist.ReadFromStream(Data);
            this.sSize.ReadFromStream(Data);
            this.sRes.ReadFromStream(Data);
            this.sSuit.ReadFromStream(Data);
            this.maxP.ReadFromStream(Data);
            this.aSpec.ReadFromStream(Data);
            this.bAlly.ReadFromStream(Data);
            this.nTeam.ReadFromStream(Data);
            this.tmgrp.ReadFromStream(Data);
            this.pSav.ReadFromStream(Data);
            this.pCol.ReadFromStream(Data);
            this.pTech.ReadFromStream(Data);
            this.incM.ReadFromStream(Data);
            this.resM.ReadFromStream(Data);
            this.scrp.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.name.WriteToStream(Destination);
            this.id.WriteToStream(Destination);
            this.rSeed.WriteToStream(Destination);
            this.aid.WriteToStream(Destination);
            this.key.WriteToStream(Destination);
            this.mapP.WriteToStream(Destination);
            this.mapS.WriteToStream(Destination);
            this.mapF.WriteToStream(Destination);
            this.nSys.WriteToStream(Destination);
            this.rEnc.WriteToStream(Destination);
            this.sDist.WriteToStream(Destination);
            this.sSize.WriteToStream(Destination);
            this.sRes.WriteToStream(Destination);
            this.sSuit.WriteToStream(Destination);
            this.maxP.WriteToStream(Destination);
            this.aSpec.WriteToStream(Destination);
            this.bAlly.WriteToStream(Destination);
            this.nTeam.WriteToStream(Destination);
            this.tmgrp.WriteToStream(Destination);
            this.pSav.WriteToStream(Destination);
            this.pCol.WriteToStream(Destination);
            this.pTech.WriteToStream(Destination);
            this.incM.WriteToStream(Destination);
            this.resM.WriteToStream(Destination);
            this.scrp.WriteToStream(Destination);
        }
    }
}