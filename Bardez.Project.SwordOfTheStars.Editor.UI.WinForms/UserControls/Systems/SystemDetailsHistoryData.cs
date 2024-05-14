using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.User_Controls.User_Control;

namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls
{
    public partial class SystemDetailsHistoryData : DisplayUserControl
    {
        public SystemDetailsHistoryData() : base()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimSystemDetailsSaveStruct System, Boolean Previous)
        {            
            this.dataGridViewPopG.Columns.Clear();

            if (Previous)
            {
                this.textBoxSuit.Text = System.PvSuit.Value.ToString();
                this.textBoxRes.Text = System.PvRes.Value.ToString();
                this.textBoxARes.Text = System.PvARes2.Value.ToString();
                this.textBoxMRes.Text = System.PvMRes.Value.ToString();
                this.checkBoxNoRebAI.Checked = System.PvNoRebAi.BooleanValue;
                this.textBoxInfra.Text = System.PvInfra.Value.ToString();
                this.textBoxPop.Text = System.PvPop.Value.ToString();
                this.dataGridViewPopG.DataSource = System.PvPopG.Values;
            }
            else
            {
                this.textBoxSuit.Text = System.Suit.Value.ToString();
                this.textBoxRes.Text = System.Res.Value.ToString();
                this.textBoxARes.Text = System.ARes.Value.ToString();
                this.textBoxMRes.Text = System.MRes.Value.ToString();
                this.checkBoxNoRebAI.Checked = System.NoRebAi.BooleanValue;
                this.textBoxInfra.Text = System.Infra.Value.ToString();
                this.textBoxPop.Text = System.Pop.Value.ToString();
                this.dataGridViewPopG.DataSource = System.PopG.Values;
            }

            this.labelPopG.Visible = this.dataGridViewPopG.Visible = (System.PopG.Length.Value > 0);
            
            if (this.dataGridViewPopG.Columns.Count > 0)
            {
                this.dataGridViewPopG.Columns.Remove("Description");
                this.dataGridViewPopG.Columns["PopT"].Width = 40;
                this.dataGridViewPopG.Columns["PopS"].Width = 40;
            }
        }

        public void UpdateStruct(SimSystemDetailsSaveStruct System, Boolean Previous)
        {
            if (Previous)
            {
                System.PvSuit.Value = Single.Parse(this.textBoxSuit.Text);
                System.PvRes.Value = Int32.Parse(this.textBoxRes.Text);
                System.PvARes2.Value = Int32.Parse(this.textBoxARes.Text);
                System.PvMRes.Value = Int32.Parse(this.textBoxMRes.Text);
                System.PvNoRebAi.BooleanValue = this.checkBoxNoRebAI.Checked;
                System.PvInfra.Value = Single.Parse(this.textBoxInfra.Text);
                System.PvPop.Value = Int32.Parse(this.textBoxPop.Text);

                System.PvPopG.Length.Value = this.dataGridViewPopG.Rows.Count;
                List<SimPopGSaveStruct> arr = new List<SimPopGSaveStruct>(this.dataGridViewPopG.Rows.Count);
                for(Int32 i = 0; i < arr.Capacity; i++)
                {
                    SimPopGSaveStruct add = new SimPopGSaveStruct();
                    add.Description.CharacterString = "PopG";
                    add.PopT.Description.CharacterString = "PopT";
                    add.PopS.Description.CharacterString = "PopS";
                    add.PopC.Description.CharacterString = "PopC";
                    add.PopT.Value = (this.dataGridViewPopG.Rows[i].Cells["PopT"].Value as Int32SaveStruct).Value;
                    add.PopS.Value = (this.dataGridViewPopG.Rows[i].Cells["PopS"].Value as Int32SaveStruct).Value;
                    add.PopC.Value = (this.dataGridViewPopG.Rows[i].Cells["PopC"].Value as Int64SaveStruct).Value;
                    arr.Add(add);
                }
                System.PvPopG.Values = arr;
            }
            else
            {

                System.Suit.Value = Single.Parse(this.textBoxSuit.Text);
                System.Res.Value = Int32.Parse(this.textBoxRes.Text);
                System.ARes.Value = Int32.Parse(this.textBoxARes.Text);
                System.MRes.Value = Int32.Parse(this.textBoxMRes.Text);
                System.NoRebAi.BooleanValue = this.checkBoxNoRebAI.Checked;
                System.Infra.Value = Single.Parse(this.textBoxInfra.Text);
                System.Pop.Value = Int32.Parse(this.textBoxPop.Text);

                System.PopG.Length.Value = this.dataGridViewPopG.Rows.Count;
                List<SimPopGSaveStruct> arr = new List<SimPopGSaveStruct>(this.dataGridViewPopG.Rows.Count);
                for (Int32 i = 0; i < arr.Capacity; i++)
                {
                    SimPopGSaveStruct add = new SimPopGSaveStruct();
                    add.Description.CharacterString = "PopG";
                    add.PopT.Description.CharacterString = "PopT";
                    add.PopS.Description.CharacterString = "PopS";
                    add.PopC.Description.CharacterString = "PopC";
                    add.PopT.Value = (this.dataGridViewPopG.Rows[i].Cells["PopT"].Value as Int32SaveStruct).Value;
                    add.PopS.Value = (this.dataGridViewPopG.Rows[i].Cells["PopS"].Value as Int32SaveStruct).Value;
                    add.PopC.Value = (this.dataGridViewPopG.Rows[i].Cells["PopC"].Value as Int64SaveStruct).Value;
                    arr.Add(add);
                }
                System.PopG.Values = arr;
            }
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.textBoxSuit.Enabled =      !ReadOnlyFlag;
            this.textBoxRes.Enabled =       !ReadOnlyFlag;
            this.checkBoxNoRebAI.Enabled =  !ReadOnlyFlag;
            this.textBoxInfra.Enabled =     !ReadOnlyFlag;
            this.textBoxPop.Enabled =       !ReadOnlyFlag;
            this.dataGridViewPopG.ReadOnly = ReadOnlyFlag;
        }

        public void Clear()
        {
            this.textBoxSuit.Text = String.Empty;
            this.textBoxRes.Text = String.Empty;
            this.textBoxARes.Text = String.Empty;
            this.textBoxMRes.Text = String.Empty;
            this.checkBoxNoRebAI.Checked = false;
            this.textBoxInfra.Text = String.Empty;
            this.textBoxPop.Text = String.Empty;
            this.dataGridViewPopG.Rows.Clear();
        }
    }
}