using System;
using System.Drawing;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerDetail : DisplayUserControl
    {
        public PlayerDetail()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimPlayerSaveStruct player)
        {
            textBoxPlayerId.Text = player.PlayerId.Value.ToString();
            textBoxPswd.Text = player.Details.Pswd.Value.ToString();
            textBoxPlayerIndex.Text = player.Details.PlayerIndex.Value.ToString();
            textBoxName.Text = player.Details.PlayerName.Value.CharacterString;
            textBoxSpecies.Text = player.Details.Species.Value.ToString();
            textBoxHomeSystem.Text = player.Details.HomeSystem.Value.ToString();
            buttonColor.BackColor = GetColorFromPlayer(player.Details);
            textBoxBadge.Text = player.Details.Badge.Value.CharacterString;
            textBoxAvatar.Text = player.Details.Avatar.Value.CharacterString;
            textBoxTeam.Text = player.Details.Team.Value.ToString();
            checkBoxNpc.Checked = player.Details.Npc.BooleanValue;
            checkBoxRebAi.Checked = player.Details.RebAi.BooleanValue;
            checkBoxHasAiRebellion.Checked = player.Details.HasAiRebellion.BooleanValue;
        }

        public void PercolateReadOnlyFlag(bool readOnlyFlag)
        {
            textBoxName.Enabled = !readOnlyFlag;
            textBoxHomeSystem.Enabled = !readOnlyFlag;
            buttonColor.Enabled = !readOnlyFlag;
            textBoxBadge.Enabled = !readOnlyFlag;
            textBoxAvatar.Enabled = !readOnlyFlag;
            textBoxTeam.Enabled = !readOnlyFlag;
            checkBoxNpc.Enabled = !readOnlyFlag;
            checkBoxRebAi.Enabled = !readOnlyFlag;
            checkBoxHasAiRebellion.Enabled = !readOnlyFlag;
            //always disabled:
            //textBoxSpecies
            //textBoxPlayerId
            //textBoxPlayerIndex
        }

        public void UpdateStruct(SimPlayerSaveStruct player)
        {
            UpdateColorForPlayer(player.Details, buttonColor.BackColor);
            player.Details.PlayerName.Value.CharacterString = textBoxName.Text;
            player.Details.HomeSystem.Value = Int32.Parse(textBoxHomeSystem.Text);
            player.Details.Badge.Value.CharacterString = textBoxBadge.Text;
            player.Details.Avatar.Value.CharacterString = textBoxAvatar.Text;
            player.Details.Team.Value = Int32.Parse(textBoxTeam.Text);
            player.Details.Npc.BooleanValue = checkBoxNpc.Checked;
            player.Details.RebAi.BooleanValue = checkBoxRebAi.Checked;
            player.Details.HasAiRebellion.BooleanValue = checkBoxHasAiRebellion.Checked;

            //do not do these:
            //player.Details.Species.Value = Int32.Parse(textBoxSpecies.Text);
            //player.Details.PlayerIndex.Value = Int32.Parse(textBoxPlayerIndex.Text);
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
        protected void UpdateColorForPlayer(SimPlayerDetailsSaveStruct playerDetails, Color SelectedColor)
        {
            SimPlayerColorSaveStruct newColor = playerDetails.ColorId;
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
            colorDialogColor.Color = buttonColor.BackColor;
            colorDialogColor.ShowDialog();
            buttonColor.BackColor = colorDialogColor.Color;
        }
    }
}
