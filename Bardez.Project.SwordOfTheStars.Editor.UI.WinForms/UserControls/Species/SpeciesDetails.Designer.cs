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
            dataGridViewSpecies = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecies).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSpecies
            // 
            dataGridViewSpecies.AllowUserToAddRows = false;
            dataGridViewSpecies.AllowUserToDeleteRows = false;
            dataGridViewSpecies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSpecies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSpecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSpecies.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewSpecies.Location = new System.Drawing.Point(0, 0);
            dataGridViewSpecies.Margin = new System.Windows.Forms.Padding(8);
            dataGridViewSpecies.Name = "dataGridViewSpecies";
            dataGridViewSpecies.ReadOnly = true;
            dataGridViewSpecies.Size = new System.Drawing.Size(341, 219);
            dataGridViewSpecies.TabIndex = 1;
            // 
            // Species_Details
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(dataGridViewSpecies);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Species_Details";
            Size = new System.Drawing.Size(341, 219);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSpecies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSpecies;
    }
}
