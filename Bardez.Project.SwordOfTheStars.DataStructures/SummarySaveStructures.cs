using System;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    /// <summary>Settings struct for each</summary>
    public class PlayerSettingsSaveStruct : ComplexSaveStruct
    {
        /// <summary>Initial treasury savings per empire</summary>
        protected Int32SaveStruct initialTreasury;

        /// <summary>Initial colonies per empire</summary>
        protected Int32SaveStruct initialColonies;

        /// <summary>Initial technologies per empire</summary>
        protected Int32SaveStruct initialTechnologies;

        /// <summary>Initial game difficulty</summary>
        /// <value>0 = Easy; 1 = Normal; 2 = Difficult</value>
        protected Int32SaveStruct difficulty;   //turn into enum?

        /// <summary>Initial treasury savings per empire</summary>
        public Int32SaveStruct InitialTreasury
        {
            get { return initialTreasury; }
            set { initialTreasury = value; }
        }

        /// <summary>Initial colonies per empire</summary>
        public Int32SaveStruct InitialColonies
        {
            get { return initialColonies; }
            set { initialColonies = value; }
        }

        /// <summary>Initial technologies per empire</summary>
        public Int32SaveStruct InitialTechnologies
        {
            get { return initialTechnologies; }
            set { initialTechnologies = value; }
        }

        /// <summary>Initial game difficulty</summary>
        /// <value>0 = Easy; 1 = Normal; 2 = Difficult</value>
        public Int32SaveStruct Difficulty       //turn into enum?
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        /// <summary>Default constructor</summary>
        public PlayerSettingsSaveStruct() : base()
        {
            this.initialTreasury = new Int32SaveStruct();
            this.initialColonies = new Int32SaveStruct();
            this.initialTechnologies = new Int32SaveStruct();
            this.difficulty = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.initialTreasury.ReadFromStream(Data);
            this.initialColonies.ReadFromStream(Data);
            this.initialTechnologies.ReadFromStream(Data);
            this.difficulty.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.initialTreasury.WriteToStream(Destination);
            this.initialColonies.WriteToStream(Destination);
            this.initialTechnologies.WriteToStream(Destination);
            this.difficulty.WriteToStream(Destination);
        }
    }

    /// <summary>Slot struct in save file. Defines characteristics of an individual player slot.</summary>
    public class PlayerSlotWrapper : ComplexSaveStruct
    {
        protected PlayerSlotSaveStruct slot;

        /// <summary>(current?) Ranking in-game</summary>
        protected Int32SaveStruct rank;

        public PlayerSlotSaveStruct Slot
        {
            get { return slot; }
            set { slot = value; }
        }

        public Int32SaveStruct Rank
        {
            get { return rank; }
            set { rank = value; }
        }

        /// <summary>Default constructor</summary>
        public PlayerSlotWrapper() : base()
        {
            this.slot = new PlayerSlotSaveStruct();
            this.rank = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.Slot.ReadFromStream(Data);
            this.rank.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.Slot.WriteToStream(Destination);
            this.rank.WriteToStream(Destination);
        }
    }

    /// <summary>Slot struct in save file. Defines characteristics of an individual player slot.</summary>
    public class PlayerSlotSaveStruct : ComplexSaveStruct
    {
        /// <summary>Is this a player?</summary>
        /// <value>Seems to be true regardless. Maybe AI rebellion won't be?</value>
        protected BooleanSaveStruct isPlay;

        /// <summary>Is the player dead/defeated?</summary>
        protected BooleanSaveStruct isDead;

        /// <summary>Is Req(uired)?</summary>
        protected BooleanSaveStruct isReq;

        /// <summary>In Rec()?</summary>
        /// <value>I have only seen false so far</value>
        protected BooleanSaveStruct isRec;

        /// <summary>Is F(i)x(ed) N(a)m(e)?</summary>
        /// <remarks>I believe this refers to a fixed name.</remarks>
        protected BooleanSaveStruct isFxNm;

        /// <summary>F(i)x(ed) N(a)m(e)</summary>
        protected StringSaveStruct fxNm;

        /// <summary>IsFxSp?</summary>
        /// <remarks>Is Fixed Species?</remarks>
        protected BooleanSaveStruct isFxSp;

        /// <summary>FxSp</summary>
        /// <remarks>Identifier for a fixed species?</remarks>
        /// <value>0 = Human; 1 = Hiver; 2 = Tarka ; 3 = Liir; 5 = Zuul; 6 = Morrigi; 4 = ??? AI Rebellion?</value>
        protected Int32SaveStruct fxSp;

        /// <summary>Is Fixed CR</summary>
        /// <remarks>Is this the fixed color?</remarks>
        protected BooleanSaveStruct isFxCr;

        /// <summary>Fixed CR Id</summary>
        /// <value>
        ///     01 - Red
        ///     02 - Yellow
        ///     03 - Blue
        ///     04 - Pink/Mangeta
        ///     05 - Orange
        ///     06 - Green
        ///     07 - Aqua
        ///     08 - Gray
        ///     09 - Dark Green
        ///     10 - Purple
        /// </value>
        protected NestedInt32SaveStruct fxCrId;

        /// <summary>Is a fixed badge?</summary>
        protected BooleanSaveStruct isFxBd;

        /// <summary>Fixed badge name</summary>
        protected StringSaveStruct fxBd;

        /// <summary>Is fixed avatar?</summary>
        protected BooleanSaveStruct isFxAv;

        /// <summary>Fixed avater name</summary>
        protected StringSaveStruct fxAv;

        /// <summary>tag</summary>
        /// <remarks>This is often set to 0x7FFFFFFF, conveniently Int32.MaxValue</remarks>
        protected Int32SaveStruct tag;

        /// <summary>Pwd</summary>
        /// <remarks>password?</remarks>
        protected Int32SaveStruct pwd;

        /// <summary>Team number</summary>
        /// <remarks>Set to 0xFFFFFF (-1) if not valid (no teams)</remarks>
        protected Int32SaveStruct team;

        /// <summary>Initial player settings (Set at game start)</summary>
        protected PlayerSettingsSaveStruct settings;

        #region Properties
        public BooleanSaveStruct IsPlay
        {
            get { return isPlay; }
            set { isPlay = value; }
        }

        public BooleanSaveStruct IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        public BooleanSaveStruct IsReq
        {
            get { return isReq; }
            set { isReq = value; }
        }

        public BooleanSaveStruct IsRec
        {
            get { return isRec; }
            set { isRec = value; }
        }

        public BooleanSaveStruct IsFxNm
        {
            get { return isFxNm; }
            set { isFxNm = value; }
        }

        public StringSaveStruct FxNm
        {
            get { return fxNm; }
            set { fxNm = value; }
        }

        public BooleanSaveStruct IsFxSp
        {
            get { return isFxSp; }
            set { isFxSp = value; }
        }

        public Int32SaveStruct FxSp
        {
            get { return fxSp; }
            set { fxSp = value; }
        }

        public BooleanSaveStruct IsFxCr
        {
            get { return isFxCr; }
            set { isFxCr = value; }
        }

        public NestedInt32SaveStruct FxCrId
        {
            get { return fxCrId; }
            set { fxCrId = value; }
        }

        public BooleanSaveStruct IsFxBd
        {
            get { return isFxBd; }
            set { isFxBd = value; }
        }

        public StringSaveStruct FxBd
        {
            get { return fxBd; }
            set { fxBd = value; }
        }

        public BooleanSaveStruct IsFxAv
        {
            get { return isFxAv; }
            set { isFxAv = value; }
        }

        public StringSaveStruct FxAv
        {
            get { return fxAv; }
            set { fxAv = value; }
        }

        public Int32SaveStruct Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public Int32SaveStruct Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        public Int32SaveStruct Team
        {
            get { return team; }
            set { team = value; }
        }

        public PlayerSettingsSaveStruct Settings
        {
            get { return settings; }
            set { settings = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public PlayerSlotSaveStruct() : base()
        {
            this.isPlay = new BooleanSaveStruct();
            this.isDead = new BooleanSaveStruct();
            this.isReq = new BooleanSaveStruct();
            this.isRec = new BooleanSaveStruct();
            this.isFxNm = new BooleanSaveStruct();
            this.fxNm = new StringSaveStruct();
            this.isFxSp = new BooleanSaveStruct();
            this.fxSp = new Int32SaveStruct();
            this.isFxCr = new BooleanSaveStruct();
            this.fxCrId = new NestedInt32SaveStruct();
            this.isFxBd = new BooleanSaveStruct();
            this.fxBd = new StringSaveStruct();
            this.isFxAv = new BooleanSaveStruct();
            this.fxAv = new StringSaveStruct();
            this.tag = new Int32SaveStruct();
            this.pwd = new Int32SaveStruct();
            this.team = new Int32SaveStruct();
            this.settings = new PlayerSettingsSaveStruct();
        }


        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.isPlay.ReadFromStream(Data);
            this.isDead.ReadFromStream(Data);
            this.isReq.ReadFromStream(Data);
            this.isRec.ReadFromStream(Data);
            this.isFxNm.ReadFromStream(Data);
            this.fxNm.ReadFromStream(Data);
            this.isFxSp.ReadFromStream(Data);
            this.fxSp.ReadFromStream(Data);
            this.isFxCr.ReadFromStream(Data);
            this.fxCrId.ReadFromStream(Data);
            this.isFxBd.ReadFromStream(Data);
            this.fxBd.ReadFromStream(Data);
            this.isFxAv.ReadFromStream(Data);
            this.fxAv.ReadFromStream(Data);
            this.tag.ReadFromStream(Data);
            this.pwd.ReadFromStream(Data);
            this.team.ReadFromStream(Data);
            this.settings.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.isPlay.WriteToStream(Destination);
            this.isDead.WriteToStream(Destination);
            this.isReq.WriteToStream(Destination);
            this.isRec.WriteToStream(Destination);
            this.isFxNm.WriteToStream(Destination);
            this.fxNm.WriteToStream(Destination);
            this.isFxSp.WriteToStream(Destination);
            this.fxSp.WriteToStream(Destination);
            this.isFxCr.WriteToStream(Destination);
            this.fxCrId.WriteToStream(Destination);
            this.isFxBd.WriteToStream(Destination);
            this.fxBd.WriteToStream(Destination);
            this.isFxAv.WriteToStream(Destination);
            this.fxAv.WriteToStream(Destination);
            this.tag.WriteToStream(Destination);
            this.pwd.WriteToStream(Destination);
            this.team.WriteToStream(Destination);
            this.settings.WriteToStream(Destination);
        }
    }

    public class SessionSaveStruct : ComplexSaveStruct
    {
        protected TmrsSaveStruct tmrs;

        public TmrsSaveStruct Tmrs
        {
            get { return tmrs; }
            set { tmrs = value; }
        }

        /// <summary>Default constructor</summary>
        public SessionSaveStruct() : base()
        {
            this.tmrs = new TmrsSaveStruct();
        }
        
        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.tmrs.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.tmrs.WriteToStream(Destination);
        }
    }

    public class TmrsSaveStruct : ComplexSaveStruct
    {
        /// <remarks>0x7F7FFFFF</remarks>
        protected Int32SaveStruct tstl;

        /// <summary>0x42700000</summary>
        protected Int32SaveStruct tctl;

        /// <remarks>0x7F7FFFFF</remarks>
        protected Int32SaveStruct tqtl;

        /// <remarks>0x00000000</remarks>
        protected Int32SaveStruct tqtle;

        public Int32SaveStruct Tstl
        {
            get { return tstl; }
            set { tstl = value; }
        }

        protected Int32SaveStruct Tctl
        {
            get { return tctl; }
            set { tctl = value; }
        }

        protected Int32SaveStruct Tqtl
        {
            get { return tqtl; }
            set { tqtl = value; }
        }

        protected Int32SaveStruct Tqtle
        {
            get { return tqtle; }
            set { tqtle = value; }
        }

        /// <summary>Default constructor</summary>
        public TmrsSaveStruct() : base()
        {
            this.tstl = new Int32SaveStruct();
            this.tctl = new Int32SaveStruct();
            this.tqtl = new Int32SaveStruct();
            this.tqtle = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.tstl.ReadFromStream(Data);
            this.tctl.ReadFromStream(Data);
            this.tqtl.ReadFromStream(Data);
            this.tqtle.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.tstl.WriteToStream(Destination);
            this.tctl.WriteToStream(Destination);
            this.tqtl.WriteToStream(Destination);
            this.tqtle.WriteToStream(Destination);
        }
    }
    
    /// <summary>Contains summary data of the save file.</summary>
    /// <remarks>One of a handful of top-level structures in the save file format.</remarks>
    public class SummarySaveStruct : ComplexSaveStruct
    {
        /// <summary>Name of the game</summary>
        protected StringSaveStruct gameName;

        /// <summary>Turn number</summary>
        protected Int32SaveStruct turn;

        /// <summary>Number of systems</summary>
        protected Int32SaveStruct numSys;

        /// <remakrs>Some checksum. Must look into.</remakrs>
        protected Int32SaveStruct checkSum;

        protected ComplexArraySaveStruct<PlayerSlotWrapper> players;
        protected SessionSaveStruct session;
        protected Int32SaveStruct mapShape;
        protected Int32SaveStruct incMod;
        protected Int32SaveStruct resMod;
        protected BooleanSaveStruct alliances;
        protected BooleanSaveStruct teams;
        protected BooleanSaveStruct encounters;
        protected StringSaveStruct scenario;

        #region Properties
        public StringSaveStruct GameName
        {
            get { return gameName; }
            set { gameName = value; }
        }

        public Int32SaveStruct Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public Int32SaveStruct NumSys
        {
            get { return numSys; }
            set { numSys = value; }
        }

        public Int32SaveStruct CheckSum
        {
            get { return checkSum; }
            set { checkSum = value; }
        }

        public ComplexArraySaveStruct<PlayerSlotWrapper> Players
        {
            get { return players; }
            set { players = value; }
        }

        public SessionSaveStruct Session
        {
            get { return session; }
            set { session = value; }
        }

        public Int32SaveStruct MapShape
        {
            get { return mapShape; }
            set { mapShape = value; }
        }

        public Int32SaveStruct IncMod
        {
            get { return incMod; }
            set { incMod = value; }
        }

        public Int32SaveStruct ResMod
        {
            get { return resMod; }
            set { resMod = value; }
        }

        public BooleanSaveStruct Alliances
        {
            get { return alliances; }
            set { alliances = value; }
        }

        public BooleanSaveStruct Teams
        {
            get { return teams; }
            set { teams = value; }
        }

        public BooleanSaveStruct Encounters
        {
            get { return encounters; }
            set { encounters = value; }
        }

        public StringSaveStruct Scenario
        {
            get { return scenario; }
            set { scenario = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SummarySaveStruct() : base()
        {
            this.gameName = new StringSaveStruct();
            this.turn = new Int32SaveStruct();
            this.numSys = new Int32SaveStruct();
            this.checkSum = new Int32SaveStruct();
            this.players = new ComplexArraySaveStruct<PlayerSlotWrapper>();
            this.session = new SessionSaveStruct();
            this.mapShape = new Int32SaveStruct();
            this.incMod = new Int32SaveStruct();
            this.resMod = new Int32SaveStruct();
            this.alliances = new BooleanSaveStruct();
            this.teams = new BooleanSaveStruct();
            this.encounters = new BooleanSaveStruct();
            this.scenario = new StringSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.gameName.ReadFromStream(Data);
            this.turn.ReadFromStream(Data);
            this.numSys.ReadFromStream(Data);
            this.checkSum.ReadFromStream(Data);
            this.players.ReadFromStream(Data);
            this.session.ReadFromStream(Data);
            this.mapShape.ReadFromStream(Data);
            this.incMod.ReadFromStream(Data);
            this.resMod.ReadFromStream(Data);
            this.alliances.ReadFromStream(Data);
            this.teams.ReadFromStream(Data);
            this.encounters.ReadFromStream(Data);
            this.scenario.ReadFromStream(Data);

            //injection into global settings
            GlobalSaveSettings.NumberOfPlayers = this.players.Length.Value;
            GlobalSaveSettings.NumberOfSystems = this.numSys.Value;
            GlobalSaveSettings.NumberOfTurns = this.turn.Value;
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.gameName.WriteToStream(Destination);
            this.turn.WriteToStream(Destination);
            this.numSys.WriteToStream(Destination);
            this.checkSum.WriteToStream(Destination);
            this.players.WriteToStream(Destination);
            this.session.WriteToStream(Destination);
            this.mapShape.WriteToStream(Destination);
            this.incMod.WriteToStream(Destination);
            this.resMod.WriteToStream(Destination);
            this.alliances.WriteToStream(Destination);
            this.teams.WriteToStream(Destination);
            this.encounters.WriteToStream(Destination);
            this.scenario.WriteToStream(Destination);
        }
    }
}