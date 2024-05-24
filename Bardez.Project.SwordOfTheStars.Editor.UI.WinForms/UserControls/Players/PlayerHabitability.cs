using System;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerHabitability : DisplayUserControl
    {
        public PlayerHabitability()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            textBoxIdealSuit.Text = playerDetails.IdealSuit.Value.ToString();
            textBoxSuitTol.Text = playerDetails.SuitTolerance.Value.ToString();
            textBoxPopMod.Text = playerDetails.PopMod.Value.ToString();
            textBoxTerrMod.Text = playerDetails.TerraMod.Value.ToString();
            textBoxHasVac.Text = playerDetails.HasVac.Value.ToString();
            textBoxHasImm.Text = playerDetails.HasImm.Value.ToString();
        }

        public void PercolateReadOnlyFlag(bool readOnlyFlag)
        {
            textBoxIdealSuit.Enabled = !readOnlyFlag;
            textBoxSuitTol.Enabled = !readOnlyFlag;
            textBoxPopMod.Enabled = !readOnlyFlag;
            textBoxTerrMod.Enabled = !readOnlyFlag;
            textBoxHasVac.Enabled = !readOnlyFlag;
            textBoxHasImm.Enabled = !readOnlyFlag;
        }

        public void UpdateStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            playerDetails.IdealSuit.Value = Single.Parse(textBoxIdealSuit.Text);
            playerDetails.SuitTolerance.Value = Single.Parse(textBoxSuitTol.Text);
            playerDetails.PopMod.Value = Single.Parse(textBoxPopMod.Text);
            playerDetails.TerraMod.Value = Single.Parse(textBoxTerrMod.Text);
            playerDetails.HasVac.Value = Int32.Parse(textBoxHasVac.Text);
            playerDetails.HasImm.Value = Int32.Parse(textBoxHasImm.Text);
        }
    }
}
