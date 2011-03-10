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
    public partial class Systems : DisplayUserControl
    {
        protected SimSaveStruct simulation;
        protected DataTable adapter;
        protected Int32 currentRow;

        public Systems() : base()
        {
            InitializeComponent();
            this.currentRow = -1;
        }

        public void LoadFromStruct(SimSaveStruct Simulation)
        {
            simulation = Simulation;
            adapter = new DataTable("Systems");
            adapter.Columns.Add(new DataColumn("Index", typeof(Int32)));
            adapter.Columns.Add(new DataColumn("System ID", typeof(Int32)));
            adapter.Columns.Add(new DataColumn("Name", typeof(String)));
            adapter.Columns.Add(new DataColumn("Size", typeof(Int32)));
            adapter.Columns.Add(new DataColumn("Climate Suitability", typeof(Single)));
            adapter.Columns.Add(new DataColumn("Resources", typeof(Int32)));
            adapter.Columns.Add(new DataColumn("Infrastructure", typeof(Single)));
            adapter.Columns.Add(new DataColumn("Advanced Infrastructure", typeof(Single)));
            adapter.Columns.Add(new DataColumn("Imperial Population", typeof(Int32)));
            adapter.Columns.Add(new DataColumn("Repair Left", typeof(Single)));
            adapter.Columns.Add(new DataColumn("Repair per Turn", typeof(Single)));
            adapter.Columns.Add(new DataColumn("Owner ID", typeof(Int32)));

            //populate the data table
            for (Int32 i = 0; i < Simulation.Systems.Values.Count; i++)
                adapter.Rows.Add(GenerateAdapterRow(i));

            this.dataGridViewSystems.AutoGenerateColumns = false;
            this.dataGridViewSystems.DataSource = adapter;
            this.GenerateDataGridViewSystemsColumns();
            this.dataGridViewSystems.AutoResizeColumns();
            this.dataGridViewSystems.AllowUserToAddRows = false;
        }

        protected void GenerateDataGridViewSystemsColumns()
        {
            this.dataGridViewSystems.Columns.Clear();
            DataTable playerTable = DataGridViewUtility.GetPlayerData(this.simulation);

            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Index", true));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("System ID", true));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Name", false));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Size", false));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Climate Suitability", false));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Resources", false));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Infrastructure", false));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Advanced Infrastructure", false));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Imperial Population", false));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Repair Left", false));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Repair per Turn", false));
            //this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateTextColumn("Owner ID", true));
            this.dataGridViewSystems.Columns.Add(DataGridViewUtility.CreateComboColumn("Owner", "Owner ID", playerTable, "Name", "Player ID", false));
        }

        public void UpdateStruct(SimSaveStruct Simulation)
        {
        }

        protected void dataGridViewSystems_CurrentCellChanged(object sender, System.EventArgs e)
        {
            //persist changes
            if (this.currentRow > -1 && this.dataGridViewSystems.CurrentRow != null)
            {
                this.PersistDetailsChanges(this.currentRow);
                this.RefreshGridRow(this.currentRow);
            }

            if (this.dataGridViewSystems.CurrentRow != null)
            {
                this.currentRow = this.dataGridViewSystems.CurrentRow.Index;
                this.RefreshDetails(this.currentRow);
            }
        }

        protected void dataGridViewSystems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //persist
            this.PersistDetailsChanges(e.RowIndex);
            this.PersistGridChanges(e.RowIndex);

            //refresh
            this.RefreshGridRow(e.RowIndex);
            this.RefreshDetails(e.RowIndex);
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.dataGridViewSystems.ReadOnly = ReadOnlyFlag;
            this.system_Details.ReadOnly = ReadOnlyFlag;
        }




        #region Persist
        //protected void AddRowAsNecessary(Int32 Row)
        //{
        //    //Add a row as necessary
        //    this.bindingSource.EndEdit();
        //    if (Row + 1 > this.simulation.Ndgr2.Paths.Length.Value)
        //        this.simulation.Ndgr2.Paths.Add(new SimNodeGridPath());
        //}

        protected void PersistGridChanges(Int32 Row)
        {
            DataGridViewRow row = this.dataGridViewSystems.Rows[Row];

            //persist data changes
            this.simulation.Systems.Values[Row].SysId.Value = (Int32)(row.Cells["System ID"].Value);
            this.simulation.Systems.Values[Row].Details.Name.Value.CharacterString = row.Cells["Name"].Value as String;
            this.simulation.Systems.Values[Row].Details.Size.Value = (Int32)(row.Cells["Size"].Value);
            this.simulation.Systems.Values[Row].Details.Suit.Value = (Single)(row.Cells["Climate Suitability"].Value);
            this.simulation.Systems.Values[Row].Details.Res.Value = (Int32)(row.Cells["Resources"].Value);
            this.simulation.Systems.Values[Row].Details.Infra.Value = (Single)(row.Cells["Infrastructure"].Value);
            this.simulation.Systems.Values[Row].Details.Ibon.Value = (Single)(row.Cells["Advanced Infrastructure"].Value);
            this.simulation.Systems.Values[Row].Details.Pop.Value = (Int32)(row.Cells["Imperial Population"].Value);
            this.simulation.Systems.Values[Row].Details.RepCur.Value = (Single)(row.Cells["Repair Left"].Value);
            this.simulation.Systems.Values[Row].Details.RepMax.Value = (Single)(row.Cells["Repair per Turn"].Value);
            this.simulation.Systems.Values[Row].Details.Pid.Value = (Int32)(row.Cells["Owner"].Value);

            /********************
            *   for added rows  *
            ********************/
            //if (row.Cells["Node Path ID"].Value != System.DBNull.Value)
            //    this.simulation.Ndgr2.Paths.Values[Row].Npid.Value = (Int32)(row.Cells["Node Path ID"].Value);
            ////if (row.Cells["From"].Value != System.DBNull.Value)
            //    this.simulation.Ndgr2.Paths.Values[Row].Npfr.Value = (Int32)(row.Cells["From"].Value);
            ////if (row.Cells["To"].Value != System.DBNull.Value)
            //    this.simulation.Ndgr2.Paths.Values[Row].Npto.Value = (Int32)(row.Cells["To"].Value);
        }

        protected void PersistDetailsChanges(Int32 Row)
        {
            this.system_Details.UpdateStruct(this.simulation.Systems.Values[Row]);
        }

        public void PersistBeforeSave()
        {
            if (this.currentRow > -1 && this.dataGridViewSystems.CurrentRow != null)
                this.PersistDetailsChanges(this.currentRow);
        }
        #endregion

        #region Refresh
        /// <summary>Refreshes the Player Details control from its data source</summary>
        protected void RefreshDetails(Int32 Row)
        {
            this.system_Details.LoadFromStruct(this.simulation.Systems.Values[Row]);
        }

        /// <summary>Refreshes the entire dataview grid's data source</summary>
        protected void RefreshGrid()
        {
            //Empty
            this.adapter.Rows.Clear();

            //Populate
            for (Int32 i = 0; i < this.simulation.Systems.Values.Count; i++)
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
                this.adapter.Rows[Row]["System ID"] = rowData[1];
                this.adapter.Rows[Row]["Name"] = rowData[2];
                this.adapter.Rows[Row]["Size"] = rowData[3];
                this.adapter.Rows[Row]["Climate Suitability"] = rowData[4];
                this.adapter.Rows[Row]["Resources"] = rowData[5];
                this.adapter.Rows[Row]["Infrastructure"] = rowData[6];
                this.adapter.Rows[Row]["Advanced Infrastructure"] = rowData[7];
                this.adapter.Rows[Row]["Imperial Population"] = rowData[8];
                this.adapter.Rows[Row]["Repair Left"] = rowData[9];
                this.adapter.Rows[Row]["Repair per Turn"] = rowData[10];
                this.adapter.Rows[Row]["Owner ID"] = rowData[11];
            }
        }
        #endregion

        protected Object[] GenerateAdapterRow(Int32 Row)
        {
            return new Object[]
                {
                    Row,
                    this.simulation.Systems.Values[Row].SysId.Value,
                    this.simulation.Systems.Values[Row].Details.Name.Value.CharacterString,
                    this.simulation.Systems.Values[Row].Details.Size.Value,
                    this.simulation.Systems.Values[Row].Details.Suit.Value,
                    this.simulation.Systems.Values[Row].Details.Res.Value,
                    this.simulation.Systems.Values[Row].Details.Infra.Value,
                    this.simulation.Systems.Values[Row].Details.Ibon.Value,
                    this.simulation.Systems.Values[Row].Details.Pop.Value,
                    this.simulation.Systems.Values[Row].Details.RepCur.Value,
                    this.simulation.Systems.Values[Row].Details.RepMax.Value,
                    this.simulation.Systems.Values[Row].Details.Pid.Value
                };
        }
    }
}