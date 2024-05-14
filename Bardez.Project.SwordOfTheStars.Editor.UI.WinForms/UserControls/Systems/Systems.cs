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
        protected Int32 currentIndex;

        public Systems() : base()
        {
            InitializeComponent();
            this.currentIndex = -1;
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

        protected void dataGridViewSystems_CurrentCellChanged(object sender, System.EventArgs e)
        {
            //persist changes
            if (this.currentIndex > -1 && this.dataGridViewSystems.CurrentRow != null)
            {
                this.PersistDetailsChanges(this.currentIndex);
                this.RefreshGridRow(this.currentIndex);
            }

            if (this.dataGridViewSystems.CurrentRow != null)
            {
                //2011-03-09 - I encountered an issue when sorting, where I was relying upon row index
                //  and not the structure array index.

                //this.currentRow = this.dataGridViewSystems.CurrentRow.Index;
                this.currentIndex = (Int32)this.dataGridViewSystems.CurrentRow.Cells["Index"].Value;
                this.RefreshDetails(this.currentIndex);
            }
        }

        protected void dataGridViewSystems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //persist
            this.PersistDetailsChanges(this.currentIndex);
            this.PersistGridChanges(this.currentIndex);

            this.currentIndex = this.GetIndexFromRow(e.RowIndex);

            //refresh
            this.RefreshGridRow(e.RowIndex);
            this.RefreshDetails(this.currentIndex);
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

        protected void PersistGridChanges(Int32 Index)
        {
            DataGridViewRow row = this.GetRowFromIndex(Index);

            //persist data changes
            this.simulation.Systems.Values[Index].SysId.Value = (Int32)(row.Cells["System ID"].Value);
            this.simulation.Systems.Values[Index].Details.Name.Value.CharacterString = row.Cells["Name"].Value as String;
            this.simulation.Systems.Values[Index].Details.Size.Value = (Int32)(row.Cells["Size"].Value);
            this.simulation.Systems.Values[Index].Details.Suit.Value = (Single)(row.Cells["Climate Suitability"].Value);
            this.simulation.Systems.Values[Index].Details.Res.Value = (Int32)(row.Cells["Resources"].Value);
            this.simulation.Systems.Values[Index].Details.Infra.Value = (Single)(row.Cells["Infrastructure"].Value);
            this.simulation.Systems.Values[Index].Details.Ibon.Value = (Single)(row.Cells["Advanced Infrastructure"].Value);
            this.simulation.Systems.Values[Index].Details.Pop.Value = (Int32)(row.Cells["Imperial Population"].Value);
            this.simulation.Systems.Values[Index].Details.RepCur.Value = (Single)(row.Cells["Repair Left"].Value);
            this.simulation.Systems.Values[Index].Details.RepMax.Value = (Single)(row.Cells["Repair per Turn"].Value);
            this.simulation.Systems.Values[Index].Details.Pid.Value = (Int32)(row.Cells["Owner"].Value);

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

        protected void PersistDetailsChanges(Int32 Index)
        {
            this.system_Details.UpdateStruct(this.simulation.Systems.Values[Index]);
        }

        public void PersistBeforeSave()
        {
            if (this.currentIndex > -1 && this.dataGridViewSystems.CurrentRow != null)
                this.PersistDetailsChanges(this.currentIndex);
        }
        #endregion

        #region Refresh
        /// <summary>Refreshes the Player Details control from its data source</summary>
        protected void RefreshDetails(Int32 Index)
        {
            this.system_Details.LoadFromStruct(this.simulation.Systems.Values[Index]);
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
        /// <param name="Index">Index of the data structure to be refreshed to form</param>
        protected void RefreshGridRow(Int32 Index)
        {
            Int32 rowNumber = this.GetAdapterRowNumberFromIndex(Index);

            if (rowNumber < this.adapter.Rows.Count - 1)
            {
                //Populate
                Object[] rowData = GenerateAdapterRow(Index);

                this.adapter.Rows[rowNumber]["Index"] = rowData[0];
                this.adapter.Rows[rowNumber]["System ID"] = rowData[1];
                this.adapter.Rows[rowNumber]["Name"] = rowData[2];
                this.adapter.Rows[rowNumber]["Size"] = rowData[3];
                this.adapter.Rows[rowNumber]["Climate Suitability"] = rowData[4];
                this.adapter.Rows[rowNumber]["Resources"] = rowData[5];
                this.adapter.Rows[rowNumber]["Infrastructure"] = rowData[6];
                this.adapter.Rows[rowNumber]["Advanced Infrastructure"] = rowData[7];
                this.adapter.Rows[rowNumber]["Imperial Population"] = rowData[8];
                this.adapter.Rows[rowNumber]["Repair Left"] = rowData[9];
                this.adapter.Rows[rowNumber]["Repair per Turn"] = rowData[10];
                this.adapter.Rows[rowNumber]["Owner ID"] = rowData[11];
            }
        }
        #endregion

        protected Object[] GenerateAdapterRow(Int32 Index)
        {
            return new Object[]
                {
                    Index,
                    this.simulation.Systems.Values[Index].SysId.Value,
                    this.simulation.Systems.Values[Index].Details.Name.Value.CharacterString,
                    this.simulation.Systems.Values[Index].Details.Size.Value,
                    this.simulation.Systems.Values[Index].Details.Suit.Value,
                    this.simulation.Systems.Values[Index].Details.Res.Value,
                    this.simulation.Systems.Values[Index].Details.Infra.Value,
                    this.simulation.Systems.Values[Index].Details.Ibon.Value,
                    this.simulation.Systems.Values[Index].Details.Pop.Value,
                    this.simulation.Systems.Values[Index].Details.RepCur.Value,
                    this.simulation.Systems.Values[Index].Details.RepMax.Value,
                    this.simulation.Systems.Values[Index].Details.Pid.Value
                };
        }

        protected Int32 GetIndexFromRow(Int32 Row)
        {
            return (Int32)this.dataGridViewSystems.Rows[Row].Cells["Index"].Value;
        }

        protected DataGridViewRow GetRowFromIndex(Int32 Index)
        {
            DataGridViewRow row = null;

            for (Int32 i = 0; i < this.dataGridViewSystems.Rows.Count; ++i)
            {
                if ((Int32)(this.dataGridViewSystems.Rows[i].Cells["Index"].Value) == Index)
                {
                    row = this.dataGridViewSystems.Rows[i];
                    break;
                }
            }

            return row;
        }

        protected Int32 GetAdapterRowNumberFromIndex(Int32 Index)
        {
            Int32 rowNumber = -1;

            if (this.adapter != null)
            {
                for (Int32 i = 0; i < this.adapter.Rows.Count; ++i)
                {
                    if ((Int32)(this.adapter.Rows[i]["Index"]) == Index)
                    {
                        rowNumber = i;
                        break;
                    }
                }
            }

            return rowNumber;
        }

        public void Clear()
        {
            if(this.adapter != null)
                this.adapter.Rows.Clear();
            this.currentIndex = -1;
            this.system_Details.Clear();
        }
    }
}