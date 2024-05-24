using System;
using System.Data;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.UserControl;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Species
{
    public partial class Species_Details : DisplayUserControl
    {
        protected DataTable adapter;
        protected SimSpeciesArraySaveStruct speciesArray;

        public Species_Details() : base()
        {
            InitializeComponent();
            this.adapter = null;
            this.speciesArray = null;
        }

        public void LoadFromStruct(SimSpeciesArraySaveStruct SpeciesArray)
        {
            this.speciesArray = SpeciesArray;

            adapter = new DataTable("Species");

            //Add two Read-only columns and an editable one
            DataColumn tempColumn = new DataColumn("Species ID", typeof(Int32));
            tempColumn.ReadOnly = true;
            adapter.Columns.Add(tempColumn);
            tempColumn = new DataColumn("Species", typeof(String));
            tempColumn.ReadOnly = true;
            adapter.Columns.Add(tempColumn);
            adapter.Columns.Add(new DataColumn("Ideal Climate Suitability", typeof(Single)));

            for(Int32 i = 0; i < SpeciesArray.Species.Length; i++)
                adapter.Rows.Add(new Object[] {i, SpeciesArray.Species[i].IsSp.Value.CharacterString, SpeciesArray.Species[i].IsSu.Value});

            this.dataGridViewSpecies.DataSource = adapter;
            this.dataGridViewSpecies.Columns[2].Width = 200;
            this.dataGridViewSpecies.AutoResizeColumns();
            this.dataGridViewSpecies.AllowUserToAddRows = false;
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.dataGridViewSpecies.ReadOnly = ReadOnlyFlag;
        }

        public void Clear()
        {
        }


        #region Write back to struct
        public void UpdateStruct(Int32 Row)
        {
            this.speciesArray.Species[Row].IsSu.Value = (Single)(dataGridViewSpecies["Ideal Climate Suitability", Row].Value);
        }

        private void dataGridViewSpecies_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateStruct(e.RowIndex);
        }
        #endregion
    }
}