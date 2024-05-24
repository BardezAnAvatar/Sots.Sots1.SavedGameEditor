using System;
using System.Drawing;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.UserControl;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerDetails : DisplayUserControl
    {
        protected SimPlayerSaveStruct player;

        public PlayerDetails() : base()
        {
            InitializeComponent();
            this.player = null;
        }

        public void LoadFromStruct(SimPlayerSaveStruct Player)
        {
            this.player = Player;
            this.LoadFromStruct();
        }

        public void LoadFromStruct()
        {
            this.textBoxPlayerId.Text				= this.player.PlayerId.Value.ToString();
            this.textBoxPlayerIndex.Text			= this.player.Details.PlayerIndex.Value.ToString();
            this.textBoxName.Text					= this.player.Details.PlayerName.Value.CharacterString;
            this.textBoxSpecies.Text				= this.player.Details.Species.Value.ToString();
            this.textBoxHomeSystem.Text				= this.player.Details.HomeSystem.Value.ToString();
            this.buttonColor.BackColor				= GetColorFromPlayer(this.player.Details);
            this.textBoxBadge.Text					= this.player.Details.Badge.Value.CharacterString;
            this.textBoxAvatar.Text					= this.player.Details.Avatar.Value.CharacterString;
            this.textBoxTeam.Text					= this.player.Details.Team.Value.ToString();
            this.textBoxIdealSuit.Text				= this.player.Details.IdealSuit.Value.ToString();
            this.textBoxSuitTol.Text				= this.player.Details.SuitTolerance.Value.ToString();
            this.textBoxSav.Text					= this.player.Details.Sav.Value.ToString();
            this.textBoxResRate.Text				= this.player.Details.ResRate.Value.ToString();
            this.textBoxResMod.Text					= this.player.Details.ResModifier.Value.ToString();
            this.textBoxResScl.Text					= this.player.Details.ResScl.Value.ToString();
            this.textBoxIndOutMod.Text				= this.player.Details.OutMod.Value.ToString();
            this.textBoxIndOutReb.Text				= this.player.Details.RebOutMod.Value.ToString();
            this.textBoxIndOutScl.Text				= this.player.Details.ScOutMod.Value.ToString();
            this.textBoxIncMod.Text					= this.player.Details.IncMod.Value.ToString();
            this.textBoxPopMod.Text					= this.player.Details.PopMod.Value.ToString();
            this.textBoxTerrMod.Text				= this.player.Details.TerraMod.Value.ToString();
            this.checkBoxNpc.Checked				= this.player.Details.Npc.BooleanValue;
            this.checkBoxRebAi.Checked				= this.player.Details.RebAi.BooleanValue;
            this.textBoxHasVac.Text					= this.player.Details.HasVac.Value.ToString();
            this.textBoxHasImm.Text					= this.player.Details.HasImm.Value.ToString();
            this.checkBoxCnTrd.Checked				= this.player.Details.CnTrd.BooleanValue;
            this.checkBoxCnRad.Checked				= this.player.Details.CnRad.BooleanValue;
            this.textBoxNextPrjId.Text				= this.player.Details.NextPrjId.Value.ToString();
            this.checkBoxHasAiRebellion.Checked		= this.player.Details.HasAiRebellion.BooleanValue;
            this.textBoxPvSav.Text					= this.player.Details.PvSav.Value.ToString();

            /****************
            *   Unknowns    *
            ****************/
            this.textBoxMaxOh.Text					= this.player.Details.MaxOH.Value.ToString();
            this.textBoxTrm.Text					= this.player.Details.Trm.Value.ToString();
            this.textBoxTrp.Text					= this.player.Details.Trp.Value.ToString();
            this.textBoxTra.Text					= this.player.Details.Tra.Value.ToString();
            this.checkBoxAmine.Checked				= this.player.Details.AMine.BooleanValue;
            this.textBoxMinPure.Text				= this.player.Details.MinPure.Value.ToString();
            this.textBoxMinRate.Text				= this.player.Details.MinRate.Value.ToString();
            this.textBoxNgts.Text					= this.player.Details.Ngts.Value.ToString();
            this.textBoxPrGtTrf.Text				= this.player.Details.PrGtTrf.Value.ToString();
            this.textBoxGTraf.Text					= this.player.Details.GTraf.Value.ToString();
            this.textBoxCstR.Text					= this.player.Details.CstR.Value.ToString();
            this.textBoxCstE.Text					= this.player.Details.CstE.Value.ToString();
            this.textBoxCstT.Text					= this.player.Details.CstT.Value.ToString();
            this.textBoxMaint.Text					= this.player.Details.Maint.Value.ToString();
            this.textBoxShrm.Text					= this.player.Details.Shrm.Value.ToString();
            this.textBoxStatus.Text					= this.player.Details.Status.Value.ToString();
            this.textBoxElim.Text					= this.player.Details.Elim.Value.ToString();
            this.checkBoxReqCl.Checked				= this.player.Details.ReqCL.BooleanValue;
            this.textBoxNpTrak.Text					= this.player.Details.NpTrak.Value.ToString();
            this.textBoxHasDisc.Text				= this.player.Details.HasDisc.Value.ToString();
            this.textBoxHasDiscSp.Text				= this.player.Details.HasDiscSp.Value.ToString();
            this.textBoxHasDiscCl.Text				= this.player.Details.HasDiscCl.Value.ToString();
            this.textBoxHasEnc.Text					= this.player.Details.HasEnc.Value.ToString();
            this.textBoxHasEng.Text					= this.player.Details.HasEng.Value.ToString();
            this.textBoxFngNum.Text					= this.player.Details.FngNum.Value.Value.ToString();
            this.textBoxPvMa.Text					= this.player.Details.PvMA.Value.ToString();
            this.textBoxAibn.Text					= this.player.Details.AibN.Value.ToString();
            this.checkBoxHgs.Checked				= this.player.Details.Hgs.BooleanValue;
            this.checkBoxHadvs.Checked				= this.player.Details.Hadvs.BooleanValue;
            this.checkBoxHarcc.Checked				= this.player.Details.Harcc.BooleanValue;
            this.checkBoxCnVItl.Checked				= this.player.Details.CnVItl.BooleanValue;
            this.textBoxPddm.Text					= this.player.Details.Pddm.Value.ToString();
            this.textBoxBankTrn.Text				= this.player.Details.BankTrn.Value.ToString();
            this.textBoxBankPr.Text					= this.player.Details.BankPr.Value.ToString();
            this.textBoxBankEl.Text					= this.player.Details.BankEl.Value.ToString();
            this.textBoxPlcy.Text					= this.player.Details.Plcy.Value.ToString();
            this.textBoxPswd.Text					= this.player.Details.Pswd.Value.ToString();
            this.textBoxLret.Text					= this.player.Details.Lret.Value.ToString();
            this.textBoxNmeid.Text					= this.player.Details.Nmeid.Value.ToString();
            this.checkBoxCdp.Checked				= this.player.Details.Cdp.BooleanValue;
            this.textBoxAidf.Text					= this.player.Details.Aidf.Value.ToString();
            this.checkBoxSrn.Checked				= this.player.Details.Srn.BooleanValue;
            this.textBoxSrcTo.Text					= this.player.Details.SrcTo.Value.ToString();
            this.textBoxLboid.Text					= this.player.Details.Lboid.Value.ToString();
            this.textBoxLcid2.Text					= this.player.Details.Lcid2.Value.ToString();
            this.textBoxResTnm.Text					= this.player.Details.ResTnm.Value.CharacterString;
            this.checkBoxResErrRoll.Checked			= this.player.Details.ResErrRoll.BooleanValue;
            this.checkBoxCta.Checked				= this.player.Details.Cta.BooleanValue;
            this.textBoxNexp.Text					= this.player.Details.Nexp.Value.ToString();
            this.textBoxNWeapXcl.Text				= this.player.Details.NWeapXcl.Value.ToString();
            this.textBoxNdeflay.Text				= this.player.Details.Ndeflay.Value.ToString();
            this.textBoxRdtc.Text					= this.player.Details.Rdtc.Value.ToString();
            this.textBoxTnc.Text					= this.player.Details.Tnc.Value.ToString();
        }



        protected Color GetColorFromPlayer(SimPlayerDetailsSaveStruct Player)
        {
            Color retColor;

            if (Player.ColorId.ColorIndex.Value == -1)
            {
                retColor = Color.FromArgb(255,
                    Player.ColorId.Rgb.R.Value > 0 ? Player.ColorId.Rgb.R.Value : 0,
                    Player.ColorId.Rgb.G.Value > 0 ? Player.ColorId.Rgb.G.Value : 0,
                    Player.ColorId.Rgb.B.Value > 0 ? Player.ColorId.Rgb.B.Value : 0
                );
            }
            else
            {
                //01 - Red
                //02 - Yellow
                //03 - Blue
                //04 - Pink/Mangeta
                //05 - Orange
                //06 - Green
                //07 - Aqua
                //08 - Gray
                //09 - Dark Green
                //10 - Purple
                switch (Player.ColorId.ColorIndex.Value)
                {
                    case 1:
                        retColor = Color.Red;
                        break;
                    case 2:
                        retColor = Color.Yellow;
                        break;
                    case 3:
                        retColor = Color.Blue;
                        break;
                    case 4:
                        retColor = Color.Magenta;
                        break;
                    case 5:
                        retColor = Color.Orange;
                        break;
                    case 6:
                        retColor = Color.Green;
                        break;
                    case 7:
                        retColor = Color.Aqua;
                        break;
                    case 8:
                        retColor = Color.Gray;
                        break;
                    case 9:
                        retColor = Color.DarkGreen;
                        break;
                    case 10:
                        retColor = Color.Purple;
                        break;
                    default:
                        retColor = Color.Pink;
                        break;
                }
            }
            
            return retColor;
        }
        
        protected Byte RgbFloatToByte(Single FloatVal)
        {
            return Convert.ToByte(FloatVal * (Single)255);
        }

        protected Single RgbByteToFloat(Byte ByteVal)
        {
            return Convert.ToSingle(ByteVal) / Convert.ToSingle(255);
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            this.colorDialogColor.Color = this.buttonColor.BackColor;
            this.colorDialogColor.ShowDialog();
            this.buttonColor.BackColor = this.colorDialogColor.Color;
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            //this.textBoxPlayerId.Enabled =          !ReadOnlyFlag;
            //this.textBoxPlayerIndex.Enabled =       !ReadOnlyFlag;
            this.textBoxName.Enabled =              !ReadOnlyFlag;
            //this.textBoxSpecies.Enabled =           !ReadOnlyFlag;
            this.textBoxHomeSystem.Enabled =        !ReadOnlyFlag;
            this.buttonColor.Enabled =              !ReadOnlyFlag;
            this.textBoxBadge.Enabled =             !ReadOnlyFlag;
            this.textBoxAvatar.Enabled =            !ReadOnlyFlag;
            this.textBoxTeam.Enabled =              !ReadOnlyFlag;
            this.textBoxIdealSuit.Enabled =         !ReadOnlyFlag;
            this.textBoxSuitTol.Enabled =           !ReadOnlyFlag;
            this.textBoxSav.Enabled =               !ReadOnlyFlag;
            this.textBoxResRate.Enabled =           !ReadOnlyFlag;
            this.textBoxResMod.Enabled =            !ReadOnlyFlag;
            this.textBoxResScl.Enabled =            !ReadOnlyFlag;
            this.textBoxIndOutMod.Enabled =         !ReadOnlyFlag;
            this.textBoxIndOutReb.Enabled =         !ReadOnlyFlag;
            this.textBoxIndOutScl.Enabled =         !ReadOnlyFlag;
            this.textBoxIncMod.Enabled =            !ReadOnlyFlag;
            this.textBoxPopMod.Enabled =            !ReadOnlyFlag;
            this.textBoxTerrMod.Enabled =           !ReadOnlyFlag;
            this.checkBoxNpc.Enabled =              !ReadOnlyFlag;
            this.checkBoxRebAi.Enabled =            !ReadOnlyFlag;
            this.textBoxHasVac.Enabled =            !ReadOnlyFlag;
            this.textBoxHasImm.Enabled =            !ReadOnlyFlag;
            this.checkBoxCnTrd.Enabled =            !ReadOnlyFlag;
            this.checkBoxCnRad.Enabled =            !ReadOnlyFlag;
            this.checkBoxHasAiRebellion.Enabled =   !ReadOnlyFlag;
        }



        protected void UpdateColorForPlayer(Color SelectedColor)
        {
            SimPlayerColorSaveStruct newColor = this.player.Details.ColorId;
            RgbColorInt32 rgb = newColor.Rgb;
            newColor.Rgb = null;    //discard 


            //01 - Red
            if (SelectedColor == Color.Red)
                newColor.ColorIndex.Value = 1;
            //02 - Yellow
            else if (SelectedColor == Color.Yellow)
                newColor.ColorIndex.Value = 2;
            //03 - Blue
            else if (SelectedColor == Color.Blue)
                newColor.ColorIndex.Value = 3;
            //04 - Pink/Mangeta
            else if (SelectedColor == Color.Magenta)
                newColor.ColorIndex.Value = 4;
            //05 - Orange
            else if (SelectedColor == Color.Orange)
                newColor.ColorIndex.Value = 5;
            //06 - Green
            else if (SelectedColor == Color.Green)
                newColor.ColorIndex.Value = 6;
            //07 - Aqua
            else if (SelectedColor == Color.Aqua)
                newColor.ColorIndex.Value = 7;
            //08 - Gray
            else if (SelectedColor == Color.Gray)
                newColor.ColorIndex.Value = 8;
            //09 - Dark Green
            else if (SelectedColor == Color.DarkGreen)
                newColor.ColorIndex.Value = 9;
            //10 - Purple
            else if (SelectedColor == Color.Purple)
                newColor.ColorIndex.Value = 10;
            else
            {
                newColor.ColorIndex.Value = -1;

                if (rgb == null)
                    rgb = new RgbColorInt32();

                rgb.R.Value = SelectedColor.R;
                rgb.G.Value = SelectedColor.G;
                rgb.B.Value = SelectedColor.B;

                newColor.Rgb = rgb;     //restore or new
            }
        }

        public void UpdateStruct()
        {
            this.UpdateColorForPlayer(this.buttonColor.BackColor);                                                                                                       
            //this.player.Details.PlayerIndex.Value                   = Int32.Parse(this.textBoxPlayerIndex.Text);
            this.player.Details.PlayerName.Value.CharacterString    = this.textBoxName.Text;
            //this.player.Details.Species.Value                       = Int32.Parse(this.textBoxSpecies.Text);
            this.player.Details.HomeSystem.Value                    = Int32.Parse(this.textBoxHomeSystem.Text);
            this.player.Details.Badge.Value.CharacterString         = this.textBoxBadge.Text;
            this.player.Details.Avatar.Value.CharacterString        = this.textBoxAvatar.Text;
            this.player.Details.Team.Value                          = Int32.Parse(this.textBoxTeam.Text);
            this.player.Details.IdealSuit.Value                     = Single.Parse(this.textBoxIdealSuit.Text);
            this.player.Details.SuitTolerance.Value                 = Single.Parse(this.textBoxSuitTol.Text);
            this.player.Details.Sav.Value                           = Int32.Parse(this.textBoxSav.Text);
            this.player.Details.ResRate.Value                       = Single.Parse(this.textBoxResRate.Text);
            this.player.Details.ResModifier.Value                   = Single.Parse(this.textBoxResMod.Text);
            this.player.Details.ResScl.Value                        = Single.Parse(this.textBoxResScl.Text);
            this.player.Details.OutMod.Value                        = Single.Parse(this.textBoxIndOutMod.Text);
            this.player.Details.RebOutMod.Value                     = Single.Parse(this.textBoxIndOutReb.Text);
            this.player.Details.ScOutMod.Value                      = Single.Parse(this.textBoxIndOutScl.Text);
            this.player.Details.IncMod.Value                        = Single.Parse(this.textBoxIncMod.Text);
            this.player.Details.PopMod.Value                        = Single.Parse(this.textBoxPopMod.Text);
            this.player.Details.TerraMod.Value                      = Single.Parse(this.textBoxTerrMod.Text);
            this.player.Details.Npc.BooleanValue                    = this.checkBoxNpc.Checked;
            this.player.Details.RebAi.BooleanValue                  = this.checkBoxRebAi.Checked;
            this.player.Details.HasVac.Value                        = Int32.Parse(this.textBoxHasVac.Text);
            this.player.Details.HasImm.Value                        = Int32.Parse(this.textBoxHasImm.Text);
            this.player.Details.CnTrd.BooleanValue                  = this.checkBoxCnTrd.Checked;
            this.player.Details.CnRad.BooleanValue                  = this.checkBoxCnRad.Checked;
            this.player.Details.NextPrjId.Value                     = Int32.Parse(this.textBoxNextPrjId.Text);
            this.player.Details.HasAiRebellion.BooleanValue         = this.checkBoxHasAiRebellion.Checked;
            this.player.Details.PvSav.Value                         = Int32.Parse(this.textBoxPvSav.Text);

            /****************
            *   Unknowns    *
            ****************/
            /*
            this.player.Details.MaxOH.Value                         = Single.Parse(this.textBoxMaxOh.Text);
            this.player.Details.Trm.Value                           = Int32.Parse(this.textBoxTrm.Text);
            this.player.Details.Trp.Value                           = Int32.Parse(this.textBoxTrp.Text);
            this.player.Details.Tra.Value                           = Int32.Parse(this.textBoxTra.Text);
            this.player.Details.AMine.BooleanValue                  = this.checkBoxAmine.Checked;
            this.player.Details.MinPure.Value                       = Single.Parse(this.textBoxMinPure.Text);
            this.player.Details.MinRate.Value                       = Single.Parse(this.textBoxMinRate.Text);
            this.player.Details.Ngts.Value                          = Int32.Parse(this.textBoxNgts.Text);
            this.player.Details.PrGtTrf.Value                       = Int32.Parse(this.textBoxPrGtTrf.Text);
            this.player.Details.GTraf.Value                         = Int32.Parse(this.textBoxGTraf.Text);
            this.player.Details.CstR.Value                          = Int32.Parse(this.textBoxCstR.Text);
            this.player.Details.CstE.Value                          = Int32.Parse(this.textBoxCstE.Text);
            this.player.Details.CstT.Value                          = Int32.Parse(this.textBoxCstT.Text);
            this.player.Details.Maint.Value                         = Int32.Parse(this.textBoxMaint.Text);
            this.player.Details.Shrm.Value                          = Int32.Parse(this.textBoxShrm.Text);
            this.player.Details.Status.Value                        = Int32.Parse(this.textBoxStatus.Text);
            this.player.Details.Elim.Value                          = Int32.Parse(this.textBoxElim.Text);
            this.player.Details.ReqCL.BooleanValue                  = this.checkBoxReqCl.Checked;
            this.player.Details.NpTrak.Value                        = Int32.Parse(this.textBoxNpTrak.Text);
            this.player.Details.HasDisc.Value                       = Int32.Parse(this.textBoxHasDisc.Text);
            this.player.Details.HasDiscSp.Value                     = Int32.Parse(this.textBoxHasDiscSp.Text);
            this.player.Details.HasDiscCl.Value                     = Int32.Parse(this.textBoxHasDiscCl.Text);
            this.player.Details.HasEnc.Value                        = Int32.Parse(this.textBoxHasEnc.Text);
            this.player.Details.HasEng.Value                        = Int32.Parse(this.textBoxHasEng.Text);
            this.player.Details.FngNum.Value.Value                  = Int32.Parse(this.textBoxFngNum.Text);
            this.player.Details.PvMA.Value                          = Int32.Parse(this.textBoxPvMa.Text);
            this.player.Details.AibN.Value                          = Int32.Parse(this.textBoxAibn.Text);
            this.player.Details.Hgs.BooleanValue                    = this.checkBoxHgs.Checked;
            this.player.Details.Hadvs.BooleanValue                  = this.checkBoxHadvs.Checked;
            this.player.Details.Harcc.BooleanValue                  = this.checkBoxHarcc.Checked;
            this.player.Details.CnVItl.BooleanValue                 = this.checkBoxCnVItl.Checked;
            this.player.Details.Pddm.Value                          = Single.Parse(this.textBoxPddm.Text);
            this.player.Details.BankTrn.Value                       = Int32.Parse(this.textBoxBankTrn.Text);
            this.player.Details.BankPr.Value                        = Int32.Parse(this.textBoxBankPr.Text);
            this.player.Details.BankEl.Value                        = Int32.Parse(this.textBoxBankEl.Text);
            this.player.Details.Plcy.Value                          = Int32.Parse(this.textBoxPlcy.Text);
            this.player.Details.Pswd.Value                          = Int32.Parse(this.textBoxPswd.Text);
            this.player.Details.Lret.Value                          = Int32.Parse(this.textBoxLret.Text);
            this.player.Details.Nmeid.Value                         = Int32.Parse(this.textBoxNmeid.Text);
            this.player.Details.Cdp.BooleanValue                    = this.checkBoxCdp.Checked;
            this.player.Details.Aidf.Value                          = Int32.Parse(this.textBoxAidf.Text);
            this.player.Details.Srn.BooleanValue                    = this.checkBoxSrn.Checked;
            this.player.Details.SrcTo.Value                         = Int32.Parse(this.textBoxSrcTo.Text);
            this.player.Details.Lboid.Value                         = Int32.Parse(this.textBoxLboid.Text);
            this.player.Details.Lcid2.Value                         = Int32.Parse(this.textBoxLcid2.Text);
            this.player.Details.ResTnm.Value.CharacterString        = this.textBoxResTnm.Text;
            this.player.Details.ResErrRoll.BooleanValue             = this.checkBoxResErrRoll.Checked;
            this.player.Details.Cta.BooleanValue                    = this.checkBoxCta.Checked;
            this.player.Details.Nexp.Value                          = Int32.Parse(this.textBoxNexp.Text);
            this.player.Details.NWeapXcl.Value                      = Int32.Parse(this.textBoxNWeapXcl.Text);
            this.player.Details.Ndeflay.Value                       = Int32.Parse(this.textBoxNdeflay.Text);
            this.player.Details.Rdtc.Value                          = Int32.Parse(this.textBoxRdtc.Text);
            this.player.Details.Tnc.Value                           = Int32.Parse(this.textBoxTnc.Text);
            */
        }
    }
}