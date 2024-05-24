using System;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerResearch : DisplayUserControl
    {
        public PlayerResearch()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            textBoxResRate.Text = playerDetails.ResRate.Value.ToString();
            textBoxResMod.Text  = playerDetails.ResModifier.Value.ToString();
            textBoxResScl.Text  = playerDetails.ResScl.Value.ToString();
            textBoxNextPrjId.Text = playerDetails.NextPrjId.Value.ToString();
        }

        public void PercolateReadOnlyFlag(bool readOnlyFlag)
        {
            textBoxResRate.Enabled = !readOnlyFlag;
            textBoxResMod.Enabled = !readOnlyFlag;
            textBoxResScl.Enabled = !readOnlyFlag;
            //textBoxNextPrjId always disabled
        }

        public void UpdateStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            playerDetails.ResRate.Value = Single.Parse(textBoxResRate.Text);
            playerDetails.ResModifier.Value = Single.Parse(textBoxResMod.Text);
            playerDetails.ResScl.Value = Single.Parse(textBoxResScl.Text);
            playerDetails.NextPrjId.Value = Int32.Parse(textBoxNextPrjId.Text);
        }
    }
}
