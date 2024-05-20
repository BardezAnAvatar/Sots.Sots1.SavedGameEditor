using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.UserControl;
using Bardez.Project.SwordOfTheStars.ResourceManagement;
using Bardez.Project.SwordOfTheStars.UI.Abstractions.TechTree.Graph;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Tech_Tree
{
    public partial class TechDetails : DisplayUserControl
    {
        protected SimPlayerTechTreeTech tech;
        protected SimPlayerTechTreeBranch branch;
        protected List<JoinedTechnology> validTechTree;

        public List<JoinedTechnology> ValidTechTree
        {
            get { return validTechTree; }
            set { validTechTree = value; }
        }

        public TechDetails()
        {
            InitializeComponent();
            this.SetStyles();
            this.tech = null;
            this.branch = null;
        }

        public void LoadFromData(SimPlayerTechTreeTech Tech, SimPlayerTechTreeBranch Branch)
        {
            this.tech = Tech;
            this.branch = Branch;
            this.LoadDetails();
        }

        protected void LoadDetails()
        {
            JoinedTechnology validTech = (from v in validTechTree where v.Name == this.tech.TNm.Value.CharacterString select v).First();

            this.labelTechName.Text = this.tech.TNm.Value.CharacterString;
            this.labelTechFriendlyName.Text = validTech.FriendlyName;
            this.labelDescription.Text = validTech.Description;
            this.textBoxResCost.Text = this.tech.TResCost.Value.ToString();
            this.textBoxResDone.Text = this.tech.TResDone.Value.ToString();
            this.textBoxAcquired.Text = this.tech.TAcq.Value.ToString();
            this.textBoxIAcquired.Text = this.tech.TiAcq.Value.ToString();
            this.textBoxSt.Text = this.tech.St.Value.ToString();
            this.textBoxTbd.Text = this.tech.Tbd.Value.ToString();
            this.checkBoxTfc.Checked = this.tech.Tfc.BooleanValue;

            this.ClearLists();

            //Valid items
            foreach (AvailableTechnologyConnection validConn in validTech.Allows)
                this.comboBoxLegitimateConnections.Items.Add(validConn.NewTech);

            //Available items
            foreach (StringSaveStruct availConn in this.branch.Branches.Values)
                this.listBoxConnections.Items.Add(availConn.Value.CharacterString);
        }

        public void ClearDetails()
        {
            this.labelTechName.Text = "[Tech Name]";
            this.labelTechFriendlyName.Text = "[Friendly Name]";
            this.labelDescription.Text = "[Tech description]";
            this.textBoxResCost.Text = String.Empty;
            this.textBoxResDone.Text = String.Empty;
            this.textBoxAcquired.Text = String.Empty;
            this.textBoxIAcquired.Text = String.Empty;
            this.textBoxSt.Text = String.Empty;
            this.textBoxTbd.Text = String.Empty;
            this.checkBoxTfc.Checked = false;

            this.ClearLists();
        }

        public void ClearLists()
        {
            //Valid items
            this.comboBoxLegitimateConnections.Items.Clear();

            //Available items
            this.listBoxConnections.Items.Clear();
        }

        private void buttonAddConnection_Click(Object sender, EventArgs e)
        {
            if (!this.listBoxConnections.Items.Contains(this.comboBoxLegitimateConnections.SelectedItem))
                this.listBoxConnections.Items.Add(this.comboBoxLegitimateConnections.SelectedItem);
        }

        private void buttonRemove_Click(Object sender, EventArgs e)
        {
            if (this.listBoxConnections.Items.Contains(this.comboBoxLegitimateConnections.SelectedItem))
                this.listBoxConnections.Items.Remove(this.comboBoxLegitimateConnections.SelectedItem);
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.textBoxResCost.Enabled =                   !ReadOnlyFlag;
            this.textBoxResDone.Enabled =                   !ReadOnlyFlag;
            this.textBoxAcquired.Enabled =                  !ReadOnlyFlag;
            this.listBoxConnections.Enabled =               !ReadOnlyFlag;
            this.comboBoxLegitimateConnections.Enabled =    !ReadOnlyFlag;
            this.buttonAddConnection.Enabled =              !ReadOnlyFlag;
            this.buttonRemove.Enabled =                     !ReadOnlyFlag;
        }

        protected void PersistDetails()
        {
            this.tech.TResCost.Value    = Int32.Parse(this.textBoxResCost.Text);
            this.tech.TResDone.Value    = Int32.Parse(this.textBoxResDone.Text);
            this.tech.TAcq.Value        = Int32.Parse(this.textBoxAcquired.Text);
            this.tech.TiAcq.Value       = Int32.Parse(this.textBoxIAcquired.Text);
            this.tech.St.Value          = Int32.Parse(this.textBoxSt.Text);
            this.tech.Tbd.Value         = Int32.Parse(this.textBoxTbd.Text);
            this.tech.Tfc.BooleanValue  = this.checkBoxTfc.Checked;
        }

        protected void PersistAvailableTech()
        {
            this.branch.Branches.Values.Clear();    //cleanup
            foreach (String techConn in this.listBoxConnections.Items)
            {
                StringSaveStruct tempAdd = new StringSaveStruct();
                tempAdd.Value.CharacterString = techConn;
                this.branch.Branches.Add(tempAdd);
            }
        }

        public void UpdateStructs()
        {
            //persist first?
            if (!(this.tech == null || this.branch == null))
            {
                this.PersistDetails();
                this.PersistAvailableTech();
            }
        }
    }
}