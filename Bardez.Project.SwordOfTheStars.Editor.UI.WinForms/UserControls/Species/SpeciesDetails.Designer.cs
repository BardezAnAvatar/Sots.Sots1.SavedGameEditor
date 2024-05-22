namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Species
{
    partial class Species_Details
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
            groupBoxSpecies = new System.Windows.Forms.GroupBox();
            dataGridViewSpecies = new System.Windows.Forms.DataGridView();
            groupBoxSpecies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecies).BeginInit();
            SuspendLayout();
            // 
            // groupBoxSpecies
            // 
            groupBoxSpecies.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxSpecies.Controls.Add(dataGridViewSpecies);
            groupBoxSpecies.Location = new System.Drawing.Point(0, 0);
            groupBoxSpecies.Margin = new System.Windows.Forms.Padding(4);
            groupBoxSpecies.Name = "groupBoxSpecies";
            groupBoxSpecies.Padding = new System.Windows.Forms.Padding(4);
            groupBoxSpecies.Size = new System.Drawing.Size(337, 216);
            groupBoxSpecies.TabIndex = 0;
            groupBoxSpecies.TabStop = false;
            groupBoxSpecies.Text = "Species";
            // 
            // dataGridViewSpecies
            // 
            dataGridViewSpecies.AllowUserToAddRows = false;
            dataGridViewSpecies.AllowUserToDeleteRows = false;
            dataGridViewSpecies.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewSpecies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSpecies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSpecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSpecies.Location = new System.Drawing.Point(8, 20);
            dataGridViewSpecies.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewSpecies.Name = "dataGridViewSpecies";
            dataGridViewSpecies.ReadOnly = true;
            dataGridViewSpecies.Size = new System.Drawing.Size(323, 187);
            dataGridViewSpecies.TabIndex = 0;
            dataGridViewSpecies.CellEndEdit += dataGridViewSpecies_CellEndEdit;
            // 
            // Species_Details
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBoxSpecies);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Species_Details";
            Size = new System.Drawing.Size(341, 219);
            groupBoxSpecies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSpecies;
        private System.Windows.Forms.DataGridView dataGridViewSpecies;
    }
}
