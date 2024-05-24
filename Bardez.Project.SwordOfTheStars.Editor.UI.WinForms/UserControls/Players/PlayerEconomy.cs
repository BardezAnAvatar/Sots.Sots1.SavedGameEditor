using System;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerEconomy : DisplayUserControl
    {
        public PlayerEconomy()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            textBoxSav.Text = playerDetails.Sav.Value.ToString();
            textBoxIncMod.Text = playerDetails.IncMod.Value.ToString();
            checkBoxCnTrd.Checked = playerDetails.CnTrd.BooleanValue;
            checkBoxCnRad.Checked = playerDetails.CnRad.BooleanValue;
            textBoxPvSav.Text = playerDetails.PvSav.Value.ToString();
        }

        public void PercolateReadOnlyFlag(bool readOnlyFlag)
        {
            textBoxSav.Enabled = !readOnlyFlag;
            textBoxIncMod.Enabled = !readOnlyFlag;
            checkBoxCnTrd.Enabled = !readOnlyFlag;
            checkBoxCnRad.Enabled = !readOnlyFlag;
            //textBoxPvSav is always disabled;
        }

        public void UpdateStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            playerDetails.Sav.Value = Int32.Parse(textBoxSav.Text);
            playerDetails.IncMod.Value = Single.Parse(textBoxIncMod.Text);
            playerDetails.CnTrd.BooleanValue = checkBoxCnTrd.Checked;
            playerDetails.CnRad.BooleanValue = checkBoxCnRad.Checked;
            playerDetails.PvSav.Value = Int32.Parse(textBoxPvSav.Text);
        }
    }
}
