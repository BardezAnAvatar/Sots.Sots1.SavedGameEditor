using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.Resource_Management;
using Bardez.Project.SwordOfTheStars.Editor.User_Controls.User_Control;

namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls.Players
{
    public partial class Players : DisplayUserControl
    {
        protected DataTable adapter;
        protected SaveGameData savegame;
        protected Int32 selectedIndex;


        /// <summary>Public property to access the Tech Tree Graph</summary>
        public Graph.Graph GraphTechTree
        {
            get { return this.techTree.GraphTechTree; }
        }

        /// <summary>Public property to access the joined and computed tech tree</summary>
        public List<JoinedTechnology> ValidTechTree
        {
            get { return this.techTree.ValidTechTree; }
            set { this.techTree.ValidTechTree = value; }
        }


        /// <summary>Default Constructor</summary>
        public Players() : base()
        {
            InitializeComponent();
            this.selectedIndex = -1;
            this.savegame = null;
        }

        public void Clear()
        {
        }


        public void LoadFromStruct(SaveGameData saveData)
        {
            //retain object reference for update
            this.savegame = saveData;

            //Populate adapter columns
            this.adapter = new DataTable("Players");
            this.AttachColumnsToAdapter();

            //popualte adapter
            this.RefreshGrid();

            //more complex bind
            this.dataGridViewPlayers.AutoGenerateColumns = false;
            this.dataGridViewPlayers.DataSource = adapter;
            this.AttachColumnsToDataGridView();     //generate and attach column definitions
            this.dataGridViewPlayers.ScrollBars = ScrollBars.Both;
            this.dataGridViewPlayers.AutoResizeColumns();
            this.dataGridViewPlayers.AllowUserToAddRows = false;
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.dataGridViewPlayers.ReadOnly = ReadOnlyFlag;
            this.playerDetailsControl.ReadOnly = ReadOnlyFlag;
            this.techTree.ReadOnly = ReadOnlyFlag;
        }

        #region Events
        private void dataGridViewPlayers_CurrentCellChanged(object sender, EventArgs e)
        {
            //update data
            if (this.selectedIndex > -1 && this.dataGridViewPlayers.CurrentRow != null)
            {
                this.PersistDetailsChanges();               //persist details                
                this.PersistTechTreeChanges();              //persist tech tree
                this.RefreshGridRow(this.selectedIndex);    //refresh data display
            }

            if (this.dataGridViewPlayers.CurrentRow != null && GetCurrentPlayerRow() != this.selectedIndex)
            {
                //update to new Row
                this.selectedIndex = GetCurrentPlayerRow();
                this.playerDetailsControl.LoadFromStruct(this.savegame.Sim.Players.Values[this.selectedIndex]);
                this.techTree.Player = this.savegame.Sim.Players.Values[this.selectedIndex].Details;

                //clear tech tree details
                this.techTree.ChangePlayer();
            }
        }
        
        private void dataGridViewPlayers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Int32 currentRow = GetCurrentPlayerRow();

            //Persist
            this.PersistDetailsChanges();           //persist details
            this.PersistTechTreeChanges();          //persist tech tree
            this.PersistGridChanges(currentRow);    //update the data for this cell

            //Refresh
            this.RefreshDetails();
            this.RefreshGridRow(currentRow);
        }
        #endregion

        #region Persist
        protected void PersistGridChanges(Int32 Row)
        {
            DataGridViewRow row = this.dataGridViewPlayers.Rows[Row];

            //Name
            this.savegame.Sim.Players.Values[Row].Details.PlayerName.Value.CharacterString = row.Cells["Name"].Value as String;
            
            //Species ID
            this.savegame.Sim.Players.Values[Row].Details.Species.Value = (Int32)(row.Cells["Species"].Value);

            //Difficulty ID
            if(Row < this.savegame.Summary.Players.Length.Value)
                this.savegame.Summary.Players.Values[Row].Slot.Settings.Difficulty.Value = (Int32)(row.Cells["Difficulty"].Value);
            
            //Ideal Climate Suitability
            this.savegame.Sim.Players.Values[Row].Details.IdealSuit.Value = (Single)(row.Cells["Ideal Climate Suitability"].Value);

            //Climate Hazard Tolerance
            this.savegame.Sim.Players.Values[Row].Details.SuitTolerance.Value = (Single)(row.Cells["Climate Hazard Tolerance"].Value);
            
            //Savings
            this.savegame.Sim.Players.Values[Row].Details.Sav.Value = (Int32)(row.Cells["Imperial Savings"].Value);

            //Research Modifier
            this.savegame.Sim.Players.Values[Row].Details.ResModifier.Value = (Single)(row.Cells["Research Modifier"].Value);

            //Research Scale
            this.savegame.Sim.Players.Values[Row].Details.ResScl.Value = (Single)(row.Cells["Research Scale"].Value);

            //Industrial Output Modifier
            this.savegame.Sim.Players.Values[Row].Details.OutMod.Value = (Single)(row.Cells["Industrial Output Modifier"].Value);

            //Industrial Output Reb
            //this.savegame.Sim.Players.Values[Row].Details.RebOutMod.Value = (Single)(row.Cells["Industrial Output Reb"].Value);
            
            //Industrial Output Scale
            //this.savegame.Sim.Players.Values[Row].Details.ScOutMod.Value = (Single)(row.Cells["Industrial Output Scale"].Value);

            //Income Modifier
            this.savegame.Sim.Players.Values[Row].Details.IncMod.Value = (Single)(row.Cells["Income Modifier"].Value);

            //Population Growth Modifier
            this.savegame.Sim.Players.Values[Row].Details.PopMod.Value = (Single)(row.Cells["Population Growth Modifier"].Value);
            
            //Terraforming Modifier
            this.savegame.Sim.Players.Values[Row].Details.TerraMod.Value = (Single)(row.Cells["Terraforming Modifier"].Value);

            //MinPure
            //this.savegame.Sim.Players.Values[Row].Details.MinPure.Value = (Single)(row.Cells["MinPure"].Value);

            //MinRate
            //this.savegame.Sim.Players.Values[Row].Details.MinRate.Value = (Single)(row.Cells["MinRate"].Value);
        }

        protected void PersistDetailsChanges()
        {
            this.playerDetailsControl.UpdateStruct();
        }

        protected void PersistTechTreeChanges()
        {
            this.techTree.UpdateStruct();
        }

        public void PersistBeforeSave()
        {
            if (this.selectedIndex > -1 && this.dataGridViewPlayers.CurrentRow != null)
                this.PersistDetailsChanges();
        }
        #endregion

        #region Refresh
        /// <summary>Refreshes the Player Details control from its data source</summary>
        protected void RefreshDetails()
        {
            this.playerDetailsControl.LoadFromStruct();
        }

        /// <summary>Refreshes the entire dataview grid's data source</summary>
        protected void RefreshGrid()
        {
            //Empty
            this.adapter.Rows.Clear();

            //Populate
            for (Int32 i = 0; i < this.savegame.Sim.Players.Values.Count; i++)
                adapter.Rows.Add(GenerateAdapterRow(i));
        }

        /// <summary>Refreshes a single row's data source</summary>
        /// <param name="Row">Index of the row to be refreshed</param>
        protected void RefreshGridRow(Int32 Row)
        {
            //Populate
            Object[] rowData = GenerateAdapterRow(Row);

            adapter.Rows[Row]["Name"] = rowData[2];
            adapter.Rows[Row]["Species ID"] = rowData[3];
            adapter.Rows[Row]["Species"] = rowData[4];
            adapter.Rows[Row]["Difficulty ID"] = rowData[5];
            adapter.Rows[Row]["Difficulty"] = rowData[6];
            adapter.Rows[Row]["Ideal Climate Suitability"] = rowData[7];
            adapter.Rows[Row]["Climate Hazard Tolerance"] = rowData[8];
            adapter.Rows[Row]["Imperial Savings"] = rowData[9];
            adapter.Rows[Row]["Research Modifier"] = rowData[10];
            adapter.Rows[Row]["Research Scale"] = rowData[11];
            adapter.Rows[Row]["Industrial Output Modifier"] = rowData[12];
            //adapter.Rows[Row]["Industrial Output Reb"] = rowData[13];
            //adapter.Rows[Row]["Industrial Output Scale"] = rowData[14];
            adapter.Rows[Row]["Income Modifier"] = rowData[13];
            adapter.Rows[Row]["Population Growth Modifier"] = rowData[14];
            adapter.Rows[Row]["Terraforming Modifier"] = rowData[15];
            //adapter.Rows[Row]["MinPure"] = rowData[18];
            //adapter.Rows[Row]["MinRate"] = rowData[19];
        }
        #endregion

        #region Protected Helpers
        protected void AttachColumnsToAdapter()
        {
            DataColumn tempAdd = new DataColumn("Index", typeof(Int32));
            tempAdd.ReadOnly = true;
            this.adapter.Columns.Add(tempAdd);
            tempAdd = new DataColumn("Player ID", typeof(Int32));
            tempAdd.ReadOnly = true;
            this.adapter.Columns.Add(tempAdd);
            this.adapter.Columns.Add(new DataColumn("Name", typeof(String)));
            this.adapter.Columns.Add(new DataColumn("Species ID", typeof(Int32)));
            this.adapter.Columns.Add(new DataColumn("Species", typeof(String)));
            this.adapter.Columns.Add(new DataColumn("Difficulty ID", typeof(Int32)));
            this.adapter.Columns.Add(new DataColumn("Difficulty", typeof(String)));
            this.adapter.Columns.Add(new DataColumn("Ideal Climate Suitability", typeof(Single)));
            this.adapter.Columns.Add(new DataColumn("Climate Hazard Tolerance", typeof(Single)));
            this.adapter.Columns.Add(new DataColumn("Imperial Savings", typeof(Int32)));
            this.adapter.Columns.Add(new DataColumn("Research Modifier", typeof(Single)));
            this.adapter.Columns.Add(new DataColumn("Research Scale", typeof(Single)));
            this.adapter.Columns.Add(new DataColumn("Industrial Output Modifier", typeof(Single)));
            //this.adapter.Columns.Add(new DataColumn("Industrial Output Reb", typeof(Single)));
            //this.adapter.Columns.Add(new DataColumn("Industrial Output Scale", typeof(Single)));
            this.adapter.Columns.Add(new DataColumn("Income Modifier", typeof(Single)));
            this.adapter.Columns.Add(new DataColumn("Population Growth Modifier", typeof(Single)));
            this.adapter.Columns.Add(new DataColumn("Terraforming Modifier", typeof(Single)));
            //this.adapter.Columns.Add(new DataColumn("MinPure", typeof(Single)));
            //this.adapter.Columns.Add(new DataColumn("MinRate", typeof(Single)));
        }

        protected void AttachColumnsToDataGridView()
        {
            this.dataGridViewPlayers.Columns.Clear();   //for safety's sake?

            //Index
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Index", true));
            //Player ID
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Player ID", true));
            //Name
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Name", false));
            //Species
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateComboColumn("Species", "Species ID",
                new ComboValue[] { new ComboValue(0, GetSpeciesName(0)), new ComboValue(1, GetSpeciesName(1)), new ComboValue(2, GetSpeciesName(2)), new ComboValue(3, GetSpeciesName(3)), new ComboValue(4, GetSpeciesName(4)), new ComboValue(5, GetSpeciesName(5)), new ComboValue(6, GetSpeciesName(6)) }, false));
            //Difficulty ID
            //this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Difficulty ID", true));
            //Difficulty
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateComboColumn("Difficulty", "Difficulty ID",
                new ComboValue[] { new ComboValue(0, GetDifficulty(0)), new ComboValue(1, GetDifficulty(1)), new ComboValue(2, GetDifficulty(2)), new ComboValue(-1, GetDifficulty(-1)) }, false));
            //Ideal Climate Hazard
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Ideal Climate Suitability", false));
            //Climate Hazard Tolerance
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Climate Hazard Tolerance", false));
            //Imperial Savings
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Imperial Savings", false));
            //Research Modifier
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Research Modifier", false));
            //Research Scale
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Research Scale", false));
            //Industrial Output Modifier
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Industrial Output Modifier", false));
            //Industrial Output Reb
            //this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Industrial Output Reb", false));
            //Industrial Output Scale
            //this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Industrial Output Scale", false));
            //Income Modifier
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Income Modifier", false));
            //Population Growth Modifier
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Population Growth Modifier", false));
            //Terraforming Modifier
            this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("Terraforming Modifier", false));
            //MinPure
            //this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("MinPure", false));
            //MinRate
            //this.dataGridViewPlayers.Columns.Add(DataGridViewUtility.CreateTextColumn("MinRate", false));
        }

        protected String GetSpeciesName(Int32 Species)
        {
            String name;
            switch (Species)
            {
                case 0:
                    name = "Human";
                    break;
                case 1:
                    name = "Hiver";
                    break;
                case 2:
                    name = "Tarka";
                    break;
                case 3:
                    name = "Liir";
                    break;
                case 4:
                    name = "NPC";
                    break;
                case 5:
                    name = "Zuul";
                    break;
                case 6:
                    name = "Morrigi";
                    break;
                default:
                    name = "Invalid";
                    break;
            }

            return name;
        }

        protected String GetDifficulty(Int32 Difficulty)
        {
            String name;
            switch (Difficulty)
            {
                case 0:
                    name = "Easy";
                    break;
                case 1:
                    name = "Normal";
                    break;
                case 2:
                    name = "Difficult";
                    break;
                default:
                    name = "Invalid";
                    break;
            }

            return name;
        }

        protected Int32 GetCurrentPlayerRow()
        {
            return (Int32)this.dataGridViewPlayers.CurrentRow.Cells["Index"].Value;
        }

        protected Object[] GenerateAdapterRow(Int32 Row)
        {
            return new Object[] 
                { Row,
                    this.savegame.Sim.Players.Values[Row].PlayerId.Value,
                    this.savegame.Sim.Players.Values[Row].Details.PlayerName.Value.CharacterString,
                    this.savegame.Sim.Players.Values[Row].Details.Species.Value,
                    GetSpeciesName(this.savegame.Sim.Players.Values[Row].Details.Species.Value),

                    Row < this.savegame.Summary.Players.Values.Count ? this.savegame.Summary.Players.Values[Row].Slot.Settings.Difficulty.Value : -1,
                    Row < this.savegame.Summary.Players.Values.Count ? GetDifficulty(this.savegame.Summary.Players.Values[Row].Slot.Settings.Difficulty.Value) : "N/A",
                
                    this.savegame.Sim.Players.Values[Row].Details.IdealSuit.Value,
                    this.savegame.Sim.Players.Values[Row].Details.SuitTolerance.Value,
                    this.savegame.Sim.Players.Values[Row].Details.Sav.Value,
                    this.savegame.Sim.Players.Values[Row].Details.ResModifier.Value,
                    this.savegame.Sim.Players.Values[Row].Details.ResScl.Value,
                    this.savegame.Sim.Players.Values[Row].Details.OutMod.Value,
                    //this.savegame.Sim.Players.Values[Row].Details.RebOutMod.Value,
                    //this.savegame.Sim.Players.Values[Row].Details.ScOutMod.Value,
                    this.savegame.Sim.Players.Values[Row].Details.IncMod.Value,
                    this.savegame.Sim.Players.Values[Row].Details.PopMod.Value,
                    this.savegame.Sim.Players.Values[Row].Details.TerraMod.Value,
                    //this.savegame.Sim.Players.Values[Row].Details.MinPure.Value,
                    //this.savegame.Sim.Players.Values[Row].Details.MinRate.Value
                };
        }
        #endregion
    }
}