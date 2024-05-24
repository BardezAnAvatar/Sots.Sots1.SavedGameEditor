using System;
using System.Drawing;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    public partial class PlayerInfo : DisplayUserControl
    {
        protected SimPlayerSaveStruct player;

        public PlayerInfo() : base()
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
            this.textBoxPswd.Text					= this.player.Details.Pswd.Value.ToString();
            this.textBoxPlayerIndex.Text			= this.player.Details.PlayerIndex.Value.ToString();
            this.textBoxName.Text					= this.player.Details.PlayerName.Value.CharacterString;
            this.textBoxSpecies.Text				= this.player.Details.Species.Value.ToString();
            this.textBoxHomeSystem.Text				= this.player.Details.HomeSystem.Value.ToString();
            this.buttonColor.BackColor				= GetColorFromPlayer(this.player.Details);
            this.textBoxBadge.Text					= this.player.Details.Badge.Value.CharacterString;
            this.textBoxAvatar.Text					= this.player.Details.Avatar.Value.CharacterString;
            this.textBoxTeam.Text					= this.player.Details.Team.Value.ToString();
            this.checkBoxNpc.Checked				= this.player.Details.Npc.BooleanValue;
            this.checkBoxRebAi.Checked				= this.player.Details.RebAi.BooleanValue;
            this.checkBoxHasAiRebellion.Checked		= this.player.Details.HasAiRebellion.BooleanValue;

            /********************
            *   Habitability    *
            ********************/
            playerHabitability.LoadFromStruct(player.Details);

            /****************
            *   Economy     *
            ****************/
            playerEconomy.LoadFromStruct(player.Details);

            /****************
            *   Research    *
            ****************/
            playerResearch.LoadFromStruct(player.Details);

            /****************
            *   Industry    *
            ****************/
            playerIndustry.LoadFromStruct(player.Details);

            /****************
            *   Unknowns    *
            ****************/
            playerUnknowns.LoadFromStruct(player.Details);
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
            this.checkBoxNpc.Enabled =              !ReadOnlyFlag;
            this.checkBoxRebAi.Enabled =            !ReadOnlyFlag;
            this.checkBoxHasAiRebellion.Enabled =   !ReadOnlyFlag;

            /********************
            *   Habitability    *
            ********************/
            playerHabitability.PercolateReadOnlyFlag(ReadOnlyFlag);

            /****************
            *   Economy     *
            ****************/
            playerEconomy.PercolateReadOnlyFlag(ReadOnlyFlag);

            /****************
            *   Research    *
            ****************/
            playerResearch.PercolateReadOnlyFlag(ReadOnlyFlag);

            /****************
            *   Industry    *
            ****************/
            playerIndustry.PercolateReadOnlyFlag(ReadOnlyFlag);
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
            this.player.Details.Npc.BooleanValue                    = this.checkBoxNpc.Checked;
            this.player.Details.RebAi.BooleanValue                  = this.checkBoxRebAi.Checked;
            this.player.Details.HasAiRebellion.BooleanValue         = this.checkBoxHasAiRebellion.Checked;

            /********************
            *   Habitability    *
            ********************/
            playerHabitability.UpdateStruct(player.Details);

            /****************
            *   Economy     *
            ****************/
            playerEconomy.UpdateStruct(player.Details);

            /****************
            *   Research    *
            ****************/
            playerResearch.UpdateStruct(player.Details);

            /****************
            *   Industry    *
            ****************/
            playerIndustry.UpdateStruct(player.Details);

            /****************
            *   Unknowns    *
            ****************/
            playerUnknowns.UpdateStruct(player.Details);
        }
    }
}