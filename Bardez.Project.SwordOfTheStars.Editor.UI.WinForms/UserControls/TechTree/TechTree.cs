using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.Resource_Management;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls.User_Control;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls.Tech_Tree
{
    public partial class TechTree : DisplayUserControl
    {
        protected const String detailsSelected = "Selected Technology Details";
        protected const String detailsNotAvailable = "Selected Technology not available to player";
        protected SimPlayerDetailsSaveStruct player;
        protected String currentTech;


        public SimPlayerDetailsSaveStruct Player
        {
            get { return player; }
            set { player = value; }
        }

        public List<JoinedTechnology> ValidTechTree
        {
            get { return this.techDetails.ValidTechTree; }
            set { this.techDetails.ValidTechTree = value; }
        }

        public Graph.Graph GraphTechTree
        {
            get { return this.graphTechTree; }
        }


        public TechTree() : base()
        {
            InitializeComponent();
            this.currentTech = null;
        }


        private void graphTechTree_ClickedTech(Object sender, Graph.ClickedTechEventArgs e)
        {
            //persist current tech details
            if(this.TechEnabled())
                this.techDetails.UpdateStructs();

            this.currentTech = e.TechName;
            this.PopulateTechDetails();
        }

        protected void PopulateTechDetails()
        {
            Int32 index = -1;
            for (Int32 i = 0; i < this.player.TechTree.Techs.Values.Count; ++i)
            {
                if (this.player.TechTree.Techs.Values[i].TNm.Value.CharacterString == this.currentTech)
                {
                    index = i;      //set the current tech index
                    break;
                }
            }

            if (index == -1)
            {
                //set the group text to "technology unavailable" and show the enable button.
                this.groupBoxDetails.Text = detailsNotAvailable;
                this.buttonEnableTech.Visible = true;
                this.techDetails.Visible = false;

                this.techDetails.ClearDetails();
            }
            //load the details of the tech
            else
            {
                //set the text back to normal and hide the enable button
                this.groupBoxDetails.Text = detailsSelected;
                this.buttonEnableTech.Visible = false;
                this.techDetails.Visible = true;

                SimPlayerTechTreeTech tech = this.player.TechTree.Techs.Values[index];
                
                index = -1;
                for (Int32 i = 0; i < this.player.TechTree.Techs.Values.Count; ++i)
                {
                    if (this.player.TechTree.Tree.Values[i].TNm.Value.CharacterString == this.currentTech)
                    {
                        index = i;
                        break;
                    }
                }

                SimPlayerTechTreeBranch branch = null;
                if (index > -1)
                    branch = this.player.TechTree.Tree.Values[index];

                //populate details
                this.techDetails.LoadFromData(tech, branch);
            }
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.graphTechTree.ReadOnly =   ReadOnlyFlag;
            this.buttonEnableTech.Enabled = !ReadOnlyFlag;
            this.techDetails.ReadOnly =     ReadOnlyFlag;
        }

        public void ChangePlayer()
        {
            this.ClearDetails();
        }

        protected void ClearDetails()
        {
            this.techDetails.Visible = false;
            this.buttonEnableTech.Visible = false;
        }

        public void UpdateStruct()
        {
            this.techDetails.UpdateStructs();
        }

        private void buttonEnableTech_Click(object sender, EventArgs e)
        {
            SimPlayerTechTreeTech addTech = new SimPlayerTechTreeTech();
            addTech.TNm.Value.CharacterString = this.currentTech;
            addTech.TResDone.Value = 0;

            //HACK -- to avoid a -1, average the cost of all techs and assign that. Since I don't read the cost from the tech file.
            //NOTE -- it would be nice to instead average the cost of techs given the height of the tech
            //        ... but I'd need to provide the joined tech tree to this control...
            Int32 avg = (Int32)((from t in this.player.TechTree.Techs.Values select t.TResCost.Value).Average());
            addTech.TResCost.Value = avg;
            
            this.player.TechTree.Techs.Add(addTech);

            SimPlayerTechTreeBranch addBranch = new SimPlayerTechTreeBranch();
            addBranch.TNm.Value.CharacterString = this.currentTech;
            addBranch.Branches.Values = new List<StringSaveStruct>();
            this.player.TechTree.Tree.Add(addBranch);
            this.PopulateTechDetails();
        }

        protected Boolean TechEnabled()
        {
            Int32 index = -1;
            for (Int32 i = 0; i < this.player.TechTree.Techs.Values.Count; ++i)
            {
                if (this.player.TechTree.Tree.Values[i].TNm.Value.CharacterString == this.currentTech)
                {
                    index = i;
                    break;
                }
            }

            return !(index == -1);
        }
    }
}