using System.Data;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.Helpers
{
    public static class DataGridViewUtility
    {
        public static DataGridViewTextBoxColumn CreateTextColumn(string SourceColumnName, bool ReadOnly)
        {
            DataGridViewTextBoxColumn textCol = new DataGridViewTextBoxColumn();
            textCol.ReadOnly = ReadOnly;
            textCol.DataPropertyName = SourceColumnName;
            textCol.Name = SourceColumnName;
            textCol.HeaderText = SourceColumnName;
            return textCol;
        }

        public static DataGridViewComboBoxColumn CreateComboColumn(string ColumnName, string ColumnSource, ComboValue[] DataSource, bool ReadOnly)
        {
            return CreateComboColumn(ColumnName, ColumnSource, DataSource, "Display", "Value", ReadOnly);
        }

        public static DataGridViewComboBoxColumn CreateComboColumn(string ColumnName, string ColumnSource, DataTable DataSource, string DisplayCol, string ValueCol, bool ReadOnly)
        {
            return CreateComboColumn(ColumnName, ColumnSource, (object)DataSource, DisplayCol, ValueCol, ReadOnly);
        }

        private static DataGridViewComboBoxColumn CreateComboColumn(string ColumnName, string ColumnSource, object DataSource, string DisplayCol, string ValueCol, bool ReadOnly)
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
            systems.Columns.Add(new DataColumn("Index", typeof(int)));
            systems.Columns.Add(new DataColumn("Name", typeof(string)));

            for (int i = 0; i < SimulationData.Systems.Values.Count; i++)
            {
                systems.Rows.Add(new object[]
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

            players.Columns.Add(new DataColumn("Player ID", typeof(int)));
            players.Columns.Add(new DataColumn("Name", typeof(string)));

            for (int i = 0; i < SimulationData.Players.Values.Count; i++)
            {
                players.Rows.Add(new object[]
                {
                    SimulationData.Players.Values[i].PlayerId.Value,
                    SimulationData.Players.Values[i].Details.PlayerName.Value.CharacterString
                });
            }

            //Invalid
            players.Rows.Add(new object[]
                {
                    0,  //Player ID, not index
                    "Unclaimed"
                });


            return players;
        }
    }

    public class ComboValue
    {
        protected int value;
        protected string display;

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public string Display
        {
            get { return display; }
            set { display = value; }
        }

        public ComboValue()
        {
            display = null;
        }

        public ComboValue(int Value, string Display)
        {
            value = Value;
            display = Display;
        }

        public override string ToString()
        {
            return display;
        }
    }
}
