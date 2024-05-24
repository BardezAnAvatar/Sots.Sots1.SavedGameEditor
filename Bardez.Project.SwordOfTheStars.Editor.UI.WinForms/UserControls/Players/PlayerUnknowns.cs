using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.UserControl;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerUnknowns : DisplayUserControl
    {
        private SimPlayerDetailsSaveStruct _playerDetails;

        public PlayerUnknowns()
        {
            InitializeComponent();
        }

        public void SetPlayerStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            _playerDetails = playerDetails;
            LoadFromStruct();
        }

        public void LoadFromStruct()
        {
            textBoxMaxOh.Text          = _playerDetails.MaxOH.Value.ToString();
            textBoxTrm.Text            = _playerDetails.Trm.Value.ToString();
            textBoxTrp.Text            = _playerDetails.Trp.Value.ToString();
            textBoxTra.Text            = _playerDetails.Tra.Value.ToString();
            checkBoxAmine.Checked      = _playerDetails.AMine.BooleanValue;
            textBoxMinPure.Text        = _playerDetails.MinPure.Value.ToString();
            textBoxMinRate.Text        = _playerDetails.MinRate.Value.ToString();
            textBoxNgts.Text           = _playerDetails.Ngts.Value.ToString();
            textBoxPrGtTrf.Text        = _playerDetails.PrGtTrf.Value.ToString();
            textBoxGTraf.Text          = _playerDetails.GTraf.Value.ToString();
            textBoxCstR.Text           = _playerDetails.CstR.Value.ToString();
            textBoxCstE.Text           = _playerDetails.CstE.Value.ToString();
            textBoxCstT.Text           = _playerDetails.CstT.Value.ToString();
            textBoxMaint.Text          = _playerDetails.Maint.Value.ToString();
            textBoxShrm.Text           = _playerDetails.Shrm.Value.ToString();
            textBoxStatus.Text         = _playerDetails.Status.Value.ToString();
            textBoxElim.Text           = _playerDetails.Elim.Value.ToString();
            checkBoxReqCl.Checked      = _playerDetails.ReqCL.BooleanValue;
            textBoxNpTrak.Text         = _playerDetails.NpTrak.Value.ToString();
            textBoxHasDisc.Text        = _playerDetails.HasDisc.Value.ToString();
            textBoxHasDiscSp.Text      = _playerDetails.HasDiscSp.Value.ToString();
            textBoxHasDiscCl.Text      = _playerDetails.HasDiscCl.Value.ToString();
            textBoxHasEnc.Text         = _playerDetails.HasEnc.Value.ToString();
            textBoxHasEng.Text         = _playerDetails.HasEng.Value.ToString();
            textBoxFngNum.Text         = _playerDetails.FngNum.Value.Value.ToString();
            textBoxPvMa.Text           = _playerDetails.PvMA.Value.ToString();
            textBoxAibn.Text           = _playerDetails.AibN.Value.ToString();
            checkBoxHgs.Checked        = _playerDetails.Hgs.BooleanValue;
            checkBoxHadvs.Checked      = _playerDetails.Hadvs.BooleanValue;
            checkBoxHarcc.Checked      = _playerDetails.Harcc.BooleanValue;
            checkBoxCnVItl.Checked     = _playerDetails.CnVItl.BooleanValue;
            textBoxPddm.Text           = _playerDetails.Pddm.Value.ToString();
            textBoxBankTrn.Text        = _playerDetails.BankTrn.Value.ToString();
            textBoxBankPr.Text         = _playerDetails.BankPr.Value.ToString();
            textBoxBankEl.Text         = _playerDetails.BankEl.Value.ToString();
            textBoxPlcy.Text           = _playerDetails.Plcy.Value.ToString();
            textBoxLret.Text           = _playerDetails.Lret.Value.ToString();
            textBoxNmeid.Text          = _playerDetails.Nmeid.Value.ToString();
            checkBoxCdp.Checked        = _playerDetails.Cdp.BooleanValue;
            textBoxAidf.Text           = _playerDetails.Aidf.Value.ToString();
            checkBoxSrn.Checked        = _playerDetails.Srn.BooleanValue;
            textBoxSrcTo.Text          = _playerDetails.SrcTo.Value.ToString();
            textBoxLboid.Text          = _playerDetails.Lboid.Value.ToString();
            textBoxLcid2.Text          = _playerDetails.Lcid2.Value.ToString();
            textBoxResTnm.Text         = _playerDetails.ResTnm.Value.CharacterString;
            checkBoxResErrRoll.Checked = _playerDetails.ResErrRoll.BooleanValue;
            checkBoxCta.Checked        = _playerDetails.Cta.BooleanValue;
            textBoxNexp.Text           = _playerDetails.Nexp.Value.ToString();
            textBoxNWeapXcl.Text       = _playerDetails.NWeapXcl.Value.ToString();
            textBoxNdeflay.Text        = _playerDetails.Ndeflay.Value.ToString();
            textBoxRdtc.Text           = _playerDetails.Rdtc.Value.ToString();
            textBoxTnc.Text            = _playerDetails.Tnc.Value.ToString();
        }
    }
}
