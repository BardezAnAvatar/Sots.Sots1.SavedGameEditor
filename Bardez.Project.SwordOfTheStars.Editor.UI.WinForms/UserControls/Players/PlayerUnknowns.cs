using System;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerUnknowns : DisplayUserControl
    {
        public PlayerUnknowns()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            textBoxMaxOh.Text          = playerDetails.MaxOH.Value.ToString();
            textBoxTrm.Text            = playerDetails.Trm.Value.ToString();
            textBoxTrp.Text            = playerDetails.Trp.Value.ToString();
            textBoxTra.Text            = playerDetails.Tra.Value.ToString();
            checkBoxAmine.Checked      = playerDetails.AMine.BooleanValue;
            textBoxMinPure.Text        = playerDetails.MinPure.Value.ToString();
            textBoxMinRate.Text        = playerDetails.MinRate.Value.ToString();
            textBoxNgts.Text           = playerDetails.Ngts.Value.ToString();
            textBoxPrGtTrf.Text        = playerDetails.PrGtTrf.Value.ToString();
            textBoxGTraf.Text          = playerDetails.GTraf.Value.ToString();
            textBoxCstR.Text           = playerDetails.CstR.Value.ToString();
            textBoxCstE.Text           = playerDetails.CstE.Value.ToString();
            textBoxCstT.Text           = playerDetails.CstT.Value.ToString();
            textBoxMaint.Text          = playerDetails.Maint.Value.ToString();
            textBoxShrm.Text           = playerDetails.Shrm.Value.ToString();
            textBoxStatus.Text         = playerDetails.Status.Value.ToString();
            textBoxElim.Text           = playerDetails.Elim.Value.ToString();
            checkBoxReqCl.Checked      = playerDetails.ReqCL.BooleanValue;
            textBoxNpTrak.Text         = playerDetails.NpTrak.Value.ToString();
            textBoxHasDisc.Text        = playerDetails.HasDisc.Value.ToString();
            textBoxHasDiscSp.Text      = playerDetails.HasDiscSp.Value.ToString();
            textBoxHasDiscCl.Text      = playerDetails.HasDiscCl.Value.ToString();
            textBoxHasEnc.Text         = playerDetails.HasEnc.Value.ToString();
            textBoxHasEng.Text         = playerDetails.HasEng.Value.ToString();
            textBoxFngNum.Text         = playerDetails.FngNum.Value.Value.ToString();
            textBoxPvMa.Text           = playerDetails.PvMA.Value.ToString();
            textBoxAibn.Text           = playerDetails.AibN.Value.ToString();
            checkBoxHgs.Checked        = playerDetails.Hgs.BooleanValue;
            checkBoxHadvs.Checked      = playerDetails.Hadvs.BooleanValue;
            checkBoxHarcc.Checked      = playerDetails.Harcc.BooleanValue;
            checkBoxCnVItl.Checked     = playerDetails.CnVItl.BooleanValue;
            textBoxPddm.Text           = playerDetails.Pddm.Value.ToString();
            textBoxBankTrn.Text        = playerDetails.BankTrn.Value.ToString();
            textBoxBankPr.Text         = playerDetails.BankPr.Value.ToString();
            textBoxBankEl.Text         = playerDetails.BankEl.Value.ToString();
            textBoxPlcy.Text           = playerDetails.Plcy.Value.ToString();
            textBoxLret.Text           = playerDetails.Lret.Value.ToString();
            textBoxNmeid.Text          = playerDetails.Nmeid.Value.ToString();
            checkBoxCdp.Checked        = playerDetails.Cdp.BooleanValue;
            textBoxAidf.Text           = playerDetails.Aidf.Value.ToString();
            checkBoxSrn.Checked        = playerDetails.Srn.BooleanValue;
            textBoxSrcTo.Text          = playerDetails.SrcTo.Value.ToString();
            textBoxLboid.Text          = playerDetails.Lboid.Value.ToString();
            textBoxLcid2.Text          = playerDetails.Lcid2.Value.ToString();
            textBoxResTnm.Text         = playerDetails.ResTnm.Value.CharacterString;
            checkBoxResErrRoll.Checked = playerDetails.ResErrRoll.BooleanValue;
            checkBoxCta.Checked        = playerDetails.Cta.BooleanValue;
            textBoxNexp.Text           = playerDetails.Nexp.Value.ToString();
            textBoxNWeapXcl.Text       = playerDetails.NWeapXcl.Value.ToString();
            textBoxNdeflay.Text        = playerDetails.Ndeflay.Value.ToString();
            textBoxRdtc.Text           = playerDetails.Rdtc.Value.ToString();
            textBoxTnc.Text            = playerDetails.Tnc.Value.ToString();
        }

        public void UpdateStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            /*
            playerDetails.MaxOH.Value                         = Single.Parse(this.textBoxMaxOh.Text);
            playerDetails.Trm.Value                           = Int32.Parse(this.textBoxTrm.Text);
            playerDetails.Trp.Value                           = Int32.Parse(this.textBoxTrp.Text);
            playerDetails.Tra.Value                           = Int32.Parse(this.textBoxTra.Text);
            playerDetails.AMine.BooleanValue                  = this.checkBoxAmine.Checked;
            playerDetails.MinPure.Value                       = Single.Parse(this.textBoxMinPure.Text);
            playerDetails.MinRate.Value                       = Single.Parse(this.textBoxMinRate.Text);
            playerDetails.Ngts.Value                          = Int32.Parse(this.textBoxNgts.Text);
            playerDetails.PrGtTrf.Value                       = Int32.Parse(this.textBoxPrGtTrf.Text);
            playerDetails.GTraf.Value                         = Int32.Parse(this.textBoxGTraf.Text);
            playerDetails.CstR.Value                          = Int32.Parse(this.textBoxCstR.Text);
            playerDetails.CstE.Value                          = Int32.Parse(this.textBoxCstE.Text);
            playerDetails.CstT.Value                          = Int32.Parse(this.textBoxCstT.Text);
            playerDetails.Maint.Value                         = Int32.Parse(this.textBoxMaint.Text);
            playerDetails.Shrm.Value                          = Int32.Parse(this.textBoxShrm.Text);
            playerDetails.Status.Value                        = Int32.Parse(this.textBoxStatus.Text);
            playerDetails.Elim.Value                          = Int32.Parse(this.textBoxElim.Text);
            playerDetails.ReqCL.BooleanValue                  = this.checkBoxReqCl.Checked;
            playerDetails.NpTrak.Value                        = Int32.Parse(this.textBoxNpTrak.Text);
            playerDetails.HasDisc.Value                       = Int32.Parse(this.textBoxHasDisc.Text);
            playerDetails.HasDiscSp.Value                     = Int32.Parse(this.textBoxHasDiscSp.Text);
            playerDetails.HasDiscCl.Value                     = Int32.Parse(this.textBoxHasDiscCl.Text);
            playerDetails.HasEnc.Value                        = Int32.Parse(this.textBoxHasEnc.Text);
            playerDetails.HasEng.Value                        = Int32.Parse(this.textBoxHasEng.Text);
            playerDetails.FngNum.Value.Value                  = Int32.Parse(this.textBoxFngNum.Text);
            playerDetails.PvMA.Value                          = Int32.Parse(this.textBoxPvMa.Text);
            playerDetails.AibN.Value                          = Int32.Parse(this.textBoxAibn.Text);
            playerDetails.Hgs.BooleanValue                    = this.checkBoxHgs.Checked;
            playerDetails.Hadvs.BooleanValue                  = this.checkBoxHadvs.Checked;
            playerDetails.Harcc.BooleanValue                  = this.checkBoxHarcc.Checked;
            playerDetails.CnVItl.BooleanValue                 = this.checkBoxCnVItl.Checked;
            playerDetails.Pddm.Value                          = Single.Parse(this.textBoxPddm.Text);
            playerDetails.BankTrn.Value                       = Int32.Parse(this.textBoxBankTrn.Text);
            playerDetails.BankPr.Value                        = Int32.Parse(this.textBoxBankPr.Text);
            playerDetails.BankEl.Value                        = Int32.Parse(this.textBoxBankEl.Text);
            playerDetails.Plcy.Value                          = Int32.Parse(this.textBoxPlcy.Text);
            playerDetails.Pswd.Value                          = Int32.Parse(this.textBoxPswd.Text);
            playerDetails.Lret.Value                          = Int32.Parse(this.textBoxLret.Text);
            playerDetails.Nmeid.Value                         = Int32.Parse(this.textBoxNmeid.Text);
            playerDetails.Cdp.BooleanValue                    = this.checkBoxCdp.Checked;
            playerDetails.Aidf.Value                          = Int32.Parse(this.textBoxAidf.Text);
            playerDetails.Srn.BooleanValue                    = this.checkBoxSrn.Checked;
            playerDetails.SrcTo.Value                         = Int32.Parse(this.textBoxSrcTo.Text);
            playerDetails.Lboid.Value                         = Int32.Parse(this.textBoxLboid.Text);
            playerDetails.Lcid2.Value                         = Int32.Parse(this.textBoxLcid2.Text);
            playerDetails.ResTnm.Value.CharacterString        = this.textBoxResTnm.Text;
            playerDetails.ResErrRoll.BooleanValue             = this.checkBoxResErrRoll.Checked;
            playerDetails.Cta.BooleanValue                    = this.checkBoxCta.Checked;
            playerDetails.Nexp.Value                          = Int32.Parse(this.textBoxNexp.Text);
            playerDetails.NWeapXcl.Value                      = Int32.Parse(this.textBoxNWeapXcl.Text);
            playerDetails.Ndeflay.Value                       = Int32.Parse(this.textBoxNdeflay.Text);
            playerDetails.Rdtc.Value                          = Int32.Parse(this.textBoxRdtc.Text);
            playerDetails.Tnc.Value                           = Int32.Parse(this.textBoxTnc.Text);
            */
        }
    }
}
