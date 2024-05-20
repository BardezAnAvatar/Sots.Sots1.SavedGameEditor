namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Node_Grid
{
    partial class NodeGrid
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
            this.groupBoxNodeDetails = new System.Windows.Forms.GroupBox();
            this.node_Grid_Details = new Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Node_Grid.NodeGridDetails();
            this.groupBoxNodeList = new System.Windows.Forms.GroupBox();
            this.dataGridViewNodes = new System.Windows.Forms.DataGridView();
            this.groupBoxNodeDetails.SuspendLayout();
            this.groupBoxNodeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNodes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxNodeDetails
            // 
            this.groupBoxNodeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxNodeDetails.Controls.Add(this.node_Grid_Details);
            this.groupBoxNodeDetails.Location = new System.Drawing.Point(3, 169);
            this.groupBoxNodeDetails.Name = "groupBoxNodeDetails";
            this.groupBoxNodeDetails.Size = new System.Drawing.Size(515, 136);
            this.groupBoxNodeDetails.TabIndex = 0;
            this.groupBoxNodeDetails.TabStop = false;
            this.groupBoxNodeDetails.Text = "Node Details";
            // 
            // node_Grid_Details
            // 
            this.node_Grid_Details.Location = new System.Drawing.Point(6, 19);
            this.node_Grid_Details.Name = "node_Grid_Details";
            this.node_Grid_Details.ReadOnly = false;
            this.node_Grid_Details.Size = new System.Drawing.Size(498, 110);
            this.node_Grid_Details.TabIndex = 0;
            // 
            // groupBoxNodeList
            // 
            this.groupBoxNodeList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNodeList.Controls.Add(this.dataGridViewNodes);
            this.groupBoxNodeList.Location = new System.Drawing.Point(3, 3);
            this.groupBoxNodeList.Name = "groupBoxNodeList";
            this.groupBoxNodeList.Size = new System.Drawing.Size(1040, 160);
            this.groupBoxNodeList.TabIndex = 1;
            this.groupBoxNodeList.TabStop = false;
            this.groupBoxNodeList.Text = "Node List";
            // 
            // dataGridViewNodes
            // 
            this.dataGridViewNodes.AllowUserToAddRows = false;
            this.dataGridViewNodes.AllowUserToDeleteRows = false;
            this.dataGridViewNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNodes.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewNodes.Name = "dataGridViewNodes";
            this.dataGridViewNodes.Size = new System.Drawing.Size(1028, 135);
            this.dataGridViewNodes.TabIndex = 0;
            this.dataGridViewNodes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNodes_CellEndEdit);
            this.dataGridViewNodes.CurrentCellChanged += new System.EventHandler(this.dataGridViewNodes_CurrentCellChanged);
            // 
            // NodeGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxNodeList);
            this.Controls.Add(this.groupBoxNodeDetails);
            this.Name = "NodeGrid";
            this.Size = new System.Drawing.Size(1046, 308);
            this.groupBoxNodeDetails.ResumeLayout(false);
            this.groupBoxNodeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxNodeDetails;
        private NodeGridDetails node_Grid_Details;
        private System.Windows.Forms.GroupBox groupBoxNodeList;
        private System.Windows.Forms.DataGridView dataGridViewNodes;
    }
}
