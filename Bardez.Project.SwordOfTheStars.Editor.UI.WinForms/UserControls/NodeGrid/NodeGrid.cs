using System;
using System.Data;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.Helpers;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Node_Grid
{
    public partial class NodeGrid : DisplayUserControl
    {
        protected DataTable adapter;
        protected SimNodeGrid2 nodeGrid;
        protected SaveGameData saveGame;
        protected Int32 currentRow;
        protected BindingSource bindingSource;

        public NodeGrid() : base()
        {
            InitializeComponent();
            this.currentRow = -1;
            this.bindingSource = null;
        }

        public void LoadFromStruct(SaveGameData SaveData)
        {
            SimNodeGrid2 NodeGrid = SaveData.Sim.Ndgr2;
            this.nodeGrid = NodeGrid;
            this.saveGame = SaveData;

            this.adapter = new DataTable();
            this.adapter.Columns.Add(new DataColumn("Index", typeof(Int32)));
            this.adapter.Columns.Add(new DataColumn("Node Path ID", typeof(Int32)));
            this.adapter.Columns.Add(new DataColumn("From Index", typeof(Int32)));
            this.adapter.Columns.Add(new DataColumn("To Index", typeof(Int32)));
            this.adapter.Columns.Add(new DataColumn("From", typeof(String)));
            this.adapter.Columns.Add(new DataColumn("To", typeof(String)));

            for (Int32 i = 0; i < NodeGrid.Paths.Values.Count; i++)
            {
                adapter.Rows.Add(this.GenerateAdapterRow(i));
            }

            this.bindingSource = new BindingSource();
            this.bindingSource.DataSource = this.adapter;

            this.dataGridViewNodes.AutoGenerateColumns = false;
            this.GenerateDataGridViewNodesColumns();
            this.dataGridViewNodes.DataSource = this.bindingSource;
            this.dataGridViewNodes.AutoResizeColumns();
            this.dataGridViewNodes.AllowUserToAddRows = true;
        }

        protected void GenerateDataGridViewNodesColumns()
        {
            this.dataGridViewNodes.Columns.Clear();
            DataTable adapter = DataGridViewUtility.GetSystemData(this.saveGame.Sim);

            this.dataGridViewNodes.Columns.Add(DataGridViewUtility.CreateTextColumn("Index", true));
            this.dataGridViewNodes.Columns.Add(DataGridViewUtility.CreateTextColumn("Node Path ID", true));
            this.dataGridViewNodes.Columns.Add(DataGridViewUtility.CreateComboColumn("From", "From Index", adapter, "Name", "Index", false));
            this.dataGridViewNodes.Columns.Add(DataGridViewUtility.CreateComboColumn("To", "To Index", adapter, "Name", "Index", false));
        }


        protected String GetPlanetName(Int32 PlanetIndex)
        {
            String name = "Invalid";
            if (PlanetIndex < this.saveGame.Sim.Systems.Values.Count && PlanetIndex > -1)
                name = this.saveGame.Sim.Systems.Values[PlanetIndex].Details.Name.Value.CharacterString;

            return name;
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.dataGridViewNodes.ReadOnly = ReadOnlyFlag;
            this.node_Grid_Details.ReadOnly = ReadOnlyFlag;
        }




        protected void dataGridViewNodes_CurrentCellChanged(object sender, EventArgs e)
        {
            //persist changes

            if (this.currentRow > -1 && this.dataGridViewNodes.CurrentRow != null)
            {
                if (!(IsNullOrDBNull(this.dataGridViewNodes.Rows[this.currentRow].Cells["Index"].Value)
                    || IsNullOrDBNull(this.dataGridViewNodes.Rows[this.currentRow].Cells["Node Path ID"].Value)
                    || IsNullOrDBNull(this.dataGridViewNodes.Rows[this.currentRow].Cells["From"].Value)
                    || IsNullOrDBNull(this.dataGridViewNodes.Rows[this.currentRow].Cells["To"].Value)))
                this.PersistDetailsChanges(this.currentRow);
            }

            if (this.dataGridViewNodes.CurrentRow != null )
            {
                this.currentRow = this.dataGridViewNodes.CurrentRow.Index;

                //Index is 0-based, Length is 1-based, so use a "<" rather than "<="
                if (this.currentRow < this.saveGame.Sim.Ndgr2.Paths.Length.Value)
                    this.RefreshDetails(this.currentRow);
                else
                    this.node_Grid_Details.Clear();
            }
        }

        protected void dataGridViewNodes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridViewNodes.Rows[e.RowIndex];

            //An error is thrown if the check below is not applied. Also, since it makes no sense to
            //      add a half-finished node (as it would probably break), do not fill in unless both are populated 
            if (row.Cells["From"].Value != System.DBNull.Value && row.Cells["To"].Value != System.DBNull.Value)
            {
                //fill in the index and node path id cells, if empty
                if (row.Cells["Index"].Value == null || row.Cells["Index"].Value == System.DBNull.Value)
                    row.Cells["Index"].Value = e.RowIndex;
                if (row.Cells["Node Path ID"].Value == null || row.Cells["Node Path ID"].Value == System.DBNull.Value)
                    row.Cells["Node Path ID"].Value = e.RowIndex + 1;

                //Persist
                this.AddRowAsNecessary(e.RowIndex);
                this.PersistDetailsChanges(e.RowIndex);
                this.PersistGridChanges(e.RowIndex);

                //Refresh grid
                this.RefreshGridRow(currentRow);

                //Refresh
                this.RefreshDetails(e.RowIndex);
            }
        }

        #region Persist
        protected void AddRowAsNecessary(Int32 Row)
        {
            //Add a row as necessary
            this.bindingSource.EndEdit();
            if (Row + 1 > this.saveGame.Sim.Ndgr2.Paths.Length.Value)
                this.saveGame.Sim.Ndgr2.Paths.Add(new SimNodeGridPath());
        }

        protected void PersistGridChanges(Int32 Row)
        {
            DataGridViewRow row = this.dataGridViewNodes.Rows[Row];

            //persist data changes
            if(row.Cells["Node Path ID"].Value != System.DBNull.Value)
                this.saveGame.Sim.Ndgr2.Paths.Values[Row].Npid.Value = (Int32)(row.Cells["Node Path ID"].Value);
            if (row.Cells["From"].Value != System.DBNull.Value)
                this.saveGame.Sim.Ndgr2.Paths.Values[Row].Npfr.Value = (Int32)(row.Cells["From"].Value);
            if (row.Cells["To"].Value != System.DBNull.Value)
                this.saveGame.Sim.Ndgr2.Paths.Values[Row].Npto.Value = (Int32)(row.Cells["To"].Value);
        }

        protected void PersistDetailsChanges(Int32 Row)
        {
            this.node_Grid_Details.UpdateStruct(this.saveGame.Sim.Ndgr2.Paths.Values[Row]);
        }

        public void PersistBeforeSave()
        {
            if (this.currentRow > -1 && this.dataGridViewNodes.CurrentRow != null)
                this.PersistDetailsChanges(this.currentRow);
        }
        #endregion

        #region Refresh
        /// <summary>Refreshes the Player Details control from its data source</summary>
        protected void RefreshDetails(Int32 Row)
        {
            this.node_Grid_Details.LoadFromStruct(this.saveGame.Sim.Ndgr2.Paths.Values[Row]);
        }

        /// <summary>Refreshes the entire dataview grid's data source</summary>
        protected void RefreshGrid()
        {
            //Empty
            this.adapter.Rows.Clear();

            //Populate
            for (Int32 i = 0; i < this.saveGame.Sim.Ndgr2.Paths.Values.Count; i++)
                adapter.Rows.Add(GenerateAdapterRow(i));
        }

        /// <summary>Refreshes a single row's data source</summary>
        /// <param name="Row">Index of the row to be refreshed</param>
        protected void RefreshGridRow(Int32 Row)
        {
            if (Row < this.adapter.Rows.Count - 1)
            {
                //Populate
                Object[] rowData = GenerateAdapterRow(Row);

                this.adapter.Rows[Row]["Index"] = rowData[0];
                this.adapter.Rows[Row]["Node Path ID"] = rowData[1];
                this.adapter.Rows[Row]["From Index"] = rowData[2];
                this.adapter.Rows[Row]["To Index"] = rowData[3];
                this.adapter.Rows[Row]["From"] = rowData[4];
                this.adapter.Rows[Row]["To"] = rowData[5];
            }
        }
        #endregion
        
        protected Object[] GenerateAdapterRow(Int32 Row)
        {
            return new Object[] 
                { 
                    Row,
                    this.saveGame.Sim.Ndgr2.Paths.Values[Row].Npid.Value,
                    this.saveGame.Sim.Ndgr2.Paths.Values[Row].Npfr.Value,
                    this.saveGame.Sim.Ndgr2.Paths.Values[Row].Npto.Value,
                    this.GetPlanetName(this.saveGame.Sim.Ndgr2.Paths.Values[Row].Npfr.Value),
                    this.GetPlanetName(this.saveGame.Sim.Ndgr2.Paths.Values[Row].Npto.Value)
                };
        }

        protected Boolean IsNullOrDBNull(Object Target)
        {
            return Target == null || Target == System.DBNull.Value;
        }

        public void Clear()
        {
        }
    }
}