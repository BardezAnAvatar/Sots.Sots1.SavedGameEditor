using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.User_Control;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
{
    public partial class SystemDetailSummary : DisplayUserControl
    {
        public SystemDetailSummary() : base()
        {
            InitializeComponent();
        }

        /// <summary>Populates the fields of the user control from a SimSystemSaveStruct object</summary>
        /// <param name="System">SimSystemSaveStruct object to read data from</param>
        /// <remarks>System should not be null, nor should System.Details, nor any of this control's data sources within</remarks>
        public void LoadFromStruct(SimSystemSaveStruct System)
        {
            
            this.textBoxSystemId.Text = System.SysId.Value.ToString();
            this.textBoxName.Text = System.Details.Name.Value.CharacterString;
            this.buttonColor.ForeColor = this.buttonColor.BackColor =
                Color.FromArgb(
                    RgbFloatToByte(System.Details.StarColor.A.Value),
                    RgbFloatToByte(System.Details.StarColor.Rgb.R.Value),
                    RgbFloatToByte(System.Details.StarColor.Rgb.G.Value),
                    RgbFloatToByte(System.Details.StarColor.Rgb.B.Value)
                );
            this.textBoxSize.Text = System.Details.Size.Value.ToString();
            this.textBoxX.Text = System.Details.Pos.X.Value.ToString();
            this.textBoxY.Text = System.Details.Pos.Y.Value.ToString();
            this.textBoxZ.Text = System.Details.Pos.Z.Value.ToString();
        }

        /// <summary>Updates a SimSystemSaveStruct object with values currently in the user control</summary>
        /// <param name="System">SimSystemSaveStruct object to update</param>
        public void UpdateStruct(SimSystemSaveStruct System)
        {
            System.SysId.Value = Int32.Parse(this.textBoxSystemId.Text);
            System.Details.Name.Value.CharacterString = this.textBoxName.Text;
            System.Details.StarColor.Rgb.R.Value = RgbByteToFloat(this.buttonColor.BackColor.R);
            System.Details.StarColor.Rgb.G.Value = RgbByteToFloat(this.buttonColor.BackColor.G);
            System.Details.StarColor.Rgb.B.Value = RgbByteToFloat(this.buttonColor.BackColor.B);
            System.Details.Pos.X.Value = Single.Parse(this.textBoxX.Text);
            System.Details.Pos.Y.Value = Single.Parse(this.textBoxY.Text);
            System.Details.Pos.Z.Value = Single.Parse(this.textBoxZ.Text);
        }


        protected Byte RgbFloatToByte(Single FloatVal)
        {
            return Convert.ToByte(FloatVal * (Single)255);
        }

        protected Single RgbByteToFloat(Byte ByteVal)
        {
            return Convert.ToSingle(ByteVal) / Convert.ToSingle(255);
        }

        protected void buttonColor_Click(Object sender, EventArgs e)
        {
            this.colorDialogColor.Color = this.buttonColor.BackColor;
            this.colorDialogColor.ShowDialog();
            this.buttonColor.BackColor = this.colorDialogColor.Color;
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.textBoxSystemId.Enabled = !ReadOnlyFlag;
            this.textBoxName.Enabled = !ReadOnlyFlag;
            this.buttonColor.Enabled = !ReadOnlyFlag;
            this.textBoxSize.Enabled = !ReadOnlyFlag;
            this.textBoxX.Enabled = !ReadOnlyFlag;
            this.textBoxY.Enabled = !ReadOnlyFlag;
            this.textBoxZ.Enabled = !ReadOnlyFlag;
        }

        public void Clear()
        {
            this.textBoxSystemId.Text = String.Empty;
            this.textBoxName.Text = String.Empty;
            this.textBoxSize.Text = String.Empty;
            this.textBoxX.Text = String.Empty;
            this.textBoxY.Text = String.Empty;
            this.textBoxZ.Text = String.Empty;
            this.buttonColor.BackColor = System.Drawing.SystemColors.Control;
        }
    }
}