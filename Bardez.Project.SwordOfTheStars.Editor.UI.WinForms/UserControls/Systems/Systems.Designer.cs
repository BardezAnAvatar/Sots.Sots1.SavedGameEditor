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
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            systemDetails = new SystemDetails();
            groupBoxSystems = new System.Windows.Forms.GroupBox();
            dataGridViewSystems = new System.Windows.Forms.DataGridView();
            tableLayoutPanel.SuspendLayout();
            groupBoxSystems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSystems).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(systemDetails, 0, 1);
            tableLayoutPanel.Controls.Add(groupBoxSystems, 0, 0);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 424F));
            tableLayoutPanel.Size = new System.Drawing.Size(939, 498);
            tableLayoutPanel.TabIndex = 3;
            // 
            // systemDetails
            // 
            systemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            systemDetails.Location = new System.Drawing.Point(4, 78);
            systemDetails.Margin = new System.Windows.Forms.Padding(4);
            systemDetails.MaximumSize = new System.Drawing.Size(948, 420);
            systemDetails.Name = "systemDetails";
            systemDetails.ReadOnly = false;
            systemDetails.Size = new System.Drawing.Size(931, 416);
            systemDetails.TabIndex = 4;
            // 
            // groupBoxSystems
            // 
            groupBoxSystems.Controls.Add(dataGridViewSystems);
            groupBoxSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxSystems.Location = new System.Drawing.Point(4, 4);
            groupBoxSystems.Margin = new System.Windows.Forms.Padding(4);
            groupBoxSystems.Name = "groupBoxSystems";
            groupBoxSystems.Padding = new System.Windows.Forms.Padding(4);
            groupBoxSystems.Size = new System.Drawing.Size(931, 66);
            groupBoxSystems.TabIndex = 3;
            groupBoxSystems.TabStop = false;
            groupBoxSystems.Text = "List of Systems";
            // 
            // dataGridViewSystems
            // 
            dataGridViewSystems.AllowUserToAddRows = false;
            dataGridViewSystems.AllowUserToDeleteRows = false;
            dataGridViewSystems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSystems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewSystems.Location = new System.Drawing.Point(4, 20);
            dataGridViewSystems.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewSystems.Name = "dataGridViewSystems";
            dataGridViewSystems.Size = new System.Drawing.Size(923, 42);
            dataGridViewSystems.TabIndex = 0;
            // 
            // Systems
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            Name = "Systems";
            Size = new System.Drawing.Size(939, 498);
            tableLayoutPanel.ResumeLayout(false);
            groupBoxSystems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSystems).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private SystemDetails systemDetails;
        private System.Windows.Forms.GroupBox groupBoxSystems;
        private System.Windows.Forms.DataGridView dataGridViewSystems;
    }
}
