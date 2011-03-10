using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;

namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls.User_Control
{
    public static class DataGridViewUtility
    {
        public static DataGridViewTextBoxColumn CreateTextColumn(String SourceColumnName, Boolean ReadOnly)
        {
            DataGridViewTextBoxColumn textCol = new DataGridViewTextBoxColumn();
            textCol.ReadOnly = ReadOnly;
            textCol.DataPropertyName = SourceColumnName;
            textCol.Name = SourceColumnName;
            textCol.HeaderText = SourceColumnName;
            return textCol;
        }

        public static DataGridViewComboBoxColumn CreateComboColumn(String ColumnName, String ColumnSource, ComboValue[] DataSource, Boolean ReadOnly)
        {
            return CreateComboColumn(ColumnName, ColumnSource, DataSource, "Display", "Value", ReadOnly);
        }

        public static DataGridViewComboBoxColumn CreateComboColumn(String ColumnName, String ColumnSource, DataTable DataSource, String DisplayCol, String ValueCol, Boolean ReadOnly)
        {
            return CreateComboColumn(ColumnName, ColumnSource, (Object)DataSource, DisplayCol, ValueCol, ReadOnly);
        }

        private static DataGridViewComboBoxColumn CreateComboColumn(String ColumnName, String ColumnSource, Object DataSource, String DisplayCol, String ValueCol, Boolean ReadOnly)
        {
            DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
            comboCol.ReadOnly = ReadOnly;
            comboCol.DataPropertyName = ColumnSource;   //source data
            comboCol.DataSource = DataSource;
            comboCol.ValueMember = ValueCol;
            comboCol.DisplayMember = DisplayCol;
            comboCol.Name = ColumnName;
            comboCol.HeaderText = ColumnName;
            comboCol.SortMode = DataGridViewColumnSortMode.Automatic;
            return comboCol;
        }

        public static DataTable GetSystemData(SimSaveStruct SimulationData)
        {
            DataTable systems = new DataTable("Systems");
            systems.Columns.Add(new DataColumn("Index", typeof(Int32)));
            systems.Columns.Add(new DataColumn("Name", typeof(String)));

            for (Int32 i = 0; i < SimulationData.Systems.Values.Count; i++)
            {
                systems.Rows.Add(new Object[]
                {
                    i,
                    SimulationData.Systems.Values[i].Details.Name.Value.CharacterString
                });
            }

            return systems;
        }

        public static DataTable GetPlayerData(SimSaveStruct SimulationData)
        {
            DataTable players = new DataTable("Players");
            //SimulationData.Players.Values[0].PlayerId

            players.Columns.Add(new DataColumn("Player ID", typeof(Int32)));
            players.Columns.Add(new DataColumn("Name", typeof(String)));

            for (Int32 i = 0; i < SimulationData.Players.Values.Count; i++)
            {
                players.Rows.Add(new Object[]
                {
                    SimulationData.Players.Values[i].PlayerId.Value,
                    SimulationData.Players.Values[i].Details.PlayerName.Value.CharacterString
                });
            }

            //Invalid
            players.Rows.Add(new Object[]
                {
                    0,  //Player ID, not index
                    "Unclaimed"
                });


            return players;
        }
    }

    public class ComboValue
    {
        protected Int32 value;
        protected String display;

        public Int32 Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public String Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public ComboValue()
        {
            this.display = null;
        }

        public ComboValue(Int32 Value, String Display)
        {
            this.value = Value;
            this.display = Display;
        }

        public override string ToString()
        {
            return this.display;
        }
    }
}
