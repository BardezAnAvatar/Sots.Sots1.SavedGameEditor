namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls
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
            this.system_Details = new Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls.SystemDetails();
            this.groupBoxSystems = new System.Windows.Forms.GroupBox();
            this.dataGridViewSystems = new System.Windows.Forms.DataGridView();
            this.groupBoxSystems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSystems)).BeginInit();
            this.SuspendLayout();
            // 
            // system_Details
            // 
            this.system_Details.Location = new System.Drawing.Point(3, 207);
            this.system_Details.Name = "system_Details";
            this.system_Details.ReadOnly = false;
            this.system_Details.Size = new System.Drawing.Size(807, 598);
            this.system_Details.TabIndex = 0;
            // 
            // groupBoxSystems
            // 
            this.groupBoxSystems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSystems.Controls.Add(this.dataGridViewSystems);
            this.groupBoxSystems.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSystems.Name = "groupBoxSystems";
            this.groupBoxSystems.Size = new System.Drawing.Size(1025, 192);
            this.groupBoxSystems.TabIndex = 2;
            this.groupBoxSystems.TabStop = false;
            this.groupBoxSystems.Text = "List of Systems";
            // 
            // dataGridViewSystems
            // 
            this.dataGridViewSystems.AllowUserToAddRows = false;
            this.dataGridViewSystems.AllowUserToDeleteRows = false;
            this.dataGridViewSystems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSystems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSystems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSystems.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewSystems.Name = "dataGridViewSystems";
            this.dataGridViewSystems.Size = new System.Drawing.Size(1012, 166);
            this.dataGridViewSystems.TabIndex = 0;
            this.dataGridViewSystems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSystems_CellEndEdit);
            this.dataGridViewSystems.CurrentCellChanged += new System.EventHandler(this.dataGridViewSystems_CurrentCellChanged);
            // 
            // Systems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxSystems);
            this.Controls.Add(this.system_Details);
            this.Name = "Systems";
            this.Size = new System.Drawing.Size(1031, 808);
            this.groupBoxSystems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSystems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SystemDetails system_Details;
        private System.Windows.Forms.GroupBox groupBoxSystems;
        private System.Windows.Forms.DataGridView dataGridViewSystems;
    }
}
