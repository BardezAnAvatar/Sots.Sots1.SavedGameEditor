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
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            groupBoxNodeDetails = new System.Windows.Forms.GroupBox();
            nodeGridDetails = new NodeGridDetails();
            groupBoxNodeList = new System.Windows.Forms.GroupBox();
            dataGridViewNodes = new System.Windows.Forms.DataGridView();
            tableLayoutPanel.SuspendLayout();
            groupBoxNodeDetails.SuspendLayout();
            groupBoxNodeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNodes).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(groupBoxNodeDetails, 0, 1);
            tableLayoutPanel.Controls.Add(groupBoxNodeList, 0, 0);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel.Size = new System.Drawing.Size(621, 303);
            tableLayoutPanel.TabIndex = 2;
            // 
            // groupBoxNodeDetails
            // 
            groupBoxNodeDetails.Controls.Add(nodeGridDetails);
            groupBoxNodeDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxNodeDetails.Location = new System.Drawing.Point(4, 155);
            groupBoxNodeDetails.Margin = new System.Windows.Forms.Padding(4);
            groupBoxNodeDetails.Name = "groupBoxNodeDetails";
            groupBoxNodeDetails.Padding = new System.Windows.Forms.Padding(4);
            groupBoxNodeDetails.Size = new System.Drawing.Size(613, 144);
            groupBoxNodeDetails.TabIndex = 3;
            groupBoxNodeDetails.TabStop = false;
            groupBoxNodeDetails.Text = "Node Details";
            // 
            // nodeGridDetails
            // 
            nodeGridDetails.AutoScroll = true;
            nodeGridDetails.AutoScrollMinSize = new System.Drawing.Size(576, 120);
            nodeGridDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            nodeGridDetails.Location = new System.Drawing.Point(4, 20);
            nodeGridDetails.Margin = new System.Windows.Forms.Padding(4);
            nodeGridDetails.Name = "nodeGridDetails";
            nodeGridDetails.ReadOnly = false;
            nodeGridDetails.Size = new System.Drawing.Size(605, 120);
            nodeGridDetails.TabIndex = 0;
            // 
            // groupBoxNodeList
            // 
            groupBoxNodeList.Controls.Add(dataGridViewNodes);
            groupBoxNodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxNodeList.Location = new System.Drawing.Point(4, 4);
            groupBoxNodeList.Margin = new System.Windows.Forms.Padding(4);
            groupBoxNodeList.Name = "groupBoxNodeList";
            groupBoxNodeList.Padding = new System.Windows.Forms.Padding(4);
            groupBoxNodeList.Size = new System.Drawing.Size(613, 143);
            groupBoxNodeList.TabIndex = 2;
            groupBoxNodeList.TabStop = false;
            groupBoxNodeList.Text = "Node List";
            // 
            // dataGridViewNodes
            // 
            dataGridViewNodes.AllowUserToAddRows = false;
            dataGridViewNodes.AllowUserToDeleteRows = false;
            dataGridViewNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewNodes.Location = new System.Drawing.Point(4, 20);
            dataGridViewNodes.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewNodes.Name = "dataGridViewNodes";
            dataGridViewNodes.Size = new System.Drawing.Size(605, 119);
            dataGridViewNodes.TabIndex = 0;
            // 
            // NodeGrid
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "NodeGrid";
            Size = new System.Drawing.Size(621, 303);
            tableLayoutPanel.ResumeLayout(false);
            groupBoxNodeDetails.ResumeLayout(false);
            groupBoxNodeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewNodes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBoxNodeDetails;
        private NodeGridDetails nodeGridDetails;
        private System.Windows.Forms.GroupBox groupBoxNodeList;
        private System.Windows.Forms.DataGridView dataGridViewNodes;
    }
}
