using System;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerIndustry : DisplayUserControl
    {
        public PlayerIndustry()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            textBoxIndOutMod.Text = playerDetails.OutMod.Value.ToString();
            textBoxIndOutReb.Text = playerDetails.RebOutMod.Value.ToString();
            textBoxIndOutScl.Text = playerDetails.ScOutMod.Value.ToString();
        }

        public void PercolateReadOnlyFlag(bool readOnlyFlag)
        {
            textBoxIndOutMod.Enabled = !readOnlyFlag;
            textBoxIndOutReb.Enabled = !readOnlyFlag;
            textBoxIndOutScl.Enabled = !readOnlyFlag;
        }

        public void UpdateStruct(SimPlayerDetailsSaveStruct playerDetails)
        {
            playerDetails.OutMod.Value = Single.Parse(this.textBoxIndOutMod.Text);
            playerDetails.RebOutMod.Value = Single.Parse(this.textBoxIndOutReb.Text);
            playerDetails.ScOutMod.Value = Single.Parse(this.textBoxIndOutScl.Text);
        }
    }
}
