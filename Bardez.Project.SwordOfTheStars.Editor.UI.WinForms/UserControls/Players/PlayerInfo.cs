using System;
using System.Drawing;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerInfo : DisplayUserControl
    {
        public PlayerInfo() : base()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimPlayerSaveStruct player)
        {
            playerDetail.LoadFromStruct(player);
            playerHabitability.LoadFromStruct(player.Details);
            playerEconomy.LoadFromStruct(player.Details);
            playerResearch.LoadFromStruct(player.Details);
            playerIndustry.LoadFromStruct(player.Details);
            playerUnknowns.LoadFromStruct(player.Details);
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            playerDetail.PercolateReadOnlyFlag(ReadOnlyFlag);
            playerHabitability.PercolateReadOnlyFlag(ReadOnlyFlag);
            playerEconomy.PercolateReadOnlyFlag(ReadOnlyFlag);
            playerResearch.PercolateReadOnlyFlag(ReadOnlyFlag);
            playerIndustry.PercolateReadOnlyFlag(ReadOnlyFlag);
        }

        public void UpdateStruct(SimPlayerSaveStruct player)
        {
            playerDetail.UpdateStruct(player);
            playerHabitability.UpdateStruct(player.Details);
            playerEconomy.UpdateStruct(player.Details);
            playerResearch.UpdateStruct(player.Details);
            playerIndustry.UpdateStruct(player.Details);
            playerUnknowns.UpdateStruct(player.Details);
        }
    }
}