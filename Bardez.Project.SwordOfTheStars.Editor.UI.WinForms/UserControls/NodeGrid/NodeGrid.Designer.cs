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
            groupBoxNodeDetails = new System.Windows.Forms.GroupBox();
            node_Grid_Details = new NodeGridDetails();
            groupBoxNodeList = new System.Windows.Forms.GroupBox();
            dataGridViewNodes = new System.Windows.Forms.DataGridView();
            groupBoxNodeDetails.SuspendLayout();
            groupBoxNodeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNodes).BeginInit();
            SuspendLayout();
            // 
            // groupBoxNodeDetails
            // 
            groupBoxNodeDetails.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxNodeDetails.Controls.Add(node_Grid_Details);
            groupBoxNodeDetails.Location = new System.Drawing.Point(0, 192);
            groupBoxNodeDetails.Margin = new System.Windows.Forms.Padding(4);
            groupBoxNodeDetails.Name = "groupBoxNodeDetails";
            groupBoxNodeDetails.Padding = new System.Windows.Forms.Padding(4);
            groupBoxNodeDetails.Size = new System.Drawing.Size(608, 150);
            groupBoxNodeDetails.TabIndex = 0;
            groupBoxNodeDetails.TabStop = false;
            groupBoxNodeDetails.Text = "Node Details";
            // 
            // node_Grid_Details
            // 
            node_Grid_Details.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            node_Grid_Details.Location = new System.Drawing.Point(7, 20);
            node_Grid_Details.Margin = new System.Windows.Forms.Padding(4);
            node_Grid_Details.Name = "node_Grid_Details";
            node_Grid_Details.ReadOnly = false;
            node_Grid_Details.Size = new System.Drawing.Size(584, 128);
            node_Grid_Details.TabIndex = 0;
            // 
            // groupBoxNodeList
            // 
            groupBoxNodeList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxNodeList.Controls.Add(dataGridViewNodes);
            groupBoxNodeList.Location = new System.Drawing.Point(0, 0);
            groupBoxNodeList.Margin = new System.Windows.Forms.Padding(4);
            groupBoxNodeList.Name = "groupBoxNodeList";
            groupBoxNodeList.Padding = new System.Windows.Forms.Padding(4);
            groupBoxNodeList.Size = new System.Drawing.Size(608, 185);
            groupBoxNodeList.TabIndex = 1;
            groupBoxNodeList.TabStop = false;
            groupBoxNodeList.Text = "Node List";
            // 
            // dataGridViewNodes
            // 
            dataGridViewNodes.AllowUserToAddRows = false;
            dataGridViewNodes.AllowUserToDeleteRows = false;
            dataGridViewNodes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNodes.Location = new System.Drawing.Point(8, 20);
            dataGridViewNodes.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewNodes.Name = "dataGridViewNodes";
            dataGridViewNodes.Size = new System.Drawing.Size(592, 156);
            dataGridViewNodes.TabIndex = 0;
            dataGridViewNodes.CellEndEdit += dataGridViewNodes_CellEndEdit;
            dataGridViewNodes.CurrentCellChanged += dataGridViewNodes_CurrentCellChanged;
            // 
            // NodeGrid
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBoxNodeList);
            Controls.Add(groupBoxNodeDetails);
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(608, 342);
            Name = "NodeGrid";
            Size = new System.Drawing.Size(608, 342);
            groupBoxNodeDetails.ResumeLayout(false);
            groupBoxNodeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewNodes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxNodeDetails;
        private NodeGridDetails node_Grid_Details;
        private System.Windows.Forms.GroupBox groupBoxNodeList;
        private System.Windows.Forms.DataGridView dataGridViewNodes;
    }
}
