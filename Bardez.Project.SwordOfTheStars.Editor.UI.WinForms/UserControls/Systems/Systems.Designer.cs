namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
{
    partial class Systems
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            system_Details = new SystemDetails();
            groupBoxSystems = new System.Windows.Forms.GroupBox();
            dataGridViewSystems = new System.Windows.Forms.DataGridView();
            groupBoxSystems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSystems).BeginInit();
            SuspendLayout();
            // 
            // system_Details
            // 
            system_Details.Location = new System.Drawing.Point(4, 239);
            system_Details.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            system_Details.Name = "system_Details";
            system_Details.ReadOnly = false;
            system_Details.Size = new System.Drawing.Size(941, 690);
            system_Details.TabIndex = 0;
            // 
            // groupBoxSystems
            // 
            groupBoxSystems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxSystems.Controls.Add(dataGridViewSystems);
            groupBoxSystems.Location = new System.Drawing.Point(0, 0);
            groupBoxSystems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxSystems.Name = "groupBoxSystems";
            groupBoxSystems.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxSystems.Size = new System.Drawing.Size(1196, 222);
            groupBoxSystems.TabIndex = 2;
            groupBoxSystems.TabStop = false;
            groupBoxSystems.Text = "List of Systems";
            // 
            // dataGridViewSystems
            // 
            dataGridViewSystems.AllowUserToAddRows = false;
            dataGridViewSystems.AllowUserToDeleteRows = false;
            dataGridViewSystems.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewSystems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSystems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSystems.Location = new System.Drawing.Point(8, 20);
            dataGridViewSystems.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dataGridViewSystems.Name = "dataGridViewSystems";
            dataGridViewSystems.Size = new System.Drawing.Size(1181, 192);
            dataGridViewSystems.TabIndex = 0;
            dataGridViewSystems.CellEndEdit += dataGridViewSystems_CellEndEdit;
            dataGridViewSystems.CurrentCellChanged += dataGridViewSystems_CurrentCellChanged;
            // 
            // Systems
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBoxSystems);
            Controls.Add(system_Details);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Systems";
            Size = new System.Drawing.Size(1203, 932);
            groupBoxSystems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSystems).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SystemDetails system_Details;
        private System.Windows.Forms.GroupBox groupBoxSystems;
        private System.Windows.Forms.DataGridView dataGridViewSystems;
    }
}
