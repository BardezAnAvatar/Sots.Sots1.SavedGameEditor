using System;
using System.Collections.Generic;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
{
    public partial class SystemDetailsMisc : DisplayUserControl
    {
        public SystemDetailsMisc() : base()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimSystemDetailsSaveStruct System)
        {            
            this.textBoxTres.Text = System.TRes.Value.ToString();
            this.textBoxAbandoned.Text = System.Abdn.Value.ToString();
            this.checkBoxDestroyed.Checked = System.Dstyd.BooleanValue;
            this.textBoxTnsOh.Text = System.TnsOh.Value.ToString();
            this.textBoxOutMod.Text = System.OutMod.Value.ToString();
            this.textBoxPid.Text = System.Pid.Value.ToString();
            this.textBoxRepCur.Text = System.RepCur.Value.ToString();
            this.textBoxRepMax.Text = System.RepMax.Value.ToString();
            this.textBoxIbon.Text = System.Ibon.Value.ToString();
            this.textBoxPbon.Text = System.Pbon.Value.ToString();
            this.textBoxLtis.Text = System.Ltis.Value.ToString();
            this.textBoxRbfl.Text = System.Rbfl.Value.ToString();
            this.textBoxRbtn.Text = System.Rbtn.Value.ToString();
            this.textBoxRbfr.Text = System.Rbfr.Value.ToString();
            this.textBoxRbwn.Text = System.Rbwn.Value.ToString();
            this.textBoxHsrg.Text = System.Hsrg.Value.ToString();
            this.textBoxBats2.Text = System.Bats2.Value.ToString();
            this.textBoxRcex.Text = System.Rcex.Value.ToString();
            this.textBoxTerrFl.Text = System.TerrFl.Value.ToString();
            this.textBoxTacq.Text = System.TAcq.Value.ToString();
            this.textBoxTfacq.Text = System.TfAcq.Value.ToString();
            this.textBoxTdst.Text = System.TDst.Value.ToString();
            this.textBoxDsu.Text = System.Dsu.Value.ToString();
            this.textBoxDeff.Text = System.DefF.Value.ToString();
            this.textBoxDefsf.Text = System.DefSf.Value.ToString();

            
            this.dataGridViewPbon2.Columns.Clear();
            this.dataGridViewPbon2.DataSource = System.Pbon2.Values;
            this.labelPbon2.Visible = this.dataGridViewPbon2.Visible = (System.Pbon2.Length.Value > 0);

            if (this.dataGridViewPbon2.Columns.Count > 0)
            {
                this.dataGridViewPbon2.Columns.Remove("Description");
                this.dataGridViewPbon2.Columns["PopT"].Width = 40;
                this.dataGridViewPbon2.Columns["PopS"].Width = 40;
            }
        }

        public void UpdateStruct(SimSystemDetailsSaveStruct System)
        {
            System.TRes.Value = Int32.Parse(this.textBoxTres.Text);
            System.Abdn.Value = Int32.Parse(this.textBoxAbandoned.Text);
            System.Dstyd.BooleanValue = this.checkBoxDestroyed.Checked;
            System.TnsOh.Value = Int32.Parse(this.textBoxTnsOh.Text);
            System.OutMod.Value = Single.Parse(this.textBoxOutMod.Text);
            System.Pid.Value = Int32.Parse(this.textBoxPid.Text);
            System.RepCur.Value = Single.Parse(this.textBoxRepCur.Text);
            System.RepMax.Value = Single.Parse(this.textBoxRepMax.Text);
            System.Ibon.Value = Single.Parse(this.textBoxIbon.Text);
            System.Pbon.Value = Int32.Parse(this.textBoxPbon.Text);
            System.Ltis.Value = Int32.Parse(this.textBoxLtis.Text);
            System.Rbfl.Value = Int32.Parse(this.textBoxRbfl.Text);
            System.Rbtn.Value = Int32.Parse(this.textBoxRbtn.Text);
            System.Rbfr.Value = Int32.Parse(this.textBoxRbfr.Text);
            System.Rbwn.Value = Int32.Parse(this.textBoxRbwn.Text);
            System.Hsrg.Value = Int32.Parse(this.textBoxHsrg.Text);
            System.Bats2.Value = Int64.Parse(this.textBoxBats2.Text);
            System.Rcex.Value = Int64.Parse(this.textBoxRcex.Text);
            System.TerrFl.Value = Int32.Parse(this.textBoxTerrFl.Text);
            System.TAcq.Value = Int32.Parse(this.textBoxTacq.Text);
            System.TfAcq.Value = Int32.Parse(this.textBoxTfacq.Text);
            System.TDst.Value = Int32.Parse(this.textBoxTdst.Text);
            System.Dsu.Value = Int32.Parse(this.textBoxDsu.Text);
            System.DefF.Value = Int32.Parse(this.textBoxDeff.Text);
            System.DefSf.Value = Int32.Parse(this.textBoxDefsf.Text);

            System.Pbon2.Length.Value = this.dataGridViewPbon2.Rows.Count;
            List<SimPopGSaveStruct> arr = new List<SimPopGSaveStruct>(this.dataGridViewPbon2.Rows.Count);
            for (Int32 i = 0; i < arr.Capacity; i++)
            {
                SimPopGSaveStruct add = new SimPopGSaveStruct();
                add.Description.CharacterString = "PopG";
                add.PopT.Description.CharacterString = "PopT";
                add.PopS.Description.CharacterString = "PopS";
                add.PopC.Description.CharacterString = "PopC";
                add.PopT.Value = (Int32)this.dataGridViewPbon2.Rows[i].Cells["PopT"].Value;
                add.PopS.Value = (Int32)this.dataGridViewPbon2.Rows[i].Cells["PopS"].Value;
                add.PopC.Value = (Int64)this.dataGridViewPbon2.Rows[i].Cells["PopC"].Value;
                arr.Add(add);
            }
            System.Pbon2.Values = arr;
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.textBoxAbandoned.Enabled =     !ReadOnlyFlag;
            this.checkBoxDestroyed.Enabled =    !ReadOnlyFlag;
            this.textBoxTnsOh.Enabled =         !ReadOnlyFlag;
            this.textBoxOutMod.Enabled =        !ReadOnlyFlag;
            this.textBoxPid.Enabled =           !ReadOnlyFlag;
            this.textBoxRepCur.Enabled =        !ReadOnlyFlag;
            this.textBoxRepMax.Enabled =        !ReadOnlyFlag;
            this.textBoxIbon.Enabled =          !ReadOnlyFlag;
            this.textBoxPbon.Enabled =          !ReadOnlyFlag;
            this.dataGridViewPbon2.ReadOnly =   ReadOnlyFlag;
        }

        public void Clear()
        {
            this.textBoxTres.Text = String.Empty;
            this.textBoxAbandoned.Text = String.Empty;
            this.checkBoxDestroyed.Checked = false;
            this.textBoxTnsOh.Text = String.Empty;
            this.textBoxOutMod.Text = String.Empty;
            this.textBoxPid.Text = String.Empty;
            this.textBoxRepCur.Text = String.Empty;
            this.textBoxRepMax.Text = String.Empty;
            this.textBoxIbon.Text = String.Empty;
            this.textBoxPbon.Text = String.Empty;
            this.dataGridViewPbon2.Rows.Clear();
            this.textBoxLtis.Text = String.Empty;
            this.textBoxRbfl.Text = String.Empty;
            this.textBoxRbtn.Text = String.Empty;
            this.textBoxRbfr.Text = String.Empty;
            this.textBoxRbwn.Text = String.Empty;
            this.textBoxHsrg.Text = String.Empty;
            this.textBoxBats2.Text = String.Empty;
            this.textBoxRcex.Text = String.Empty;
            this.textBoxTerrFl.Text = String.Empty;
            this.textBoxTacq.Text = String.Empty;
            this.textBoxTfacq.Text = String.Empty;
            this.textBoxTdst.Text = String.Empty;
            this.textBoxDsu.Text = String.Empty;
            this.textBoxDeff.Text = String.Empty;
            this.textBoxDefsf.Text = String.Empty;
        }
    }
}