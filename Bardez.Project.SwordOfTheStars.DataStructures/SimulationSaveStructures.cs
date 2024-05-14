using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bardez.Project.SwordOfTheStars.DataStructures
{
    //Note: SimSystemDetailSpiesArray, SimSvSctObXscnXsc not defined.
    //Note: SimSystemDetailSpy needs to be populated
    //Note: are Preps constructed properly?
    //Note: SimScSctObEncObjDetails is wrong. it is an array (non-complex) followed by an infest array (complex)


    #region Random Number Generation
    public class RngSaveStruct : ComplexSaveStruct
    {
        /// <remarks>
        ///     Indeterminate constant length of 2497 - 2500.
        ///     It seems that it is 2500, but always has 2-3 NULLs for the end data,
        ///     which kind of screws with a "random seed" theory, since trailing constant values generally
        ///     tend to upset randomness.
        /// 
        ///     However, if it was 2499, then the end marker would come four bytes earlier. So I will assume
        ///     the length is 2500 with 2-3 trailing 0's, then NUL padding
        /// </remarks>
        private const Int32 RngLength = 2500;
        protected ByteArraySaveStruct unknownData;   //2500

        public ByteArraySaveStruct UnknownData
        {
            get { return unknownData; }
            set { unknownData = value; }
        }

        /// <summary>Default constructor</summary>
        public RngSaveStruct() : base()
        {
            this.unknownData = new ByteArraySaveStruct();
            this.unknownData.Length = RngLength;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.unknownData.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknownData.WriteToStream(Destination);
        }
    }
    #endregion

    
    #region PopG - A bit generic / shared
    public class SimPopGSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct popT;
        protected Int32SaveStruct popS;
        protected Int64SaveStruct popC;     //civilian population?

        public Int32SaveStruct PopT
        {
            get { return popT; }
            set { popT = value; }
        }

        public Int32SaveStruct PopS
        {
            get { return popS; }
            set { popS = value; }
        }

        public Int64SaveStruct PopC
        {
            get { return popC; }
            set { popC = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPopGSaveStruct() : base()
        {
            this.popT = new Int32SaveStruct();
            this.popS = new Int32SaveStruct();
            this.popC = new Int64SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.popT.ReadFromStream(Data);
            this.popS.ReadFromStream(Data);
            this.popC.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.popT.WriteToStream(Destination);
            this.popS.WriteToStream(Destination);
            this.popC.WriteToStream(Destination);
        }
    }
    #endregion

    #region Sprjs - Technologies / Projects? Special Projects?
    public class ResearchSaveStruct : ISotsStructure
    {
        /// <remarks>Should this be a boolean indicating the presence of two optional values, usp & usc?</remarks>

        protected NonComplexArraySaveStruct<ResearchOptionalSaveStruct> us;

        /// <summary>Name</summary>
        protected StringSaveStruct nm;
        protected StringSaveStruct ntg;

        public NonComplexArraySaveStruct<ResearchOptionalSaveStruct> Us
        {
            get { return us; }
            set { us = value; }
        }

        public StringSaveStruct Nm
        {
            get { return nm; }
            set { nm = value; }
        }

        public StringSaveStruct Ntg
        {
            get { return ntg; }
            set { ntg = value; }
        }

        /// <summary>Default constructor</summary>
        public ResearchSaveStruct() : base()
        {
            this.us = new NonComplexArraySaveStruct<ResearchOptionalSaveStruct>();
            this.nm = new StringSaveStruct();
            this.ntg = new StringSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.us.ReadFromStream(Data);
            this.nm.ReadFromStream(Data);
            this.ntg.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.us.WriteToStream(Destination);
            this.nm.WriteToStream(Destination);
            this.ntg.WriteToStream(Destination);
        }
    }

    public class ResearchOptionalSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct usc;
        protected Int32SaveStruct usp;

        public Int32SaveStruct Usnc
        {
            get { return usc; }
            set { usc = value; }
        }

        public Int32SaveStruct Usnp
        {
            get { return usp; }
            set { usp = value; }
        }

        /// <summary>Default constructor</summary>
        public ResearchOptionalSaveStruct() : base()
        {
            this.usc = new Int32SaveStruct();
            this.usp = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.usc.ReadFromStream(Data);
            this.usp.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.usc.WriteToStream(Destination);
            this.usp.WriteToStream(Destination);
        }
    }
    #endregion

    #region Turn statistics / History
    public class TurnPly : ISotsStructure
    {
        /// <remarks>more of an ID than anything</remarks>
        protected Int32SaveStruct ply;

        protected PlyHistSaveStruct hist;

        public Int32SaveStruct Ply
        {
            get { return ply; }
            set { ply = value; }
        }

        public PlyHistSaveStruct Hist
        {
            get { return hist; }
            set { hist = value; }
        }

        /// <summary>Default constructor</summary>
        public TurnPly()
        {
            this.ply = new Int32SaveStruct();
            this.hist = new PlyHistSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.ply.ReadFromStream(Data);
            this.hist.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.ply.WriteToStream(Destination);
            this.hist.WriteToStream(Destination);
        }
    }

    public class PlyHistSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct ply;

        /// <summary>It would appear to be one stat structure per turn</summary>
        protected PlyHistStatsSaveStruct[] stats;

        public Int32SaveStruct Ply
        {
            get { return ply; }
            set { ply = value; }
        }

        public PlyHistStatsSaveStruct[] Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        /// <summary>Default constructor</summary>
        public PlyHistSaveStruct() : base()
        {
            this.ply = new Int32SaveStruct();
            this.stats = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ply.ReadFromStream(Data);

            this.stats = new PlyHistStatsSaveStruct[GlobalSaveSettings.NumberOfTurns];
            for (Int32 i = 0; i < stats.Length; i++)
            {
                this.stats[i] = new PlyHistStatsSaveStruct();
                this.stats[i].ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ply.WriteToStream(Destination);
            for (Int32 i = 0; i < stats.Length; i++)
                this.stats[i].WriteToStream(Destination);
        }
    }

    public class PlyHistStatsSacq : ComplexSaveStruct
    {
        protected Int32SaveStruct set;
        protected Int32SaveStruct ses;
        protected Int32SaveStruct seop;
        protected Int32SaveStruct senp;
        //protected Int32SaveStruct seno2;
        protected NonComplexArraySaveStruct<Int32SaveStruct> seo;

        #region Properties
		public Int32SaveStruct Set
        {
            get { return set; }
            set { set = value; }
        }

        public Int32SaveStruct Ses
        {
            get { return ses; }
            set { ses = value; }
        }

        public Int32SaveStruct Seop
        {
            get { return seop; }
            set { seop = value; }
        }

        public Int32SaveStruct Senp
        {
            get { return senp; }
            set { senp = value; }
        }

        //public Int32SaveStruct Seno2
        //{
        //    get { return seno2; }
        //    set { seno2 = value; }
        //}

        public NonComplexArraySaveStruct<Int32SaveStruct> Seo
        {
            get { return seo; }
            set { seo = value; }
        }
	    #endregion

        /// <summary>Default constructor</summary>
        public PlyHistStatsSacq() : base()
        {
            this.set = new Int32SaveStruct();
            this.ses = new Int32SaveStruct();
            this.seop = new Int32SaveStruct();
            this.senp = new Int32SaveStruct();
            //this.seno2 = new Int32SaveStruct();
            this.seo = new NonComplexArraySaveStruct<Int32SaveStruct>();
        }
        
        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.set.ReadFromStream(Data);
            this.ses.ReadFromStream(Data);
            this.seop.ReadFromStream(Data);
            this.senp.ReadFromStream(Data);
            //this.seno2.ReadFromStream(Data);
            this.seo.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.set.WriteToStream(Destination);
            this.ses.WriteToStream(Destination);
            this.seop.WriteToStream(Destination);
            this.senp.WriteToStream(Destination);
            //this.seno2.WriteToStream(Destination);
            this.seo.WriteToStream(Destination);
        }
    }

    public class PlyHistStatsSaveStruct : ComplexSaveStruct
    {
        protected Int64SaveStruct pop;
        protected ComplexArraySaveStruct<PlyHistStatsSacq> sacq;
        protected ComplexArraySaveStruct<PlyHistStatsSacq> slost;
        protected Int32SaveStruct trn;
        protected Int32SaveStruct almem;
        protected Int32SaveStruct inc;
        protected Int32SaveStruct tdinc;
        protected Int32SaveStruct sav;
        protected Int32SaveStruct col;
        protected Int32SaveStruct bat;
        protected Int32SaveStruct tch;
        protected NonComplexArraySaveStruct<PlyHistClsSaveStruct> cls;

        #region Properties
        public Int64SaveStruct Pop
        {
            get { return pop; }
            set { pop = value; }
        }

        public ComplexArraySaveStruct<PlyHistStatsSacq> Sacq
        {
            get { return sacq; }
            set { sacq = value; }
        }

        public ComplexArraySaveStruct<PlyHistStatsSacq> Slost
        {
            get { return slost; }
            set { slost = value; }
        }

        public Int32SaveStruct Trn
        {
            get { return trn; }
            set { trn = value; }
        }

        public Int32SaveStruct Almem
        {
            get { return almem; }
            set { almem = value; }
        }

        public Int32SaveStruct Inc
        {
            get { return inc; }
            set { inc = value; }
        }

        public Int32SaveStruct Tdinc
        {
            get { return tdinc; }
            set { tdinc = value; }
        }

        public Int32SaveStruct Sav
        {
            get { return sav; }
            set { sav = value; }
        }

        public Int32SaveStruct Col
        {
            get { return col; }
            set { col = value; }
        }

        public Int32SaveStruct Bat
        {
            get { return bat; }
            set { bat = value; }
        }

        public Int32SaveStruct Tch
        {
            get { return tch; }
            set { tch = value; }
        }

        public NonComplexArraySaveStruct<PlyHistClsSaveStruct> Cls
        {
            get { return cls; }
            set { cls = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public PlyHistStatsSaveStruct() : base()
        {
            this.pop = new Int64SaveStruct();
            this.sacq = new  ComplexArraySaveStruct<PlyHistStatsSacq>();
            this.slost = new ComplexArraySaveStruct<PlyHistStatsSacq>();
            this.trn = new Int32SaveStruct();
            this.almem = new Int32SaveStruct();
            this.inc = new Int32SaveStruct();
            this.tdinc = new Int32SaveStruct();
            this.sav = new Int32SaveStruct();
            this.col = new Int32SaveStruct();
            this.bat = new Int32SaveStruct();
            this.tch = new Int32SaveStruct();
            this.cls = new NonComplexArraySaveStruct<PlyHistClsSaveStruct>();
        }


        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.pop.ReadFromStream(Data);
            this.sacq.ReadFromStream(Data);
            this.slost.ReadFromStream(Data);
            this.trn.ReadFromStream(Data);
            this.almem.ReadFromStream(Data);
            this.inc.ReadFromStream(Data);
            this.tdinc.ReadFromStream(Data);
            this.sav.ReadFromStream(Data);
            this.col.ReadFromStream(Data);
            this.bat.ReadFromStream(Data);
            this.tch.ReadFromStream(Data);
            this.cls.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.pop.WriteToStream(Destination);
            this.sacq.WriteToStream(Destination);
            this.slost.WriteToStream(Destination);
            this.trn.WriteToStream(Destination);
            this.almem.WriteToStream(Destination);
            this.inc.WriteToStream(Destination);
            this.tdinc.WriteToStream(Destination);
            this.sav.WriteToStream(Destination);
            this.col.WriteToStream(Destination);
            this.bat.WriteToStream(Destination);
            this.tch.WriteToStream(Destination);
            this.cls.WriteToStream(Destination);
        }
    }

    public class PlyHistClsSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct cls;
        protected Int32SaveStruct shpt;
        protected Int32SaveStruct shpl;
        protected Int32SaveStruct shpk;
        protected Int32SaveStruct satt;
        protected Int32SaveStruct satl;
        protected Int32SaveStruct satk;

        #region Properties
        public Int32SaveStruct Cls
        {
            get { return cls; }
            set { cls = value; }
        }

        public Int32SaveStruct Shpt
        {
            get { return shpt; }
            set { shpt = value; }
        }

        public Int32SaveStruct Shpl
        {
            get { return shpl; }
            set { shpl = value; }
        }

        public Int32SaveStruct Shpk
        {
            get { return shpk; }
            set { shpk = value; }
        }

        public Int32SaveStruct Satt
        {
            get { return satt; }
            set { satt = value; }
        }

        public Int32SaveStruct Satl
        {
            get { return satl; }
            set { satl = value; }
        }

        public Int32SaveStruct Satk
        {
            get { return satk; }
            set { satk = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public PlyHistClsSaveStruct()
        {
            this.cls = new Int32SaveStruct();
            this.shpt = new Int32SaveStruct();
            this.shpl = new Int32SaveStruct();
            this.shpk = new Int32SaveStruct();
            this.satt = new Int32SaveStruct();
            this.satl = new Int32SaveStruct();
            this.satk = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.cls.ReadFromStream(Data);
            this.shpt.ReadFromStream(Data);
            this.shpl.ReadFromStream(Data);
            this.shpk.ReadFromStream(Data);
            this.satt.ReadFromStream(Data);
            this.satl.ReadFromStream(Data);
            this.satk.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.cls.WriteToStream(Destination);
            this.shpt.WriteToStream(Destination);
            this.shpl.WriteToStream(Destination);
            this.shpk.WriteToStream(Destination);
            this.satt.WriteToStream(Destination);
            this.satl.WriteToStream(Destination);
            this.satk.WriteToStream(Destination);
        }
    }
    #endregion
    
    #region Sim Crep
    public class SimCrepSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct cid;
        protected Int32SaveStruct trn;
        protected SpatialCoordinateSaveStruct pos;
        protected Int32SaveStruct sid;
        protected Int32SaveStruct auto;
        protected Int32SaveStruct dur;
        protected Int32SaveStruct cow;
        protected Int32SaveStruct cdst;
        protected Int32SaveStruct cpk;
        protected Int32SaveStruct cpt;
        protected Int32SaveStruct cdt;
        protected Int32SaveStruct cdi;
        protected ComplexArraySaveStruct<SimCrepPrepSaveStruct> prep;
        protected ComplexArraySaveStruct<SimCrepWrepSaveStruct> wrep;

        #region Properties
        public Int32SaveStruct Cid
        {
            get { return cid; }
            set { cid = value; }
        }

        public Int32SaveStruct Trn
        {
            get { return trn; }
            set { trn = value; }
        }

        public SpatialCoordinateSaveStruct Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public Int32SaveStruct Sid
        {
            get { return sid; }
            set { sid = value; }
        }

        public Int32SaveStruct Auto
        {
            get { return auto; }
            set { auto = value; }
        }

        public Int32SaveStruct Dur
        {
            get { return dur; }
            set { dur = value; }
        }

        public Int32SaveStruct Cow
        {
            get { return cow; }
            set { cow = value; }
        }

        public Int32SaveStruct Cdst
        {
            get { return cdst; }
            set { cdst = value; }
        }

        public Int32SaveStruct Cpk
        {
            get { return cpk; }
            set { cpk = value; }
        }

        public Int32SaveStruct Cpt
        {
            get { return cpt; }
            set { cpt = value; }
        }

        public Int32SaveStruct Cdt
        {
            get { return cdt; }
            set { cdt = value; }
        }

        public Int32SaveStruct Cdi
        {
            get { return cdi; }
            set { cdi = value; }
        }

        public ComplexArraySaveStruct<SimCrepPrepSaveStruct> Prep
        {
            get { return prep; }
            set { prep = value; }
        }

        public ComplexArraySaveStruct<SimCrepWrepSaveStruct> Wrep
        {
            get { return wrep; }
            set { wrep = value; }
        }
        
        #endregion

        /// <summary>Default constructor</summary>
        public SimCrepSaveStruct() : base()
        {
            this.cid = new Int32SaveStruct();
            this.trn = new Int32SaveStruct();
            this.pos= new SpatialCoordinateSaveStruct();
            this.sid = new Int32SaveStruct();
            this.auto = new Int32SaveStruct();
            this.dur = new Int32SaveStruct();
            this.cow = new Int32SaveStruct();
            this.cdst = new Int32SaveStruct();
            this.cpk = new Int32SaveStruct();
            this.cpt = new Int32SaveStruct();
            this.cdt = new Int32SaveStruct();
            this.cdi = new Int32SaveStruct();
            this.prep = new ComplexArraySaveStruct<SimCrepPrepSaveStruct>();
            this.wrep = new ComplexArraySaveStruct<SimCrepWrepSaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.cid.ReadFromStream(Data);
            this.trn.ReadFromStream(Data);
            this.pos.ReadFromStream(Data);
            this.sid.ReadFromStream(Data);
            this.auto.ReadFromStream(Data);
            this.dur.ReadFromStream(Data);
            this.cow.ReadFromStream(Data);
            this.cdst.ReadFromStream(Data);
            this.cpk.ReadFromStream(Data);
            this.cpt.ReadFromStream(Data);
            this.cdt.ReadFromStream(Data);
            this.cdi.ReadFromStream(Data);
            this.prep.ReadFromStream(Data);
            this.wrep.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.cid.WriteToStream(Destination);
            this.trn.WriteToStream(Destination);
            this.pos.WriteToStream(Destination);
            this.sid.WriteToStream(Destination);
            this.auto.WriteToStream(Destination);
            this.dur.WriteToStream(Destination);
            this.cow.WriteToStream(Destination);
            this.cdst.WriteToStream(Destination);
            this.cpk.WriteToStream(Destination);
            this.cpt.WriteToStream(Destination);
            this.cdt.WriteToStream(Destination);
            this.cdi.WriteToStream(Destination);
            this.prep.WriteToStream(Destination);
            this.wrep.WriteToStream(Destination);
        }
    }

    public class SimCrepPrepSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct plr;
        protected BooleanSaveStruct ai;
        protected Int32SaveStruct ally;
        protected Int32SaveStruct status;
        protected Int32SaveStruct mxeng;
        protected Int32SaveStruct mxcls;
        protected Int32SaveStruct mxmsl;
        protected NonComplexArraySaveStruct<SimCrepPrepClsSaveStruct> cls;
        protected NonComplexArraySaveStruct<SimCrepPrepSecSaveStruct> sec;
        protected Int32SaveStruct ndam;
        protected ComplexArraySaveStruct<SimCrepPrepSrepSaveStruct> srep;

        #region Properties
        public Int32SaveStruct Plr
        {
            get { return plr; }
            set { plr = value; }
        }

        public BooleanSaveStruct Ai
        {
            get { return ai; }
            set { ai = value; }
        }

        public Int32SaveStruct Ally
        {
            get { return ally; }
            set { ally = value; }
        }

        public Int32SaveStruct Status
        {
            get { return status; }
            set { status = value; }
        }

        public Int32SaveStruct Mxeng
        {
            get { return mxeng; }
            set { mxeng = value; }
        }

        public Int32SaveStruct Mxcls
        {
            get { return mxcls; }
            set { mxcls = value; }
        }

        public Int32SaveStruct Mxmsl
        {
            get { return mxmsl; }
            set { mxmsl = value; }
        }

        public NonComplexArraySaveStruct<SimCrepPrepClsSaveStruct> Cls
        {
            get { return cls; }
            set { cls = value; }
        }

        public NonComplexArraySaveStruct<SimCrepPrepSecSaveStruct> Sec
        {
            get { return sec; }
            set { sec = value; }
        }

        public Int32SaveStruct Ndam
        {
            get { return ndam; }
            set { ndam = value; }
        }

        public ComplexArraySaveStruct<SimCrepPrepSrepSaveStruct> Srep
        {
            get { return srep; }
            set { srep = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimCrepPrepSaveStruct() : base()
        {
            this.plr = new Int32SaveStruct();
            this.ai = new BooleanSaveStruct();
            this.ally = new Int32SaveStruct();
            this.status = new Int32SaveStruct();
            this.mxeng = new Int32SaveStruct();
            this.mxcls = new Int32SaveStruct();
            this.mxmsl = new Int32SaveStruct();
            this.cls = new NonComplexArraySaveStruct<SimCrepPrepClsSaveStruct>();
            this.sec = new NonComplexArraySaveStruct<SimCrepPrepSecSaveStruct>();
            this.ndam = new Int32SaveStruct();
            this.srep = new ComplexArraySaveStruct<SimCrepPrepSrepSaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.plr.ReadFromStream(Data);
            this.ai.ReadFromStream(Data);
            this.ally.ReadFromStream(Data);
            this.status.ReadFromStream(Data);
            this.mxeng.ReadFromStream(Data);
            this.mxcls.ReadFromStream(Data);
            this.mxmsl.ReadFromStream(Data);
            this.cls.ReadFromStream(Data);
            this.sec.ReadFromStream(Data);
            this.ndam.ReadFromStream(Data);
            this.srep.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.plr.WriteToStream(Destination);
            this.ai.WriteToStream(Destination);
            this.ally.WriteToStream(Destination);
            this.status.WriteToStream(Destination);
            this.mxeng.WriteToStream(Destination);
            this.mxcls.WriteToStream(Destination);
            this.mxmsl.WriteToStream(Destination);
            this.cls.WriteToStream(Destination);
            this.sec.WriteToStream(Destination);
            this.ndam.WriteToStream(Destination);
            this.srep.WriteToStream(Destination);
        }
    }

    public class SimCrepPrepClsSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct cls;  //class ID?
        protected Int32SaveStruct nshp;
        protected Int32SaveStruct nsat;
        protected Int32SaveStruct nshfld;
        protected Int32SaveStruct nshlst;
        protected Int32SaveStruct nsatl;

        #region Properties
        public Int32SaveStruct Cls
        {
            get { return cls; }
            set { cls = value; }
        }

        public Int32SaveStruct Nshp
        {
            get { return nshp; }
            set { nshp = value; }
        }

        public Int32SaveStruct Nsat
        {
            get { return nsat; }
            set { nsat = value; }
        }

        public Int32SaveStruct Nshfld
        {
            get { return nshfld; }
            set { nshfld = value; }
        }

        public Int32SaveStruct Nshlst
        {
            get { return nshlst; }
            set { nshlst = value; }
        }

        public Int32SaveStruct Nsatl
        {
            get { return nsatl; }
            set { nsatl = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimCrepPrepClsSaveStruct()
        {
            this.cls = new Int32SaveStruct();
            this.nshp = new Int32SaveStruct();
            this.nsat = new Int32SaveStruct();
            this.nshfld = new Int32SaveStruct();
            this.nshlst = new Int32SaveStruct();
            this.nsatl = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.cls.ReadFromStream(Data);
            this.nshp.ReadFromStream(Data);
            this.nsat.ReadFromStream(Data);
            this.nshfld.ReadFromStream(Data);
            this.nshlst.ReadFromStream(Data);
            this.nsatl.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.cls.WriteToStream(Destination);
            this.nshp.WriteToStream(Destination);
            this.nsat.WriteToStream(Destination);
            this.nshfld.WriteToStream(Destination);
            this.nshlst.WriteToStream(Destination);
            this.nsatl.WriteToStream(Destination);
        }
    }

    public class SimCrepPrepSecSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct ssec;
        protected Int32SaveStruct nshp;

        public Int32SaveStruct Ssec
        {
            get { return ssec; }
            set { ssec = value; }
        }

        public Int32SaveStruct Nshp
        {
            get { return nshp; }
            set { nshp = value; }
        }

        /// <summary>Default constructor</summary>
        public SimCrepPrepSecSaveStruct()
        {
            this.ssec = new Int32SaveStruct();
            this.nshp = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.ssec.ReadFromStream(Data);
            this.nshp.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.ssec.WriteToStream(Destination);
            this.nshp.WriteToStream(Destination);
        }
    }

    public class SimCrepPrepSrepSaveStruct : ComplexSaveStruct
    {
        protected StringSaveStruct name;
        protected Int32SaveStruct did;
        protected Int32SaveStruct cls;
        protected Int64SaveStruct caps2;
        protected Int32SaveStruct nshp;
        protected Int32SaveStruct nfld;
        protected Int32SaveStruct nlst;
        protected Int32SaveStruct dtak;
        protected SimDamsSaveStruct dams;

        #region Properties
        public StringSaveStruct Name
        {
            get { return name; }
            set { name = value; }
        }

        public Int32SaveStruct Did
        {
            get { return did; }
            set { did = value; }
        }

        public Int32SaveStruct Cls
        {
            get { return cls; }
            set { cls = value; }
        }

        public Int64SaveStruct Caps2
        {
            get { return caps2; }
            set { caps2 = value; }
        }

        public Int32SaveStruct Nshp
        {
            get { return nshp; }
            set { nshp = value; }
        }

        public Int32SaveStruct Nfld
        {
            get { return nfld; }
            set { nfld = value; }
        }

        public Int32SaveStruct Nlst
        {
            get { return nlst; }
            set { nlst = value; }
        }

        public Int32SaveStruct Dtak
        {
            get { return dtak; }
            set { dtak = value; }
        }

        public SimDamsSaveStruct Dams
        {
            get { return dams; }
            set { dams = value; }
        }        
        #endregion

        /// <summary>Default constructor</summary>
        public SimCrepPrepSrepSaveStruct() : base()
        {
            this.name = new StringSaveStruct();
            this.did = new Int32SaveStruct();
            this.cls = new Int32SaveStruct();
            this.caps2 = new Int64SaveStruct();
            this.nshp = new Int32SaveStruct();
            this.nfld = new Int32SaveStruct();
            this.nlst = new Int32SaveStruct();
            this.dtak = new Int32SaveStruct();
            this.dams = new SimDamsSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.name.ReadFromStream(Data);
            this.did.ReadFromStream(Data);
            this.cls.ReadFromStream(Data);
            this.caps2.ReadFromStream(Data);
            this.nshp.ReadFromStream(Data);
            this.nfld.ReadFromStream(Data);
            this.nlst.ReadFromStream(Data);
            this.dtak.ReadFromStream(Data);
            this.dams.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.name.WriteToStream(Destination);
            this.did.WriteToStream(Destination);
            this.cls.WriteToStream(Destination);
            this.caps2.WriteToStream(Destination);
            this.nshp.WriteToStream(Destination);
            this.nfld.WriteToStream(Destination);
            this.nlst.WriteToStream(Destination);
            this.dtak.WriteToStream(Destination);
            this.dams.WriteToStream(Destination);
        }
    }

    public class SimDamsSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct dams;
        protected Int32SaveStruct damp;
        protected Int32SaveStruct dami;
        protected Int32SaveStruct damt;

        public Int32SaveStruct Dams
        {
            get { return dams; }
            set { dams = value; }
        }

        public Int32SaveStruct Damp
        {
            get { return damp; }
            set { damp = value; }
        }

        public Int32SaveStruct Dami
        {
            get { return dami; }
            set { dami = value; }
        }

        public Int32SaveStruct Damt
        {
            get { return damt; }
            set { damt = value; }
        }

        /// <summary>Defaul constructor</summary>
        public SimDamsSaveStruct()
        {
            this.dams = new Int32SaveStruct();
            this.damp = new Int32SaveStruct();
            this.dami = new Int32SaveStruct();
            this.damt = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.dams.ReadFromStream(Data);
            this.damp.ReadFromStream(Data);
            this.dami.ReadFromStream(Data);
            this.damt.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.dams.WriteToStream(Destination);
            this.damp.WriteToStream(Destination);
            this.dami.WriteToStream(Destination);
            this.damt.WriteToStream(Destination);
        }
    }

    public class SimCrepWrepSaveStruct : ComplexSaveStruct
    {
        protected StringSaveStruct wep;
        protected SimDamsSaveStruct dams;

        public StringSaveStruct Wep
        {
            get { return wep; }
            set { wep = value; }
        }

        public SimDamsSaveStruct Dams
        {
            get { return dams; }
            set { dams = value; }
        }

        /// <summary>Default constructor</summary>
        public SimCrepWrepSaveStruct() : base()
        {
            this.wep = new StringSaveStruct();
            this.dams = new SimDamsSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.wep.ReadFromStream(Data);
            this.dams.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.wep.WriteToStream(Destination);
            this.dams.WriteToStream(Destination);
        }
    }
    #endregion

    #region Player
    #region Tech Tree
    public class SimPlayerTechTree : ComplexSaveStruct
    {
        protected NonComplexArraySaveStruct<SimPlayerTechTreeBranch> tree;
        protected NonComplexArraySaveStruct<SimPlayerTechTreeTech> techs;

        public NonComplexArraySaveStruct<SimPlayerTechTreeBranch> Tree
        {
            get { return tree; }
            set { tree = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerTechTreeTech> Techs
        {
            get { return techs; }
            set { techs = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerTechTree() : base()
        {
            this.tree = new NonComplexArraySaveStruct<SimPlayerTechTreeBranch>();
            this.techs = new NonComplexArraySaveStruct<SimPlayerTechTreeTech>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.tree.ReadFromStream(Data);
            this.techs.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.tree.WriteToStream(Destination);
            this.techs.WriteToStream(Destination);
        }
    }
    
    public class SimPlayerTechTreeBranch : ISotsStructure
    {
        protected StringSaveStruct tNm;                 //techname
        protected NonComplexArraySaveStruct<StringSaveStruct> branches;   //tech tree branches

        public StringSaveStruct TNm
        {
            get { return tNm; }
            set { tNm = value; }
        }

        public NonComplexArraySaveStruct<StringSaveStruct> Branches
        {
            get { return branches; }
            set { branches = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerTechTreeBranch()
        {
            this.tNm = new StringSaveStruct();
            this.branches = new NonComplexArraySaveStruct<StringSaveStruct>();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.tNm.ReadFromStream(Data);
            this.branches.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.tNm.WriteToStream(Destination);
            this.branches.WriteToStream(Destination);
        }
    }

    public class SimPlayerTechTreeTech : ISotsStructure
    {
        protected StringSaveStruct tNm;         //techname
        protected Int32SaveStruct st;           //?
        protected Int32SaveStruct tResCost;     //research (points) cost
        protected Int32SaveStruct tResDone;     //research (points) cost towards completion
        protected Int32SaveStruct tAcq;         //turn acquired?
        protected Int32SaveStruct tiAcq;        //turns it took to acquire?
        protected Int32SaveStruct tbd;          //?
        protected BooleanSaveStruct tfc;        //?

        /// <remarks>-1 is common</remarks>
        protected Int32SaveStruct tUnlck;       //is the tech unlocked?

        #region Properties
        public StringSaveStruct TNm
        {
            get { return tNm; }
            set { tNm = value; }
        }

        public Int32SaveStruct St
        {
            get { return st; }
            set { st = value; }
        }

        public Int32SaveStruct TResCost
        {
            get { return tResCost; }
            set { tResCost = value; }
        }

        public Int32SaveStruct TResDone
        {
            get { return tResDone; }
            set { tResDone = value; }
        }

        public Int32SaveStruct TAcq
        {
            get { return tAcq; }
            set { tAcq = value; }
        }

        public Int32SaveStruct TiAcq
        {
            get { return tiAcq; }
            set { tiAcq = value; }
        }

        public Int32SaveStruct Tbd
        {
            get { return tbd; }
            set { tbd = value; }
        }

        public BooleanSaveStruct Tfc
        {
            get { return tfc; }
            set { tfc = value; }
        }

        public Int32SaveStruct TUnlck
        {
            get { return tUnlck; }
            set { tUnlck = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerTechTreeTech()
        {
            this.tNm = new StringSaveStruct();
            this.st = new Int32SaveStruct();
            this.tResCost = new Int32SaveStruct();
            this.tResDone = new Int32SaveStruct();
            this.tAcq = new Int32SaveStruct();
            this.tiAcq = new Int32SaveStruct();
            this.tbd = new Int32SaveStruct();
            this.tfc = new BooleanSaveStruct();
            this.tUnlck = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.tNm.ReadFromStream(Data);
            this.st.ReadFromStream(Data);
            this.tResCost.ReadFromStream(Data);
            this.tResDone.ReadFromStream(Data);
            this.tAcq.ReadFromStream(Data);
            this.tiAcq.ReadFromStream(Data);
            this.tbd.ReadFromStream(Data);
            this.tfc.ReadFromStream(Data);
            this.tUnlck.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.tNm.WriteToStream(Destination);
            this.st.WriteToStream(Destination);
            this.tResCost.WriteToStream(Destination);
            this.tResDone.WriteToStream(Destination);
            this.tAcq.WriteToStream(Destination);
            this.tiAcq.WriteToStream(Destination);
            this.tbd.WriteToStream(Destination);
            this.tfc.WriteToStream(Destination);
            this.tUnlck.WriteToStream(Destination);
        }
    }
    #endregion
    
    public class SimPlayerTeamSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct alid;
        protected Int32SaveStruct al;
        protected Int32SaveStruct na;
        protected Int32SaveStruct cf;

        public Int32SaveStruct Alid
        {
            get { return alid; }
            set { alid = value; }
        }

        public Int32SaveStruct Al
        {
            get { return al; }
            set { al = value; }
        }

        public Int32SaveStruct Na
        {
            get { return na; }
            set { na = value; }
        }

        public Int32SaveStruct Cf
        {
            get { return cf; }
            set { cf = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerTeamSaveStruct() : base()
        {
            this.alid = new Int32SaveStruct();
            this.al = new Int32SaveStruct();
            this.na = new Int32SaveStruct();
            this.cf = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.alid.ReadFromStream(Data);
            this.al.ReadFromStream(Data);
            this.na.ReadFromStream(Data);
            this.cf.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.alid.WriteToStream(Destination);
            this.al.WriteToStream(Destination);
            this.na.WriteToStream(Destination);
            this.cf.WriteToStream(Destination);
        }
    }

    #region Events
    public class SimPlayerEventsSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct evNxId;
        protected ComplexArraySaveStruct<SimPlayerEvent> events;

        public Int32SaveStruct EvNxId
        {
            get { return evNxId; }
            set { evNxId = value; }
        }

        public ComplexArraySaveStruct<SimPlayerEvent> Events
        {
            get { return events; }
            set { events = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerEventsSaveStruct()
        {
            this.evNxId = new Int32SaveStruct();
            this.events = new ComplexArraySaveStruct<SimPlayerEvent>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.evNxId.ReadFromStream(Data);
            this.events.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.evNxId.WriteToStream(Destination);
            this.events.WriteToStream(Destination);
        }
    }

    public class SimPlayerEvent : ComplexSaveStruct
    {
        protected Int32SaveStruct evTurn;
        protected ComplexArraySaveStruct<SimPlayerEventEventDetails> events;

        public Int32SaveStruct EvTurn
        {
            get { return evTurn; }
            set { evTurn = value; }
        }

        public ComplexArraySaveStruct<SimPlayerEventEventDetails> Events
        {
            get { return events; }
            set { events = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerEvent() : base()
        {
            this.evTurn = new Int32SaveStruct();
            this.events = new ComplexArraySaveStruct<SimPlayerEventEventDetails>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.evTurn.ReadFromStream(Data);
            this.events.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.evTurn.WriteToStream(Destination);
            this.events.WriteToStream(Destination);
        }
    }

    public class SimPlayerEventEventDetails : ComplexSaveStruct
    {
        protected Int32SaveStruct evEId;
        protected StringSaveStruct evDsc;
        protected StringSaveStruct evMsg;
        protected StringSaveStruct evImg;
        protected Int32SaveStruct evLoc;
        protected SpatialCoordinateSaveStruct evPos;
        protected Int32SaveStruct evAct;
        protected Int32SaveStruct evCId;    //combat ID?

        #region Properties
        public Int32SaveStruct EvEId
        {
            get { return evEId; }
            set { evEId = value; }
        }

        public StringSaveStruct EvDsc
        {
            get { return evDsc; }
            set { evDsc = value; }
        }

        public StringSaveStruct EvMsg
        {
            get { return evMsg; }
            set { evMsg = value; }
        }

        public StringSaveStruct EvImg
        {
            get { return evImg; }
            set { evImg = value; }
        }

        public Int32SaveStruct EvLoc
        {
            get { return evLoc; }
            set { evLoc = value; }
        }

        public SpatialCoordinateSaveStruct EvPos
        {
            get { return evPos; }
            set { evPos = value; }
        }

        public Int32SaveStruct EvAct
        {
            get { return evAct; }
            set { evAct = value; }
        }

        public Int32SaveStruct EvCId
        {
            get { return evCId; }
            set { evCId = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerEventEventDetails() : base()
        {
            this.evEId = new Int32SaveStruct();
            this.evDsc = new StringSaveStruct();
            this.evMsg = new StringSaveStruct();
            this.evImg = new StringSaveStruct();
            this.evLoc = new Int32SaveStruct();
            this.evPos = new SpatialCoordinateSaveStruct();
            this.evAct = new Int32SaveStruct();
            this.evCId = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.evEId.ReadFromStream(Data);
            this.evDsc.ReadFromStream(Data);
            this.evMsg.ReadFromStream(Data);
            this.evImg.ReadFromStream(Data);
            this.evLoc.ReadFromStream(Data);
            this.evPos.ReadFromStream(Data);
            this.evAct.ReadFromStream(Data);
            this.evCId.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.evEId.WriteToStream(Destination);
            this.evDsc.WriteToStream(Destination);
            this.evMsg.WriteToStream(Destination);
            this.evImg.WriteToStream(Destination);
            this.evLoc.WriteToStream(Destination);
            this.evPos.WriteToStream(Destination);
            this.evAct.WriteToStream(Destination);
            this.evCId.WriteToStream(Destination);
        }
    }
    #endregion

    #region Ship Recs
    public class SimPlayerShipRecsEventsSaveStruct : ComplexSaveStruct
    {
        //srnc is length
        protected NonComplexArraySaveStruct<SimPlayerShipRecSectionEventsSaveStruct> srbs;
        protected NonComplexArraySaveStruct<SimPlayerShipRecDroneEventsSaveStruct> srds;

        public NonComplexArraySaveStruct<SimPlayerShipRecSectionEventsSaveStruct> Srbs
        {
            get { return srbs; }
            set { srbs = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerShipRecDroneEventsSaveStruct> Srds
        {
            get { return srds; }
            set { srds = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerShipRecsEventsSaveStruct()
        {
            this.srbs = new NonComplexArraySaveStruct<SimPlayerShipRecSectionEventsSaveStruct>();
            this.srds = new NonComplexArraySaveStruct<SimPlayerShipRecDroneEventsSaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.srbs.ReadFromStream(Data);
            this.srds.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.srbs.WriteToStream(Destination);
            this.srds.WriteToStream(Destination);
        }
    }

    public class SimPlayerShipRecSectionEventsSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct srb;
        protected Int32SaveStruct srl;
        protected Int32SaveStruct srk;
        protected Int32SaveStruct sri;

        public Int32SaveStruct Srb
        {
            get { return srb; }
            set { srb = value; }
        }

        public Int32SaveStruct Srl
        {
            get { return srl; }
            set { srl = value; }
        }

        public Int32SaveStruct Srk
        {
            get { return srk; }
            set { srk = value; }
        }

        public Int32SaveStruct Sri
        {
            get { return sri; }
            set { sri = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerShipRecSectionEventsSaveStruct()
        {
            this.srb = new Int32SaveStruct();
            this.srl = new Int32SaveStruct();
            this.srk = new Int32SaveStruct();
            this.sri = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.srb.ReadFromStream(Data);
            this.srl.ReadFromStream(Data);
            this.srk.ReadFromStream(Data);
            this.sri.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.srb.WriteToStream(Destination);
            this.srl.WriteToStream(Destination);
            this.srk.WriteToStream(Destination);
            this.sri.WriteToStream(Destination);
        }
    }

    public class SimPlayerShipRecDroneEventsSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct srd;
        protected Int32SaveStruct src;
        protected Int32SaveStruct srb;
        protected Int32SaveStruct srl;
        protected Int32SaveStruct sri;
        
        public Int32SaveStruct Srd
        {
            get { return srd; }
            set { srd = value; }
        }

        public Int32SaveStruct Src
        {
            get { return src; }
            set { src = value; }
        }

        public Int32SaveStruct Srb
        {
            get { return srb; }
            set { srb = value; }
        }

        public Int32SaveStruct Srl
        {
            get { return srl; }
            set { srl = value; }
        }

        public Int32SaveStruct Sri
        {
            get { return sri; }
            set { sri = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerShipRecDroneEventsSaveStruct()
        {
            this.srd = new Int32SaveStruct();
            this.src = new Int32SaveStruct();
            this.srb = new Int32SaveStruct();
            this.srl = new Int32SaveStruct();
            this.sri = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.srd.ReadFromStream(Data);
            this.src.ReadFromStream(Data);
            this.srb.ReadFromStream(Data);
            this.srl.ReadFromStream(Data);
            this.sri.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.srd.WriteToStream(Destination);
            this.src.WriteToStream(Destination);
            this.srb.WriteToStream(Destination);
            this.srl.WriteToStream(Destination);
            this.sri.WriteToStream(Destination);
        }
    }
    #endregion

    public class SimPlayerSpySaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct defc2;
        protected Int32SaveStruct rtc;
        protected Int32SaveStruct evc;
        protected Int32SaveStruct ttc;

        public Int32SaveStruct Defc2
        {
            get { return defc2; }
            set { defc2 = value; }
        }

        public Int32SaveStruct Rtc
        {
            get { return rtc; }
            set { rtc = value; }
        }

        public Int32SaveStruct Evc
        {
            get { return evc; }
            set { evc = value; }
        }

        public Int32SaveStruct Ttc
        {
            get { return ttc; }
            set { ttc = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerSpySaveStruct() : base()
        {
            this.defc2 = new Int32SaveStruct();
            this.rtc = new Int32SaveStruct();
            this.evc = new Int32SaveStruct();
            this.ttc = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.defc2.ReadFromStream(Data);
            this.rtc.ReadFromStream(Data);
            this.evc.ReadFromStream(Data);
            this.ttc.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.defc2.WriteToStream(Destination);
            this.rtc.WriteToStream(Destination);
            this.evc.WriteToStream(Destination);
            this.ttc.WriteToStream(Destination);
        }
    }

    #region Civr
    public class SimPlayerCivrSaveStruct : ComplexSaveStruct
    {
        protected FloatSaveStruct smx;
        protected ComplexArraySaveStruct<SimPlayerCivrSpeSpVa> spe;

        public FloatSaveStruct Smx
        {
            get { return smx; }
            set { smx = value; }
        }

        public ComplexArraySaveStruct<SimPlayerCivrSpeSpVa> Spe
        {
            get { return spe; }
            set { spe = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerCivrSaveStruct() : base()
        {
            this.smx = new FloatSaveStruct();
            this.spe = new ComplexArraySaveStruct<SimPlayerCivrSpeSpVa>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.smx.ReadFromStream(Data);
            this.spe.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.smx.WriteToStream(Destination);
            this.spe.WriteToStream(Destination);
        }
    }

    public class SimPlayerCivrSpeSpVa : ISotsStructure
    {
        protected Int32SaveStruct sp;
        protected Int32SaveStruct va2;

        public Int32SaveStruct Sp
        {
            get { return sp; }
            set { sp = value; }
        }

        public Int32SaveStruct Va2
        {
            get { return va2; }
            set { va2 = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerCivrSpeSpVa()
        {
            this.sp = new Int32SaveStruct();
            this.va2 = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.sp.ReadFromStream(Data);
            this.va2.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.sp.WriteToStream(Destination);
            this.va2.WriteToStream(Destination);
        }
    }
    #endregion
    
    public class SimPlayerModsSaveStruct : ISotsStructure
    {
        protected SimPlayerConModSaveStruct mod1;
        protected SimPlayerConModSaveStruct mod2;
        protected SimPlayerConModSaveStruct mod3;

        public SimPlayerConModSaveStruct Mod1
        {
            get { return mod1; }
            set { mod1 = value; }
        }

        public SimPlayerConModSaveStruct Mod2
        {
            get { return mod2; }
            set { mod2 = value; }
        }

        public SimPlayerConModSaveStruct Mod3
        {
            get { return mod3; }
            set { mod3 = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerModsSaveStruct()
        {
            this.mod1 = new SimPlayerConModSaveStruct();
            this.mod2 = new SimPlayerConModSaveStruct();
            this.mod3 = new SimPlayerConModSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.mod1.ReadFromStream(Data);
            this.mod2.ReadFromStream(Data);
            this.mod3.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.mod1.WriteToStream(Destination);
            this.mod2.WriteToStream(Destination);
            this.mod3.WriteToStream(Destination);
        }
    }

    public class SimPlayerConModSaveStruct : ISotsStructure
    {
        protected FloatSaveStruct conMod;
        protected FloatSaveStruct savMod;

        public FloatSaveStruct ConMod
        {
            get { return conMod; }
            set { conMod = value; }
        }

        public FloatSaveStruct SavMod
        {
            get { return savMod; }
            set { savMod = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerConModSaveStruct()
        {
            this.conMod = new FloatSaveStruct();
            this.savMod = new FloatSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.conMod.ReadFromStream(Data);
            this.savMod.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.conMod.WriteToStream(Destination);
            this.savMod.WriteToStream(Destination);
        }
    }
    
    #region Ship Design
    public class SimPlayerDesignEntrySaveStruct : ISotsStructure
    {
        protected Int32SaveStruct designId;
        protected SimPlayerDesignSaveStruct design;

        public Int32SaveStruct DesignId
        {
            get { return designId; }
            set { designId = value; }
        }

        public SimPlayerDesignSaveStruct Design
        {
            get { return design; }
            set { design = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDesignEntrySaveStruct()
        {
            this.designId = new Int32SaveStruct();
            this.design = new SimPlayerDesignSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.designId.ReadFromStream(Data);
            this.design.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.designId.WriteToStream(Destination);
            this.design.WriteToStream(Destination);
        }
    }

    public class SimPlayerDesignDwg : ComplexSaveStruct
    {
        protected NonComplexArraySaveStruct<SimPlayerDesignGng> wgng;

        public NonComplexArraySaveStruct<SimPlayerDesignGng> Wgng
        {
            get { return wgng; }
            set { wgng = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDesignDwg() : base()
        {
            this.wgng = new NonComplexArraySaveStruct<SimPlayerDesignGng>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.wgng.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.wgng.WriteToStream(Destination);
        }
    }

    public class SimPlayerDesignGng : ISotsStructure
    {
        protected Int32SaveStruct wgid;
        protected SimPlayerDesignDwgWgb wgb;

        public Int32SaveStruct Wgid
        {
            get { return wgid; }
            set { wgid = value; }
        }

        public SimPlayerDesignDwgWgb Wgb
        {
            get { return wgb; }
            set { wgb = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDesignGng()
        {
            this.wgid = new Int32SaveStruct();
            this.wgb = new SimPlayerDesignDwgWgb();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.wgid.ReadFromStream(Data);
            this.wgb.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.wgid.WriteToStream(Destination);
            this.wgb.WriteToStream(Destination);
        }
    }

    public class SimPlayerDesignDwgWgb : ComplexSaveStruct
    {
        protected Int32SaveStruct unknown1;
        protected Int32SaveStruct unknown2;
        protected Int32SaveStruct unknown3;

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

        /// <summary>Default constructor</summary>
        public SimPlayerDesignDwgWgb() : base()
        {
            this.unknown1 = new Int32SaveStruct();
            this.unknown2 = new Int32SaveStruct();
            this.unknown3 = new Int32SaveStruct();
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
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
            this.unknown3.WriteToStream(Destination);
        }
    }

    public class SimPlayerDesignSaveStruct : ComplexSaveStruct
    {
        protected BooleanSaveStruct faiDes;
        protected BooleanSaveStruct dHide;
        protected Int32SaveStruct dWep;
        protected StringSaveStruct dName;
        protected SimPlayerDesignSectionArray sections;
        protected Int32SaveStruct dtc;
        protected NonComplexArraySaveStruct<SimPlayerDesignDwg> dwgv;

        #region Properties
        public BooleanSaveStruct FaiDes
        {
            get { return faiDes; }
            set { faiDes = value; }
        }

        public BooleanSaveStruct DHide
        {
            get { return dHide; }
            set { dHide = value; }
        }

        public Int32SaveStruct DWep
        {
            get { return dWep; }
            set { dWep = value; }
        }

        public StringSaveStruct DName
        {
            get { return dName; }
            set { dName = value; }
        }

        public SimPlayerDesignSectionArray Sections
        {
            get { return sections; }
            set { sections = value; }
        }

        public Int32SaveStruct Dtc
        {
            get { return dtc; }
            set { dtc = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerDesignDwg> Dwgv
        {
            get { return dwgv; }
            set { dwgv = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerDesignSaveStruct() : base()
        {
            this.faiDes = new BooleanSaveStruct();
            this.dHide = new BooleanSaveStruct();
            this.dWep = new Int32SaveStruct();
            this.dName = new StringSaveStruct();
            this.sections = new SimPlayerDesignSectionArray();
            this.dtc = new Int32SaveStruct();
            this.dwgv = new NonComplexArraySaveStruct<SimPlayerDesignDwg>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.faiDes.ReadFromStream(Data);
            this.dHide.ReadFromStream(Data);
            this.dWep.ReadFromStream(Data);
            this.dName.ReadFromStream(Data);
            this.sections.ReadFromStream(Data);
            this.dtc.ReadFromStream(Data);
            this.dwgv.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.faiDes.WriteToStream(Destination);
            this.dHide.WriteToStream(Destination);
            this.dWep.WriteToStream(Destination);
            this.dName.WriteToStream(Destination);
            this.sections.WriteToStream(Destination);
            this.dtc.WriteToStream(Destination);
            this.dwgv.WriteToStream(Destination);
        }
    }

    public class SimPlayerDesignSectionSaveStruct : ComplexSaveStruct
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
        public SimPlayerDesignSectionSaveStruct() : base()
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

    public class SimPlayerDesignSectionArray : ISotsStructure
    {
        /// <remarks>
        ///     Acts like an array, so needs a count. There are only ever three sections.
        ///     I am wating for this assumption to bite me in the ass for stations, etc.
        /// </remarks>
        protected Int32 SectionCount
        {
            get { return 3; }
        }

        protected SimPlayerDesignSectionEntrySaveStruct[] sections;

        public SimPlayerDesignSectionEntrySaveStruct[] Sections
        {
            get { return sections; }
            set { sections = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDesignSectionArray()
        {
            this.sections = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.sections = new SimPlayerDesignSectionEntrySaveStruct[this.SectionCount];
            for (Int32 i = 0; i < this.sections.Length; i++)
            {
                this.sections[i] = new SimPlayerDesignSectionEntrySaveStruct();
                this.sections[i].ReadFromStream(Data);
            }
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            for (Int32 i = 0; i < this.sections.Length; i++)
                this.sections[i].WriteToStream(Destination);
        }
    }

    public class SimPlayerDesignSectionEntrySaveStruct : ComplexSaveStruct
    {
        protected SimPlayerDesignSectionSaveStruct dsec;
        protected ComplexArraySaveStruct<SimPlayerDesignUnknown1SaveStruct> dgbnk2;
        protected ComplexArraySaveStruct<StringSaveStruct> dOpts;

        public SimPlayerDesignSectionSaveStruct Dsec
        {
            get { return dsec; }
            set { dsec = value; }
        }

        public ComplexArraySaveStruct<SimPlayerDesignUnknown1SaveStruct> Dgbnk2
        {
            get { return dgbnk2; }
            set { dgbnk2 = value; }
        }

        public ComplexArraySaveStruct<StringSaveStruct> DOpts
        {
            get { return dOpts; }
            set { dOpts = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDesignSectionEntrySaveStruct() : base()
        {
            this.dsec = new SimPlayerDesignSectionSaveStruct();
            this.dgbnk2 = new ComplexArraySaveStruct<SimPlayerDesignUnknown1SaveStruct>();
            this.dOpts = new ComplexArraySaveStruct<StringSaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.dsec.ReadFromStream(Data);
            this.dgbnk2.ReadFromStream(Data);
            this.dOpts.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.dsec.WriteToStream(Destination);
            this.dgbnk2.WriteToStream(Destination);
            this.dOpts.WriteToStream(Destination);
        }
    }

    public class SimPlayerDesignUnknown1SaveStruct : ComplexSaveStruct
    {
        protected SimPlayerDesignDw2SaveStruct dw2;

        public SimPlayerDesignDw2SaveStruct Dw2
        {
            get { return dw2; }
            set { dw2 = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDesignUnknown1SaveStruct() : base()
        {
            this.dw2 = new SimPlayerDesignDw2SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.dw2.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.dw2.WriteToStream(Destination);
        }
    }

    public class SimPlayerDesignDw2SaveStruct : ComplexSaveStruct
    {
        /// <summary>Indicates whether to expect a weapon ID or a weapon full name</summary>
        /// <value>true indicates wId, false indicates wfn</value>
        protected BooleanSaveStruct bId;

        /// <summary>Describes a weapon system resource path (Full Name?)</summary>
        protected StringSaveStruct wfn;

        /// <summary>Describes a weapon ID</summary>
        protected Int32SaveStruct wId;
        protected Int32SaveStruct dId;

        public BooleanSaveStruct BId
        {
            get { return bId; }
            set { bId = value; }
        }

        public StringSaveStruct Wfn
        {
            get { return wfn; }
            set { wfn = value; }
        }

        public Int32SaveStruct WId
        {
            get { return wId; }
            set { wId = value; }
        }

        public Int32SaveStruct DId
        {
            get { return dId; }
            set { dId = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDesignDw2SaveStruct() : base()
        {
            this.bId = new BooleanSaveStruct();
            this.wfn = null;
            this.wId = null;
            this.dId = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.bId.ReadFromStream(Data);

            if (this.bId.BooleanValue)
            {
                this.wId = new Int32SaveStruct();
                this.wId.ReadFromStream(Data);
            }
            else
            {
                this.wfn = new StringSaveStruct();
                this.wfn.ReadFromStream(Data);
            }

            this.dId.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.bId.WriteToStream(Destination);
            
            if (this.bId.BooleanValue)
                this.wId.WriteToStream(Destination);
            else
                this.wfn.WriteToStream(Destination);

            this.dId.WriteToStream(Destination);
        }
    }
    #endregion

    #region Notes
    public class SimPlayerNote : ComplexSaveStruct
    {
        protected Int32SaveStruct ntSys;
        protected StringSaveStruct ntTxt;
        protected Int32SaveStruct ntTrn;

        public Int32SaveStruct NtSys
        {
            get { return ntSys; }
            set { ntSys = value; }
        }

        public StringSaveStruct NtTxt
        {
            get { return ntTxt; }
            set { ntTxt = value; }
        }

        public Int32SaveStruct NtTrn
        {
            get { return ntTrn; }
            set { ntTrn = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerNote() : base()
        {
            this.ntSys = new Int32SaveStruct();
            this.ntTxt = new StringSaveStruct();
            this.ntTrn = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ntSys.ReadFromStream(Data);
            this.ntTxt.ReadFromStream(Data);
            this.ntTrn.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ntSys.WriteToStream(Destination);
            this.ntTxt.WriteToStream(Destination);
            this.ntTrn.WriteToStream(Destination);
        }
    }
    #endregion

    #region PR
    public class SimPlayerPr : ISotsStructure
    {
        protected FloatSaveStruct prm;
        protected Int32SaveStruct prbt;

        public FloatSaveStruct Prm
        {
            get { return prm; }
            set { prm = value; }
        }

        public Int32SaveStruct Prbt
        {
            get { return prbt; }
            set { prbt = value; }
        }

        /// <summary>Default cosntructor</summary>
        public SimPlayerPr()
        {
            this.prm = new FloatSaveStruct();
            this.prbt = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.prm.ReadFromStream(Data);
            this.prbt.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.prm.WriteToStream(Destination);
            this.prbt.WriteToStream(Destination);
        }
    }
    #endregion

    public class SimPlayerDipStat : ComplexSaveStruct
    {
        protected Int32SaveStruct other;
        protected SimPlayerDipStatDetail nap;
        protected SimPlayerDipStatDetail ally;
        protected SimPlayerDipStatDetail cf;
        protected Int32SaveStruct deadhome; //boolean?

        #region Properties
        public Int32SaveStruct Other
        {
            get { return other; }
            set { other = value; }
        }

        public SimPlayerDipStatDetail Nap
        {
            get { return nap; }
            set { nap = value; }
        }

        public SimPlayerDipStatDetail Ally
        {
            get { return ally; }
            set { ally = value; }
        }

        public SimPlayerDipStatDetail Cf
        {
            get { return cf; }
            set { cf = value; }
        }

        public Int32SaveStruct Deadhome
        {
            get { return deadhome; }
            set { deadhome = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerDipStat() : base()
        {
            this.other = new Int32SaveStruct();
            this.nap = new SimPlayerDipStatDetail();    //non-aggression pact
            this.ally = new SimPlayerDipStatDetail();   //alliance
            this.cf = new SimPlayerDipStatDetail();     //??
            this.deadhome = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.other.ReadFromStream(Data);
            this.nap.ReadFromStream(Data);
            this.ally.ReadFromStream(Data);
            this.cf.ReadFromStream(Data);
            this.deadhome.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.other.WriteToStream(Destination);
            this.nap.WriteToStream(Destination);
            this.ally.WriteToStream(Destination);
            this.cf.WriteToStream(Destination);
            this.deadhome.WriteToStream(Destination);
        }
    }

    public class SimPlayerDipStatDetail : ISotsStructure
    {
        protected Int32SaveStruct last_;
        protected Int32SaveStruct last_bty;
        protected Int32SaveStruct bkn_;
        protected Int32SaveStruct bty_;

        public Int32SaveStruct Last_
        {
            get { return last_; }
            set { last_ = value; }
        }

        public Int32SaveStruct Last_bty
        {
            get { return last_bty; }
            set { last_bty = value; }
        }

        public Int32SaveStruct Bkn_
        {
            get { return bkn_; }
            set { bkn_ = value; }
        }

        public Int32SaveStruct Bty_
        {
            get { return bty_; }
            set { bty_ = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDipStatDetail()
        {
            this.last_ = new Int32SaveStruct();
            this.last_bty = new Int32SaveStruct();
            this.bkn_ = new Int32SaveStruct();
            this.bty_ = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.last_.ReadFromStream(Data);
            this.last_bty.ReadFromStream(Data);
            this.bkn_.ReadFromStream(Data);
            this.bty_.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.last_.WriteToStream(Destination);
            this.last_bty.WriteToStream(Destination);
            this.bkn_.WriteToStream(Destination);
            this.bty_.WriteToStream(Destination);
        }
    }

    public class SimPlayerComm : ISotsStructure
    {
        protected Int32SaveStruct msgt;
        protected SimPlayerCommMsg msg;

        public Int32SaveStruct Msgt
        {
            get { return this.msgt; }
            set { this.msgt = value; }
        }

        public SimPlayerCommMsg Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerComm()
        {
            this.msgt = new Int32SaveStruct();
            this.msg = new SimPlayerCommMsg();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.msgt.ReadFromStream(Data);
            this.msg.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.msgt.WriteToStream(Destination);
            this.msg.WriteToStream(Destination);
        }
    }

    public class SimPlayerCommMsg : ComplexSaveStruct
    {
        protected Int32SaveStruct cid2;
        protected Int32SaveStruct snd;      //seen 0 and 5, 5 leaving a "sys" trailing integer
        protected Int32SaveStruct rcp;
        protected Int32SaveStruct exp;      //ususally 16-bit, -1
        protected Int32SaveStruct sent;     //turn sent?
        protected Int32SaveStruct rcpt;     //usually 2
        protected Int32SaveStruct sys;     //system ID
        
        #region Properties
        public Int32SaveStruct Cid2
        {
            get { return this.cid2; }
            set { this.cid2 = value; }
        }

        public Int32SaveStruct Snd
        {
            get { return this.snd; }
            set { this.snd = value; }
        }

        public Int32SaveStruct Rcp
        {
            get { return this.rcp; }
            set { this.rcp = value; }
        }

        public Int32SaveStruct Exp
        {
            get { return this.exp; }
            set { this.exp = value; }
        }

        public Int32SaveStruct Sent
        {
            get { return this.sent; }
            set { this.sent = value; }
        }

        public Int32SaveStruct Rcpt
        {
            get { return this.rcpt; }
            set { this.rcpt = value; }
        }

        public Int32SaveStruct Sys
        {
            get { return this.sys; }
            set { this.sys = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerCommMsg() : base()
        {
            this.cid2 = new Int32SaveStruct();
            this.snd = new Int32SaveStruct();
            this.rcp = new Int32SaveStruct();
            this.exp = new Int32SaveStruct();
            this.sent = new Int32SaveStruct();
            this.rcpt = new Int32SaveStruct();
            this.sys = null;    //not always present
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.cid2.ReadFromStream(Data);
            this.snd.ReadFromStream(Data);
            this.rcp.ReadFromStream(Data);
            this.exp.ReadFromStream(Data);
            this.sent.ReadFromStream(Data);
            this.rcpt.ReadFromStream(Data);

            if (this.snd.Value != 0)
            {
                this.sys = new Int32SaveStruct();
                this.sys.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.cid2.WriteToStream(Destination);
            this.snd.WriteToStream(Destination);
            this.rcp.WriteToStream(Destination);
            this.exp.WriteToStream(Destination);
            this.sent.WriteToStream(Destination);
            this.rcpt.WriteToStream(Destination);

            if (this.snd.Value != 0)
                this.sys.WriteToStream(Destination);
        }
    }


    #region Preps
    public class SimPlayerPrepSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct oid;
        protected Int32SaveStruct pid;
        protected Int32SaveStruct flds;
        protected Int32SaveStruct sav;
        protected Int32SaveStruct home;
        protected Int32SaveStruct ncol;
        protected Int32SaveStruct mpwr;
        protected Int32SaveStruct mcls;
        protected Int32SaveStruct mmsl;
        protected Int32SaveStruct nshp;
        protected Int32SaveStruct nsat;

        #region Properties
        public Int32SaveStruct Oid
        {
            get { return oid; }
            set { oid = value; }
        }

        public Int32SaveStruct Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public Int32SaveStruct Flds
        {
            get { return flds; }
            set { flds = value; }
        }

        public Int32SaveStruct Sav
        {
            get { return sav; }
            set { sav = value; }
        }

        public Int32SaveStruct Home
        {
            get { return home; }
            set { home = value; }
        }

        public Int32SaveStruct Ncol
        {
            get { return ncol; }
            set { ncol = value; }
        }

        public Int32SaveStruct Mpwr
        {
            get { return mpwr; }
            set { mpwr = value; }
        }

        public Int32SaveStruct Mcls
        {
            get { return mcls; }
            set { mcls = value; }
        }

        public Int32SaveStruct Mmsl
        {
            get { return mmsl; }
            set { mmsl = value; }
        }

        public Int32SaveStruct Nshp
        {
            get { return nshp; }
            set { nshp = value; }
        }

        public Int32SaveStruct Nsat
        {
            get { return nsat; }
            set { nsat = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerPrepSaveStruct() : base()
        {
            this.oid = new Int32SaveStruct();
            this.pid = new Int32SaveStruct();
            this.flds = new Int32SaveStruct();
            this.sav = new Int32SaveStruct();
            this.home = new Int32SaveStruct();
            this.ncol = new Int32SaveStruct();
            this.mpwr = new Int32SaveStruct();
            this.mcls = new Int32SaveStruct();
            this.mmsl = new Int32SaveStruct();
            this.nshp = new Int32SaveStruct();
            this.nsat = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.oid.ReadFromStream(Data);
            this.pid.ReadFromStream(Data);
            this.flds.ReadFromStream(Data);
            this.sav.ReadFromStream(Data);
            this.home.ReadFromStream(Data);
            this.ncol.ReadFromStream(Data);
            this.mpwr.ReadFromStream(Data);
            this.mcls.ReadFromStream(Data);
            this.mmsl.ReadFromStream(Data);
            this.nshp.ReadFromStream(Data);
            this.nsat.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.oid.WriteToStream(Destination);
            this.pid.WriteToStream(Destination);
            this.flds.WriteToStream(Destination);
            this.sav.WriteToStream(Destination);
            this.home.WriteToStream(Destination);
            this.ncol.WriteToStream(Destination);
            this.mpwr.WriteToStream(Destination);
            this.mcls.WriteToStream(Destination);
            this.mmsl.WriteToStream(Destination);
            this.nshp.WriteToStream(Destination);
            this.nsat.WriteToStream(Destination);
        }
    }
    #endregion

    #region Odes
    public class SimPlayerOdesSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct ontF;
        protected Int32SaveStruct otnL;
        protected Int32SaveStruct odid;
        protected Int32SaveStruct opid;

        public Int32SaveStruct OntF
        {
            get { return ontF; }
            set { ontF = value; }
        }

        public Int32SaveStruct OtnL
        {
            get { return otnL; }
            set { otnL = value; }
        }

        public Int32SaveStruct Odid
        {
            get { return odid; }
            set { odid = value; }
        }

        public Int32SaveStruct Opid
        {
            get { return opid; }
            set { opid = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerOdesSaveStruct() : base()
        {
            this.ontF = new Int32SaveStruct();
            this.otnL = new Int32SaveStruct();
            this.odid = new Int32SaveStruct();
            this.opid = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ontF.ReadFromStream(Data);
            this.otnL.ReadFromStream(Data);
            this.odid.ReadFromStream(Data);
            this.opid.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ontF.WriteToStream(Destination);
            this.otnL.WriteToStream(Destination);
            this.odid.WriteToStream(Destination);
            this.opid.WriteToStream(Destination);
        }
    }
    #endregion

    #region Owep
    public class SimPlayerOwepSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct ontF;
        protected Int32SaveStruct otnL;
        protected Int32SaveStruct odet;
        protected StringSaveStruct owep;
        protected Int32SaveStruct owith;

        public Int32SaveStruct OntF
        {
            get { return ontF; }
            set { ontF = value; }
        }

        public Int32SaveStruct OtnL
        {
            get { return otnL; }
            set { otnL = value; }
        }

        public Int32SaveStruct Odet
        {
            get { return odet; }
            set { odet = value; }
        }

        public StringSaveStruct Owep
        {
            get { return owep; }
            set { owep = value; }
        }

        public Int32SaveStruct Owith
        {
            get { return owith; }
            set { owith = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerOwepSaveStruct() : base()
        {
            this.ontF = new Int32SaveStruct();
            this.otnL = new Int32SaveStruct();
            this.odet = new Int32SaveStruct();
            this.owep = new StringSaveStruct();
            this.owith = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ontF.ReadFromStream(Data);
            this.otnL.ReadFromStream(Data);
            this.odet.ReadFromStream(Data);
            this.owep.ReadFromStream(Data);
            this.owith.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ontF.WriteToStream(Destination);
            this.otnL.WriteToStream(Destination);
            this.odet.WriteToStream(Destination);
            this.owep.WriteToStream(Destination);
            this.owith.WriteToStream(Destination);
        }
    }
    #endregion

    #region Otch
    public class SimPlayerOtchSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct ontF;
        protected Int32SaveStruct otnL;
        protected Int32SaveStruct odet;
        protected StringSaveStruct otch;
        protected Int32SaveStruct owith;

        public Int32SaveStruct OntF
        {
            get { return ontF; }
            set { ontF = value; }
        }

        public Int32SaveStruct OtnL
        {
            get { return otnL; }
            set { otnL = value; }
        }

        public Int32SaveStruct Odet
        {
            get { return odet; }
            set { odet = value; }
        }

        public StringSaveStruct Otch
        {
            get { return otch; }
            set { otch = value; }
        }

        public Int32SaveStruct Owith
        {
            get { return owith; }
            set { owith = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerOtchSaveStruct() : base()
        {
            this.ontF = new Int32SaveStruct();
            this.otnL = new Int32SaveStruct();
            this.odet = new Int32SaveStruct();
            this.otch = new StringSaveStruct();
            this.owith = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ontF.ReadFromStream(Data);
            this.otnL.ReadFromStream(Data);
            this.odet.ReadFromStream(Data);
            this.otch.ReadFromStream(Data);
            this.owith.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ontF.WriteToStream(Destination);
            this.otnL.WriteToStream(Destination);
            this.odet.WriteToStream(Destination);
            this.otch.WriteToStream(Destination);
            this.owith.WriteToStream(Destination);
        }
    }
    #endregion

    public class SimPlayerColorSaveStruct : ComplexSaveStruct
    {
        /// <summary>Default color palette index</summary>
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
        protected Int32SaveStruct colorIndex;

        /// <summary>Non-palette color definition</summary>
        protected RgbColorInt32 rgb;

        public Int32SaveStruct ColorIndex
        {
            get { return colorIndex; }
            set { colorIndex = value; }
        }

        public RgbColorInt32 Rgb
        {
            get { return rgb; }
            set { rgb = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerColorSaveStruct() : base()
        {
            this.colorIndex = new Int32SaveStruct();
            this.rgb = null;   ///dunno if this should be new or not...
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.colorIndex.ReadFromStream(Data);
            if (this.colorIndex.Value == -1)
            {
                rgb = new RgbColorInt32();
                rgb.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.colorIndex.WriteToStream(Destination);
            if (this.colorIndex.Value == -1)
                rgb.WriteToStream(Destination);
        }
    }

    public class SimPlayerSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct playerId;
        protected SimPlayerDetailsSaveStruct details;

        public Int32SaveStruct PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }

        public SimPlayerDetailsSaveStruct Details
        {
            get { return details; }
            set { details = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerSaveStruct()
        {
            this.playerId = new Int32SaveStruct();
            this.details = new SimPlayerDetailsSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.playerId.ReadFromStream(Data);
            this.details.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.playerId.WriteToStream(Destination);
            this.details.WriteToStream(Destination);
        }
    }

    #region Special Projects
    public class SimPlayerDetailsSpecialProjectT : ISotsStructure
    {
        /// <remarks>Special Project Type?</remarks>
        /// <value>1 = Asteroid Monitor, 0 = tech?</value>
        protected Int32SaveStruct sprjT;
        protected SimPlayerDetailsSpecialProjectDetails sprj;

        public Int32SaveStruct SprjT
        {
            get { return sprjT; }
            set { sprjT = value; }
        }

        public SimPlayerDetailsSpecialProjectDetails Sprj
        {
            get { return sprj; }
            set { sprj = value; }
        }

        /// <summary>Default constructor</summary>
        public SimPlayerDetailsSpecialProjectT()
        {
            this.sprjT = new Int32SaveStruct();
            this.sprj = new SimPlayerDetailsSpecialProjectDetails();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.sprjT.ReadFromStream(Data);
            this.sprj.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.sprjT.WriteToStream(Destination);
            this.sprj.WriteToStream(Destination);
        }
    }

    public class SimPlayerDetailsSpecialProjectDetails : ComplexSaveStruct
    {
        protected Int32SaveStruct stp;
        protected SimPlayerDetailsSpecialProjectSpi spi;

        /// <summary>Variable trailing variables, based on the type of special project</summary>
        protected SimPlayerDetailsSpecialProjectDetailsTail tail;

        #region Properties
        public Int32SaveStruct Stp
        {
            get { return stp; }
            set { stp = value; }
        }

        public SimPlayerDetailsSpecialProjectSpi Spi
        {
            get { return spi; }
            set { spi = value; }
        }

        public SimPlayerDetailsSpecialProjectDetailsTail Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerDetailsSpecialProjectDetails() : base()
        {
            this.stp = new Int32SaveStruct();
            this.spi = new SimPlayerDetailsSpecialProjectSpi();
            this.tail = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.stp.ReadFromStream(Data);
            this.spi.ReadFromStream(Data);

            if (this.stp.Value == 1)
                this.tail = new SimPlayerDetailsSpecialProjectDetailsTailAsMon();
            else if (this.stp.Value == 0)
                this.tail = new SimPlayerDetailsSpecialProjectDetailsTailTech();
            //else... throw an error :§

            this.tail.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.stp.WriteToStream(Destination);
            this.spi.WriteToStream(Destination);
            this.tail.WriteToStream(Destination);
        }
    }

    public abstract class SimPlayerDetailsSpecialProjectDetailsTail : ISotsStructure
    {
        protected Int32SaveStruct rDn;

        public Int32SaveStruct RDn
        {
            get { return rDn; }
            set { rDn = value; }
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public abstract void ReadFromStream(Stream Data);

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public abstract void WriteToStream(Stream Destination);
    }

    public class SimPlayerDetailsSpecialProjectDetailsTailAsMon : SimPlayerDetailsSpecialProjectDetailsTail
    {
        protected Int32SaveStruct sys;
        protected Int32SaveStruct rMn;
        protected Int32SaveStruct rMx;
        protected FloatSaveStruct rMd;

        #region Properties
        public Int32SaveStruct Sys
        {
            get { return sys; }
            set { sys = value; }
        }

        public Int32SaveStruct RMn
        {
            get { return rMn; }
            set { rMn = value; }
        }

        public Int32SaveStruct RMx
        {
            get { return rMx; }
            set { rMx = value; }
        }

        public FloatSaveStruct RMd
        {
            get { return rMd; }
            set { rMd = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerDetailsSpecialProjectDetailsTailAsMon()
        {
            this.sys = new Int32SaveStruct();
            this.rMn = new Int32SaveStruct();
            this.rMx = new Int32SaveStruct();
            this.rDn = new Int32SaveStruct();
            this.rMd = new FloatSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            this.sys.ReadFromStream(Data);
            this.rMn.ReadFromStream(Data);
            this.rMx.ReadFromStream(Data);
            this.rDn.ReadFromStream(Data);
            this.rMd.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            this.sys.WriteToStream(Destination);
            this.rMn.WriteToStream(Destination);
            this.rMx.WriteToStream(Destination);
            this.rDn.WriteToStream(Destination);
            this.rMd.WriteToStream(Destination);
        }
    }

    public class SimPlayerDetailsSpecialProjectDetailsTailTech : SimPlayerDetailsSpecialProjectDetailsTail
    {
        protected FloatSaveStruct aOdd;
        protected FloatSaveStruct aInc;
        protected StringSaveStruct tch;
        protected Int32SaveStruct rCst;

        #region Properties
        public FloatSaveStruct AOdd
        {
            get { return aOdd; }
            set { aOdd = value; }
        }

        public FloatSaveStruct AInc
        {
            get { return aInc; }
            set { aInc = value; }
        }

        public StringSaveStruct Tch
        {
            get { return tch; }
            set { tch = value; }
        }

        public Int32SaveStruct RCst
        {
            get { return rCst; }
            set { rCst = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerDetailsSpecialProjectDetailsTailTech()
        {
            this.aOdd = new FloatSaveStruct();
            this.aInc = new FloatSaveStruct();
            this.tch = new StringSaveStruct();
            this.rCst = new Int32SaveStruct();
            this.rDn = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            this.aOdd.ReadFromStream(Data);
            this.aInc.ReadFromStream(Data);
            this.tch.ReadFromStream(Data);
            this.rCst.ReadFromStream(Data);
            this.rDn.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            this.aOdd.WriteToStream(Destination);
            this.aInc.WriteToStream(Destination);
            this.tch.WriteToStream(Destination);
            this.rCst.WriteToStream(Destination);
            this.rDn.WriteToStream(Destination);
        }
    }

    public class SimPlayerDetailsSpecialProjectSpi : ComplexSaveStruct
    {
        protected Int32SaveStruct sPid;
        protected Int32SaveStruct sts;
        protected FloatSaveStruct cst;
        protected Int32SaveStruct mxC;
        protected StringSaveStruct name;
        protected Int32SaveStruct trns;

        #region Properties
        public Int32SaveStruct SPid
        {
            get { return sPid; }
            set { sPid = value; }
        }

        public Int32SaveStruct Sts
        {
            get { return sts; }
            set { sts = value; }
        }

        public FloatSaveStruct Cst
        {
            get { return cst; }
            set { cst = value; }
        }

        public Int32SaveStruct MxC
        {
            get { return mxC; }
            set { mxC = value; }
        }

        public StringSaveStruct Name
        {
            get { return name; }
            set { name = value; }
        }

        public Int32SaveStruct Trns
        {
            get { return trns; }
            set { trns = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerDetailsSpecialProjectSpi() : base()
        {
            this.sPid = new Int32SaveStruct();
            this.sts = new Int32SaveStruct();
            this.cst = new FloatSaveStruct();
            this.mxC = new Int32SaveStruct();
            this.name = new StringSaveStruct();
            this.trns = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.sPid.ReadFromStream(Data);
            this.sts.ReadFromStream(Data);
            this.cst.ReadFromStream(Data);
            this.mxC.ReadFromStream(Data);
            this.name.ReadFromStream(Data);
            this.trns.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.sPid.WriteToStream(Destination);
            this.sts.WriteToStream(Destination);
            this.cst.WriteToStream(Destination);
            this.mxC.WriteToStream(Destination);
            this.name.WriteToStream(Destination);
            this.trns.WriteToStream(Destination);
        }
    }
    #endregion

    public class SimPlayerDetailsOjv : ComplexSaveStruct
    {
        protected Int32SaveStruct id;
        protected BooleanSaveStruct cmp;
        protected Int32SaveStruct spr;
        protected StringSaveStruct dsc;
        protected Int32SaveStruct nid;

        #region Properties
        public Int32SaveStruct Id
        {
            get { return id; }
            set { id = value; }
        }

        public BooleanSaveStruct Cmp
        {
            get { return cmp; }
            set { cmp = value; }
        }

        public Int32SaveStruct Spr
        {
            get { return spr; }
            set { spr = value; }
        }

        public StringSaveStruct Dsc
        {
            get { return dsc; }
            set { dsc = value; }
        }

        public Int32SaveStruct Nid
        {
            get { return nid; }
            set { nid = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerDetailsOjv() : base()
        {
            this.id = new Int32SaveStruct();
            this.cmp = new BooleanSaveStruct();
            this.spr = new Int32SaveStruct();
            this.dsc = new StringSaveStruct();
            this.nid = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.id.ReadFromStream(Data);
            this.cmp.ReadFromStream(Data);
            this.spr.ReadFromStream(Data);
            this.dsc.ReadFromStream(Data);
            this.nid.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.id.WriteToStream(Destination);
            this.cmp.WriteToStream(Destination);
            this.spr.WriteToStream(Destination);
            this.dsc.WriteToStream(Destination);
            this.nid.WriteToStream(Destination);
        }
    }
    
    public class SimPlayerDetailsSaveStruct : ComplexSaveStruct
    {
        protected SimPlayerTechTree techTree;
        protected Int32SaveStruct homeSystem;
        protected Int32SaveStruct playerIndex;
        protected StringSaveStruct playerName;
        protected Int32SaveStruct species;
        protected SimPlayerColorSaveStruct colorId;
        protected StringSaveStruct badge;
        protected StringSaveStruct avatar;
        protected Int32SaveStruct team;
        protected Int32SaveStruct sav;
        protected FloatSaveStruct idealSuit;        //ideal climate hazard
        protected FloatSaveStruct suitTolerance;    //climate hazard tolerance
        protected FloatSaveStruct maxOH;            //?
        protected FloatSaveStruct resRate;      //research rate
        protected FloatSaveStruct resModifier;  //research rate modifier
        protected FloatSaveStruct resScl;       //research what? -- Scale according to the other guy's
        protected Int32SaveStruct trm;
        protected Int32SaveStruct trp;
        protected Int32SaveStruct tra;
        protected FloatSaveStruct outMod;
        protected FloatSaveStruct rebOutMod;
        protected FloatSaveStruct scOutMod;
        protected FloatSaveStruct incMod;       //income modifier
        protected FloatSaveStruct popMod;       //population growth modifier?
        protected FloatSaveStruct terraMod;     //terraforming modifier
        protected BooleanSaveStruct aMine;
        protected FloatSaveStruct minPure;
        protected FloatSaveStruct minRate;
        protected Int32SaveStruct ngts;
        protected Int32SaveStruct prGtTrf;
        protected Int32SaveStruct gTraf;
        protected Int32SaveStruct cstR;
        protected Int32SaveStruct cstE;
        protected Int32SaveStruct cstT;
        protected Int32SaveStruct maint;
        protected Int32SaveStruct shrm;
        protected Int32SaveStruct status;
        protected Int32SaveStruct elim;
        protected BooleanSaveStruct npc;
        protected BooleanSaveStruct rebAi;      //AI rebellion
        protected BooleanSaveStruct reqCL;
        protected SimPlayerTeamSaveStruct teamStruct;
        protected Int32SaveStruct hasVac;
        protected Int32SaveStruct hasImm;
        protected Int32SaveStruct npTrak;
        protected Int32SaveStruct hasDisc;
        protected Int32SaveStruct hasDiscSp;
        protected Int32SaveStruct hasDiscCl;
        protected Int32SaveStruct hasEnc;
        protected Int32SaveStruct hasEng;
        protected SimPlayerEventsSaveStruct events;

        /// <remarks>Originally though to be a struct, but having seen 0 and 0x7D, both were nested</remarks>
        protected NestedInt32SaveStruct fngNum;
        protected Int32SaveStruct pvSav;
        protected Int32SaveStruct pvMA;
        protected Int32SaveStruct aibN;
        protected BooleanSaveStruct cnTrd;
        protected BooleanSaveStruct cnRad;
        protected BooleanSaveStruct hgs;
        protected BooleanSaveStruct hadvs;
        protected BooleanSaveStruct harcc;
        protected BooleanSaveStruct cnVItl;
        protected FloatSaveStruct pddm;
        protected Int32SaveStruct bankWrn;
        protected Int32SaveStruct bankTrn;
        protected Int32SaveStruct bankPr;   //Float is NaN, so definitely an Int
        protected Int32SaveStruct bankEl;
        protected SimPlayerShipRecsEventsSaveStruct shipRecs;
        protected Int32SaveStruct nextPrjId;
        protected Int32SaveStruct plcy;         //imperial policy (for AI?)
        protected Int32SaveStruct pswd;     //password? Boolean?
        protected Int32SaveStruct lret;
        protected Int32SaveStruct nmeid;
        protected BooleanSaveStruct cdp;
        protected SimPlayerSpySaveStruct spy2;
        protected SimPlayerCivrSaveStruct civR;
        protected Int32SaveStruct aidf;
        protected BooleanSaveStruct srn;
        protected Int32SaveStruct srcTo;
        protected Int32SaveStruct lboid;
        protected Int32SaveStruct lcid2;
        protected StringSaveStruct resTnm;
        protected BooleanSaveStruct resErrRoll;
        protected SimPlayerModsSaveStruct conMods;
        protected NonComplexArraySaveStruct<Int32SaveStruct> ownerIds;
        protected NonComplexArraySaveStruct<SimPlayerDesignEntrySaveStruct> designs;
        protected NonComplexArraySaveStruct<SimPlayerDesignEntrySaveStruct> droneDesigns;
        protected NonComplexArraySaveStruct<SimPlayerNote> notes;
        protected NonComplexArraySaveStruct<SimPlayerPr> pr;
        protected BooleanSaveStruct hasAiRebellion;
        protected BooleanSaveStruct cta;
        protected NestedInt32SaveStruct aienf;      //has to be a struct
        protected NonComplexArraySaveStruct<SimPlayerDetailsSpecialProjectT> nSprj;
        protected Int32SaveStruct nexp;
        protected Int32SaveStruct nWeapXcl;
        protected ComplexArraySaveStruct<SimPlayerDetailsOjv> ovjs;
        protected ComplexArraySaveStruct<SimPlayerDipStat> dipStats;    //has to be a struct, was NestedInt32SaveStruct
        protected ComplexArraySaveStruct<SimPlayerComm> comms;          //has to be a struct, was NestedInt32SaveStruct
        protected ComplexArraySaveStruct<SimPlayerPrepSaveStruct> preps;
        protected ComplexArraySaveStruct<SimPlayerOdesSaveStruct> odes;
        protected ComplexArraySaveStruct<SimPlayerOwepSaveStruct> owep;
        protected ComplexArraySaveStruct<SimPlayerOtchSaveStruct> otch;
        protected NestedInt32SaveStruct aid;         //get one with player aid
        protected Int32SaveStruct ndeflay;
        protected Int32SaveStruct rdtc;
        protected Int32SaveStruct tnc;

        #region Properties
        public SimPlayerTechTree TechTree
        {
            get { return techTree; }
            set { techTree = value; }
        }

        public Int32SaveStruct HomeSystem
        {
            get { return homeSystem; }
            set { homeSystem = value; }
        }

        public Int32SaveStruct PlayerIndex
        {
            get { return playerIndex; }
            set { playerIndex = value; }
        }

        public StringSaveStruct PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public Int32SaveStruct Species
        {
            get { return species; }
            set { species = value; }
        }

        public SimPlayerColorSaveStruct ColorId
        {
            get { return colorId; }
            set { colorId = value; }
        }

        public StringSaveStruct Badge
        {
            get { return badge; }
            set { badge = value; }
        }

        public StringSaveStruct Avatar
        {
            get { return avatar; }
            set { avatar = value; }
        }

        public Int32SaveStruct Team
        {
            get { return team; }
            set { team = value; }
        }

        public Int32SaveStruct Sav
        {
            get { return sav; }
            set { sav = value; }
        }

        public FloatSaveStruct IdealSuit
        {
            get { return idealSuit; }
            set { idealSuit = value; }
        }

        public FloatSaveStruct SuitTolerance
        {
            get { return suitTolerance; }
            set { suitTolerance = value; }
        }

        public FloatSaveStruct MaxOH
        {
            get { return maxOH; }
            set { maxOH = value; }
        }

        public FloatSaveStruct ResRate
        {
            get { return resRate; }
            set { resRate = value; }
        }

        public FloatSaveStruct ResModifier
        {
            get { return resModifier; }
            set { resModifier = value; }
        }

        public FloatSaveStruct ResScl
        {
            get { return resScl; }
            set { resScl = value; }
        }

        public Int32SaveStruct Trm
        {
            get { return trm; }
            set { trm = value; }
        }

        public Int32SaveStruct Trp
        {
            get { return trp; }
            set { trp = value; }
        }

        public Int32SaveStruct Tra
        {
            get { return tra; }
            set { tra = value; }
        }

        public FloatSaveStruct OutMod
        {
            get { return outMod; }
            set { outMod = value; }
        }

        public FloatSaveStruct RebOutMod
        {
            get { return rebOutMod; }
            set { rebOutMod = value; }
        }

        public FloatSaveStruct ScOutMod
        {
            get { return scOutMod; }
            set { scOutMod = value; }
        }

        public FloatSaveStruct IncMod
        {
            get { return incMod; }
            set { incMod = value; }
        }

        public FloatSaveStruct PopMod
        {
            get { return popMod; }
            set { popMod = value; }
        }

        public FloatSaveStruct TerraMod
        {
            get { return terraMod; }
            set { terraMod = value; }
        }

        public BooleanSaveStruct AMine
        {
            get { return aMine; }
            set { aMine = value; }
        }

        public FloatSaveStruct MinPure
        {
            get { return minPure; }
            set { minPure = value; }
        }

        public FloatSaveStruct MinRate
        {
            get { return minRate; }
            set { minRate = value; }
        }

        public Int32SaveStruct Ngts
        {
            get { return ngts; }
            set { ngts = value; }
        }

        public Int32SaveStruct PrGtTrf
        {
            get { return prGtTrf; }
            set { prGtTrf = value; }
        }

        public Int32SaveStruct GTraf
        {
            get { return gTraf; }
            set { gTraf = value; }
        }

        public Int32SaveStruct CstR
        {
            get { return cstR; }
            set { cstR = value; }
        }

        public Int32SaveStruct CstE
        {
            get { return cstE; }
            set { cstE = value; }
        }

        public Int32SaveStruct CstT
        {
            get { return cstT; }
            set { cstT = value; }
        }

        public Int32SaveStruct Maint
        {
            get { return maint; }
            set { maint = value; }
        }

        public Int32SaveStruct Shrm
        {
            get { return shrm; }
            set { shrm = value; }
        }

        public Int32SaveStruct Status
        {
            get { return status; }
            set { status = value; }
        }

        public Int32SaveStruct Elim
        {
            get { return elim; }
            set { elim = value; }
        }

        public BooleanSaveStruct Npc
        {
            get { return npc; }
            set { npc = value; }
        }

        public BooleanSaveStruct RebAi
        {
            get { return rebAi; }
            set { rebAi = value; }
        }

        public BooleanSaveStruct ReqCL
        {
            get { return reqCL; }
            set { reqCL = value; }
        }

        public SimPlayerTeamSaveStruct TeamStruct
        {
            get { return teamStruct; }
            set { teamStruct = value; }
        }

        public Int32SaveStruct HasVac
        {
            get { return hasVac; }
            set { hasVac = value; }
        }

        public Int32SaveStruct HasImm
        {
            get { return hasImm; }
            set { hasImm = value; }
        }

        public Int32SaveStruct NpTrak
        {
            get { return npTrak; }
            set { npTrak = value; }
        }

        public Int32SaveStruct HasDisc
        {
            get { return hasDisc; }
            set { hasDisc = value; }
        }

        public Int32SaveStruct HasDiscSp
        {
            get { return hasDiscSp; }
            set { hasDiscSp = value; }
        }

        public Int32SaveStruct HasDiscCl
        {
            get { return hasDiscCl; }
            set { hasDiscCl = value; }
        }

        public Int32SaveStruct HasEnc
        {
            get { return hasEnc; }
            set { hasEnc = value; }
        }

        public Int32SaveStruct HasEng
        {
            get { return hasEng; }
            set { hasEng = value; }
        }

        public SimPlayerEventsSaveStruct Events
        {
            get { return events; }
            set { events = value; }
        }

        public NestedInt32SaveStruct FngNum
        {
            get { return fngNum; }
            set { fngNum = value; }
        }

        public Int32SaveStruct PvSav
        {
            get { return pvSav; }
            set { pvSav = value; }
        }

        public Int32SaveStruct PvMA
        {
            get { return pvMA; }
            set { pvMA = value; }
        }

        public Int32SaveStruct AibN
        {
            get { return aibN; }
            set { aibN = value; }
        }

        public BooleanSaveStruct CnTrd
        {
            get { return cnTrd; }
            set { cnTrd = value; }
        }

        public BooleanSaveStruct CnRad
        {
            get { return cnRad; }
            set { cnRad = value; }
        }

        public BooleanSaveStruct Hgs
        {
            get { return hgs; }
            set { hgs = value; }
        }

        public BooleanSaveStruct Hadvs
        {
            get { return hadvs; }
            set { hadvs = value; }
        }

        public BooleanSaveStruct Harcc
        {
            get { return harcc; }
            set { harcc = value; }
        }

        public BooleanSaveStruct CnVItl
        {
            get { return cnVItl; }
            set { cnVItl = value; }
        }

        public FloatSaveStruct Pddm
        {
            get { return pddm; }
            set { pddm = value; }
        }

        public Int32SaveStruct BankWrn
        {
            get { return bankWrn; }
            set { bankWrn = value; }
        }

        public Int32SaveStruct BankTrn
        {
            get { return bankTrn; }
            set { bankTrn = value; }
        }

        public Int32SaveStruct BankPr
        {
            get { return bankPr; }
            set { bankPr = value; }
        }

        public Int32SaveStruct BankEl
        {
            get { return bankEl; }
            set { bankEl = value; }
        }

        public SimPlayerShipRecsEventsSaveStruct ShipRecs
        {
            get { return shipRecs; }
            set { shipRecs = value; }
        }

        public Int32SaveStruct NextPrjId
        {
            get { return nextPrjId; }
            set { nextPrjId = value; }
        }

        public Int32SaveStruct Plcy
        {
            get { return plcy; }
            set { plcy = value; }
        }

        public Int32SaveStruct Pswd
        {
            get { return pswd; }
            set { pswd = value; }
        }

        public Int32SaveStruct Lret
        {
            get { return lret; }
            set { lret = value; }
        }

        public Int32SaveStruct Nmeid
        {
            get { return nmeid; }
            set { nmeid = value; }
        }

        public BooleanSaveStruct Cdp
        {
            get { return cdp; }
            set { cdp = value; }
        }

        public SimPlayerSpySaveStruct Spy2
        {
            get { return spy2; }
            set { spy2 = value; }
        }

        public SimPlayerCivrSaveStruct CivR
        {
            get { return civR; }
            set { civR = value; }
        }

        public Int32SaveStruct Aidf
        {
            get { return aidf; }
            set { aidf = value; }
        }

        public BooleanSaveStruct Srn
        {
            get { return srn; }
            set { srn = value; }
        }

        public Int32SaveStruct SrcTo
        {
            get { return srcTo; }
            set { srcTo = value; }
        }

        public Int32SaveStruct Lboid
        {
            get { return lboid; }
            set { lboid = value; }
        }

        public Int32SaveStruct Lcid2
        {
            get { return lcid2; }
            set { lcid2 = value; }
        }

        public StringSaveStruct ResTnm
        {
            get { return resTnm; }
            set { resTnm = value; }
        }

        public BooleanSaveStruct ResErrRoll
        {
            get { return resErrRoll; }
            set { resErrRoll = value; }
        }

        public SimPlayerModsSaveStruct ConMods
        {
            get { return conMods; }
            set { conMods = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> OwnerIds
        {
            get { return ownerIds; }
            set { ownerIds = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerDesignEntrySaveStruct> Designs
        {
            get { return designs; }
            set { designs = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerDesignEntrySaveStruct> DroneDesigns
        {
            get { return droneDesigns; }
            set { droneDesigns = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerNote> Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerPr> Pr
        {
            get { return pr; }
            set { pr = value; }
        }

        public BooleanSaveStruct HasAiRebellion
        {
            get { return hasAiRebellion; }
            set { hasAiRebellion = value; }
        }

        public BooleanSaveStruct Cta
        {
            get { return cta; }
            set { cta = value; }
        }

        public NestedInt32SaveStruct Aienf
        {
            get { return aienf; }
            set { aienf = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerDetailsSpecialProjectT> NSprj
        {
            get { return nSprj; }
            set { nSprj = value; }
        }

        public Int32SaveStruct Nexp
        {
            get { return nexp; }
            set { nexp = value; }
        }

        public Int32SaveStruct NWeapXcl
        {
            get { return nWeapXcl; }
            set { nWeapXcl = value; }
        }

        public ComplexArraySaveStruct<SimPlayerDetailsOjv> Ovjs
        {
            get { return ovjs; }
            set { ovjs = value; }
        }

        public ComplexArraySaveStruct<SimPlayerDipStat> DipStats
        {
            get { return dipStats; }
            set { dipStats = value; }
        }

        public ComplexArraySaveStruct<SimPlayerComm> Comms
        {
            get { return this.comms; }
            set { this.comms = value; }
        }

        public ComplexArraySaveStruct<SimPlayerPrepSaveStruct> Preps
        {
            get { return preps; }
            set { preps = value; }
        }

        public ComplexArraySaveStruct<SimPlayerOdesSaveStruct> Odes
        {
            get { return odes; }
            set { odes = value; }
        }

        public ComplexArraySaveStruct<SimPlayerOwepSaveStruct> Owep
        {
            get { return owep; }
            set { owep = value; }
        }

        public ComplexArraySaveStruct<SimPlayerOtchSaveStruct> Otch
        {
            get { return otch; }
            set { otch = value; }
        }

        public NestedInt32SaveStruct Aid
        {
            get { return aid; }
            set { aid = value; }
        }

        public Int32SaveStruct Ndeflay
        {
            get { return ndeflay; }
            set { ndeflay = value; }
        }

        public Int32SaveStruct Rdtc
        {
            get { return rdtc; }
            set { rdtc = value; }
        }

        public Int32SaveStruct Tnc
        {
            get { return tnc; }
            set { tnc = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimPlayerDetailsSaveStruct() : base()
        {
            this.techTree = new SimPlayerTechTree();
            this.homeSystem = new Int32SaveStruct();
            this.playerIndex = new Int32SaveStruct();
            this.playerName = new StringSaveStruct();
            this.species = new Int32SaveStruct();
            this.colorId = new SimPlayerColorSaveStruct();
            this.badge = new StringSaveStruct();
            this.avatar = new StringSaveStruct();
            this.team = new Int32SaveStruct();
            this.sav = new Int32SaveStruct();
            this.idealSuit = new FloatSaveStruct();
            this.suitTolerance = new FloatSaveStruct();
            this.maxOH = new FloatSaveStruct();
            this.resRate = new FloatSaveStruct();
            this.resModifier = new FloatSaveStruct();
            this.resScl = new FloatSaveStruct();
            this.trm = new Int32SaveStruct();
            this.trp = new Int32SaveStruct();
            this.tra = new Int32SaveStruct();
            this.outMod = new FloatSaveStruct();
            this.rebOutMod = new FloatSaveStruct();
            this.scOutMod = new FloatSaveStruct();
            this.incMod = new FloatSaveStruct();
            this.popMod = new FloatSaveStruct();
            this.terraMod = new FloatSaveStruct();
            this.aMine = new BooleanSaveStruct();
            this.minPure = new FloatSaveStruct();
            this.minRate = new FloatSaveStruct();
            this.ngts = new Int32SaveStruct();
            this.prGtTrf = new Int32SaveStruct();
            this.gTraf = new Int32SaveStruct();
            this.cstR = new Int32SaveStruct();
            this.cstE = new Int32SaveStruct();
            this.cstT = new Int32SaveStruct();
            this.maint = new Int32SaveStruct();
            this.shrm = new Int32SaveStruct();
            this.status = new Int32SaveStruct();
            this.elim = new Int32SaveStruct();
            this.npc = new BooleanSaveStruct();
            this.rebAi = new BooleanSaveStruct();
            this.reqCL = new BooleanSaveStruct();
            this.teamStruct = new SimPlayerTeamSaveStruct();
            this.hasVac = new Int32SaveStruct();
            this.hasImm = new Int32SaveStruct();
            this.npTrak = new Int32SaveStruct();
            this.hasDisc = new Int32SaveStruct();
            this.hasDiscSp = new Int32SaveStruct();
            this.hasDiscCl = new Int32SaveStruct();
            this.hasEnc = new Int32SaveStruct();
            this.hasEng = new Int32SaveStruct();
            this.events = new SimPlayerEventsSaveStruct();
            this.fngNum = new NestedInt32SaveStruct();
            this.pvSav = new Int32SaveStruct();
            this.pvMA = new Int32SaveStruct();
            this.aibN = new Int32SaveStruct();
            this.cnTrd = new BooleanSaveStruct();
            this.cnRad = new BooleanSaveStruct();
            this.hgs = new BooleanSaveStruct();
            this.hadvs = new BooleanSaveStruct();
            this.harcc = new BooleanSaveStruct();
            this.cnVItl = new BooleanSaveStruct();
            this.pddm = new FloatSaveStruct();
            this.bankWrn = new Int32SaveStruct();
            this.bankTrn = new Int32SaveStruct();
            this.bankPr = new Int32SaveStruct();
            this.bankEl = new Int32SaveStruct();
            this.shipRecs = new SimPlayerShipRecsEventsSaveStruct();
            this.nextPrjId = new Int32SaveStruct();
            this.plcy = new Int32SaveStruct();
            this.pswd = new Int32SaveStruct();
            this.lret = new Int32SaveStruct();
            this.nmeid = new Int32SaveStruct();
            this.cdp = new BooleanSaveStruct();
            this.spy2 = new SimPlayerSpySaveStruct();
            this.civR = new SimPlayerCivrSaveStruct();
            this.aidf = new Int32SaveStruct();
            this.srn = new BooleanSaveStruct();
            this.srcTo = new Int32SaveStruct();
            this.lboid = new Int32SaveStruct();
            this.lcid2 = new Int32SaveStruct();
            this.resTnm = new StringSaveStruct();
            this.resErrRoll = new BooleanSaveStruct();
            this.conMods = new SimPlayerModsSaveStruct();
            this.ownerIds = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.designs = new NonComplexArraySaveStruct<SimPlayerDesignEntrySaveStruct>();
            this.droneDesigns = new NonComplexArraySaveStruct<SimPlayerDesignEntrySaveStruct>();
            this.notes = new NonComplexArraySaveStruct<SimPlayerNote>();
            this.pr = new NonComplexArraySaveStruct<SimPlayerPr>();
            this.hasAiRebellion = new BooleanSaveStruct();
            this.cta = new BooleanSaveStruct();
            this.aienf = new NestedInt32SaveStruct();
            this.nSprj = new NonComplexArraySaveStruct<SimPlayerDetailsSpecialProjectT>();
            this.nexp = new Int32SaveStruct();
            this.nWeapXcl = new Int32SaveStruct();
            this.ovjs = new ComplexArraySaveStruct<SimPlayerDetailsOjv>();
            this.dipStats = new ComplexArraySaveStruct<SimPlayerDipStat>();
            this.comms = new ComplexArraySaveStruct<SimPlayerComm>();
            this.preps = new ComplexArraySaveStruct<SimPlayerPrepSaveStruct>();
            this.odes = new ComplexArraySaveStruct<SimPlayerOdesSaveStruct>();
            this.owep = new ComplexArraySaveStruct<SimPlayerOwepSaveStruct>();
            this.otch = new ComplexArraySaveStruct<SimPlayerOtchSaveStruct>();
            this.aid = new NestedInt32SaveStruct();
            this.ndeflay = new Int32SaveStruct();
            this.rdtc = new Int32SaveStruct();
            this.tnc = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.techTree.ReadFromStream(Data);
            this.homeSystem.ReadFromStream(Data);
            this.playerIndex.ReadFromStream(Data);
            this.playerName.ReadFromStream(Data);
            this.species.ReadFromStream(Data);
            this.colorId.ReadFromStream(Data);
            this.badge.ReadFromStream(Data);
            this.avatar.ReadFromStream(Data);
            this.team.ReadFromStream(Data);
            this.sav.ReadFromStream(Data);
            this.idealSuit.ReadFromStream(Data);
            this.suitTolerance.ReadFromStream(Data);
            this.maxOH.ReadFromStream(Data);
            this.resRate.ReadFromStream(Data);
            this.resModifier.ReadFromStream(Data);
            this.resScl.ReadFromStream(Data);
            this.trm.ReadFromStream(Data);
            this.trp.ReadFromStream(Data);
            this.tra.ReadFromStream(Data);
            this.outMod.ReadFromStream(Data);
            this.rebOutMod.ReadFromStream(Data);
            this.scOutMod.ReadFromStream(Data);
            this.incMod.ReadFromStream(Data);
            this.popMod.ReadFromStream(Data);
            this.terraMod.ReadFromStream(Data);
            this.aMine.ReadFromStream(Data);
            this.minPure.ReadFromStream(Data);
            this.minRate.ReadFromStream(Data);
            this.ngts.ReadFromStream(Data);
            this.prGtTrf.ReadFromStream(Data);
            this.gTraf.ReadFromStream(Data);
            this.cstR.ReadFromStream(Data);
            this.cstE.ReadFromStream(Data);
            this.cstT.ReadFromStream(Data);
            this.maint.ReadFromStream(Data);
            this.shrm.ReadFromStream(Data);
            this.status.ReadFromStream(Data);
            this.elim.ReadFromStream(Data);
            this.npc.ReadFromStream(Data);
            this.rebAi.ReadFromStream(Data);
            this.reqCL.ReadFromStream(Data);
            this.teamStruct.ReadFromStream(Data);
            this.hasVac.ReadFromStream(Data);
            this.hasImm.ReadFromStream(Data);
            this.npTrak.ReadFromStream(Data);
            this.hasDisc.ReadFromStream(Data);
            this.hasDiscSp.ReadFromStream(Data);
            this.hasDiscCl.ReadFromStream(Data);
            this.hasEnc.ReadFromStream(Data);
            this.hasEng.ReadFromStream(Data);
            this.events.ReadFromStream(Data);
            this.fngNum.ReadFromStream(Data);
            this.pvSav.ReadFromStream(Data);
            this.pvMA.ReadFromStream(Data);
            this.aibN.ReadFromStream(Data);
            this.cnTrd.ReadFromStream(Data);
            this.cnRad.ReadFromStream(Data);
            this.hgs.ReadFromStream(Data);
            this.hadvs.ReadFromStream(Data);
            this.harcc.ReadFromStream(Data);
            this.cnVItl.ReadFromStream(Data);
            this.pddm.ReadFromStream(Data);
            this.bankWrn.ReadFromStream(Data);
            this.bankTrn.ReadFromStream(Data);
            this.bankPr.ReadFromStream(Data);
            this.bankEl.ReadFromStream(Data);
            this.shipRecs.ReadFromStream(Data);
            this.nextPrjId.ReadFromStream(Data);
            this.plcy.ReadFromStream(Data);
            this.pswd.ReadFromStream(Data);
            this.lret.ReadFromStream(Data);
            this.nmeid.ReadFromStream(Data);
            this.cdp.ReadFromStream(Data);
            this.spy2.ReadFromStream(Data);
            this.civR.ReadFromStream(Data);
            this.aidf.ReadFromStream(Data);
            this.srn.ReadFromStream(Data);
            this.srcTo.ReadFromStream(Data);
            this.lboid.ReadFromStream(Data);
            this.lcid2.ReadFromStream(Data);
            this.resTnm.ReadFromStream(Data);
            this.resErrRoll.ReadFromStream(Data);
            this.conMods.ReadFromStream(Data);
            this.ownerIds.ReadFromStream(Data);
            this.designs.ReadFromStream(Data);
            this.droneDesigns.ReadFromStream(Data);
            this.notes.ReadFromStream(Data);
            this.pr.ReadFromStream(Data);
            this.hasAiRebellion.ReadFromStream(Data);
            this.cta.ReadFromStream(Data);
            this.aienf.ReadFromStream(Data);
            this.nSprj.ReadFromStream(Data);
            this.nexp.ReadFromStream(Data);
            this.nWeapXcl.ReadFromStream(Data);
            this.ovjs.ReadFromStream(Data);
            this.dipStats.ReadFromStream(Data);
            this.comms.ReadFromStream(Data);
            this.preps.ReadFromStream(Data);
            this.odes.ReadFromStream(Data);
            this.owep.ReadFromStream(Data);
            this.otch.ReadFromStream(Data);
            this.aid.ReadFromStream(Data);
            this.ndeflay.ReadFromStream(Data);
            this.rdtc.ReadFromStream(Data);
            this.tnc.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.techTree.WriteToStream(Destination);
            this.homeSystem.WriteToStream(Destination);
            this.playerIndex.WriteToStream(Destination);
            this.playerName.WriteToStream(Destination);
            this.species.WriteToStream(Destination);
            this.colorId.WriteToStream(Destination);
            this.badge.WriteToStream(Destination);
            this.avatar.WriteToStream(Destination);
            this.team.WriteToStream(Destination);
            this.sav.WriteToStream(Destination);
            this.idealSuit.WriteToStream(Destination);
            this.suitTolerance.WriteToStream(Destination);
            this.maxOH.WriteToStream(Destination);
            this.resRate.WriteToStream(Destination);
            this.resModifier.WriteToStream(Destination);
            this.resScl.WriteToStream(Destination);
            this.trm.WriteToStream(Destination);
            this.trp.WriteToStream(Destination);
            this.tra.WriteToStream(Destination);
            this.outMod.WriteToStream(Destination);
            this.rebOutMod.WriteToStream(Destination);
            this.scOutMod.WriteToStream(Destination);
            this.incMod.WriteToStream(Destination);
            this.popMod.WriteToStream(Destination);
            this.terraMod.WriteToStream(Destination);
            this.aMine.WriteToStream(Destination);
            this.minPure.WriteToStream(Destination);
            this.minRate.WriteToStream(Destination);
            this.ngts.WriteToStream(Destination);
            this.prGtTrf.WriteToStream(Destination);
            this.gTraf.WriteToStream(Destination);
            this.cstR.WriteToStream(Destination);
            this.cstE.WriteToStream(Destination);
            this.cstT.WriteToStream(Destination);
            this.maint.WriteToStream(Destination);
            this.shrm.WriteToStream(Destination);
            this.status.WriteToStream(Destination);
            this.elim.WriteToStream(Destination);
            this.npc.WriteToStream(Destination);
            this.rebAi.WriteToStream(Destination);
            this.reqCL.WriteToStream(Destination);
            this.teamStruct.WriteToStream(Destination);
            this.hasVac.WriteToStream(Destination);
            this.hasImm.WriteToStream(Destination);
            this.npTrak.WriteToStream(Destination);
            this.hasDisc.WriteToStream(Destination);
            this.hasDiscSp.WriteToStream(Destination);
            this.hasDiscCl.WriteToStream(Destination);
            this.hasEnc.WriteToStream(Destination);
            this.hasEng.WriteToStream(Destination);
            this.events.WriteToStream(Destination);
            this.fngNum.WriteToStream(Destination);
            this.pvSav.WriteToStream(Destination);
            this.pvMA.WriteToStream(Destination);
            this.aibN.WriteToStream(Destination);
            this.cnTrd.WriteToStream(Destination);
            this.cnRad.WriteToStream(Destination);
            this.hgs.WriteToStream(Destination);
            this.hadvs.WriteToStream(Destination);
            this.harcc.WriteToStream(Destination);
            this.cnVItl.WriteToStream(Destination);
            this.pddm.WriteToStream(Destination);
            this.bankWrn.WriteToStream(Destination);
            this.bankTrn.WriteToStream(Destination);
            this.bankPr.WriteToStream(Destination);
            this.bankEl.WriteToStream(Destination);
            this.shipRecs.WriteToStream(Destination);
            this.nextPrjId.WriteToStream(Destination);
            this.plcy.WriteToStream(Destination);
            this.pswd.WriteToStream(Destination);
            this.lret.WriteToStream(Destination);
            this.nmeid.WriteToStream(Destination);
            this.cdp.WriteToStream(Destination);
            this.spy2.WriteToStream(Destination);
            this.civR.WriteToStream(Destination);
            this.aidf.WriteToStream(Destination);
            this.srn.WriteToStream(Destination);
            this.srcTo.WriteToStream(Destination);
            this.lboid.WriteToStream(Destination);
            this.lcid2.WriteToStream(Destination);
            this.resTnm.WriteToStream(Destination);
            this.resErrRoll.WriteToStream(Destination);
            this.conMods.WriteToStream(Destination);
            this.ownerIds.WriteToStream(Destination);
            this.designs.WriteToStream(Destination);
            this.droneDesigns.WriteToStream(Destination);
            this.notes.WriteToStream(Destination);
            this.pr.WriteToStream(Destination);
            this.hasAiRebellion.WriteToStream(Destination);
            this.cta.WriteToStream(Destination);
            this.aienf.WriteToStream(Destination);
            this.nSprj.WriteToStream(Destination);
            this.nexp.WriteToStream(Destination);
            this.nWeapXcl.WriteToStream(Destination);
            this.ovjs.WriteToStream(Destination);
            this.dipStats.WriteToStream(Destination);
            this.comms.WriteToStream(Destination);
            this.preps.WriteToStream(Destination);
            this.odes.WriteToStream(Destination);
            this.owep.WriteToStream(Destination);
            this.otch.WriteToStream(Destination);
            this.aid.WriteToStream(Destination);
            this.ndeflay.WriteToStream(Destination);
            this.rdtc.WriteToStream(Destination);
            this.tnc.WriteToStream(Destination);
        }
    }
    #endregion
    
    #region Species
    public class SimSpeciesArraySaveStruct : ISotsStructure
    {
        protected Int32 SpeciesCount
        {
            get { return 7; }
        }

        protected SimSpeciesSaveStruct[] species;

        public SimSpeciesSaveStruct[] Species
        {
            get { return species; }
            set { species = value; }
        }

        /// <summary>Defaul constructor</summary>
        public SimSpeciesArraySaveStruct()
        {
            this.species = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.species = new SimSpeciesSaveStruct[this.SpeciesCount];
            for (Int32 i = 0; i < this.species.Length; i++)
            {
                this.species[i] = new SimSpeciesSaveStruct();
                this.species[i].ReadFromStream(Data);
            }
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            for (Int32 i = 0; i < this.species.Length; i++)
                this.species[i].WriteToStream(Destination);
        }
    }

    public class SimSpeciesSaveStruct : ISotsStructure
    {
        protected StringSaveStruct isSp;    //species
        protected FloatSaveStruct isSu;     //species suitability?

        public StringSaveStruct IsSp
        {
            get { return isSp; }
            set { isSp = value; }
        }

        public FloatSaveStruct IsSu
        {
            get { return isSu; }
            set { isSu = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSpeciesSaveStruct()
        {
            this.isSp = new StringSaveStruct();
            this.isSu = new FloatSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.isSp.ReadFromStream(Data);
            this.isSu.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.isSp.WriteToStream(Destination);
            this.isSu.WriteToStream(Destination);
        }
    }
    #endregion

    #region Systems
    public class SimSystemSaveStruct : ISotsStructure
    {
        protected Int32SaveStruct sysId;
        protected SimSystemDetailsSaveStruct details;

        public Int32SaveStruct SysId
        {
            get { return sysId; }
            set { sysId = value; }
        }

        public SimSystemDetailsSaveStruct Details
        {
            get { return details; }
            set { details = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemSaveStruct()
        {
            this.sysId = new Int32SaveStruct();
            this.details = new SimSystemDetailsSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.sysId.ReadFromStream(Data);
            this.details.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.sysId.WriteToStream(Destination);
            this.details.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailRtsSaveStruct : ComplexSaveStruct
    {
        protected FloatSaveStruct sRs;
        protected FloatSaveStruct sRt;
        protected FloatSaveStruct sRsc;
        protected FloatSaveStruct sRtf;
        protected FloatSaveStruct sRi;
        protected FloatSaveStruct sRoh;
        protected FloatSaveStruct sRnr;

        #region Properties
        public FloatSaveStruct SRs
        {
            get { return sRs; }
            set { sRs = value; }
        }

        public FloatSaveStruct SRt
        {
            get { return sRt; }
            set { sRt = value; }
        }

        public FloatSaveStruct SRsc
        {
            get { return sRsc; }
            set { sRsc = value; }
        }

        public FloatSaveStruct SRtf
        {
            get { return sRtf; }
            set { sRtf = value; }
        }

        public FloatSaveStruct SRi
        {
            get { return sRi; }
            set { sRi = value; }
        }

        public FloatSaveStruct SRoh
        {
            get { return sRoh; }
            set { sRoh = value; }
        }

        public FloatSaveStruct SRnr
        {
            get { return sRnr; }
            set { sRnr = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimSystemDetailRtsSaveStruct() : base()
        {
            this.sRs = new FloatSaveStruct();
            this.sRt = new FloatSaveStruct();
            this.sRsc = new FloatSaveStruct();
            this.sRtf = new FloatSaveStruct();
            this.sRi = new FloatSaveStruct();
            this.sRoh = new FloatSaveStruct();
            this.sRnr = new FloatSaveStruct();
        }


        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.sRs.ReadFromStream(Data);
            this.sRt.ReadFromStream(Data);
            this.sRsc.ReadFromStream(Data);
            this.sRtf.ReadFromStream(Data);
            this.sRi.ReadFromStream(Data);
            this.sRoh.ReadFromStream(Data);
            this.sRnr.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.sRs.WriteToStream(Destination);
            this.sRt.WriteToStream(Destination);
            this.sRsc.WriteToStream(Destination);
            this.sRtf.WriteToStream(Destination);
            this.sRi.WriteToStream(Destination);
            this.sRoh.WriteToStream(Destination);
            this.sRnr.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailHalt : ISotsStructure
    {
        protected Int32SaveStruct haltt;
        protected BooleanSaveStruct haltv;

        public Int32SaveStruct Haltt
        {
            get { return haltt; }
            set { haltt = value; }
        }

        public BooleanSaveStruct Haltv
        {
            get { return haltv; }
            set { haltv = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailHalt()
        {
            this.haltt = new Int32SaveStruct();
            this.haltv = new BooleanSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.haltt.ReadFromStream(Data);
            this.haltv.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.haltt.WriteToStream(Destination);
            this.haltv.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailFlags1 : ISotsStructure
    {
        protected Int32SaveStruct vFlags;
        protected Int32SaveStruct eFlags;
        protected Int32SaveStruct aFlags;
        protected Int32SaveStruct fFlags;
        protected Int32SaveStruct gFlags;

        public Int32SaveStruct VFlags
        {
            get { return vFlags; }
            set { vFlags = value; }
        }

        public Int32SaveStruct EFlags
        {
            get { return eFlags; }
            set { eFlags = value; }
        }

        public Int32SaveStruct AFlags
        {
            get { return aFlags; }
            set { aFlags = value; }
        }

        public Int32SaveStruct FFlags
        {
            get { return fFlags; }
            set { fFlags = value; }
        }

        public Int32SaveStruct GFlags
        {
            get { return gFlags; }
            set { gFlags = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailFlags1()
        {
            this.vFlags = new Int32SaveStruct();
            this.eFlags = new Int32SaveStruct();
            this.aFlags = new Int32SaveStruct();
            this.fFlags = new Int32SaveStruct();
            this.gFlags = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.vFlags.ReadFromStream(Data);
            this.eFlags.ReadFromStream(Data);
            this.aFlags.ReadFromStream(Data);
            this.fFlags.ReadFromStream(Data);
            this.gFlags.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.vFlags.WriteToStream(Destination);
            this.eFlags.WriteToStream(Destination);
            this.aFlags.WriteToStream(Destination);
            this.fFlags.WriteToStream(Destination);
            this.gFlags.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailFlags2 : ISotsStructure
    {
        protected Int32SaveStruct mnRFlags;
        protected Int32SaveStruct rfRFlags;
        protected Int32SaveStruct clkFlags;

        public Int32SaveStruct MnRFlags
        {
            get { return mnRFlags; }
            set { mnRFlags = value; }
        }

        public Int32SaveStruct RfRFlags
        {
            get { return rfRFlags; }
            set { rfRFlags = value; }
        }

        public Int32SaveStruct ClkFlags
        {
            get { return clkFlags; }
            set { clkFlags = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailFlags2()
        {
            this.mnRFlags = new Int32SaveStruct();
            this.rfRFlags = new Int32SaveStruct();
            this.clkFlags = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.mnRFlags.ReadFromStream(Data);
            this.rfRFlags.ReadFromStream(Data);
            this.clkFlags.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.mnRFlags.WriteToStream(Destination);
            this.rfRFlags.WriteToStream(Destination);
            this.clkFlags.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailCm : ISotsStructure
    {
        protected Int32SaveStruct msp;
        protected Int32SaveStruct mv;

        public Int32SaveStruct Msp
        {
            get { return msp; }
            set { msp = value; }
        }

        public Int32SaveStruct Mv
        {
            get { return mv; }
            set { mv = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailCm() : base()
        {
            this.msp = new Int32SaveStruct();
            this.mv = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.msp.ReadFromStream(Data);
            this.mv.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.msp.WriteToStream(Destination);
            this.mv.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailCme2 : ComplexSaveStruct
    {
        protected Int32SaveStruct mid;
        protected Int32SaveStruct mtrT;
        protected Int32SaveStruct mn;
        protected Int32SaveStruct mtp;
        protected ComplexArraySaveStruct<SimSystemDetailCm> mfx;
        protected StringSaveStruct mdsc;

        #region Properties
        public Int32SaveStruct Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        public Int32SaveStruct MtrT
        {
            get { return mtrT; }
            set { mtrT = value; }
        }

        public Int32SaveStruct Mn
        {
            get { return mn; }
            set { mn = value; }
        }

        public Int32SaveStruct Mtp
        {
            get { return mtp; }
            set { mtp = value; }
        }

        public ComplexArraySaveStruct<SimSystemDetailCm> Mfx
        {
            get { return mfx; }
            set { mfx = value; }
        }

        public StringSaveStruct Mdsc
        {
            get { return mdsc; }
            set { mdsc = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimSystemDetailCme2() : base()
        {
            this.mid = new Int32SaveStruct();
            this.mtrT = new Int32SaveStruct();
            this.mn = new Int32SaveStruct();
            this.mtp = new Int32SaveStruct();
            this.mfx = new ComplexArraySaveStruct<SimSystemDetailCm>();
            this.mdsc = new StringSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.mid.ReadFromStream(Data);
            this.mtrT.ReadFromStream(Data);
            this.mn.ReadFromStream(Data);
            this.mtp.ReadFromStream(Data);
            this.mfx.ReadFromStream(Data);
            this.mdsc.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.mid.WriteToStream(Destination);
            this.mtrT.WriteToStream(Destination);
            this.mn.WriteToStream(Destination);
            this.mtp.WriteToStream(Destination);
            this.mfx.WriteToStream(Destination);
            this.mdsc.WriteToStream(Destination);
        }
    }

    //need to run some spies
    public class SimSystemDetailSpy : ComplexSaveStruct
    {

        /// <summary>Default constructor</summary>
        public SimSystemDetailSpy() : base()
        {
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
        }
    }

    public class SimSystemDetailAdct : ISotsStructure
    {
        protected Int32SaveStruct ads;
        protected Int32SaveStruct adt;

        #region Properties
        public Int32SaveStruct Ads
        {
            get { return this.ads; }
            set { this.ads = value; }
        }

        public Int32SaveStruct Adt
        {
            get { return this.adt; }
            set { this.adt = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimSystemDetailAdct()
        {
            this.ads = new Int32SaveStruct();
            this.adt = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.ads.ReadFromStream(Data);
            this.adt.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.ads.WriteToStream(Destination);
            this.adt.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailNvo : ISotsStructure
    {
        protected Int32SaveStruct pid;
        protected Int32SaveStruct tShn;
        protected Int32SaveStruct oId;
        protected BooleanSaveStruct isInd;      //is independent colony?
        protected SimSystemDetailNvoIndi indi;

        #region Properties
        public Int32SaveStruct Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public Int32SaveStruct TShn
        {
            get { return tShn; }
            set { tShn = value; }
        }

        public Int32SaveStruct OId
        {
            get { return oId; }
            set { oId = value; }
        }

        public BooleanSaveStruct IsInd
        {
            get { return isInd; }
            set { isInd = value; }
        }

        public SimSystemDetailNvoIndi Indi
        {
            get { return indi; }
            set { indi = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimSystemDetailNvo()
        {
            this.pid = new Int32SaveStruct();
            this.tShn = new Int32SaveStruct();
            this.oId = new Int32SaveStruct();
            this.isInd = new BooleanSaveStruct();
            this.indi = new SimSystemDetailNvoIndi();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.pid.ReadFromStream(Data);
            this.tShn.ReadFromStream(Data);
            this.oId.ReadFromStream(Data);
            this.isInd.ReadFromStream(Data);
            this.indi.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.pid.WriteToStream(Destination);
            this.tShn.WriteToStream(Destination);
            this.oId.WriteToStream(Destination);
            this.isInd.WriteToStream(Destination);
            this.indi.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailNvoIndi : ComplexSaveStruct
    {
        protected Int32SaveStruct indsp;
        protected SimSystemDetailNvoIndcl indcl;
        protected StringSaveStruct indnm;           //independent name
        protected StringSaveStruct indav;           //independent avatar
        protected StringSaveStruct indba;           //independent badge

        public Int32SaveStruct Indsp
        {
            get { return indsp; }
            set { indsp = value; }
        }

        public SimSystemDetailNvoIndcl Indcl
        {
            get { return indcl; }
            set { indcl = value; }
        }

        public StringSaveStruct Indnm
        {
            get { return indnm; }
            set { indnm = value; }
        }

        public StringSaveStruct Indav
        {
            get { return indav; }
            set { indav = value; }
        }

        public StringSaveStruct Indba
        {
            get { return indba; }
            set { indba = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailNvoIndi() : base()
        {
            this.indsp = new Int32SaveStruct();
            this.indcl = new SimSystemDetailNvoIndcl();
            this.indnm = new StringSaveStruct();
            this.indav = new StringSaveStruct();
            this.indba = new StringSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.indsp.ReadFromStream(Data);
            this.indcl.ReadFromStream(Data);
            this.indnm.ReadFromStream(Data);
            this.indav.ReadFromStream(Data);
            this.indba.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.indsp.WriteToStream(Destination);
            this.indcl.WriteToStream(Destination);
            this.indnm.WriteToStream(Destination);
            this.indav.WriteToStream(Destination);
            this.indba.WriteToStream(Destination);
        }
    }

    /// <remarks>no idea what this is. either 1 int32save struct or 4</remarks>
    public class SimSystemDetailNvoIndcl : ComplexSaveStruct
    {
        protected Int32SaveStruct unknown1;         //0 if 1, FFFFFFFF if 4
        protected SimSystemDetailNvoIndclUnknowns unknownSet;

        public Int32SaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public SimSystemDetailNvoIndclUnknowns UnknownSet
        {
            get { return unknownSet; }
            set { unknownSet = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailNvoIndcl() : base()
        {
            this.unknown1 = new Int32SaveStruct();
            this.unknownSet = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.unknown1.ReadFromStream(Data);

            if (this.unknown1.Value == -1)
            {
                this.unknownSet = new SimSystemDetailNvoIndclUnknowns();
                this.unknownSet.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);

            if (this.unknown1.Value == -1)
                this.unknownSet.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailNvoIndclUnknowns : ISotsStructure
    {
        protected Int32SaveStruct unknown1;
        protected Int32SaveStruct unknown2;
        protected Int32SaveStruct unknown3;

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

        /// <summary>Default constructor</summary>
        public SimSystemDetailNvoIndclUnknowns()
        {
            this.unknown1 = new Int32SaveStruct();
            this.unknown2 = new Int32SaveStruct();
            this.unknown3 = new Int32SaveStruct();
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

    public class SimSystemDetailBq : ComplexSaveStruct
    {
        protected ComplexArraySaveStruct<SimSystemDetailBqOrd> ords;

        public ComplexArraySaveStruct<SimSystemDetailBqOrd> Ords
        {
            get { return ords; }
            set { ords = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailBq() : base()
        {
            this.ords = new ComplexArraySaveStruct<SimSystemDetailBqOrd>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ords.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ords.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailBqOrd : ComplexSaveStruct   //orders?
    {
        protected Int32SaveStruct desId;
        protected Int32SaveStruct con;
        protected Int32SaveStruct conleft;
        protected Int32SaveStruct sav;
        protected Int32SaveStruct ordId;

        public Int32SaveStruct DesId
        {
            get { return desId; }
            set { desId = value; }
        }

        public Int32SaveStruct Con
        {
            get { return con; }
            set { con = value; }
        }

        public Int32SaveStruct Conleft
        {
            get { return conleft; }
            set { conleft = value; }
        }

        public Int32SaveStruct Sav
        {
            get { return sav; }
            set { sav = value; }
        }

        public Int32SaveStruct OrdId
        {
            get { return ordId; }
            set { ordId = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailBqOrd() : base()
        {
            this.desId = new Int32SaveStruct();
            this.con = new Int32SaveStruct();
            this.conleft = new Int32SaveStruct();
            this.sav = new Int32SaveStruct();
            this.ordId = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.desId.ReadFromStream(Data);
            this.con.ReadFromStream(Data);
            this.conleft.ReadFromStream(Data);
            this.sav.ReadFromStream(Data);
            this.ordId.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.desId.WriteToStream(Destination);
            this.con.WriteToStream(Destination);
            this.conleft.WriteToStream(Destination);
            this.sav.WriteToStream(Destination);
            this.ordId.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailVe : ISotsStructure
    {
        protected Int32SaveStruct ePid;
        protected Int32SaveStruct ets;
        protected Int32SaveStruct eid;

        public Int32SaveStruct EPid
        {
            get { return ePid; }
            set { ePid = value; }
        }

        public Int32SaveStruct Ets
        {
            get { return ets; }
            set { ets = value; }
        }

        public Int32SaveStruct Eid
        {
            get { return eid; }
            set { eid = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailVe()
        {
            this.ePid = new Int32SaveStruct();
            this.ets = new Int32SaveStruct();
            this.eid = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.ePid.ReadFromStream(Data);
            this.ets.ReadFromStream(Data);
            this.eid.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.ePid.WriteToStream(Destination);
            this.ets.WriteToStream(Destination);
            this.eid.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailVs : ISotsStructure
    {
        protected Int32SaveStruct pid;
        protected SimSystemDetailVsPView pview;

        public Int32SaveStruct Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public SimSystemDetailVsPView Pview
        {
            get { return pview; }
            set { pview = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailVs()
        {
            this.pid = new Int32SaveStruct();
            this.pview = new SimSystemDetailVsPView();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.pid.ReadFromStream(Data);
            this.pview.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.pid.WriteToStream(Destination);
            this.pview.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailVsPView : ComplexSaveStruct
    {
        protected Int32SaveStruct vTrn;
        protected Int32SaveStruct pop;
        protected ComplexArraySaveStruct<SimPopGSaveStruct> pop2;
        protected Int32SaveStruct infra;
        protected FloatSaveStruct suit;     //climate hazard
        protected Int32SaveStruct res;      //resources
        protected Int32SaveStruct aRes2;    //?
        protected Int32SaveStruct mRes;     //?
        protected BooleanSaveStruct noRebAi;    //no AI rebellion
        protected Int32SaveStruct pbon;
        protected ComplexArraySaveStruct<SimPopGSaveStruct> pbon2;
        protected FloatSaveStruct ibon;
        protected Int32SaveStruct terrFl;
        protected BooleanSaveStruct footer;
        
        #region Properties
        public Int32SaveStruct VTrn
        {
            get { return vTrn; }
            set { vTrn = value; }
        }

        public Int32SaveStruct Pop
        {
            get { return pop; }
            set { pop = value; }
        }

        public ComplexArraySaveStruct<SimPopGSaveStruct> Pop2
        {
            get { return pop2; }
            set { pop2 = value; }
        }

        public Int32SaveStruct Infra
        {
            get { return infra; }
            set { infra = value; }
        }

        public FloatSaveStruct Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public Int32SaveStruct Res
        {
            get { return res; }
            set { res = value; }
        }

        public Int32SaveStruct ARes2
        {
            get { return aRes2; }
            set { aRes2 = value; }
        }

        public Int32SaveStruct MRes
        {
            get { return mRes; }
            set { mRes = value; }
        }

        public BooleanSaveStruct NoRebAi
        {
            get { return noRebAi; }
            set { noRebAi = value; }
        }

        public Int32SaveStruct Pbon
        {
            get { return pbon; }
            set { pbon = value; }
        }

        public ComplexArraySaveStruct<SimPopGSaveStruct> Pbon2
        {
            get { return pbon2; }
            set { pbon2 = value; }
        }

        public FloatSaveStruct Ibon
        {
            get { return ibon; }
            set { ibon = value; }
        }

        public Int32SaveStruct TerrFl
        {
            get { return terrFl; }
            set { terrFl = value; }
        }

        public BooleanSaveStruct Footer
        {
            get { return footer; }
            set { footer = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimSystemDetailVsPView() : base()
        {
            this.vTrn = new Int32SaveStruct();
            this.pop = new Int32SaveStruct();
            this.pop2 = new ComplexArraySaveStruct<SimPopGSaveStruct>();
            this.infra = new Int32SaveStruct();
            this.suit = new FloatSaveStruct();
            this.res = new Int32SaveStruct();
            this.aRes2 = new Int32SaveStruct();
            this.mRes = new Int32SaveStruct();
            this.noRebAi = new BooleanSaveStruct();
            this.pbon = new Int32SaveStruct();
            this.pbon2 = new ComplexArraySaveStruct<SimPopGSaveStruct>();
            this.ibon = new FloatSaveStruct();
            this.terrFl = new Int32SaveStruct();
            this.footer = new BooleanSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.vTrn.ReadFromStream(Data);
            this.pop.ReadFromStream(Data);
            this.pop2.ReadFromStream(Data);
            this.infra.ReadFromStream(Data);
            this.suit.ReadFromStream(Data);
            this.res.ReadFromStream(Data);
            this.aRes2.ReadFromStream(Data);
            this.mRes.ReadFromStream(Data);
            this.noRebAi.ReadFromStream(Data);
            this.pbon.ReadFromStream(Data);
            this.pbon2.ReadFromStream(Data);
            this.ibon.ReadFromStream(Data);
            this.terrFl.ReadFromStream(Data);
            this.footer.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.vTrn.WriteToStream(Destination);
            this.pop.WriteToStream(Destination);
            this.pop2.WriteToStream(Destination);
            this.infra.WriteToStream(Destination);
            this.suit.WriteToStream(Destination);
            this.res.WriteToStream(Destination);
            this.aRes2.WriteToStream(Destination);
            this.mRes.WriteToStream(Destination);
            this.noRebAi.WriteToStream(Destination);
            this.pbon.WriteToStream(Destination);
            this.pbon2.WriteToStream(Destination);
            this.ibon.WriteToStream(Destination);
            this.terrFl.WriteToStream(Destination);
            this.footer.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailsIndi : ISotsStructure
    {
        protected BooleanSaveStruct hindi;
        protected SimSystemDetailsIndiDetails indi;

        public BooleanSaveStruct Hindi
        {
            get { return hindi; }
            set { hindi = value; }
        }

        public SimSystemDetailsIndiDetails Indi
        {
            get { return indi; }
            set { indi = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailsIndi()
        {
            this.hindi = new BooleanSaveStruct();
            this.indi = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.hindi.ReadFromStream(Data);

            if (this.hindi.BooleanValue)
            {
                this.indi = new SimSystemDetailsIndiDetails();
                this.indi.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.hindi.WriteToStream(Destination);

            if (this.hindi.BooleanValue)
                this.indi.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailsIndiDetails : ComplexSaveStruct
    {
        protected Int32SaveStruct indsp;
        protected SimPlayerColorSaveStruct indcl;
        protected StringSaveStruct indnm;
        protected StringSaveStruct indav;
        protected StringSaveStruct indba;

        #region Properties
        public Int32SaveStruct Indsp
        {
            get { return indsp; }
            set { indsp = value; }
        }

        public SimPlayerColorSaveStruct Indcl
        {
            get { return indcl; }
            set { indcl = value; }
        }

        public StringSaveStruct Indnm
        {
            get { return indnm; }
            set { indnm = value; }
        }

        public StringSaveStruct Indav
        {
            get { return indav; }
            set { indav = value; }
        }

        public StringSaveStruct Indba
        {
            get { return indba; }
            set { indba = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimSystemDetailsIndiDetails() : base()
        {
            this.indsp = new Int32SaveStruct();
            this.indcl = new SimPlayerColorSaveStruct();
            this.indnm = new StringSaveStruct();
            this.indav = new StringSaveStruct();
            this.indba = new StringSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.indsp.ReadFromStream(Data);
            this.indcl.ReadFromStream(Data);
            this.indnm.ReadFromStream(Data);
            this.indav.ReadFromStream(Data);
            this.indba.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.indsp.WriteToStream(Destination);
            this.indcl.WriteToStream(Destination);
            this.indnm.WriteToStream(Destination);
            this.indav.WriteToStream(Destination);
            this.indba.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailsVonNeumann : ISotsStructure
    {
        /// <remarks>Appears to be followed by additional data only if true.</remarks>
        protected BooleanSaveStruct vnh;            //von neumann homeworld
        protected SimSystemDetailsVonNeumannDetails details;

        public BooleanSaveStruct Vnh
        {
            get { return vnh; }
            set { vnh = value; }
        }

        public SimSystemDetailsVonNeumannDetails Details
        {
            get { return details; }
            set { details = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailsVonNeumann()
        {
            this.vnh = new BooleanSaveStruct();
            this.details = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.vnh.ReadFromStream(Data);

            if (this.vnh.BooleanValue)
            {
                this.details = new SimSystemDetailsVonNeumannDetails();
                this.details.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.vnh.WriteToStream(Destination);

            if (this.vnh.BooleanValue)
                this.details.WriteToStream(Destination);
        }
    }

    public class SimSystemDetailsVonNeumannDetails : ISotsStructure
    {
        protected BooleanSaveStruct vnd;            //von neumann death star?
        protected BooleanSaveStruct vnex3;
        protected BooleanSaveStruct vnpex3;

        public BooleanSaveStruct Vnd
        {
            get { return vnd; }
            set { vnd = value; }
        }

        public BooleanSaveStruct Vnex3
        {
            get { return vnex3; }
            set { vnex3 = value; }
        }

        public BooleanSaveStruct Vnpex3
        {
            get { return vnpex3; }
            set { vnpex3 = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSystemDetailsVonNeumannDetails()
        {
            this.vnd =  new BooleanSaveStruct();
            this.vnex3 = new BooleanSaveStruct();
            this.vnpex3 = new BooleanSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.vnd.ReadFromStream(Data);
            this.vnex3.ReadFromStream(Data);
            this.vnpex3.ReadFromStream(Data);
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.vnd.WriteToStream(Destination);
            this.vnex3.WriteToStream(Destination);
            this.vnpex3.WriteToStream(Destination);
        }
    }

    /// <summary>Most content of the system definition</summary>
    public class SimSystemDetailsSaveStruct : ComplexSaveStruct
    {
        protected SpatialCoordinateSaveStruct pos;
        protected RgbaColorFloat starColor;
        protected Int32SaveStruct idx;
        protected Int32SaveStruct size;     //scale 1-10
        protected FloatSaveStruct suit;     //climate hazard
        protected Int32SaveStruct res;      //resources?
        protected Int32SaveStruct aRes;     //?
        protected Int32SaveStruct mRes;     //?
        protected BooleanSaveStruct noRebAi;    //no AI rebellion
        protected Int32SaveStruct tRes;     //?
        protected Int32SaveStruct pop;      //population (imperial?)
        protected ComplexArraySaveStruct<SimPopGSaveStruct> popG;
        protected FloatSaveStruct infra;    //infrastructure
        protected Int32SaveStruct pvPop;    //?
        protected ComplexArraySaveStruct<SimPopGSaveStruct> pvPopG;
        protected FloatSaveStruct pvInfra;
        protected FloatSaveStruct pvSuit;
        protected Int32SaveStruct pvRes;
        protected Int32SaveStruct pvARes2;     //?
        protected Int32SaveStruct pvMRes;     //?
        protected BooleanSaveStruct pvNoRebAi;    //no AI rebellion
        protected SimSystemDetailRtsSaveStruct rts;
        protected Int32SaveStruct abdn;     //abandoned colony?
        protected BooleanSaveStruct dstyd;
        protected Int32SaveStruct tnsOh;
        protected FloatSaveStruct outMod;
        protected FloatSaveStruct repCur;   //repair avail.
        protected FloatSaveStruct repMax;   //max. turn repair
        protected Int32SaveStruct ntdev;
        protected Int32SaveStruct pbon;     //population bonus?
        protected ComplexArraySaveStruct<SimPopGSaveStruct> pbon2;  //PopG bonus?
        protected FloatSaveStruct ibon;     //infrastructure bonus?
        protected Int32SaveStruct ltis;
        protected Int32SaveStruct rbfl;
        protected Int32SaveStruct rbtn;
        protected Int32SaveStruct rbfr;
        protected Int32SaveStruct rbwn;
        protected Int32SaveStruct hsrg;
        protected NonComplexArraySaveStruct<SimSystemDetailHalt> halt;
        protected SimSystemDetailsVonNeumann vnm;
        protected StringSaveStruct name;
        protected SimSystemDetailFlags1 flags1;
        protected Int64SaveStruct bats2;
        protected Int64SaveStruct rcex;
        protected SimSystemDetailFlags2 flags2;
        protected Int32SaveStruct eggScio;
        protected Int32SaveStruct terrFl;
        protected Int32SaveStruct tAcq;
        protected Int32SaveStruct tfAcq;
        protected Int32SaveStruct tDst;
        protected ComplexArraySaveStruct<SimPopGSaveStruct> dcs;
        protected Int32SaveStruct dsu;
        protected ComplexArraySaveStruct<SimSystemDetailCm> cm;
        protected ComplexArraySaveStruct<SimSystemDetailCm> pvcm;
        protected ComplexArraySaveStruct<SimSystemDetailCme2> cme2;
        protected ComplexArraySaveStruct<SimSystemDetailSpy> spies;
        protected Int32SaveStruct pid;  //player (owner) id
        protected Int32SaveStruct defF;
        protected Int32SaveStruct defSf;

        //bq -- only if an imperial planet?
        protected SimSystemDetailBq bq;

        protected NonComplexArraySaveStruct<SimSystemDetailAdct> adct;    //a noncomplex array of ... something
        protected Int32SaveStruct numPlgs2;      //probably a noncomplex array of plauges affecting system.
        protected NonComplexArraySaveStruct<Int32SaveStruct> flts;
        protected NonComplexArraySaveStruct<FloatSaveStruct> gfs;
        protected NonComplexArraySaveStruct<Int32SaveStruct> snF;
        protected NonComplexArraySaveStruct<Int32SaveStruct> mnF;
        protected NonComplexArraySaveStruct<SimSystemDetailNvo> nvos;
        protected NonComplexArraySaveStruct<SimSystemDetailVe> nve;
        protected NonComplexArraySaveStruct<SimSystemDetailVs> nvs;
        protected SimSystemDetailsIndi indi;

        #region Properties
        public SpatialCoordinateSaveStruct Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public RgbaColorFloat StarColor
        {
            get { return starColor; }
            set { starColor = value; }
        }

        public Int32SaveStruct Idx
        {
            get { return idx; }
            set { idx = value; }
        }

        public Int32SaveStruct Size
        {
            get { return size; }
            set { size = value; }
        }

        public FloatSaveStruct Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public Int32SaveStruct Res
        {
            get { return res; }
            set { res = value; }
        }

        public Int32SaveStruct ARes
        {
            get { return aRes; }
            set { aRes = value; }
        }

        public Int32SaveStruct MRes
        {
            get { return mRes; }
            set { mRes = value; }
        }

        public BooleanSaveStruct NoRebAi
        {
            get { return noRebAi; }
            set { noRebAi = value; }
        }

        public Int32SaveStruct TRes
        {
            get { return tRes; }
            set { tRes = value; }
        }

        public Int32SaveStruct Pop
        {
            get { return pop; }
            set { pop = value; }
        }

        public ComplexArraySaveStruct<SimPopGSaveStruct> PopG
        {
            get { return popG; }
            set { popG = value; }
        }

        public FloatSaveStruct Infra
        {
            get { return infra; }
            set { infra = value; }
        }

        public Int32SaveStruct PvPop
        {
            get { return pvPop; }
            set { pvPop = value; }
        }

        public ComplexArraySaveStruct<SimPopGSaveStruct> PvPopG
        {
            get { return pvPopG; }
            set { pvPopG = value; }
        }

        public FloatSaveStruct PvInfra
        {
            get { return pvInfra; }
            set { pvInfra = value; }
        }

        public FloatSaveStruct PvSuit
        {
            get { return pvSuit; }
            set { pvSuit = value; }
        }

        public Int32SaveStruct PvRes
        {
            get { return pvRes; }
            set { pvRes = value; }
        }

        public Int32SaveStruct PvARes2
        {
            get { return pvARes2; }
            set { pvARes2 = value; }
        }

        public Int32SaveStruct PvMRes
        {
            get { return pvMRes; }
            set { pvMRes = value; }
        }

        public BooleanSaveStruct PvNoRebAi
        {
            get { return pvNoRebAi; }
            set { pvNoRebAi = value; }
        }

        public SimSystemDetailRtsSaveStruct Rts
        {
            get { return rts; }
            set { rts = value; }
        }

        public Int32SaveStruct Abdn
        {
            get { return abdn; }
            set { abdn = value; }
        }

        public BooleanSaveStruct Dstyd
        {
            get { return dstyd; }
            set { dstyd = value; }
        }

        public Int32SaveStruct TnsOh
        {
            get { return tnsOh; }
            set { tnsOh = value; }
        }

        public FloatSaveStruct OutMod
        {
            get { return outMod; }
            set { outMod = value; }
        }

        public FloatSaveStruct RepCur
        {
            get { return repCur; }
            set { repCur = value; }
        }

        public FloatSaveStruct RepMax
        {
            get { return repMax; }
            set { repMax = value; }
        }

        public Int32SaveStruct Ntdev
        {
            get { return ntdev; }
            set { ntdev = value; }
        }

        public Int32SaveStruct Pbon
        {
            get { return pbon; }
            set { pbon = value; }
        }

        public ComplexArraySaveStruct<SimPopGSaveStruct> Pbon2
        {
            get { return pbon2; }
            set { pbon2 = value; }
        }

        public FloatSaveStruct Ibon
        {
            get { return ibon; }
            set { ibon = value; }
        }

        public Int32SaveStruct Ltis
        {
            get { return ltis; }
            set { ltis = value; }
        }

        public Int32SaveStruct Rbfl
        {
            get { return rbfl; }
            set { rbfl = value; }
        }

        public Int32SaveStruct Rbtn
        {
            get { return rbtn; }
            set { rbtn = value; }
        }

        public Int32SaveStruct Rbfr
        {
            get { return rbfr; }
            set { rbfr = value; }
        }

        public Int32SaveStruct Rbwn
        {
            get { return rbwn; }
            set { rbwn = value; }
        }

        public Int32SaveStruct Hsrg
        {
            get { return hsrg; }
            set { hsrg = value; }
        }

        public NonComplexArraySaveStruct<SimSystemDetailHalt> Halt
        {
            get { return halt; }
            set { halt = value; }
        }
        
        public SimSystemDetailsVonNeumann Vnm
        {
            get { return vnm; }
            set { vnm = value; }
        }

        public StringSaveStruct Name
        {
            get { return name; }
            set { name = value; }
        }

        public SimSystemDetailFlags1 Flags1
        {
            get { return flags1; }
            set { flags1 = value; }
        }

        public Int64SaveStruct Bats2
        {
            get { return bats2; }
            set { bats2 = value; }
        }

        public Int64SaveStruct Rcex
        {
            get { return rcex; }
            set { rcex = value; }
        }

        public SimSystemDetailFlags2 Flags2
        {
            get { return flags2; }
            set { flags2 = value; }
        }

        public Int32SaveStruct EggScio
        {
            get { return eggScio; }
            set { eggScio = value; }
        }

        public Int32SaveStruct TerrFl
        {
            get { return terrFl; }
            set { terrFl = value; }
        }

        public Int32SaveStruct TAcq
        {
            get { return tAcq; }
            set { tAcq = value; }
        }

        public Int32SaveStruct TfAcq
        {
            get { return tfAcq; }
            set { tfAcq = value; }
        }

        public Int32SaveStruct TDst
        {
            get { return tDst; }
            set { tDst = value; }
        }

        public ComplexArraySaveStruct<SimPopGSaveStruct> Dcs
        {
            get { return dcs; }
            set { dcs = value; }
        }

        public Int32SaveStruct Dsu
        {
            get { return dsu; }
            set { dsu = value; }
        }

        public ComplexArraySaveStruct<SimSystemDetailCm> Cm
        {
            get { return cm; }
            set { cm = value; }
        }

        public ComplexArraySaveStruct<SimSystemDetailCm> Pvcm
        {
            get { return pvcm; }
            set { pvcm = value; }
        }

        public ComplexArraySaveStruct<SimSystemDetailCme2> Cme2
        {
            get { return cme2; }
            set { cme2 = value; }
        }

        public ComplexArraySaveStruct<SimSystemDetailSpy> Spies
        {
            get { return spies; }
            set { spies = value; }
        }

        public Int32SaveStruct Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public Int32SaveStruct DefF
        {
            get { return defF; }
            set { defF = value; }
        }

        public Int32SaveStruct DefSf
        {
            get { return defSf; }
            set { defSf = value; }
        }

        public SimSystemDetailBq Bq
        {
            get { return bq; }
            set { bq = value; }
        }

        public NonComplexArraySaveStruct<SimSystemDetailAdct> Adct
        {
            get { return this.adct; }
            set { this.adct = value; }
        }

        public Int32SaveStruct NumPlgs2
        {
            get { return numPlgs2; }
            set { numPlgs2 = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Flts
        {
            get { return flts; }
            set { flts = value; }
        }

        public NonComplexArraySaveStruct<FloatSaveStruct> Gfs
        {
            get { return gfs; }
            set { gfs = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> SnF
        {
            get { return snF; }
            set { snF = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> MnF
        {
            get { return mnF; }
            set { mnF = value; }
        }

        public NonComplexArraySaveStruct<SimSystemDetailNvo> Nvos
        {
            get { return nvos; }
            set { nvos = value; }
        }

        public NonComplexArraySaveStruct<SimSystemDetailVe> Nve
        {
            get { return nve; }
            set { nve = value; }
        }

        public NonComplexArraySaveStruct<SimSystemDetailVs> Nvs
        {
            get { return nvs; }
            set { nvs = value; }
        }

        public SimSystemDetailsIndi Indi
        {
            get { return indi; }
            set { indi = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimSystemDetailsSaveStruct() : base()
        {
            this.pos = new SpatialCoordinateSaveStruct();
            this.starColor = new RgbaColorFloat();
            this.idx = new Int32SaveStruct();
            this.size = new Int32SaveStruct();
            this.suit = new FloatSaveStruct();
            this.res = new Int32SaveStruct();
            this.aRes = new Int32SaveStruct();
            this.mRes = new Int32SaveStruct();
            this.noRebAi = new BooleanSaveStruct();
            this.tRes = new Int32SaveStruct();
            this.pop = new Int32SaveStruct();
            this.popG = new ComplexArraySaveStruct<SimPopGSaveStruct>();
            this.infra = new FloatSaveStruct();
            this.pvPop = new Int32SaveStruct();
            this.pvPopG = new ComplexArraySaveStruct<SimPopGSaveStruct>();
            this.pvInfra = new FloatSaveStruct();
            this.pvSuit = new FloatSaveStruct();
            this.pvRes = new Int32SaveStruct();
            this.pvARes2 = new Int32SaveStruct();
            this.pvMRes = new Int32SaveStruct();
            this.pvNoRebAi = new BooleanSaveStruct();
            this.rts = new SimSystemDetailRtsSaveStruct();
            this.abdn = new Int32SaveStruct();
            this.dstyd = new BooleanSaveStruct();
            this.tnsOh = new Int32SaveStruct();
            this.outMod = new FloatSaveStruct();
            this.repCur = new FloatSaveStruct();
            this.repMax = new FloatSaveStruct();
            this.ntdev = new Int32SaveStruct();
            this.pbon = new Int32SaveStruct();
            this.pbon2 = new ComplexArraySaveStruct<SimPopGSaveStruct>();
            this.ibon = new FloatSaveStruct();
            this.ltis = new Int32SaveStruct();
            this.rbfl = new Int32SaveStruct();
            this.rbtn = new Int32SaveStruct();
            this.rbfr = new Int32SaveStruct();
            this.rbwn = new Int32SaveStruct();
            this.hsrg = new Int32SaveStruct();
            this.halt = new NonComplexArraySaveStruct<SimSystemDetailHalt>();
            this.vnm = new SimSystemDetailsVonNeumann();
            this.name = new StringSaveStruct();
            this.flags1 = new SimSystemDetailFlags1();
            this.bats2 = new Int64SaveStruct();
            this.rcex = new Int64SaveStruct();
            this.flags2 = new SimSystemDetailFlags2();
            this.eggScio = new Int32SaveStruct();
            this.terrFl = new Int32SaveStruct();
            this.tAcq = new Int32SaveStruct();
            this.tfAcq = new Int32SaveStruct();
            this.tDst = new Int32SaveStruct();
            this.dcs = new ComplexArraySaveStruct<SimPopGSaveStruct>();
            this.dsu = new Int32SaveStruct();
            this.cm = new ComplexArraySaveStruct<SimSystemDetailCm>();
            this.pvcm = new ComplexArraySaveStruct<SimSystemDetailCm>();
            this.cme2 = new ComplexArraySaveStruct<SimSystemDetailCme2>();
            this.spies = new ComplexArraySaveStruct<SimSystemDetailSpy>();
            this.pid = new Int32SaveStruct();
            this.defF = new Int32SaveStruct();
            this.defSf = new Int32SaveStruct();

            this.bq = null; //only if imperial

            this.adct = new NonComplexArraySaveStruct<SimSystemDetailAdct>();
            this.numPlgs2 = new Int32SaveStruct();
            this.flts = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.gfs = new NonComplexArraySaveStruct<FloatSaveStruct>();
            this.snF = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.mnF = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.nvos = new NonComplexArraySaveStruct<SimSystemDetailNvo>();
            this.nve = new NonComplexArraySaveStruct<SimSystemDetailVe>();
            this.nvs = new NonComplexArraySaveStruct<SimSystemDetailVs>();
            this.indi = new SimSystemDetailsIndi();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.pos.ReadFromStream(Data);
            this.starColor.ReadFromStream(Data);
            this.idx.ReadFromStream(Data);
            this.size.ReadFromStream(Data);
            this.suit.ReadFromStream(Data);
            this.res.ReadFromStream(Data);
            this.aRes.ReadFromStream(Data);
            this.mRes.ReadFromStream(Data);
            this.noRebAi.ReadFromStream(Data);
            this.tRes.ReadFromStream(Data);
            this.pop.ReadFromStream(Data);
            this.popG.ReadFromStream(Data);
            this.infra.ReadFromStream(Data);
            this.pvPop.ReadFromStream(Data);
            this.pvPopG.ReadFromStream(Data);
            this.pvInfra.ReadFromStream(Data);
            this.pvSuit.ReadFromStream(Data);
            this.pvRes.ReadFromStream(Data);
            this.pvARes2.ReadFromStream(Data);
            this.pvMRes.ReadFromStream(Data);
            this.pvNoRebAi.ReadFromStream(Data);
            this.rts.ReadFromStream(Data);
            this.abdn.ReadFromStream(Data);
            this.dstyd.ReadFromStream(Data);
            this.tnsOh.ReadFromStream(Data);
            this.outMod.ReadFromStream(Data);
            this.repCur.ReadFromStream(Data);
            this.repMax.ReadFromStream(Data);
            this.ntdev.ReadFromStream(Data);
            this.pbon.ReadFromStream(Data);
            this.pbon2.ReadFromStream(Data);
            this.ibon.ReadFromStream(Data);
            this.ltis.ReadFromStream(Data);
            this.rbfl.ReadFromStream(Data);
            this.rbtn.ReadFromStream(Data);
            this.rbfr.ReadFromStream(Data);
            this.rbwn.ReadFromStream(Data);
            this.hsrg.ReadFromStream(Data);
            this.halt.ReadFromStream(Data);
            this.vnm.ReadFromStream(Data);
            this.name.ReadFromStream(Data);
            this.flags1.ReadFromStream(Data);
            this.bats2.ReadFromStream(Data);
            this.rcex.ReadFromStream(Data);
            this.flags2.ReadFromStream(Data);
            this.eggScio.ReadFromStream(Data);
            this.terrFl.ReadFromStream(Data);
            this.tAcq.ReadFromStream(Data);
            this.tfAcq.ReadFromStream(Data);
            this.tDst.ReadFromStream(Data);
            this.dcs.ReadFromStream(Data);
            this.dsu.ReadFromStream(Data);
            this.cm.ReadFromStream(Data);
            this.pvcm.ReadFromStream(Data);
            this.cme2.ReadFromStream(Data);
            this.spies.ReadFromStream(Data);
            this.pid.ReadFromStream(Data);
            this.defF.ReadFromStream(Data);
            this.defSf.ReadFromStream(Data);

            if (this.pid.Value != 0)
            {
                this.bq = new SimSystemDetailBq();
                this.bq.ReadFromStream(Data);
            }


            this.adct.ReadFromStream(Data);
            this.numPlgs2.ReadFromStream(Data);
            this.flts.ReadFromStream(Data);
            this.gfs.ReadFromStream(Data);
            this.snF.ReadFromStream(Data);
            this.mnF.ReadFromStream(Data);
            this.nvos.ReadFromStream(Data);
            this.nve.ReadFromStream(Data);
            this.nvs.ReadFromStream(Data);
            this.indi.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.pos.WriteToStream(Destination);
            this.starColor.WriteToStream(Destination);
            this.idx.WriteToStream(Destination);
            this.size.WriteToStream(Destination);
            this.suit.WriteToStream(Destination);
            this.res.WriteToStream(Destination);
            this.aRes.WriteToStream(Destination);
            this.mRes.WriteToStream(Destination);
            this.noRebAi.WriteToStream(Destination);
            this.tRes.WriteToStream(Destination);
            this.pop.WriteToStream(Destination);
            this.popG.WriteToStream(Destination);
            this.infra.WriteToStream(Destination);
            this.pvPop.WriteToStream(Destination);
            this.pvPopG.WriteToStream(Destination);
            this.pvInfra.WriteToStream(Destination);
            this.pvSuit.WriteToStream(Destination);
            this.pvRes.WriteToStream(Destination);
            this.pvARes2.WriteToStream(Destination);
            this.pvMRes.WriteToStream(Destination);
            this.pvNoRebAi.WriteToStream(Destination);
            this.rts.WriteToStream(Destination);
            this.abdn.WriteToStream(Destination);
            this.dstyd.WriteToStream(Destination);
            this.tnsOh.WriteToStream(Destination);
            this.outMod.WriteToStream(Destination);
            this.repCur.WriteToStream(Destination);
            this.repMax.WriteToStream(Destination);
            this.ntdev.WriteToStream(Destination);
            this.pbon.WriteToStream(Destination);
            this.pbon2.WriteToStream(Destination);
            this.ibon.WriteToStream(Destination);
            this.ltis.WriteToStream(Destination);
            this.rbfl.WriteToStream(Destination);
            this.rbtn.WriteToStream(Destination);
            this.rbfr.WriteToStream(Destination);
            this.rbwn.WriteToStream(Destination);
            this.hsrg.WriteToStream(Destination);
            this.halt.WriteToStream(Destination);
            this.vnm.WriteToStream(Destination);
            this.name.WriteToStream(Destination);
            this.flags1.WriteToStream(Destination);
            this.bats2.WriteToStream(Destination);
            this.rcex.WriteToStream(Destination);
            this.flags2.WriteToStream(Destination);
            this.eggScio.WriteToStream(Destination);
            this.terrFl.WriteToStream(Destination);
            this.tAcq.WriteToStream(Destination);
            this.tfAcq.WriteToStream(Destination);
            this.tDst.WriteToStream(Destination);
            this.dcs.WriteToStream(Destination);
            this.dsu.WriteToStream(Destination);
            this.cm.WriteToStream(Destination);
            this.pvcm.WriteToStream(Destination);
            this.cme2.WriteToStream(Destination);
            this.spies.WriteToStream(Destination);
            this.pid.WriteToStream(Destination);
            this.defF.WriteToStream(Destination);
            this.defSf.WriteToStream(Destination);

            if (this.pid.Value != 0)
            {
                this.bq.WriteToStream(Destination);
            }

            this.adct.WriteToStream(Destination);
            this.numPlgs2.WriteToStream(Destination);
            this.flts.WriteToStream(Destination);
            this.gfs.WriteToStream(Destination);
            this.snF.WriteToStream(Destination);
            this.mnF.WriteToStream(Destination);
            this.nvos.WriteToStream(Destination);
            this.nve.WriteToStream(Destination);
            this.nvs.WriteToStream(Destination);
            this.indi.WriteToStream(Destination);
        }

        public override string ToString()
        {
            return this.name.Value.CharacterString;
        }
    }
    #endregion

    #region Node Grid
    public class SimNodeGrid2 : ComplexSaveStruct
    {
        protected ComplexArraySaveStruct<SimNodeGridPath> paths;
        protected Int32SaveStruct nextId;   //next node id, for Zuul?

        public ComplexArraySaveStruct<SimNodeGridPath> Paths
        {
            get { return paths; }
            set { paths = value; }
        }

        public Int32SaveStruct NextId
        {
            get { return nextId; }
            set { nextId = value; }
        }

        /// <summary>Default constructor</summary>
        public SimNodeGrid2() : base()
        {
            this.paths = new ComplexArraySaveStruct<SimNodeGridPath>();
            this.nextId = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.paths.ReadFromStream(Data);
            this.nextId.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.paths.WriteToStream(Destination);
            this.nextId.WriteToStream(Destination);
        }
    }

    public class SimNodeGridPath : ComplexSaveStruct
    {
        protected Int32SaveStruct npt;
        protected Int32SaveStruct npid;
        protected Int32SaveStruct npfr;     //from?
        protected Int32SaveStruct npto;     //to?
        protected Int32SaveStruct npctm;
        protected Int32SaveStruct npcby;
        protected Int32SaveStruct npdtn;
        protected Int32SaveStruct npdtf;
        protected Int32SaveStruct npenp;
        protected Int32SaveStruct npuse;
        protected Int32SaveStruct nptf;

        #region Properties
        public Int32SaveStruct Npt
        {
            get { return npt; }
            set { npt = value; }
        }

        public Int32SaveStruct Npid
        {
            get { return npid; }
            set { npid = value; }
        }

        public Int32SaveStruct Npfr
        {
            get { return npfr; }
            set { npfr = value; }
        }

        public Int32SaveStruct Npto
        {
            get { return npto; }
            set { npto = value; }
        }

        public Int32SaveStruct Npctm
        {
            get { return npctm; }
            set { npctm = value; }
        }

        public Int32SaveStruct Npcby
        {
            get { return npcby; }
            set { npcby = value; }
        }

        public Int32SaveStruct Npdtn
        {
            get { return npdtn; }
            set { npdtn = value; }
        }

        public Int32SaveStruct Npdtf
        {
            get { return npdtf; }
            set { npdtf = value; }
        }

        public Int32SaveStruct Npenp
        {
            get { return npenp; }
            set { npenp = value; }
        }

        public Int32SaveStruct Npuse
        {
            get { return npuse; }
            set { npuse = value; }
        }

        public Int32SaveStruct Nptf
        {
            get { return nptf; }
            set { nptf = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimNodeGridPath() : base()
        {
            this.npt = new Int32SaveStruct();
            this.npid = new Int32SaveStruct();
            this.npfr = new Int32SaveStruct();
            this.npto = new Int32SaveStruct();
            this.npctm = new Int32SaveStruct();
            this.npcby = new Int32SaveStruct();
            this.npdtn = new Int32SaveStruct();
            this.npdtf = new Int32SaveStruct();
            this.npenp = new Int32SaveStruct();
            this.npuse = new Int32SaveStruct();
            this.nptf = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.npt.ReadFromStream(Data);
            this.npid.ReadFromStream(Data);
            this.npfr.ReadFromStream(Data);
            this.npto.ReadFromStream(Data);
            this.npctm.ReadFromStream(Data);
            this.npcby.ReadFromStream(Data);
            this.npdtn.ReadFromStream(Data);
            this.npdtf.ReadFromStream(Data);
            this.npenp.ReadFromStream(Data);
            this.npuse.ReadFromStream(Data);
            this.nptf.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.npt.WriteToStream(Destination);
            this.npid.WriteToStream(Destination);
            this.npfr.WriteToStream(Destination);
            this.npto.WriteToStream(Destination);
            this.npctm.WriteToStream(Destination);
            this.npcby.WriteToStream(Destination);
            this.npdtn.WriteToStream(Destination);
            this.npdtf.WriteToStream(Destination);
            this.npenp.WriteToStream(Destination);
            this.npuse.WriteToStream(Destination);
            this.nptf.WriteToStream(Destination);
        }
    }
    #endregion

    #region Trade Manager
    public class SimTradeManager : ComplexSaveStruct
    {
        protected NonComplexArraySaveStruct<SimTradeSector> tradeSectors;
        protected FloatSaveStruct sctSize;

        /// <summary>This appears to be trade routes</summary>
        /// <remarks>
        ///     As a gut feeling, this structure is there when there are trade routes, and is not when the tech is
        ///     either not researched by any parties or not in use by any trade fleets. Unknown what indicates presence.
        /// 
        ///     I cannot find a solid anchor defining the presence of this struct. It would appear, however,
        ///     that it may be triggered with any of the tradeSectors containing a fleet, which would start trade.
        ///     This may not, however, be anything other than a correlation that simply works due to another
        ///     deterministic factor and not a causal relationship.
        /// 
        ///     Also, while this is an array, I do not see any indicator for its length. Perhaps a read while an end
        ///     token cannot be found would be appropraite?
        /// </remarks>
        protected List<SimTradeSectorRt> rt;
        //protected ComplexArraySaveStruct<SimTradeSectorRt> rt;

        public NonComplexArraySaveStruct<SimTradeSector> TradeSectors
        {
            get { return tradeSectors; }
            set { tradeSectors = value; }
        }

        public FloatSaveStruct SctSize
        {
            get { return sctSize; }
            set { sctSize = value; }
        }

        public List<SimTradeSectorRt> Rt
        {
            get { return rt; }
            set { rt = value; }
        }

        /// <summary>Default constructor</summary>
        public SimTradeManager() : base()
        {
            this.tradeSectors = new NonComplexArraySaveStruct<SimTradeSector>();
            this.sctSize = new FloatSaveStruct();
            this.rt = null;
            
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.tradeSectors.ReadFromStream(Data);
            this.sctSize.ReadFromStream(Data);
            
            if (HasRoutes())
            {
                //Instantiate list
                this.rt = new List<SimTradeSectorRt>();

                //Peek variables
                Int64 position;
                Byte[] temp = new Byte[4];

                //reading the rt structures
                Boolean inStruct = true;
                SimTradeSectorRt tempRt;

                //loop since there is no visible length
                while (inStruct)
                {
                    //peek
                    position = Data.Position;
                    Data.Read(temp, 0, 4);

                    //compare
                    if (BitConverter.ToUInt32(temp, 0) == ~StructureMarker)
                        inStruct = false;

                    //jump back
                    Data.Seek(position, SeekOrigin.Begin);

                    //if not end, read
                    if (inStruct)
                    {
                        tempRt = new SimTradeSectorRt();
                        tempRt.ReadFromStream(Data);
                        this.rt.Add(tempRt);
                    }
                }
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.tradeSectors.WriteToStream(Destination);
            this.sctSize.WriteToStream(Destination);
            
            if (HasRoutes())
            {
                foreach (SimTradeSectorRt tempRt in this.rt)
                    tempRt.WriteToStream(Destination);
            }
        }

        protected Boolean HasRoutes()
        {
            Boolean hasRoutes = false;
            foreach (SimTradeSector t in this.tradeSectors.Values)
            {
                if (t.Trade.Tsflt.Length.Value > 0)
                {
                    hasRoutes = true;
                    break;
                }
            }

            return hasRoutes;
        }
    }

    public class SimTradeSector : ISotsStructure
    {
        protected Int32SaveStruct tradeId;
        protected SimTradeSectorTradeSaveStruct trade;

        public Int32SaveStruct TradeId
        {
            get { return tradeId; }
            set { tradeId = value; }
        }

        public SimTradeSectorTradeSaveStruct Trade
        {
            get { return trade; }
            set { trade = value; }
        }

        /// <summary>Default constructor</summary>
        public SimTradeSector()
        {
            this.tradeId = new Int32SaveStruct();
            this.trade = new SimTradeSectorTradeSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.tradeId.ReadFromStream(Data);
            this.trade.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.tradeId.WriteToStream(Destination);
            this.trade.WriteToStream(Destination);
        }
    }

    public class SimTradeSectorTradeSaveStruct : ComplexSaveStruct
    {
        protected SpatialCoordinateSaveStruct pos;
        protected Int32SaveStruct tradeSectorGridId;
        protected SimTradeSectorTradeCtrSaveStruct tsctr;
        protected Int32SaveStruct tssec;
        protected Int32SaveStruct tsct;
        protected Int32SaveStruct tscr;
        protected Int32SaveStruct ptssec;
        protected Int32SaveStruct ptsct;
        protected Int32SaveStruct ptscr;
        protected ComplexArraySaveStruct<SimTradeSectorTradeFwarnSaveStruct> fwarn;
        protected NonComplexArraySaveStruct<Int32SaveStruct> systems;
        protected NonComplexArraySaveStruct<Int32SaveStruct> tsflt;

        #region Properties
        public SpatialCoordinateSaveStruct Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public Int32SaveStruct TradeSectorGridId
        {
            get { return tradeSectorGridId; }
            set { tradeSectorGridId = value; }
        }

        public SimTradeSectorTradeCtrSaveStruct Tsctr
        {
            get { return tsctr; }
            set { tsctr = value; }
        }

        public Int32SaveStruct Tssec
        {
            get { return tssec; }
            set { tssec = value; }
        }

        public Int32SaveStruct Tsct
        {
            get { return tsct; }
            set { tsct = value; }
        }

        public Int32SaveStruct Tscr
        {
            get { return tscr; }
            set { tscr = value; }
        }

        public Int32SaveStruct Ptssec
        {
            get { return ptssec; }
            set { ptssec = value; }
        }

        public Int32SaveStruct Ptsct
        {
            get { return ptsct; }
            set { ptsct = value; }
        }

        public Int32SaveStruct Ptscr
        {
            get { return ptscr; }
            set { ptscr = value; }
        }

        public ComplexArraySaveStruct<SimTradeSectorTradeFwarnSaveStruct> Fwarn
        {
            get { return fwarn; }
            set { fwarn = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Systems
        {
            get { return systems; }
            set { systems = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Tsflt
        {
            get { return tsflt; }
            set { tsflt = value; }
        }
        #endregion
        
        /// <summary>Default constructor</summary>
        public SimTradeSectorTradeSaveStruct() : base()
        {
            this.pos = new SpatialCoordinateSaveStruct();
            this.tradeSectorGridId = new Int32SaveStruct();
            this.tsctr = new SimTradeSectorTradeCtrSaveStruct();
            this.tssec = new Int32SaveStruct();
            this.tsct = new Int32SaveStruct();
            this.tscr = new Int32SaveStruct();
            this.ptssec= new Int32SaveStruct();
            this.ptsct = new Int32SaveStruct();
            this.ptscr = new Int32SaveStruct();
            this.fwarn = new ComplexArraySaveStruct<SimTradeSectorTradeFwarnSaveStruct>();
            this.systems = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.tsflt = new NonComplexArraySaveStruct<Int32SaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.pos.ReadFromStream(Data);
            this.tradeSectorGridId.ReadFromStream(Data);
            this.tsctr.ReadFromStream(Data);
            this.tssec.ReadFromStream(Data);
            this.tsct.ReadFromStream(Data);
            this.tscr.ReadFromStream(Data);
            this.ptssec.ReadFromStream(Data);
            this.ptsct.ReadFromStream(Data);
            this.ptscr.ReadFromStream(Data);
            this.fwarn.ReadFromStream(Data);
            this.systems.ReadFromStream(Data);
            this.tsflt.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.pos.WriteToStream(Destination);
            this.tradeSectorGridId.WriteToStream(Destination);
            this.tsctr.WriteToStream(Destination);
            this.tssec.WriteToStream(Destination);
            this.tsct.WriteToStream(Destination);
            this.tscr.WriteToStream(Destination);
            this.ptssec.WriteToStream(Destination);
            this.ptsct.WriteToStream(Destination);
            this.ptscr.WriteToStream(Destination);
            this.fwarn.WriteToStream(Destination);
            this.systems.WriteToStream(Destination);
            this.tsflt.WriteToStream(Destination);
        }
    }

    public class SimTradeSectorTradeCtrSaveStruct : ComplexSaveStruct
    {
        protected FloatSaveStruct unknown1;
        protected FloatSaveStruct unknown2;
        protected FloatSaveStruct unknown3;

        public FloatSaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public FloatSaveStruct Unknown2
        {
            get { return unknown2; }
            set { unknown2 = value; }
        }

        public FloatSaveStruct Unknown3
        {
            get { return unknown3; }
            set { unknown3 = value; }
        }

        /// <summary>Default constructor</summary>
        public SimTradeSectorTradeCtrSaveStruct() : base()
        {
            this.unknown1 = new FloatSaveStruct();
            this.unknown2 = new FloatSaveStruct();
            this.unknown3 = new FloatSaveStruct();
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
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
            this.unknown3.WriteToStream(Destination);
        }
    }

    public class SimTradeSectorTradeFwarnSaveStruct : ComplexSaveStruct
    {
        protected Int32SaveStruct pId;
        protected Int32SaveStruct ntrns;

        public Int32SaveStruct PId
        {
            get { return pId; }
            set { pId = value; }
        }

        public Int32SaveStruct Ntrns
        {
            get { return ntrns; }
            set { ntrns = value; }
        }

        /// <summary>Default constructor</summary>
        public SimTradeSectorTradeFwarnSaveStruct() : base()
        {
            this.pId = new Int32SaveStruct();
            this.ntrns = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.pId.ReadFromStream(Data);
            this.ntrns.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.pId.WriteToStream(Destination);
            this.ntrns.WriteToStream(Destination);
        }
    }

    public class SimTradeSectorRt : ComplexSaveStruct
    {
        protected Int32SaveStruct tro;
        protected Int32SaveStruct trfow;
        protected Int32SaveStruct trfr;
        protected Int32SaveStruct trfrs;
        protected Int32SaveStruct trtow;
        protected Int32SaveStruct trto;
        protected Int32SaveStruct trtos;
        protected Int32SaveStruct trtc;

        #region Properties
        public Int32SaveStruct Tro
        {
            get { return tro; }
            set { tro = value; }
        }

        public Int32SaveStruct Trfow
        {
            get { return trfow; }
            set { trfow = value; }
        }

        public Int32SaveStruct Trfr
        {
            get { return trfr; }
            set { trfr = value; }
        }

        public Int32SaveStruct Trfrs
        {
            get { return trfrs; }
            set { trfrs = value; }
        }

        public Int32SaveStruct Trtow
        {
            get { return trtow; }
            set { trtow = value; }
        }

        public Int32SaveStruct Trto
        {
            get { return trto; }
            set { trto = value; }
        }

        public Int32SaveStruct Trtos
        {
            get { return trtos; }
            set { trtos = value; }
        }

        public Int32SaveStruct Trtc
        {
            get { return trtc; }
            set { trtc = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimTradeSectorRt()
        {
            this.tro = new Int32SaveStruct();
            this.trfow = new Int32SaveStruct();
            this.trfr = new Int32SaveStruct();
            this.trfrs = new Int32SaveStruct();
            this.trtow = new Int32SaveStruct();
            this.trto = new Int32SaveStruct();
            this.trtos = new Int32SaveStruct();
            this.trtc = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.tro.ReadFromStream(Data);
            this.trfow.ReadFromStream(Data);
            this.trfr.ReadFromStream(Data);
            this.trfrs.ReadFromStream(Data);
            this.trtow.ReadFromStream(Data);
            this.trto.ReadFromStream(Data);
            this.trtos.ReadFromStream(Data);
            this.trtc.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.tro.WriteToStream(Destination);
            this.trfow.WriteToStream(Destination);
            this.trfr.WriteToStream(Destination);
            this.trfrs.WriteToStream(Destination);
            this.trtow.WriteToStream(Destination);
            this.trto.WriteToStream(Destination);
            this.trtos.WriteToStream(Destination);
            this.trtc.WriteToStream(Destination);
        }
    }
    #endregion

    #region Spy Manager
    public class SimSpyManager : ComplexSaveStruct
    {
        protected Int32SaveStruct xsid;
        protected Int32SaveStruct nspy;

        public Int32SaveStruct Xsid
        {
            get { return xsid; }
            set { xsid = value; }
        }

        public Int32SaveStruct Nspy
        {
            get { return nspy; }
            set { nspy = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSpyManager() : base()
        {
            this.xsid = new Int32SaveStruct();
            this.nspy = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.xsid.ReadFromStream(Data);
            this.nspy.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.xsid.WriteToStream(Destination);
            this.nspy.WriteToStream(Destination);
        }
    }
    #endregion

    #region Fleets
    public class SimFleet : ISotsStructure
    {
        protected Int32SaveStruct fltId;
        protected SimFleetDetails flt;

        public Int32SaveStruct FltId
        {
            get { return fltId; }
            set { fltId = value; }
        }

        public SimFleetDetails Flt
        {
            get { return flt; }
            set { flt = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleet()
        {
            this.fltId = new Int32SaveStruct();
            this.flt = new SimFleetDetails();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.fltId.ReadFromStream(Data);
            this.flt.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.fltId.WriteToStream(Destination);
            this.flt.WriteToStream(Destination);
        }
    }

    public class SimFleetDetailsFlightPlanContainer : ISotsStructure
    {
        /// <summary>Has a flight plan</summary>
        protected BooleanSaveStruct hfPlan;
        protected SimFleetDetailsFlightPlan fplan;

        public BooleanSaveStruct HfPlan
        {
            get { return hfPlan; }
            set { hfPlan = value; }
        }

        public SimFleetDetailsFlightPlan Fplan
        {
            get { return fplan; }
            set { fplan = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetDetailsFlightPlanContainer()
        {
            this.hfPlan = new BooleanSaveStruct();
            this.fplan = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.hfPlan.ReadFromStream(Data);

            if (this.hfPlan.BooleanValue)
            {
                this.fplan = new SimFleetDetailsFlightPlan();
                this.fplan.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.hfPlan.WriteToStream(Destination);

            if (this.hfPlan.BooleanValue)
                this.fplan.WriteToStream(Destination);
        }
    }

    public class SimFleetDetailsFlightPlan : ComplexSaveStruct
    {
        protected ComplexArraySaveStruct<SimFleetDetailsFlightPlanWpt> wpts;
        protected FloatSaveStruct fPsp2;
        protected Int32SaveStruct fPeta2;
        protected SimFleetDetailsFlightPlanFpogn2 fPogn2;
        protected SpatialCoordinateSaveStruct fPdpos;
        protected Int32SaveStruct pnd;

        #region Properties
        public ComplexArraySaveStruct<SimFleetDetailsFlightPlanWpt> Wpts
        {
            get { return wpts; }
            set { wpts = value; }
        }

        public FloatSaveStruct FPsp2
        {
            get { return fPsp2; }
            set { fPsp2 = value; }
        }

        public Int32SaveStruct FPeta2
        {
            get { return fPeta2; }
            set { fPeta2 = value; }
        }

        public SimFleetDetailsFlightPlanFpogn2 FPogn2
        {
            get { return fPogn2; }
            set { fPogn2 = value; }
        }

        public SpatialCoordinateSaveStruct FPdpos
        {
            get { return fPdpos; }
            set { fPdpos = value; }
        }

        public Int32SaveStruct Pnd
        {
            get { return pnd; }
            set { pnd = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimFleetDetailsFlightPlan() : base()
        {
            this.wpts = new ComplexArraySaveStruct<SimFleetDetailsFlightPlanWpt>();
            this.fPsp2 = new FloatSaveStruct();
            this.fPeta2 = new Int32SaveStruct();
            this.fPogn2 = new SimFleetDetailsFlightPlanFpogn2();
            this.fPdpos = new SpatialCoordinateSaveStruct();
            this.pnd = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.wpts.ReadFromStream(Data);
            this.fPsp2.ReadFromStream(Data);
            this.fPeta2.ReadFromStream(Data);
            this.fPogn2.ReadFromStream(Data);
            this.fPdpos.ReadFromStream(Data);
            this.pnd.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.wpts.WriteToStream(Destination);
            this.fPsp2.WriteToStream(Destination);
            this.fPeta2.WriteToStream(Destination);
            this.fPogn2.WriteToStream(Destination);
            this.fPdpos.WriteToStream(Destination);
            this.pnd.WriteToStream(Destination);
        }
    }

    public class SimFleetDetailsFlightPlanWpt : ComplexSaveStruct
    {
        protected Int32SaveStruct wpt;
        protected Int32SaveStruct tp;
        protected SimFleetDetailsFlightPlanWptNrt nrt;

        public Int32SaveStruct Wpt
        {
            get { return wpt; }
            set { wpt = value; }
        }

        public Int32SaveStruct Tp
        {
            get { return tp; }
            set { tp = value; }
        }

        public SimFleetDetailsFlightPlanWptNrt Nrt
        {
            get { return nrt; }
            set { nrt = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetDetailsFlightPlanWpt() : base()
        {
            this.wpt = new Int32SaveStruct();
            this.tp = new Int32SaveStruct();
            this.nrt = new SimFleetDetailsFlightPlanWptNrt();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.wpt.ReadFromStream(Data);
            this.tp.ReadFromStream(Data);
            this.nrt.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.wpt.WriteToStream(Destination);
            this.tp.WriteToStream(Destination);
            this.nrt.WriteToStream(Destination);
        }
    }

    public class SimFleetDetailsFlightPlanWptNrt : ComplexSaveStruct
    {
        protected Int32SaveStruct nrp;
        protected Int32SaveStruct nrf;
        protected Int32SaveStruct nrt;

        public Int32SaveStruct Nrp
        {
            get { return nrp; }
            set { nrp = value; }
        }

        public Int32SaveStruct Nrf
        {
            get { return nrf; }
            set { nrf = value; }
        }

        public Int32SaveStruct Nrt
        {
            get { return nrt; }
            set { nrt = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetDetailsFlightPlanWptNrt() : base()
        {
            this.nrp = new Int32SaveStruct();
            this.nrf = new Int32SaveStruct();
            this.nrt = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.nrp.ReadFromStream(Data);
            this.nrf.ReadFromStream(Data);
            this.nrt.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.nrp.WriteToStream(Destination);
            this.nrf.WriteToStream(Destination);
            this.nrt.WriteToStream(Destination);
        }
    }

    public class SimFleetDetailsFlightPlanFpogn2 : ComplexSaveStruct
    {
        protected FloatSaveStruct unknown1;
        protected FloatSaveStruct unknown2;
        protected FloatSaveStruct unknown3;

        public FloatSaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public FloatSaveStruct Unknown2
        {
            get { return unknown2; }
            set { unknown2 = value; }
        }

        public FloatSaveStruct Unknown3
        {
            get { return unknown3; }
            set { unknown3 = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetDetailsFlightPlanFpogn2() : base()
        {
            this.unknown1 = new FloatSaveStruct();
            this.unknown2 = new FloatSaveStruct();
            this.unknown3 = new FloatSaveStruct();
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
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
            this.unknown3.WriteToStream(Destination);
        }
    }
    
    public class SimFleetDetailsLayContainer : ISotsStructure
    {
        /// <summary>Has a flight plan</summary>
        protected BooleanSaveStruct hLay;
        protected SimFleetDetailsLay lay;

        public BooleanSaveStruct HLay
        {
            get { return hLay; }
            set { hLay = value; }
        }

        public SimFleetDetailsLay Lay
        {
            get { return lay; }
            set { lay = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetDetailsLayContainer()
        {
            this.hLay = new BooleanSaveStruct();
            this.lay = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.hLay.ReadFromStream(Data);

            if (this.hLay.BooleanValue)
            {
                this.lay = new SimFleetDetailsLay();
                this.lay.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.hLay.WriteToStream(Destination);

            if (this.hLay.BooleanValue)
                this.lay.WriteToStream(Destination);
        }
    }

    public class SimFleetDetailsLay : ComplexSaveStruct
    {
        protected SimFleetDetailsLayPntsContainer ftPnts;
        protected NonComplexArraySaveStruct<Int32SaveStruct> unknown;

        #region Properties
        public SimFleetDetailsLayPntsContainer FtPnts
        {
            get { return ftPnts; }
            set { ftPnts = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Unknown
        {
            get { return unknown; }
            set { unknown = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimFleetDetailsLay() : base()
        {
            this.ftPnts = new SimFleetDetailsLayPntsContainer();
            this.unknown = new NonComplexArraySaveStruct<Int32SaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ftPnts.ReadFromStream(Data);
            this.unknown.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ftPnts.WriteToStream(Destination);
            this.unknown.WriteToStream(Destination);
        }
    }

    public class SimFleetDetailsLayPntsContainer : ComplexSaveStruct
    {
        private ComplexArraySaveStruct<SimFleetDetailsLayPnts> ftPnts;

        protected ComplexArraySaveStruct<SimFleetDetailsLayPnts> FtPnts
        {
            get { return ftPnts; }
            set { ftPnts = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetDetailsLayPntsContainer()
        {
            this.ftPnts = new ComplexArraySaveStruct<SimFleetDetailsLayPnts>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ftPnts.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ftPnts.WriteToStream(Destination);
        }
    }
    
    public class SimFleetDetailsLayPnts : ComplexSaveStruct
    {
        protected Int32SaveStruct ftpShId;
        protected Int32SaveStruct ftpDesId;
        protected Int32SaveStruct ftpPosX;
        protected Int32SaveStruct ftpPosY;
        protected Int32SaveStruct ftpSqd;

        #region Properties
        public Int32SaveStruct FtpShId
        {
            get { return ftpShId; }
            set { ftpShId = value; }
        }

        public Int32SaveStruct FtpDesId
        {
            get { return ftpDesId; }
            set { ftpDesId = value; }
        }

        public Int32SaveStruct FtpPosX
        {
            get { return ftpPosX; }
            set { ftpPosX = value; }
        }

        public Int32SaveStruct FtpPosY
        {
            get { return ftpPosY; }
            set { ftpPosY = value; }
        }

        public Int32SaveStruct FtpSqd
        {
            get { return ftpSqd; }
            set { ftpSqd = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimFleetDetailsLayPnts() : base()
        {
            this.ftpShId = new Int32SaveStruct();
            this.ftpDesId = new Int32SaveStruct();
            this.ftpPosX = new Int32SaveStruct();
            this.ftpPosY = new Int32SaveStruct();
            this.ftpSqd = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ftpShId.ReadFromStream(Data);
            this.ftpDesId.ReadFromStream(Data);
            this.ftpPosX.ReadFromStream(Data);
            this.ftpPosY.ReadFromStream(Data);
            this.ftpSqd.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ftpShId.WriteToStream(Destination);
            this.ftpDesId.WriteToStream(Destination);
            this.ftpPosX.WriteToStream(Destination);
            this.ftpPosY.WriteToStream(Destination);
            this.ftpSqd.WriteToStream(Destination);
        }
    }

    public class SimFleetDetails : ComplexSaveStruct
    {
        protected SpatialCoordinateSaveStruct pos;
        protected Int32SaveStruct pId;
        protected Int32SaveStruct locId;
        protected SimFleetDetailsFlightPlanContainer fplan;
        protected StringSaveStruct ftName;
        protected Int32SaveStruct ftTrans;
        protected SimFleetOrigin ftOrig;
        protected Int32SaveStruct ftFlag;
        protected Int32SaveStruct ftae;
        protected Int32SaveStruct ftpae;
        protected Int32SaveStruct ftEnc;
        protected Int32SaveStruct ftMs;
        protected Int32SaveStruct perm;
        protected SpatialCoordinateSaveStruct prvPos;
        protected SimFleetDetailsLayContainer lay;
        protected NonComplexArraySaveStruct<SimFleetShip> ships;

        #region Properties
        public SpatialCoordinateSaveStruct Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public Int32SaveStruct PId
        {
            get { return pId; }
            set { pId = value; }
        }

        public Int32SaveStruct LocId
        {
            get { return locId; }
            set { locId = value; }
        }

        public SimFleetDetailsFlightPlanContainer Fplan
        {
            get { return fplan; }
            set { fplan = value; }
        }

        public StringSaveStruct FtName
        {
            get { return ftName; }
            set { ftName = value; }
        }

        public Int32SaveStruct FtTrans
        {
            get { return ftTrans; }
            set { ftTrans = value; }
        }

        public SimFleetOrigin FtOrig
        {
            get { return ftOrig; }
            set { ftOrig = value; }
        }

        public Int32SaveStruct FtFlag
        {
            get { return ftFlag; }
            set { ftFlag = value; }
        }

        public Int32SaveStruct Ftae
        {
            get { return ftae; }
            set { ftae = value; }
        }

        public Int32SaveStruct Ftpae
        {
            get { return ftpae; }
            set { ftpae = value; }
        }

        public Int32SaveStruct FtEnc
        {
            get { return ftEnc; }
            set { ftEnc = value; }
        }

        public Int32SaveStruct FtMs
        {
            get { return ftMs; }
            set { ftMs = value; }
        }

        public Int32SaveStruct Perm
        {
            get { return perm; }
            set { perm = value; }
        }

        public SpatialCoordinateSaveStruct PrvPos
        {
            get { return prvPos; }
            set { prvPos = value; }
        }

        public SimFleetDetailsLayContainer Lay
        {
            get { return lay; }
            set { lay = value; }
        }

        public NonComplexArraySaveStruct<SimFleetShip> Ships
        {
            get { return ships; }
            set { ships = value; }
        }
        
        #endregion

        /// <summary>Default constructor</summary>
        public SimFleetDetails() : base()
        {
            this.pos = new SpatialCoordinateSaveStruct();
            this.pId = new Int32SaveStruct();
            this.locId = new Int32SaveStruct();
            this.fplan = new SimFleetDetailsFlightPlanContainer();
            this.ftName = new StringSaveStruct();
            this.ftTrans = new Int32SaveStruct();
            this.ftOrig = new SimFleetOrigin();
            this.ftFlag = new Int32SaveStruct();
            this.ftae = new Int32SaveStruct();
            this.ftpae = new Int32SaveStruct();
            this.ftEnc = new Int32SaveStruct();
            this.ftMs = new Int32SaveStruct();
            this.perm = new Int32SaveStruct();
            this.prvPos = new SpatialCoordinateSaveStruct();
            this.lay = new SimFleetDetailsLayContainer();
            this.ships = new NonComplexArraySaveStruct<SimFleetShip>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.pos.ReadFromStream(Data);
            this.pId.ReadFromStream(Data);
            this.locId.ReadFromStream(Data);
            this.fplan.ReadFromStream(Data);
            this.ftName.ReadFromStream(Data);
            this.ftTrans.ReadFromStream(Data);
            this.ftOrig.ReadFromStream(Data);
            this.ftFlag.ReadFromStream(Data);
            this.ftae.ReadFromStream(Data);
            this.ftpae.ReadFromStream(Data);
            this.ftEnc.ReadFromStream(Data);
            this.ftMs.ReadFromStream(Data);
            this.perm.ReadFromStream(Data);
            this.prvPos.ReadFromStream(Data);
            this.lay.ReadFromStream(Data);
            this.ships.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.pos.WriteToStream(Destination);
            this.pId.WriteToStream(Destination);
            this.locId.WriteToStream(Destination);
            this.fplan.WriteToStream(Destination);
            this.ftName.WriteToStream(Destination);
            this.ftTrans.WriteToStream(Destination);
            this.ftOrig.WriteToStream(Destination);
            this.ftFlag.WriteToStream(Destination);
            this.ftae.WriteToStream(Destination);
            this.ftpae.WriteToStream(Destination);
            this.ftEnc.WriteToStream(Destination);
            this.ftMs.WriteToStream(Destination);
            this.perm.WriteToStream(Destination);
            this.prvPos.WriteToStream(Destination);
            this.lay.WriteToStream(Destination);
            this.ships.WriteToStream(Destination);
        }
    }

    public class SimFleetOrigin : ComplexSaveStruct
    {
        protected Int32SaveStruct unknown1;
        protected Int32SaveStruct unknown2;
        protected Int32SaveStruct unknown3;

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

        /// <summary>Default constructor</summary>
        public SimFleetOrigin() : base()
        {
            this.unknown1 = new Int32SaveStruct();
            this.unknown2 = new Int32SaveStruct();
            this.unknown3 = new Int32SaveStruct();
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
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
            this.unknown3.WriteToStream(Destination);
        }
    }

    public class SimFleetShip : ISotsStructure
    {
        protected Int32SaveStruct shipId;
        protected SimFleetShipDetails ship;

        public Int32SaveStruct ShipId
        {
            get { return shipId; }
            set { shipId = value; }
        }

        public SimFleetShipDetails Ship
        {
            get { return ship; }
            set { ship = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetShip()
        {
            this.shipId = new Int32SaveStruct();
            this.ship = new SimFleetShipDetails();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.shipId.ReadFromStream(Data);
            this.ship.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.shipId.WriteToStream(Destination);
            this.ship.WriteToStream(Destination);
        }
    }

    public class SimFleetShipDetailsTh : ISotsStructure
    {
        protected FloatSaveStruct th;
        protected FloatSaveStruct thm;

        public FloatSaveStruct Th
        {
            get { return th; }
            set { th = value; }
        }

        public FloatSaveStruct Thm
        {
            get { return thm; }
            set { thm = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetShipDetailsTh()
        {
            this.th = new FloatSaveStruct();
            this.thm = new FloatSaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.th.ReadFromStream(Data);
            this.thm.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.th.WriteToStream(Destination);
            this.thm.WriteToStream(Destination);
        }
    }

    public class SimFleetShipDetails : ComplexSaveStruct
    {
        protected Int32SaveStruct desId;
        protected Int32SaveStruct fltId;
        protected Int32SaveStruct plrId;
        protected FloatSaveStruct range;
        protected SimFleetShipHealth health;
        protected Int32SaveStruct conCap;       //cnc?
        protected Int32SaveStruct refCap;       //refuel?
        protected Int32SaveStruct repCap;       //repair?
        protected Int32SaveStruct mineCap;      //mining vessel?
        protected Int32SaveStruct plg;
        protected Int32SaveStruct act;
        protected BooleanSaveStruct dep;
        protected BooleanSaveStruct atq;
        protected Int32SaveStruct encId;
        protected SimFleetShipPrish prish;      //propoganda? doubt it.
        protected Int32SaveStruct lct;
        protected Int32SaveStruct tsd;
        protected Int32SaveStruct atsp;
        protected Int32SaveStruct tblt;
        protected BooleanSaveStruct hbq;        //has BQ
        protected SimFleetShipDetailsBq bq;
        protected BooleanSaveStruct hsp;
        protected SimFleetShipDetailsSp sp;
        protected NonComplexArraySaveStruct<SimFleetShipDetailsTh> th;

        #region Properties
        public Int32SaveStruct DesId
        {
            get { return desId; }
            set { desId = value; }
        }

        public Int32SaveStruct FltId
        {
            get { return fltId; }
            set { fltId = value; }
        }

        public Int32SaveStruct PlrId
        {
            get { return plrId; }
            set { plrId = value; }
        }

        public FloatSaveStruct Range
        {
            get { return range; }
            set { range = value; }
        }

        public SimFleetShipHealth Health
        {
            get { return health; }
            set { health = value; }
        }

        public Int32SaveStruct ConCap
        {
            get { return conCap; }
            set { conCap = value; }
        }

        public Int32SaveStruct RefCap
        {
            get { return refCap; }
            set { refCap = value; }
        }

        public Int32SaveStruct RepCap
        {
            get { return repCap; }
            set { repCap = value; }
        }

        public Int32SaveStruct MineCap
        {
            get { return mineCap; }
            set { mineCap = value; }
        }

        public Int32SaveStruct Plg
        {
            get { return plg; }
            set { plg = value; }
        }

        public Int32SaveStruct Act
        {
            get { return act; }
            set { act = value; }
        }

        public BooleanSaveStruct Dep
        {
            get { return dep; }
            set { dep = value; }
        }

        public BooleanSaveStruct Atq
        {
            get { return atq; }
            set { atq = value; }
        }

        public Int32SaveStruct EncId
        {
            get { return encId; }
            set { encId = value; }
        }

        public SimFleetShipPrish Prish
        {
            get { return prish; }
            set { prish = value; }
        }

        public Int32SaveStruct Lct
        {
            get { return lct; }
            set { lct = value; }
        }

        public Int32SaveStruct Tsd
        {
            get { return tsd; }
            set { tsd = value; }
        }

        public Int32SaveStruct Atsp
        {
            get { return atsp; }
            set { atsp = value; }
        }

        public Int32SaveStruct Tblt
        {
            get { return tblt; }
            set { tblt = value; }
        }

        public BooleanSaveStruct Hbq
        {
            get { return hbq; }
            set { hbq = value; }
        }

        public SimFleetShipDetailsBq BQ
        {
            get { return this.bq; }
            set { this.bq = value; }
        }

        public BooleanSaveStruct Hsp
        {
            get { return hsp; }
            set { hsp = value; }
        }

        public SimFleetShipDetailsSp Sp
        {
            get { return sp; }
            set { sp = value; }
        }

        public NonComplexArraySaveStruct<SimFleetShipDetailsTh> TH
        {
            get { return th; }
            set { th = value; }
        }        
        #endregion

        /// <summary>Default constructor</summary>
        public SimFleetShipDetails() : base()
        {
            this.desId = new Int32SaveStruct();
            this.fltId = new Int32SaveStruct();
            this.plrId = new Int32SaveStruct();
            this.range = new FloatSaveStruct();
            this.health = new SimFleetShipHealth();
            this.conCap = new Int32SaveStruct();
            this.refCap = new Int32SaveStruct();
            this.repCap = new Int32SaveStruct();
            this.mineCap = new Int32SaveStruct();
            this.plg = new Int32SaveStruct();
            this.act = new Int32SaveStruct();
            this.dep = new BooleanSaveStruct();
            this.atq = new BooleanSaveStruct();
            this.encId = new Int32SaveStruct();
            this.prish = new SimFleetShipPrish();
            this.lct = new Int32SaveStruct();
            this.tsd = new Int32SaveStruct();
            this.atsp = new Int32SaveStruct();
            this.tblt = new Int32SaveStruct();
            this.hbq = new BooleanSaveStruct();
            this.bq = null;
            this.hsp = new BooleanSaveStruct();
            this.sp = null;
            this.th = new NonComplexArraySaveStruct<SimFleetShipDetailsTh>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.desId.ReadFromStream(Data);
            this.fltId.ReadFromStream(Data);
            this.plrId.ReadFromStream(Data);
            this.range.ReadFromStream(Data);
            this.health.ReadFromStream(Data);
            this.conCap.ReadFromStream(Data);
            this.refCap.ReadFromStream(Data);
            this.repCap.ReadFromStream(Data);
            this.mineCap.ReadFromStream(Data);
            this.plg.ReadFromStream(Data);
            this.act.ReadFromStream(Data);
            this.dep.ReadFromStream(Data);
            this.atq.ReadFromStream(Data);
            this.encId.ReadFromStream(Data);
            this.prish.ReadFromStream(Data);
            this.lct.ReadFromStream(Data);
            this.tsd.ReadFromStream(Data);
            this.atsp.ReadFromStream(Data);
            this.tblt.ReadFromStream(Data);
            this.hbq.ReadFromStream(Data);
            if (this.hbq.BooleanValue)
            {
                this.bq = new SimFleetShipDetailsBq();
                this.bq.ReadFromStream(Data);
            }

            this.hsp.ReadFromStream(Data);
            if (this.hsp.BooleanValue)
            {
                this.sp = new SimFleetShipDetailsSp();
                this.sp.ReadFromStream(Data);
            }

            this.th.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.desId.WriteToStream(Destination);
            this.fltId.WriteToStream(Destination);
            this.plrId.WriteToStream(Destination);
            this.range.WriteToStream(Destination);
            this.health.WriteToStream(Destination);
            this.conCap.WriteToStream(Destination);
            this.refCap.WriteToStream(Destination);
            this.repCap.WriteToStream(Destination);
            this.mineCap.WriteToStream(Destination);
            this.plg.WriteToStream(Destination);
            this.act.WriteToStream(Destination);
            this.dep.WriteToStream(Destination);
            this.atq.WriteToStream(Destination);
            this.encId.WriteToStream(Destination);
            this.prish.WriteToStream(Destination);
            this.lct.WriteToStream(Destination);
            this.tsd.WriteToStream(Destination);
            this.atsp.WriteToStream(Destination);
            this.tblt.WriteToStream(Destination);
            this.hbq.WriteToStream(Destination);
            if (this.hbq.BooleanValue)
                this.bq.WriteToStream(Destination);
            this.hsp.WriteToStream(Destination);
            if (this.hsp.BooleanValue)
                this.sp.WriteToStream(Destination);
            this.th.WriteToStream(Destination);
        }
    }

    public class SimFleetShipDetailsBq : ComplexSaveStruct
    {
        protected ComplexArraySaveStruct<SimFleetShipDetailsBqOrd> ords;

        /// <summary>Default constructor</summary>
        public SimFleetShipDetailsBq() : base()
        {
            this.ords = new ComplexArraySaveStruct<SimFleetShipDetailsBqOrd>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ords.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ords.WriteToStream(Destination);
        }
    }

    public class SimFleetShipDetailsSp : ISotsStructure
    {
        protected SimFleetShipDetailsSpPop pop;
        protected SimFleetShipDetailsSpPop pPop;

        public SimFleetShipDetailsSpPop Pop
        {
            get { return pop; }
            set { pop = value; }
        }

        public SimFleetShipDetailsSpPop PPop
        {
            get { return pPop; }
            set { pPop = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetShipDetailsSp()
        {
            this.pop = new SimFleetShipDetailsSpPop();
            this.pPop = new SimFleetShipDetailsSpPop();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.pop.ReadFromStream(Data);
            this.pPop.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.pop.WriteToStream(Destination);
            this.pPop.WriteToStream(Destination);
        }
    }

    public class SimFleetShipDetailsSpPop : ComplexSaveStruct
    {
        protected NonComplexArraySaveStruct<SimPopGSaveStruct> popG;

        /// <summary>Default constructor</summary>
        public SimFleetShipDetailsSpPop() : base()
        {
            this.popG = new NonComplexArraySaveStruct<SimPopGSaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.popG.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.popG.WriteToStream(Destination);
        }
    }
    
    //This is taken from planet, copy-paste. Do Not use, but probably will...
    public class SimFleetShipDetailsBqOrd : ComplexSaveStruct   //orders?
    {
        protected Int32SaveStruct desId;
        protected Int32SaveStruct con;
        protected Int32SaveStruct conleft;
        protected Int32SaveStruct sav;
        protected Int32SaveStruct ordId;

        public Int32SaveStruct DesId
        {
            get { return desId; }
            set { desId = value; }
        }

        public Int32SaveStruct Con
        {
            get { return con; }
            set { con = value; }
        }

        public Int32SaveStruct Conleft
        {
            get { return conleft; }
            set { conleft = value; }
        }

        public Int32SaveStruct Sav
        {
            get { return sav; }
            set { sav = value; }
        }

        public Int32SaveStruct OrdId
        {
            get { return ordId; }
            set { ordId = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetShipDetailsBqOrd() : base()
        {
            this.desId = new Int32SaveStruct();
            this.con = new Int32SaveStruct();
            this.conleft = new Int32SaveStruct();
            this.sav = new Int32SaveStruct();
            this.ordId = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.desId.ReadFromStream(Data);
            this.con.ReadFromStream(Data);
            this.conleft.ReadFromStream(Data);
            this.sav.ReadFromStream(Data);
            this.ordId.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.desId.WriteToStream(Destination);
            this.con.WriteToStream(Destination);
            this.conleft.WriteToStream(Destination);
            this.sav.WriteToStream(Destination);
            this.ordId.WriteToStream(Destination);
        }
    }

    /// <remarks>Does this go for command, mission and propulsion sections?</remarks>
    public class SimFleetShipHealth : ComplexSaveStruct
    {
        protected FloatSaveStruct unknown1;     //command?
        protected FloatSaveStruct unknown2;     //mission?
        protected FloatSaveStruct unknown3;     //drive?

        public FloatSaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        public FloatSaveStruct Unknown2
        {
            get { return unknown2; }
            set { unknown2 = value; }
        }

        public FloatSaveStruct Unknown3
        {
            get { return unknown3; }
            set { unknown3 = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetShipHealth() : base()
        {
            this.unknown1 = new FloatSaveStruct();
            this.unknown2 = new FloatSaveStruct();
            this.unknown3 = new FloatSaveStruct();
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
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.unknown1.WriteToStream(Destination);
            this.unknown2.WriteToStream(Destination);
            this.unknown3.WriteToStream(Destination);
        }
    }

    //tell me this is an array instead. it just seems to be, but I can't prove nuttin'
    public class SimFleetShipPrish : ComplexSaveStruct
    {
        protected Int32SaveStruct prMax;
        //actually, All I see is prNSP, which is 0
        //  but... it's intuition
        protected NonComplexArraySaveStruct<Int32SaveStruct> prSp;

        public Int32SaveStruct PrMax
        {
            get { return prMax; }
            set { prMax = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> PrSp
        {
            get { return prSp; }
            set { prSp = value; }
        }

        /// <summary>Default constructor</summary>
        public SimFleetShipPrish() : base()
        {
            this.prMax = new Int32SaveStruct();
            this.prSp = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.prMax.ReadFromStream(Data);
            if (this.prMax.Value > 0)
            {
                this.prSp = new NonComplexArraySaveStruct<Int32SaveStruct>();
                this.prSp.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.prMax.WriteToStream(Destination);
            if (this.prMax.Value > 0)
                this.prSp.WriteToStream(Destination);
        }
    }
    #endregion

    #region SvSctOb
    public class SimSvSctObScnObj : ComplexSaveStruct
    {
        /// <summary>Default constructor</summary>
        public SimSvSctObScnObj() : base()
        {
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
        }
    }

    public class SimSvSctObScnObjStruct : ISotsStructure
    {
        protected Int32SaveStruct scnId;
        protected SimSvSctObScnObj scnObj;

        public Int32SaveStruct ScnId
        {
            get { return scnId; }
            set { scnId = value; }
        }

        public SimSvSctObScnObj ScnObj
        {
            get { return scnObj; }
            set { scnObj = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSvSctObScnObjStruct()
        {
            this.scnId = new Int32SaveStruct();
            this.scnObj = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.scnId.ReadFromStream(Data);

            if (this.scnId.Value > 0)
            {
                this.scnObj = new SimSvSctObScnObj();
                this.scnObj.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the structure data to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.scnId.WriteToStream(Destination);

            if (this.scnId.Value > 0)
                this.scnObj.WriteToStream(Destination);
        }
    }

    public class SimSvSctOb : ComplexSaveStruct     //unpronouncable
    {
        protected SimSvSctObScnObjStruct scn;
        protected NonComplexArraySaveStruct<SimSvSctObXscn> xscn;
        protected SimScSctObEncObjArray encObjs;

        #region Properties
        public SimSvSctObScnObjStruct Scn
        {
            get { return scn; }
            set { scn = value; }
        }

        public NonComplexArraySaveStruct<SimSvSctObXscn> Xscn
        {
            get { return xscn; }
            set { xscn = value; }
        }

        public SimScSctObEncObjArray EncObjs
        {
            get { return encObjs; }
            set { encObjs = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimSvSctOb() : base()
        {
            this.scn = new SimSvSctObScnObjStruct();
            this.xscn = new NonComplexArraySaveStruct<SimSvSctObXscn>();
            this.encObjs = new SimScSctObEncObjArray();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.scn.ReadFromStream(Data);
            this.xscn.ReadFromStream(Data);
            this.encObjs.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.scn.WriteToStream(Destination);
            this.xscn.WriteToStream(Destination);
            this.encObjs.WriteToStream(Destination);
        }
    }

    public class SimSvSctObXscn : ISotsStructure
    {
        protected StringSaveStruct xcsn;
        protected SimSvSctObXscnXsc xsc;    //polymorphism?

        public StringSaveStruct Xcsn
        {
            get { return xcsn; }
            set { xcsn = value; }
        }

        public SimSvSctObXscnXsc Xsc
        {
            get { return xsc; }
            set { xsc = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSvSctObXscn()
        {
            this.xcsn = new StringSaveStruct();
            this.xsc = null;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.xcsn.ReadFromStream(Data);

            switch (this.xcsn.Value.CharacterString)
            {
                case "crowdefs":
                    this.xsc = new SimSvSctObXscnXscCrowdefs();
                    break;
                case "gmtrigger":
                    this.xsc = new SimSvSctObXscnXscGmtrigger();
                    break;
                case "traps":
                    this.xsc = new SimSvSctObXscnXscTraps();
                    break;
                case "indsys":
                default:
                    this.xsc = new SimSvSctObXscnXsc();
                    break;
            }

            this.xsc.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.xcsn.WriteToStream(Destination);
            this.xsc.WriteToStream(Destination);
        }
    }

    /// <remarks>This structure looks different for each type of xcsn entry</remarks>
    /// <value>
    ///     crowdefs seems to be an array of dsys (systems)? and an array of des and a drad
    ///     gmtrigger seems to be a single integer named gmch
    ///     indsys seems to be null
    ///     traps seems to be big
    /// </value>
    public class SimSvSctObXscnXsc : ComplexSaveStruct
    {
        /// <summary>Default constructor</summary>
        public SimSvSctObXscnXsc() : base()
        {
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
        }
    }

    public class SimSvSctObXscnXscTraps : SimSvSctObXscnXsc
    {
        protected ComplexArraySaveStruct<SimSvSctObXscnXscTrapDetails> traps;

        public ComplexArraySaveStruct<SimSvSctObXscnXscTrapDetails> Traps
        {
            get { return traps; }
            set { traps = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSvSctObXscnXscTraps() : base()
        {
            this.traps = new ComplexArraySaveStruct<SimSvSctObXscnXscTrapDetails>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.traps.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.traps.WriteToStream(Destination);
        }
    }

    public class SimSvSctObXscnXscTrapDetails : ComplexSaveStruct
    {
        protected Int32SaveStruct sys;
        protected Int32SaveStruct pid;
        protected Int32SaveStruct trenc;
        protected Int32SaveStruct trgenc;

        #region Properties
        public Int32SaveStruct Sys
        {
            get { return sys; }
            set { sys = value; }
        }

        public Int32SaveStruct Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        public Int32SaveStruct Trenc
        {
            get { return trenc; }
            set { trenc = value; }
        }

        public Int32SaveStruct Trgenc
        {
            get { return trgenc; }
            set { trgenc = value; }
        } 
        #endregion
        
        /// <summary>Default constructor</summary>
        public SimSvSctObXscnXscTrapDetails() : base()
        {
            this.sys = new Int32SaveStruct();
            this.pid = new Int32SaveStruct();
            this.trenc = new Int32SaveStruct();
            this.trgenc = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.sys.ReadFromStream(Data);
            this.pid.ReadFromStream(Data);
            this.trenc.ReadFromStream(Data);
            this.trgenc.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.sys.WriteToStream(Destination);
            this.pid.WriteToStream(Destination);
            this.trenc.WriteToStream(Destination);
            this.trgenc.WriteToStream(Destination);
        }
    }

    public class SimSvSctObXscnXscGmtrigger : SimSvSctObXscnXsc
    {
        protected Int32SaveStruct gmch;

        public Int32SaveStruct Gmch
        {
            get { return gmch; }
            set { gmch = value; }
        }

        /// <summary>Default constructor</summary>
        public SimSvSctObXscnXscGmtrigger() : base()
        {
            this.gmch = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.gmch.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.gmch.WriteToStream(Destination);
        }
    }

    public class SimSvSctObXscnXscCrowdefs : SimSvSctObXscnXsc
    {
        protected Int32SaveStruct sys;
        protected NonComplexArraySaveStruct<Int32SaveStruct> dsys;
        protected NonComplexArraySaveStruct<Int32SaveStruct> des;
        protected FloatSaveStruct drad;

        #region Properties
        public Int32SaveStruct Sys
        {
            get { return sys; }
            set { sys = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Dsys
        {
            get { return dsys; }
            set { dsys = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Des
        {
            get { return des; }
            set { des = value; }
        }

        public FloatSaveStruct Drad
        {
            get { return drad; }
            set { drad = value; }
        } 
        #endregion
                
        /// <summary>Default constructor</summary>
        public SimSvSctObXscnXscCrowdefs() : base()
        {
            this.sys = new Int32SaveStruct();
            this.dsys = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.des = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.drad = new FloatSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.sys.ReadFromStream(Data);
            this.dsys.ReadFromStream(Data);
            this.des.ReadFromStream(Data);
            this.drad.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.sys.WriteToStream(Destination);
            this.dsys.WriteToStream(Destination);
            this.des.WriteToStream(Destination);
            this.drad.WriteToStream(Destination);
        }
    }

    #region Encounter Objects
    /// <summary>Enc(ounter) Obj(ect)</summary>
    /// <remarks>
    ///     It would appear, at first glance, that there are 8 encounter objects. It would also appear
    ///     that these appear within the save file in a certain order. Since I do not recall having the ability
    ///     to disable certain encounter objects, I deduce that there are 8 distinct types all of similar decent,
    ///     which will always / usually appear. My test files uphold this theory, currently.
    /// </remarks>
    public class SimScSctObEncObj : ISotsStructure
    {
        protected Int32SaveStruct encId;
        protected SimScSctObEncObjDetails encObj;        //polymorphism

        public Int32SaveStruct EncId
        {
            get { return encId; }
            set { encId = value; }
        }

        public SimScSctObEncObjDetails EncObj
        {
            get { return encObj; }
            set { encObj = value; }
        }

        /// <summary>Default constructor</summary>
        public SimScSctObEncObj()
        {
            this.encId = new Int32SaveStruct();
            this.encObj = new SimScSctObEncObjDetails();
        }

        /// <summary>Assignment constructor</summary>
        public SimScSctObEncObj(SimScSctObEncObjDetails EncObj)
        {
            this.encId = new Int32SaveStruct();
            this.encObj = EncObj;
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.encId.ReadFromStream(Data);
            this.encObj.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.encId.WriteToStream(Destination);
            this.encObj.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsAsg : ISotsStructure
    {
        protected Int32SaveStruct eflt;
        protected Int32SaveStruct esys;

        public Int32SaveStruct Eflt
        {
            get { return eflt; }
            set { eflt = value; }
        }

        public Int32SaveStruct Esys
        {
            get { return esys; }
            set { esys = value; }
        }


        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsAsg()
        {
            this.eflt = new Int32SaveStruct();
            this.esys = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.eflt.ReadFromStream(Data);
            this.esys.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.eflt.WriteToStream(Destination);
            this.esys.WriteToStream(Destination);
        }
    }
    
    public class SimScSctObEncObjDetailsDsn : ISotsStructure
    {
        protected Int32SaveStruct dsnId;
        protected Int32SaveStruct dwght;

        public Int32SaveStruct DsnId
        {
            get { return dsnId; }
            set { dsnId = value; }
        }

        public Int32SaveStruct Dwght
        {
            get { return dwght; }
            set { dwght = value; }
        }


        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsDsn()
        {
            this.dsnId = new Int32SaveStruct();
            this.dwght = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.dsnId.ReadFromStream(Data);
            this.dwght.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.dsnId.WriteToStream(Destination);
            this.dwght.WriteToStream(Destination);
        }
    }

    #region Infest
    public class SimScSctObEncObjDetailsEncInfest : SimScSctObEncObjDetails
    {
        protected NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> asg;
        protected ComplexArraySaveStruct<SimScSctObEncObjInfest> infests;
        protected Int32SaveStruct deshive;
        protected Int32SaveStruct deslarva;

        #region Properties
        public NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> Asg
        {
            get { return asg; }
            set { asg = value; }
        }

        public ComplexArraySaveStruct<SimScSctObEncObjInfest> Infests
        {
            get { return infests; }
            set { infests = value; }
        }

        public Int32SaveStruct Deshive
        {
            get { return deshive; }
            set { deshive = value; }
        }

        public Int32SaveStruct Deslarva
        {
            get { return deslarva; }
            set { deslarva = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncInfest() : base()
        {
            this.asg = new NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg>();
            this.infests = new ComplexArraySaveStruct<SimScSctObEncObjInfest>();
            this.deshive = new Int32SaveStruct();
            this.deslarva = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.asg.ReadFromStream(Data);
            this.infests.ReadFromStream(Data);
            this.deshive.ReadFromStream(Data);
            this.deslarva.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.asg.WriteToStream(Destination);
            this.infests.WriteToStream(Destination);
            this.deshive.WriteToStream(Destination);
            this.deslarva.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjInfest : ComplexSaveStruct
    {
        protected Int32SaveStruct sysid;
        protected Int32SaveStruct stg;
        protected Int32SaveStruct strn;
        protected Int32SaveStruct mtrn;
        protected Int32SaveStruct trgtrn;
        protected Int32SaveStruct canh;

        #region Properties
        public Int32SaveStruct Sysid
        {
            get { return sysid; }
            set { sysid = value; }
        }

        public Int32SaveStruct Stg
        {
            get { return stg; }
            set { stg = value; }
        }

        public Int32SaveStruct Strn
        {
            get { return strn; }
            set { strn = value; }
        }

        public Int32SaveStruct Mtrn
        {
            get { return mtrn; }
            set { mtrn = value; }
        }

        public Int32SaveStruct Trgtrn
        {
            get { return trgtrn; }
            set { trgtrn = value; }
        }

        public Int32SaveStruct Canh
        {
            get { return canh; }
            set { canh = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjInfest() : base()
        {
            this.sysid = new Int32SaveStruct();
            this.stg = new Int32SaveStruct();
            this.strn = new Int32SaveStruct();
            this.mtrn = new Int32SaveStruct();
            this.trgtrn = new Int32SaveStruct();
            this.canh = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.sysid.ReadFromStream(Data);
            this.stg.ReadFromStream(Data);
            this.strn.ReadFromStream(Data);
            this.mtrn.ReadFromStream(Data);
            this.trgtrn.ReadFromStream(Data);
            this.canh.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.sysid.WriteToStream(Destination);
            this.stg.WriteToStream(Destination);
            this.strn.WriteToStream(Destination);
            this.mtrn.WriteToStream(Destination);
            this.trgtrn.WriteToStream(Destination);
            this.canh.WriteToStream(Destination);
        }
    }
    #endregion

    #region DSN
    public class SimScSctObEncObjDetailsEncDsn : SimScSctObEncObjDetails
    {
        protected NonComplexArraySaveStruct<SimScSctObEncObjDetailsDsn> dsn;
        protected NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> asg;

        public NonComplexArraySaveStruct<SimScSctObEncObjDetailsDsn> Dsn
        {
            get { return dsn; }
            set { dsn = value; }
        }

        public NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> Asg
        {
            get { return asg; }
            set { asg = value; }
        }

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncDsn() : base()
        {
            this.dsn = new NonComplexArraySaveStruct<SimScSctObEncObjDetailsDsn>();
            this.asg = new NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.dsn.ReadFromStream(Data);
            this.asg.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.dsn.WriteToStream(Destination);
            this.asg.WriteToStream(Destination);
        }
    }
    #endregion

    #region Asteroid Monitor
    public class SimScSctObEncObjDetailsAsteroidMonitor : ISotsStructure
    {
        protected StringSaveStruct scnm;
        protected Int32SaveStruct spwt;
        protected FloatSaveStruct rsmd;
        protected Int32SaveStruct dsgn;

        #region Properties
        public StringSaveStruct Scnm
        {
            get { return scnm; }
            set { scnm = value; }
        }

        public Int32SaveStruct Spwt
        {
            get { return spwt; }
            set { spwt = value; }
        }

        public FloatSaveStruct Rsmd
        {
            get { return rsmd; }
            set { rsmd = value; }
        }

        public Int32SaveStruct Dsgn
        {
            get { return dsgn; }
            set { dsgn = value; }
        } 
        #endregion
        
        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsAsteroidMonitor()
        {
            this.scnm = new StringSaveStruct();
            this.spwt = new Int32SaveStruct();
            this.rsmd = new FloatSaveStruct();
            this.dsgn = new Int32SaveStruct();
        }

        /// <summary>Populates the data structure from the incoming stream by reading expected values.</summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public void ReadFromStream(Stream Data)
        {
            this.scnm.ReadFromStream(Data);
            this.spwt.ReadFromStream(Data);
            this.rsmd.ReadFromStream(Data);
            this.dsgn.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public void WriteToStream(Stream Destination)
        {
            this.scnm.WriteToStream(Destination);
            this.spwt.WriteToStream(Destination);
            this.rsmd.WriteToStream(Destination);
            this.dsgn.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsEncAsteroidMonitor : SimScSctObEncObjDetails
    {
        protected NonComplexArraySaveStruct<SimScSctObEncObjDetailsDsn> dsn;
        protected NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> asg;
        protected NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsteroidMonitor> astmn;

        public NonComplexArraySaveStruct<SimScSctObEncObjDetailsDsn> Dsn
        {
            get { return dsn; }
            set { dsn = value; }
        }

        public NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> Asg
        {
            get { return asg; }
            set { asg = value; }
        }

        public NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsteroidMonitor> Astmn
        {
            get { return astmn; }
            set { astmn = value; }
        }

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncAsteroidMonitor() : base()
        {
            this.dsn = new NonComplexArraySaveStruct<SimScSctObEncObjDetailsDsn>();
            this.asg = new NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg>();
            this.astmn = new NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsteroidMonitor>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.dsn.ReadFromStream(Data);
            this.asg.ReadFromStream(Data);
            this.astmn.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.dsn.WriteToStream(Destination);
            this.asg.WriteToStream(Destination);
            this.astmn.WriteToStream(Destination);
        }
    }
    #endregion

    #region TDAD
    public class SimScSctObEncObjDetailsEncTD : SimScSctObEncObjDetails
    {
        protected NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> asg;
        protected Int32SaveStruct cDiff;
        protected NonComplexArraySaveStruct<Int32SaveStruct> tdids;
        protected NonComplexArraySaveStruct<Int32SaveStruct> adids;

        #region Properties
        public NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> Asg
        {
            get { return asg; }
            set { asg = value; }
        }

        public Int32SaveStruct CDiff
        {
            get { return cDiff; }
            set { cDiff = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> TDIDs
        {
            get { return tdids; }
            set { tdids = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> ADIDs
        {
            get { return adids; }
            set { adids = value; }
        } 
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncTD() : base()
        {
            this.asg = new NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg>();
            this.cDiff = new Int32SaveStruct();
            this.tdids = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.adids = new NonComplexArraySaveStruct<Int32SaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.asg.ReadFromStream(Data);
            this.cDiff.ReadFromStream(Data);
            this.tdids.ReadFromStream(Data);
            this.adids.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.asg.WriteToStream(Destination);
            this.cDiff.WriteToStream(Destination);
            this.tdids.WriteToStream(Destination);
            this.adids.WriteToStream(Destination);
        }
    }
    #endregion

    #region WD
    public class SimScSctObEncObjDetailsEncWD : SimScSctObEncObjDetails
    {
        protected NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> asg;
        protected NonComplexArraySaveStruct<Int32SaveStruct> wids;

        #region Properties
        public NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg> Asg
        {
            get { return asg; }
            set { asg = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Wids
        {
            get { return wids; }
            set { wids = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncWD() : base()
        {
            this.asg = new NonComplexArraySaveStruct<SimScSctObEncObjDetailsAsg>();
            this.wids = new NonComplexArraySaveStruct<Int32SaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.asg.ReadFromStream(Data);
            this.wids.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.asg.WriteToStream(Destination);
            this.wids.WriteToStream(Destination);
        }
    }
    #endregion

    #region Hives
    public class SimScSctObEncObjHive : ComplexSaveStruct
    {
        protected Int32SaveStruct hiveId;
        protected Int32SaveStruct queenId;
        protected Int32SaveStruct nextQ;

        #region Properties
        public Int32SaveStruct HiveId
        {
            get { return hiveId; }
            set { hiveId = value; }
        }

        public Int32SaveStruct QueenId
        {
            get { return queenId; }
            set { queenId = value; }
        }

        public Int32SaveStruct NextQ
        {
            get { return nextQ; }
            set { nextQ = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjHive() : base()
        {
            this.hiveId = new Int32SaveStruct();
            this.queenId = new Int32SaveStruct();
            this.nextQ = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.hiveId.ReadFromStream(Data);
            this.queenId.ReadFromStream(Data);
            this.nextQ.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.hiveId.WriteToStream(Destination);
            this.queenId.WriteToStream(Destination);
            this.nextQ.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjQueen : ComplexSaveStruct
    {
        protected Int32SaveStruct queenId;
        protected Int32SaveStruct qDstId;

        #region Properties
        public Int32SaveStruct QueenId
        {
            get { return queenId; }
            set { queenId = value; }
        }

        public Int32SaveStruct QDstId
        {
            get { return qDstId; }
            set { qDstId = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjQueen() : base()
        {
            this.queenId = new Int32SaveStruct();
            this.qDstId = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.queenId.ReadFromStream(Data);
            this.qDstId.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.queenId.WriteToStream(Destination);
            this.qDstId.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsEncHives : SimScSctObEncObjDetails
    {
        protected Int32SaveStruct qDesignId;
        protected ComplexArraySaveStruct<SimScSctObEncObjHive> hives;
        protected ComplexArraySaveStruct<SimScSctObEncObjQueen> queens;
        protected ComplexArraySaveStruct<NestedInt32SaveStruct> sysMem;

        #region Properties
        public Int32SaveStruct QDesignId
        {
            get { return qDesignId; }
            set { qDesignId = value; }
        }

        public ComplexArraySaveStruct<SimScSctObEncObjHive> Hives
        {
            get { return hives; }
            set { hives = value; }
        }

        public ComplexArraySaveStruct<SimScSctObEncObjQueen> Queens
        {
            get { return queens; }
            set { queens = value; }
        }

        public ComplexArraySaveStruct<NestedInt32SaveStruct> SysMem
        {
            get { return sysMem; }
            set { sysMem = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncHives() : base()
        {
            this.qDesignId = new Int32SaveStruct();
            this.hives = new ComplexArraySaveStruct<SimScSctObEncObjHive>();
            this.queens = new ComplexArraySaveStruct<SimScSctObEncObjQueen>();
            this.sysMem = new ComplexArraySaveStruct<NestedInt32SaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.qDesignId.ReadFromStream(Data);
            this.hives.ReadFromStream(Data);
            this.queens.ReadFromStream(Data);
            this.sysMem.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.qDesignId.WriteToStream(Destination);
            this.hives.WriteToStream(Destination);
            this.queens.WriteToStream(Destination);
            this.sysMem.WriteToStream(Destination);
        }
    }
    #endregion

    #region rsuc
    public class SimScSctObEncObjDetailsEncRsuc : SimScSctObEncObjDetails
    {
        protected Int32SaveStruct rsuc;
        protected NonComplexArraySaveStruct<Int32SaveStruct> did;
        protected BooleanSaveStruct ini;
        
        #region Properties
        public Int32SaveStruct Rsuc
        {
            get { return rsuc; }
            set { rsuc = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> Did
        {
            get { return did; }
            set { did = value; }
        }

        public BooleanSaveStruct Ini
        {
            get { return ini; }
            set { ini = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncRsuc() : base()
        {
            this.rsuc = new Int32SaveStruct();
            this.did = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.ini = new BooleanSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.rsuc.ReadFromStream(Data);
            this.did.ReadFromStream(Data);
            this.ini.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.rsuc.WriteToStream(Destination);
            this.did.WriteToStream(Destination);
            this.ini.WriteToStream(Destination);
        }
    }
    #endregion

    #region dfts
    public class SimScSctObEncObjDft : ComplexSaveStruct
    {
        protected Int32SaveStruct sys;
        protected Int32SaveStruct ndft;
        
        //struct below?
        protected Int32SaveStruct nxrv;
        protected Int32SaveStruct lstd;
        protected Int32SaveStruct bkdf;
        
        #region Properties
        public Int32SaveStruct Sys
        {
            get { return sys; }
            set { sys = value; }
        }

        public Int32SaveStruct Ndft
        {
            get { return ndft; }
            set { ndft = value; }
        }

        public Int32SaveStruct Nxrv
        {
            get { return nxrv; }
            set { nxrv = value; }
        }

        public Int32SaveStruct Lstd
        {
            get { return lstd; }
            set { lstd = value; }
        }

        public Int32SaveStruct Bkdf
        {
            get { return bkdf; }
            set { bkdf = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDft() : base()
        {
            this.sys = new Int32SaveStruct();
            this.ndft = new Int32SaveStruct();
            this.nxrv = new Int32SaveStruct();
            this.lstd = new Int32SaveStruct();
            this.bkdf = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.sys.ReadFromStream(Data);
            this.ndft.ReadFromStream(Data);
            this.nxrv.ReadFromStream(Data);
            this.lstd.ReadFromStream(Data);
            this.bkdf.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.sys.WriteToStream(Destination);
            this.ndft.WriteToStream(Destination);
            this.nxrv.WriteToStream(Destination);
            this.lstd.WriteToStream(Destination);
            this.bkdf.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsEncDfts : SimScSctObEncObjDetails
    {
        protected ComplexArraySaveStruct<SimScSctObEncObjDft> dfts;
        protected Int32SaveStruct rusav;
        protected Int32SaveStruct nenc;
        protected Int32SaveStruct nmb;
        protected Int32SaveStruct nml;
        protected Int32SaveStruct nbb;
        protected Int32SaveStruct nbl;
        protected Int32SaveStruct nskb;
        protected Int32SaveStruct nskl;

        //array of what?
        protected NestedInt32SaveStruct mts;

        protected Int32SaveStruct ntm;
        protected Int32SaveStruct ntb;
        protected Int32SaveStruct sken;
        protected Int32SaveStruct skdid;
        protected Int32SaveStruct skhid;
        protected Int32SaveStruct skfid;
        protected Int32SaveStruct sktq;
        protected Int32SaveStruct skt;
        protected Int32SaveStruct sktc;
        protected Int32SaveStruct mbid;
        protected Int32SaveStruct mbgid;
        protected Int32SaveStruct skgid;
        protected Int64SaveStruct vnhp;
        protected Int32SaveStruct vnhw;

        //array of what?
        protected NestedInt32SaveStruct trev;


        #region Properties
        public ComplexArraySaveStruct<SimScSctObEncObjDft> Dfts
        {
            get { return dfts; }
            set { dfts = value; }
        }

        public Int32SaveStruct Rusav
        {
            get { return rusav; }
            set { rusav = value; }
        }

        public Int32SaveStruct Nenc
        {
            get { return nenc; }
            set { nenc = value; }
        }

        public Int32SaveStruct Nmb
        {
            get { return nmb; }
            set { nmb = value; }
        }

        public Int32SaveStruct Nml
        {
            get { return nml; }
            set { nml = value; }
        }

        public Int32SaveStruct Nbb
        {
            get { return nbb; }
            set { nbb = value; }
        }

        public Int32SaveStruct Nbl
        {
            get { return nbl; }
            set { nbl = value; }
        }

        public Int32SaveStruct Nskb
        {
            get { return nskb; }
            set { nskb = value; }
        }

        public Int32SaveStruct Nskl
        {
            get { return nskl; }
            set { nskl = value; }
        }

        public NestedInt32SaveStruct Mts
        {
            get { return mts; }
            set { mts = value; }
        }

        public Int32SaveStruct Ntm
        {
            get { return ntm; }
            set { ntm = value; }
        }

        public Int32SaveStruct Ntb
        {
            get { return ntb; }
            set { ntb = value; }
        }

        public Int32SaveStruct Sken
        {
            get { return sken; }
            set { sken = value; }
        }

        public Int32SaveStruct Skdid
        {
            get { return skdid; }
            set { skdid = value; }
        }

        public Int32SaveStruct Skhid
        {
            get { return skhid; }
            set { skhid = value; }
        }

        public Int32SaveStruct Skfid
        {
            get { return skfid; }
            set { skfid = value; }
        }

        public Int32SaveStruct Sktq
        {
            get { return sktq; }
            set { sktq = value; }
        }

        public Int32SaveStruct Skt
        {
            get { return skt; }
            set { skt = value; }
        }

        public Int32SaveStruct Sktc
        {
            get { return sktc; }
            set { sktc = value; }
        }

        public Int32SaveStruct Mbid
        {
            get { return mbid; }
            set { mbid = value; }
        }

        public Int32SaveStruct Mbgid
        {
            get { return mbgid; }
            set { mbgid = value; }
        }

        public Int32SaveStruct Skgid
        {
            get { return skgid; }
            set { skgid = value; }
        }

        public Int64SaveStruct Vnhp
        {
            get { return vnhp; }
            set { vnhp = value; }
        }

        public Int32SaveStruct Vnhw
        {
            get { return vnhw; }
            set { vnhw = value; }
        }

        public NestedInt32SaveStruct Trev
        {
            get { return trev; }
            set { trev = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncDfts() : base()
        {
            this.dfts = new ComplexArraySaveStruct<SimScSctObEncObjDft>();
            this.rusav = new Int32SaveStruct();
            this.nenc = new Int32SaveStruct();
            this.nmb = new Int32SaveStruct();
            this.nml = new Int32SaveStruct();
            this.nbb = new Int32SaveStruct();
            this.nbl = new Int32SaveStruct();
            this.nskb = new Int32SaveStruct();
            this.nskl = new Int32SaveStruct();
            this.mts = new NestedInt32SaveStruct();
            this.ntm = new Int32SaveStruct();
            this.ntb = new Int32SaveStruct();
            this.sken = new Int32SaveStruct();
            this.skdid = new Int32SaveStruct();
            this.skhid = new Int32SaveStruct();
            this.skfid = new Int32SaveStruct();
            this.sktq = new Int32SaveStruct();
            this.skt = new Int32SaveStruct();
            this.sktc = new Int32SaveStruct();
            this.mbid = new Int32SaveStruct();
            this.mbgid = new Int32SaveStruct();
            this.skgid = new Int32SaveStruct();
            this.vnhp = new Int64SaveStruct();
            this.vnhw = new Int32SaveStruct();
            this.trev = new NestedInt32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.dfts.ReadFromStream(Data);
            this.rusav.ReadFromStream(Data);
            this.nenc.ReadFromStream(Data);
            this.nmb.ReadFromStream(Data);
            this.nml.ReadFromStream(Data);
            this.nbb.ReadFromStream(Data);
            this.nbl.ReadFromStream(Data);
            this.nskb.ReadFromStream(Data);
            this.nskl.ReadFromStream(Data);
            this.mts.ReadFromStream(Data);
            this.ntm.ReadFromStream(Data);
            this.ntb.ReadFromStream(Data);
            this.sken.ReadFromStream(Data);
            this.skdid.ReadFromStream(Data);
            this.skhid.ReadFromStream(Data);
            this.skfid.ReadFromStream(Data);
            this.sktq.ReadFromStream(Data);
            this.skt.ReadFromStream(Data);
            this.sktc.ReadFromStream(Data);
            this.mbid.ReadFromStream(Data);
            this.mbgid.ReadFromStream(Data);
            this.skgid.ReadFromStream(Data);
            this.vnhp.ReadFromStream(Data);
            this.vnhw.ReadFromStream(Data);
            this.trev.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.dfts.WriteToStream(Destination);
            this.rusav.WriteToStream(Destination);
            this.nenc.WriteToStream(Destination);
            this.nmb.WriteToStream(Destination);
            this.nml.WriteToStream(Destination);
            this.nbb.WriteToStream(Destination);
            this.nbl.WriteToStream(Destination);
            this.nskb.WriteToStream(Destination);
            this.nskl.WriteToStream(Destination);
            this.mts.WriteToStream(Destination);
            this.ntm.WriteToStream(Destination);
            this.ntb.WriteToStream(Destination);
            this.sken.WriteToStream(Destination);
            this.skdid.WriteToStream(Destination);
            this.skhid.WriteToStream(Destination);
            this.skfid.WriteToStream(Destination);
            this.sktq.WriteToStream(Destination);
            this.skt.WriteToStream(Destination);
            this.sktc.WriteToStream(Destination);
            this.mbid.WriteToStream(Destination);
            this.mbgid.WriteToStream(Destination);
            this.skgid.WriteToStream(Destination);
            this.vnhp.WriteToStream(Destination);
            this.vnhw.WriteToStream(Destination);
            this.trev.WriteToStream(Destination);
        }
    }
    #endregion

    #region Ini2
    public class SimScSctObEncObjDetailsEncIni2 : SimScSctObEncObjDetails
    {
        protected Int32SaveStruct ini2;
        protected SimScSctObEncObjDetailsEncIni2Nst nst;
        protected SimScSctObEncObjDetailsEncIni2Flt flt;
        protected SimScSctObEncObjDetailsEncIni2Vis vis;
        protected Int32SaveStruct des;
        
        #region Properties
        public Int32SaveStruct Ini2
        {
            get { return ini2; }
            set { ini2 = value; }
        }

        public SimScSctObEncObjDetailsEncIni2Nst Nst
        {
            get { return nst; }
            set { nst = value; }
        }

        public SimScSctObEncObjDetailsEncIni2Flt Flt
        {
            get { return flt; }
            set { flt = value; }
        }

        public SimScSctObEncObjDetailsEncIni2Vis Vis
        {
            get { return vis; }
            set { vis = value; }
        }

        public Int32SaveStruct Des
        {
            get { return des; }
            set { des = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncIni2() : base()
        {
            this.ini2 = new Int32SaveStruct();
            this.nst = new SimScSctObEncObjDetailsEncIni2Nst();
            this.flt = new SimScSctObEncObjDetailsEncIni2Flt();
            this.vis = new SimScSctObEncObjDetailsEncIni2Vis();
            this.des = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.ini2.ReadFromStream(Data);
            this.nst.ReadFromStream(Data);
            this.flt.ReadFromStream(Data);
            this.vis.ReadFromStream(Data);
            this.des.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.ini2.WriteToStream(Destination);
            this.nst.WriteToStream(Destination);
            this.flt.WriteToStream(Destination);
            this.vis.WriteToStream(Destination);
            this.des.WriteToStream(Destination);
        }
    }
    
    public class SimScSctObEncObjDetailsEncIni2NstFltBase : ComplexSaveStruct
    {
        protected Int32SaveStruct siz;          //size
        protected Int32SaveStruct unknown1;     //not always present?

        public Int32SaveStruct Siz
        {
            get { return siz; }
            set { siz = value; }
        }

        public Int32SaveStruct Unknown1
        {
            get { return unknown1; }
            set { unknown1 = value; }
        }

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncIni2NstFltBase() : base()
        {
            this.siz = new Int32SaveStruct();
            //this.unknown1 = new Int32SaveStruct();
            this.unknown1 = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.siz.ReadFromStream(Data);
            if (this.siz.Value > 0)
            {
                this.unknown1 = new Int32SaveStruct();
                this.unknown1.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.siz.WriteToStream(Destination);
            if (this.siz.Value > 0)
                this.unknown1.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsEncIni2Nst : SimScSctObEncObjDetailsEncIni2NstFltBase
    {
        protected SimScSctObEncObjDetailsEncIni2NstObj nstObj;  //not always there?

        public SimScSctObEncObjDetailsEncIni2NstObj NstObj
        {
          get { return nstObj; }
          set { nstObj = value; }
        }

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncIni2Nst() : base()
        {
            this.nstObj = null;
            //this.nstObj = new SimScSctObEncObjDetailsEncIni2NstObj();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            base.ReadBodyFromStream(Data);

            if (this.siz.Value != 0)
            {
                this.nstObj = new SimScSctObEncObjDetailsEncIni2NstObj();
                this.nstObj.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            base.WriteBodyToStream(Destination);

            if (this.siz.Value != 0)
                this.nstObj.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsEncIni2Flt : SimScSctObEncObjDetailsEncIni2NstFltBase
    {
        protected SimScSctObEncObjDetailsEncIni2FltObj fltObj;      //not always there?

        public SimScSctObEncObjDetailsEncIni2FltObj FltObj
        {
            get { return fltObj; }
            set { fltObj = value; }
        }

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncIni2Flt() : base()
        {
            //this.fltObj = new SimScSctObEncObjDetailsEncIni2FltObj();
            this.fltObj = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            base.ReadBodyFromStream(Data);

            if (this.siz.Value != 0)
            {
                this.fltObj = new SimScSctObEncObjDetailsEncIni2FltObj();
                this.fltObj.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            base.WriteBodyToStream(Destination);

            if (this.siz.Value != 0)
                this.fltObj.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsEncIni2NstObj : ComplexSaveStruct
    {
        protected Int32SaveStruct res;

        public Int32SaveStruct Res
        {
            get { return res; }
            set { res = value; }
        }

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncIni2NstObj() : base()
        {
            this.res = new Int32SaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.res.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.res.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsEncIni2FltObj : ComplexSaveStruct
    {
        protected BooleanSaveStruct hav;
        protected BooleanSaveStruct don;
        protected Int32SaveStruct dsy;
        protected SpatialCoordinateSaveStruct dst;

        #region Properties
        public BooleanSaveStruct Hav
        {
            get { return hav; }
            set { hav = value; }
        }

        public BooleanSaveStruct Don
        {
            get { return don; }
            set { don = value; }
        }

        public Int32SaveStruct Dsy
        {
            get { return dsy; }
            set { dsy = value; }
        }

        public SpatialCoordinateSaveStruct Dst
        {
            get { return dst; }
            set { dst = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncIni2FltObj() : base()
        {
            this.hav = new BooleanSaveStruct();
            this.don = new BooleanSaveStruct();
            this.dsy = new Int32SaveStruct();
            this.dst = new SpatialCoordinateSaveStruct();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.hav.ReadFromStream(Data);
            this.don.ReadFromStream(Data);
            this.dsy.ReadFromStream(Data);
            this.dst.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.hav.WriteToStream(Destination);
            this.don.WriteToStream(Destination);
            this.dsy.WriteToStream(Destination);
            this.dst.WriteToStream(Destination);
        }
    }

    public class SimScSctObEncObjDetailsEncIni2Vis : ComplexSaveStruct
    {
        protected NonComplexArraySaveStruct<NestedInt32SaveStruct> vis;

        public NonComplexArraySaveStruct<NestedInt32SaveStruct> Vis
        {
            get { return vis; }
            set { vis = value; }
        }
        
        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetailsEncIni2Vis() : base()
        {
            this.vis = new NonComplexArraySaveStruct<NestedInt32SaveStruct>();
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.vis.ReadFromStream(Data);
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.vis.WriteToStream(Destination);
        }
    }
    #endregion

    public class SimScSctObEncObjDetails : ComplexSaveStruct
    {
        /// <summary>Default constructor</summary>
        public SimScSctObEncObjDetails() : base()
        {
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
        }
    }

    public class SimScSctObEncObjArray : NonComplexArraySaveStruct<SimScSctObEncObj>
    {
        /// <summary>Default constructor</summary>
        public SimScSctObEncObjArray() : base()
        {
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        public override void ReadFromStream(Stream Data)
        {
            this.length.ReadFromStream(Data);

            this.values = new List<SimScSctObEncObj>();
            for (Int32 i = 0; i < this.length.Value; i++)
            {
                SimScSctObEncObj newScSct;
                switch (i)
                {
                    case 0:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncInfest());
                        break;
                    case 1:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncDsn());
                        break;
                    case 2:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncAsteroidMonitor());
                        break;
                    case 3:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncTD());
                        break;
                    case 4:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncWD());
                        break;
                    case 5:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncHives());
                        break;
                    case 6:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncRsuc());
                        break;
                    case 7:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncDfts());
                        break;
                    case 8:
                        newScSct = new SimScSctObEncObj(new SimScSctObEncObjDetailsEncIni2());
                        break;
                    default:
                        newScSct = new SimScSctObEncObj();
                        break;
                }

                newScSct.ReadFromStream(Data);
                this.values.Add(newScSct);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        public override void WriteToStream(Stream Destination)
        {
            this.length.WriteToStream(Destination);
            for (Int32 i = 0; i < this.values.Count; i++)
                this.values[i].WriteToStream(Destination);
        }
    }
    #endregion
    #endregion
    
    /// <summary>Simulation top-level save game data structure</summary>
    public class SimSaveStruct : ComplexSaveStruct
    {
        protected StringSaveStruct keyPath;
        protected Int32SaveStruct nMsz;
        protected Int32SaveStruct nMlc;
        protected Int32SaveStruct nMnx;
        protected NonComplexArraySaveStruct<Int32SaveStruct> playerIds;
        protected NonComplexArraySaveStruct<Int32SaveStruct> designIds;
        protected NonComplexArraySaveStruct<Int32SaveStruct> systemIds;
        protected NonComplexArraySaveStruct<Int32SaveStruct> fleetIds;
        protected NonComplexArraySaveStruct<Int32SaveStruct> shipIds;
        protected NonComplexArraySaveStruct<Int32SaveStruct> tradeIds;
        protected Int32SaveStruct modCount;
        protected Int32SaveStruct frame;
        protected Int32SaveStruct gameId;
        protected AttributeSaveStruct attribute;
        protected RngSaveStruct rng;
        protected StringSaveStruct gameName;
        protected Int32SaveStruct map;
        protected Int32SaveStruct incMod;
        protected Int32SaveStruct resMod;
        protected Int32SaveStruct enAl;
        protected Int32SaveStruct enTm;
        protected Int32SaveStruct gOTurn;
        protected NestedInt32SaveStruct gOWinPly;
        protected Int32SaveStruct npcm;
        protected Int32SaveStruct npco;
        protected Int32SaveStruct npci;
        protected Int32SaveStruct npcv;
        protected Int32SaveStruct npca;
        protected Int32SaveStruct szad;
        protected Int32SaveStruct rsad;
        protected Int32SaveStruct suad;
        protected ComplexArraySaveStruct<ResearchSaveStruct> sprjs;
        protected FloatSaveStruct randEncAdjustment;
        protected Int32SaveStruct cmbtid;
        protected ComplexArraySaveStruct<TurnPly> turnstats;
        protected NonComplexArraySaveStruct<SimCrepSaveStruct> creps;
        protected Int32SaveStruct ninv;
        protected Int32SaveStruct allExc1;
        protected Int32SaveStruct allExc2;
        protected Int32SaveStruct allExcCF;
        protected NonComplexArraySaveStruct<SimPlayerSaveStruct> players;
        protected SimSpeciesArraySaveStruct species;
        protected NonComplexArraySaveStruct<SimSystemSaveStruct> systems;
        protected SimNodeGrid2 ndgr2;
        protected SimTradeManager trdmgr;
        protected SimSpyManager spymgr;
        protected NonComplexArraySaveStruct<SimFleet> flt;
        protected NonComplexArraySaveStruct<Int32SaveStruct> acts;
        protected SimSvSctOb svSctOb;
        protected Int32SaveStruct zdsc; //Boolean?
        protected Int32SaveStruct zdsi;
        protected Int32SaveStruct zdst;

        #region Properties
        public StringSaveStruct KeyPath
        {
            get { return keyPath; }
            set { keyPath = value; }
        }

        public Int32SaveStruct NMsz
        {
            get { return nMsz; }
            set { nMsz = value; }
        }

        public Int32SaveStruct NMlc
        {
            get { return nMlc; }
            set { nMlc = value; }
        }

        public Int32SaveStruct NMnx
        {
            get { return nMnx; }
            set { nMnx = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> PlayerIds
        {
            get { return playerIds; }
            set { playerIds = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> DesignIds
        {
            get { return designIds; }
            set { designIds = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> SystemIds
        {
            get { return systemIds; }
            set { systemIds = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> FleetIds
        {
            get { return fleetIds; }
            set { fleetIds = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> ShipIds
        {
            get { return shipIds; }
            set { shipIds = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> TradeIds
        {
            get { return tradeIds; }
            set { tradeIds = value; }
        }

        public Int32SaveStruct ModCount
        {
            get { return modCount; }
            set { modCount = value; }
        }

        public Int32SaveStruct Frame
        {
            get { return frame; }
            set { frame = value; }
        }

        public Int32SaveStruct GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }

        public AttributeSaveStruct Attribute
        {
            get { return attribute; }
            set { attribute = value; }
        }

        public RngSaveStruct Rng
        {
            get { return rng; }
            set { rng = value; }
        }

        public StringSaveStruct GameName
        {
            get { return gameName; }
            set { gameName = value; }
        }

        public Int32SaveStruct Map
        {
            get { return map; }
            set { map = value; }
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

        public Int32SaveStruct EnAl
        {
            get { return enAl; }
            set { enAl = value; }
        }

        public Int32SaveStruct EnTm
        {
            get { return enTm; }
            set { enTm = value; }
        }

        public Int32SaveStruct GOTurn
        {
            get { return gOTurn; }
            set { gOTurn = value; }
        }

        public NestedInt32SaveStruct GOWinPly
        {
            get { return gOWinPly; }
            set { gOWinPly = value; }
        }

        public Int32SaveStruct Npcm
        {
            get { return npcm; }
            set { npcm = value; }
        }

        public Int32SaveStruct Npco
        {
            get { return npco; }
            set { npco = value; }
        }

        public Int32SaveStruct Npci
        {
            get { return npci; }
            set { npci = value; }
        }

        public Int32SaveStruct Npcv
        {
            get { return npcv; }
            set { npcv = value; }
        }

        public Int32SaveStruct Npca
        {
            get { return npca; }
            set { npca = value; }
        }

        public Int32SaveStruct Szad
        {
            get { return szad; }
            set { szad = value; }
        }

        public Int32SaveStruct Rsad
        {
            get { return rsad; }
            set { rsad = value; }
        }

        public Int32SaveStruct Suad
        {
            get { return suad; }
            set { suad = value; }
        }

        public ComplexArraySaveStruct<ResearchSaveStruct> Sprjs
        {
            get { return sprjs; }
            set { sprjs = value; }
        }

        public FloatSaveStruct RandEncAdjustment
        {
            get { return randEncAdjustment; }
            set { randEncAdjustment = value; }
        }

        public Int32SaveStruct Cmbtid
        {
            get { return cmbtid; }
            set { cmbtid = value; }
        }

        public ComplexArraySaveStruct<TurnPly> Turnstats
        {
            get { return turnstats; }
            set { turnstats = value; }
        }

        public NonComplexArraySaveStruct<SimCrepSaveStruct> Creps
        {
            get { return creps; }
            set { creps = value; }
        }

        public Int32SaveStruct Ninv
        {
            get { return ninv; }
            set { ninv = value; }
        }

        public Int32SaveStruct AllExc1
        {
            get { return allExc1; }
            set { allExc1 = value; }
        }

        public Int32SaveStruct AllExc2
        {
            get { return allExc2; }
            set { allExc2 = value; }
        }

        public Int32SaveStruct AllExcCF
        {
            get { return allExcCF; }
            set { allExcCF = value; }
        }

        public NonComplexArraySaveStruct<SimPlayerSaveStruct> Players
        {
            get { return players; }
            set { players = value; }
        }

        public SimSpeciesArraySaveStruct Species
        {
            get { return species; }
            set { species = value; }
        }

        public NonComplexArraySaveStruct<SimSystemSaveStruct> Systems
        {
            get { return systems; }
            set { systems = value; }
        }

        public SimNodeGrid2 Ndgr2
        {
            get { return ndgr2; }
            set { ndgr2 = value; }
        }

        public SimTradeManager Trdmgr
        {
            get { return trdmgr; }
            set { trdmgr = value; }
        }

        public SimSpyManager Spymgr
        {
            get { return spymgr; }
            set { spymgr = value; }
        }

        public NonComplexArraySaveStruct<SimFleet> Flt
        {
            get { return flt; }
            set { flt = value; }
        }

        public NonComplexArraySaveStruct<Int32SaveStruct> NumActs
        {
            get { return acts; }
            set { acts = value; }
        }

        public SimSvSctOb SvSctOb
        {
            get { return svSctOb; }
            set { svSctOb = value; }
        }

        public Int32SaveStruct Zdsc
        {
            get { return zdsc; }
            set { zdsc = value; }
        }

        public Int32SaveStruct Zdsi
        {
            get { return zdsi; }
            set { zdsi = value; }
        }

        public Int32SaveStruct Zdst
        {
            get { return zdst; }
            set { zdst = value; }
        }
        #endregion

        /// <summary>Default constructor</summary>
        public SimSaveStruct() : base()
        {
            this.keyPath = new StringSaveStruct();
            this.nMsz = new Int32SaveStruct();
            this.nMlc = new Int32SaveStruct();
            this.nMnx = new Int32SaveStruct();
            this.playerIds = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.designIds = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.systemIds = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.fleetIds = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.shipIds = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.tradeIds = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.modCount = new Int32SaveStruct();
            this.frame = new Int32SaveStruct();
            this.gameId = new Int32SaveStruct();
            this.attribute = new AttributeSaveStruct();
            this.rng = new RngSaveStruct();
            this.gameName = new StringSaveStruct();
            this.map = new Int32SaveStruct();
            this.incMod = new Int32SaveStruct();
            this.resMod = new Int32SaveStruct();
            this.enAl = new Int32SaveStruct();
            this.enTm = new Int32SaveStruct();
            this.gOTurn = new Int32SaveStruct();
            this.gOWinPly = new NestedInt32SaveStruct();
            this.npcm = new Int32SaveStruct();
            this.npco = new Int32SaveStruct();
            this.npci = new Int32SaveStruct();
            this.npcv = new Int32SaveStruct();
            this.npca = new Int32SaveStruct();
            this.szad = new Int32SaveStruct();
            this.rsad = new Int32SaveStruct();
            this.suad = new Int32SaveStruct();
            this.sprjs = new ComplexArraySaveStruct<ResearchSaveStruct>();
            this.randEncAdjustment = new FloatSaveStruct();
            this.cmbtid = new Int32SaveStruct();
            this.turnstats = new ComplexArraySaveStruct<TurnPly>();
            this.creps = new NonComplexArraySaveStruct<SimCrepSaveStruct>();
            this.ninv = new Int32SaveStruct();
            this.allExc1 = new Int32SaveStruct();
            this.allExc2 = new Int32SaveStruct();
            this.allExcCF = new Int32SaveStruct();
            this.players = new NonComplexArraySaveStruct<SimPlayerSaveStruct>();
            this.species = new SimSpeciesArraySaveStruct();
            this.systems = new NonComplexArraySaveStruct<SimSystemSaveStruct>();
            this.ndgr2 = new SimNodeGrid2();
            this.trdmgr = new SimTradeManager();
            this.spymgr = new SimSpyManager();
            this.flt = new NonComplexArraySaveStruct<SimFleet>();
            this.acts = new NonComplexArraySaveStruct<Int32SaveStruct>();
            this.svSctOb = new SimSvSctOb();
            this.zdsc = new Int32SaveStruct();
            this.zdsi = null;
            this.zdst = null;
        }

        /// <summary>
        ///     Populates the body (additional members from the base type) of the data structure from the
        ///     incoming stream by reading expected values.
        /// </summary>
        /// <param name="Data">Stream of binary data to read from</param>
        protected override void ReadBodyFromStream(Stream Data)
        {
            this.keyPath.ReadFromStream(Data);
            this.nMsz.ReadFromStream(Data);
            this.nMlc.ReadFromStream(Data);
            this.nMnx.ReadFromStream(Data);
            this.playerIds.ReadFromStream(Data);
            this.designIds.ReadFromStream(Data);
            this.systemIds.ReadFromStream(Data);
            this.fleetIds.ReadFromStream(Data);
            this.shipIds.ReadFromStream(Data);
            this.tradeIds.ReadFromStream(Data);
            this.modCount.ReadFromStream(Data);
            this.frame.ReadFromStream(Data);
            this.gameId.ReadFromStream(Data);
            this.attribute.ReadFromStream(Data);
            this.rng.ReadFromStream(Data);
            this.gameName.ReadFromStream(Data);
            this.map.ReadFromStream(Data);
            this.incMod.ReadFromStream(Data);
            this.resMod.ReadFromStream(Data);
            this.enAl.ReadFromStream(Data);
            this.enTm.ReadFromStream(Data);
            this.gOTurn.ReadFromStream(Data);
            this.gOWinPly.ReadFromStream(Data);
            this.npcm.ReadFromStream(Data);
            this.npco.ReadFromStream(Data);
            this.npci.ReadFromStream(Data);
            this.npcv.ReadFromStream(Data);
            this.npca.ReadFromStream(Data);
            this.szad.ReadFromStream(Data);
            this.rsad.ReadFromStream(Data);
            this.suad.ReadFromStream(Data);
            this.sprjs.ReadFromStream(Data);
            this.randEncAdjustment.ReadFromStream(Data);
            this.cmbtid.ReadFromStream(Data);
            this.turnstats.ReadFromStream(Data);
            this.creps.ReadFromStream(Data);
            this.ninv.ReadFromStream(Data);
            this.allExc1.ReadFromStream(Data);
            this.allExc2.ReadFromStream(Data);
            this.allExcCF.ReadFromStream(Data);
            this.players.ReadFromStream(Data);
            this.species.ReadFromStream(Data);
            this.systems.ReadFromStream(Data);
            this.ndgr2.ReadFromStream(Data);
            this.trdmgr.ReadFromStream(Data);
            this.spymgr.ReadFromStream(Data);
            this.flt.ReadFromStream(Data);
            this.acts.ReadFromStream(Data);
            this.svSctOb.ReadFromStream(Data);
            this.zdsc.ReadFromStream(Data);

            if (this.zdsc.Value == 1)
            {
                this.zdsi = new Int32SaveStruct();
                this.zdst = new Int32SaveStruct();
                this.zdsi.ReadFromStream(Data);
                this.zdst.ReadFromStream(Data);
            }
        }

        /// <summary>Writes the body (additional members from the base type) of the data structure to the destination stream.</summary>
        /// <param name="Destination">Destination stream to write to. Should be writable.</param>
        protected override void WriteBodyToStream(Stream Destination)
        {
            this.keyPath.WriteToStream(Destination);
            this.nMsz.WriteToStream(Destination);
            this.nMlc.WriteToStream(Destination);
            this.nMnx.WriteToStream(Destination);
            this.playerIds.WriteToStream(Destination);
            this.designIds.WriteToStream(Destination);
            this.systemIds.WriteToStream(Destination);
            this.fleetIds.WriteToStream(Destination);
            this.shipIds.WriteToStream(Destination);
            this.tradeIds.WriteToStream(Destination);
            this.modCount.WriteToStream(Destination);
            this.frame.WriteToStream(Destination);
            this.gameId.WriteToStream(Destination);
            this.attribute.WriteToStream(Destination);
            this.rng.WriteToStream(Destination);
            this.gameName.WriteToStream(Destination);
            this.map.WriteToStream(Destination);
            this.incMod.WriteToStream(Destination);
            this.resMod.WriteToStream(Destination);
            this.enAl.WriteToStream(Destination);
            this.enTm.WriteToStream(Destination);
            this.gOTurn.WriteToStream(Destination);
            this.gOWinPly.WriteToStream(Destination);
            this.npcm.WriteToStream(Destination);
            this.npco.WriteToStream(Destination);
            this.npci.WriteToStream(Destination);
            this.npcv.WriteToStream(Destination);
            this.npca.WriteToStream(Destination);
            this.szad.WriteToStream(Destination);
            this.rsad.WriteToStream(Destination);
            this.suad.WriteToStream(Destination);
            this.sprjs.WriteToStream(Destination);
            this.randEncAdjustment.WriteToStream(Destination);
            this.cmbtid.WriteToStream(Destination);
            this.turnstats.WriteToStream(Destination);
            this.creps.WriteToStream(Destination);
            this.ninv.WriteToStream(Destination);
            this.allExc1.WriteToStream(Destination);
            this.allExc2.WriteToStream(Destination);
            this.allExcCF.WriteToStream(Destination);
            this.players.WriteToStream(Destination);
            this.species.WriteToStream(Destination);
            this.systems.WriteToStream(Destination);
            this.ndgr2.WriteToStream(Destination);
            this.trdmgr.WriteToStream(Destination);
            this.spymgr.WriteToStream(Destination);
            this.flt.WriteToStream(Destination);
            this.acts.WriteToStream(Destination);
            this.svSctOb.WriteToStream(Destination);
            this.zdsc.WriteToStream(Destination);

            if (this.zdsc.Value == 1)
            {
                this.zdsi.WriteToStream(Destination);
                this.zdst.WriteToStream(Destination);
            }
        }
    }
}