using System;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.UserControl;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
{
    public partial class SystemDetailsVonNeumann : DisplayUserControl
    {
        public SystemDetailsVonNeumann() : base()
        {
            InitializeComponent();
        }

        /// <summary>Populates the user control off of the appropriate save data structure</summary>
        /// <param name="VonNeumann">SimSystemDetailsVonNeumann containing Von Neumann homeworld data</param>
        public void LoadFromStruct(SimSystemDetailsVonNeumann VonNeumann)
        {
            this.checkBoxVonNeumannHomeWorld.Checked = VonNeumann.Vnh.BooleanValue;

            if (this.checkBoxVonNeumannHomeWorld.Checked)
            {
                this.checkBoxVnd.Checked = VonNeumann.Details.Vnd.BooleanValue;
                this.checkBoxVnex3.Checked = VonNeumann.Details.Vnex3.BooleanValue;
                this.checkBoxVnpex3.Checked = VonNeumann.Details.Vnpex3.BooleanValue;
                this.groupBoxDetails.Visible = true;
            }
            else
                this.groupBoxDetails.Visible = false;
        }

        /// <summary>Updates the data structure with data from the user control</summary>
        /// <param name="VonNeumann">SimSystemDetailsVonNeumann data structure to be updated</param>
        public void UpdateStruct(SimSystemDetailsVonNeumann VonNeumann)
        {
            VonNeumann.Vnh.BooleanValue = this.checkBoxVonNeumannHomeWorld.Checked;

            if (VonNeumann.Vnh.BooleanValue)
            {
                VonNeumann.Details = new SimSystemDetailsVonNeumannDetails();
                VonNeumann.Details.Vnd.BooleanValue = this.checkBoxVnd.Checked;
                VonNeumann.Details.Vnex3.BooleanValue = this.checkBoxVnex3.Checked;
                VonNeumann.Details.Vnpex3.BooleanValue = this.checkBoxVnpex3.Checked;
            }
            else
                VonNeumann.Details = null;
        }

        /// <summary>Toggles the visibility of Von Neumann homeworld details</summary>
        /// <param name="sender">Standard event Object sender</param>
        /// <param name="e">Standard even EventArgs e</param>
        private void checkBoxVonNeumannHomeWorld_CheckedChanged(Object sender, EventArgs e)
        {
            this.groupBoxDetails.Visible = this.checkBoxVonNeumannHomeWorld.Checked;
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.checkBoxVnd.Enabled =                  !ReadOnlyFlag;
            this.checkBoxVnex3.Enabled =                !ReadOnlyFlag;
            this.checkBoxVnpex3.Enabled =               !ReadOnlyFlag;
            this.checkBoxVonNeumannHomeWorld.Enabled =  !ReadOnlyFlag;
        }

        public void Clear()
        {
            this.checkBoxVonNeumannHomeWorld.Checked = false;
            this.checkBoxVnd.Checked = false;
            this.checkBoxVnex3.Checked = false;
            this.checkBoxVnpex3.Checked = false;
        }
    }
}