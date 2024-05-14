namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls.Tech_Tree
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
            this.groupBoxTechTreeGraph = new System.Windows.Forms.GroupBox();
            this.graphTechTree = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.Graph.Graph();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.buttonEnableTech = new System.Windows.Forms.Button();
            this.techDetails = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.Tech_Tree.TechDetails();
            this.tableLayoutPanelLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxTechTreeGraph.SuspendLayout();
            this.groupBoxDetails.SuspendLayout();
            this.tableLayoutPanelLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTechTreeGraph
            // 
            this.groupBoxTechTreeGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTechTreeGraph.Controls.Add(this.graphTechTree);
            this.groupBoxTechTreeGraph.Location = new System.Drawing.Point(3, 3);
            this.groupBoxTechTreeGraph.Name = "groupBoxTechTreeGraph";
            this.groupBoxTechTreeGraph.Size = new System.Drawing.Size(722, 256);
            this.groupBoxTechTreeGraph.TabIndex = 0;
            this.groupBoxTechTreeGraph.TabStop = false;
            this.groupBoxTechTreeGraph.Text = "Global Tech Tree";
            // 
            // graphTechTree
            // 
            this.graphTechTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.graphTechTree.AutoScroll = true;
            this.graphTechTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphTechTree.Location = new System.Drawing.Point(7, 19);
            this.graphTechTree.Name = "graphTechTree";
            this.graphTechTree.ReadOnly = false;
            this.graphTechTree.Size = new System.Drawing.Size(709, 231);
            this.graphTechTree.TabIndex = 0;
            this.graphTechTree.ClickedTech += new Bardez.Project.SwordOfTheStars.Editor.User_Controls.Graph.Graph.ClickTech(this.graphTechTree_ClickedTech);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetails.Controls.Add(this.buttonEnableTech);
            this.groupBoxDetails.Controls.Add(this.techDetails);
            this.groupBoxDetails.Location = new System.Drawing.Point(3, 265);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(722, 257);
            this.groupBoxDetails.TabIndex = 1;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Selected Technology Details";
            // 
            // buttonEnableTech
            // 
            this.buttonEnableTech.Location = new System.Drawing.Point(7, 20);
            this.buttonEnableTech.Name = "buttonEnableTech";
            this.buttonEnableTech.Size = new System.Drawing.Size(75, 23);
            this.buttonEnableTech.TabIndex = 1;
            this.buttonEnableTech.Text = "Enable";
            this.buttonEnableTech.UseVisualStyleBackColor = true;
            this.buttonEnableTech.Visible = false;
            this.buttonEnableTech.Click += new System.EventHandler(this.buttonEnableTech_Click);
            // 
            // techDetails
            // 
            this.techDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.techDetails.Location = new System.Drawing.Point(6, 19);
            this.techDetails.Name = "techDetails";
            this.techDetails.ReadOnly = false;
            this.techDetails.Size = new System.Drawing.Size(715, 232);
            this.techDetails.TabIndex = 0;
            this.techDetails.ValidTechTree = null;
            this.techDetails.Visible = false;
            // 
            // tableLayoutPanelLayout
            // 
            this.tableLayoutPanelLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelLayout.ColumnCount = 1;
            this.tableLayoutPanelLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLayout.Controls.Add(this.groupBoxTechTreeGraph, 0, 0);
            this.tableLayoutPanelLayout.Controls.Add(this.groupBoxDetails, 0, 1);
            this.tableLayoutPanelLayout.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLayout.Name = "tableLayoutPanelLayout";
            this.tableLayoutPanelLayout.RowCount = 2;
            this.tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLayout.Size = new System.Drawing.Size(728, 525);
            this.tableLayoutPanelLayout.TabIndex = 2;
            // 
            // TechTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelLayout);
            this.Name = "TechTree";
            this.Size = new System.Drawing.Size(734, 531);
            this.groupBoxTechTreeGraph.ResumeLayout(false);
            this.groupBoxDetails.ResumeLayout(false);
            this.tableLayoutPanelLayout.ResumeLayout(false);
            this.ResumeLayout(false);

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