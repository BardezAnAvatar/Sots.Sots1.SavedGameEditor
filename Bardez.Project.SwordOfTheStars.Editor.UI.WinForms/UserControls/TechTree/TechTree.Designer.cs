namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Tech_Tree
{
    partial class TechTree
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
            groupBoxTechTreeGraph = new System.Windows.Forms.GroupBox();
            graphTechTree = new Graph.Graph();
            groupBoxDetails = new System.Windows.Forms.GroupBox();
            buttonEnableTech = new System.Windows.Forms.Button();
            techDetails = new TechDetails();
            tableLayoutPanelLayout = new System.Windows.Forms.TableLayoutPanel();
            groupBoxTechTreeGraph.SuspendLayout();
            groupBoxDetails.SuspendLayout();
            tableLayoutPanelLayout.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxTechTreeGraph
            // 
            groupBoxTechTreeGraph.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxTechTreeGraph.Controls.Add(graphTechTree);
            groupBoxTechTreeGraph.Location = new System.Drawing.Point(4, 3);
            groupBoxTechTreeGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxTechTreeGraph.Name = "groupBoxTechTreeGraph";
            groupBoxTechTreeGraph.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxTechTreeGraph.Size = new System.Drawing.Size(928, 187);
            groupBoxTechTreeGraph.TabIndex = 0;
            groupBoxTechTreeGraph.TabStop = false;
            groupBoxTechTreeGraph.Text = "Global Tech Tree";
            // 
            // graphTechTree
            // 
            graphTechTree.AutoScroll = true;
            graphTechTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            graphTechTree.Dock = System.Windows.Forms.DockStyle.Fill;
            graphTechTree.Location = new System.Drawing.Point(4, 19);
            graphTechTree.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            graphTechTree.Name = "graphTechTree";
            graphTechTree.ReadOnly = false;
            graphTechTree.Size = new System.Drawing.Size(920, 165);
            graphTechTree.TabIndex = 0;
            graphTechTree.ClickedTech += graphTechTree_ClickedTech;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(buttonEnableTech);
            groupBoxDetails.Controls.Add(techDetails);
            groupBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxDetails.Location = new System.Drawing.Point(4, 197);
            groupBoxDetails.Margin = new System.Windows.Forms.Padding(4);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new System.Windows.Forms.Padding(4);
            groupBoxDetails.Size = new System.Drawing.Size(928, 202);
            groupBoxDetails.TabIndex = 1;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Selected Technology Details";
            // 
            // buttonEnableTech
            // 
            buttonEnableTech.Location = new System.Drawing.Point(8, 23);
            buttonEnableTech.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonEnableTech.Name = "buttonEnableTech";
            buttonEnableTech.Size = new System.Drawing.Size(88, 27);
            buttonEnableTech.TabIndex = 1;
            buttonEnableTech.Text = "Enable";
            buttonEnableTech.UseVisualStyleBackColor = true;
            buttonEnableTech.Visible = false;
            buttonEnableTech.Click += buttonEnableTech_Click;
            // 
            // techDetails
            // 
            techDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            techDetails.Location = new System.Drawing.Point(7, 23);
            techDetails.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            techDetails.MinimumSize = new System.Drawing.Size(868, 180);
            techDetails.Name = "techDetails";
            techDetails.ReadOnly = false;
            techDetails.Size = new System.Drawing.Size(868, 180);
            techDetails.TabIndex = 0;
            techDetails.ValidTechTree = null;
            techDetails.Visible = false;
            // 
            // tableLayoutPanelLayout
            // 
            tableLayoutPanelLayout.ColumnCount = 1;
            tableLayoutPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelLayout.Controls.Add(groupBoxTechTreeGraph, 0, 0);
            tableLayoutPanelLayout.Controls.Add(groupBoxDetails, 0, 1);
            tableLayoutPanelLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelLayout.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelLayout.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanelLayout.Name = "tableLayoutPanelLayout";
            tableLayoutPanelLayout.RowCount = 2;
            tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            tableLayoutPanelLayout.Size = new System.Drawing.Size(936, 403);
            tableLayoutPanelLayout.TabIndex = 2;
            // 
            // TechTree
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelLayout);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "TechTree";
            Size = new System.Drawing.Size(936, 403);
            groupBoxTechTreeGraph.ResumeLayout(false);
            groupBoxDetails.ResumeLayout(false);
            tableLayoutPanelLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTechTreeGraph;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private TechDetails techDetails;
        private System.Windows.Forms.Button buttonEnableTech;
        private Graph.Graph graphTechTree;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLayout;        
    }
}