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
            this.groupBoxSpecies = new System.Windows.Forms.GroupBox();
            this.dataGridViewSpecies = new System.Windows.Forms.DataGridView();
            this.groupBoxSpecies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecies)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxSpecies
            // 
            this.groupBoxSpecies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSpecies.Controls.Add(this.dataGridViewSpecies);
            this.groupBoxSpecies.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSpecies.Name = "groupBoxSpecies";
            this.groupBoxSpecies.Size = new System.Drawing.Size(289, 187);
            this.groupBoxSpecies.TabIndex = 0;
            this.groupBoxSpecies.TabStop = false;
            this.groupBoxSpecies.Text = "Species";
            // 
            // dataGridViewSpecies
            // 
            this.dataGridViewSpecies.AllowUserToAddRows = false;
            this.dataGridViewSpecies.AllowUserToDeleteRows = false;
            this.dataGridViewSpecies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSpecies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSpecies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewSpecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpecies.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewSpecies.Name = "dataGridViewSpecies";
            this.dataGridViewSpecies.ReadOnly = true;
            this.dataGridViewSpecies.Size = new System.Drawing.Size(277, 162);
            this.dataGridViewSpecies.TabIndex = 0;
            this.dataGridViewSpecies.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpecies_CellEndEdit);
            // 
            // Species_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxSpecies);
            this.Name = "Species_Details";
            this.Size = new System.Drawing.Size(292, 190);
            this.groupBoxSpecies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpecies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSpecies;
        private System.Windows.Forms.DataGridView dataGridViewSpecies;
    }
}
