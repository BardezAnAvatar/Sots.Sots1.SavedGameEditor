namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls.Players
{
    partial class Players
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
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.playerDetailsControl = new Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls.Players.PlayerDetails();
            this.dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            this.tabControlPlayer = new System.Windows.Forms.TabControl();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.tabPageTechTree = new System.Windows.Forms.TabPage();
            this.techTree = new Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls.Tech_Tree.TechTree();
            this.groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).BeginInit();
            this.tabControlPlayer.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.tabPageTechTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetails.Controls.Add(this.playerDetailsControl);
            this.groupBoxDetails.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(1104, 519);
            this.groupBoxDetails.TabIndex = 2;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Player Details";
            // 
            // playerDetailsControl
            // 
            this.playerDetailsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playerDetailsControl.Location = new System.Drawing.Point(14, 19);
            this.playerDetailsControl.Name = "playerDetailsControl";
            this.playerDetailsControl.ReadOnly = false;
            this.playerDetailsControl.Size = new System.Drawing.Size(1084, 494);
            this.playerDetailsControl.TabIndex = 1;
            // 
            // dataGridViewPlayers
            // 
            this.dataGridViewPlayers.AllowUserToAddRows = false;
            this.dataGridViewPlayers.AllowUserToDeleteRows = false;
            this.dataGridViewPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlayers.Location = new System.Drawing.Point(6, 0);
            this.dataGridViewPlayers.Name = "dataGridViewPlayers";
            this.dataGridViewPlayers.Size = new System.Drawing.Size(1114, 256);
            this.dataGridViewPlayers.TabIndex = 0;
            this.dataGridViewPlayers.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPlayers_CellEndEdit);
            this.dataGridViewPlayers.CurrentCellChanged += new System.EventHandler(this.dataGridViewPlayers_CurrentCellChanged);
            // 
            // tabControlPlayer
            // 
            this.tabControlPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPlayer.Controls.Add(this.tabPageDetails);
            this.tabControlPlayer.Controls.Add(this.tabPageTechTree);
            this.tabControlPlayer.Location = new System.Drawing.Point(6, 262);
            this.tabControlPlayer.Name = "tabControlPlayer";
            this.tabControlPlayer.SelectedIndex = 0;
            this.tabControlPlayer.Size = new System.Drawing.Size(1124, 557);
            this.tabControlPlayer.TabIndex = 3;
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDetails.Controls.Add(this.groupBoxDetails);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(1116, 531);
            this.tabPageDetails.TabIndex = 0;
            this.tabPageDetails.Text = "Details";
            // 
            // tabPageTechTree
            // 
            this.tabPageTechTree.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTechTree.Controls.Add(this.techTree);
            this.tabPageTechTree.Location = new System.Drawing.Point(4, 22);
            this.tabPageTechTree.Name = "tabPageTechTree";
            this.tabPageTechTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTechTree.Size = new System.Drawing.Size(1116, 531);
            this.tabPageTechTree.TabIndex = 1;
            this.tabPageTechTree.Text = "Tech Tree";
            // 
            // techTree
            // 
            this.techTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.techTree.Location = new System.Drawing.Point(6, 6);
            this.techTree.Name = "techTree";
            this.techTree.Player = null;
            this.techTree.ReadOnly = false;
            this.techTree.Size = new System.Drawing.Size(1104, 519);
            this.techTree.TabIndex = 0;
            this.techTree.ValidTechTree = null;
            // 
            // Players
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlPlayer);
            this.Controls.Add(this.dataGridViewPlayers);
            this.MinimumSize = new System.Drawing.Size(1130, 822);
            this.Name = "Players";
            this.Size = new System.Drawing.Size(1130, 822);
            this.groupBoxDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlayers)).EndInit();
            this.tabControlPlayer.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.tabPageTechTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPlayers;
        private PlayerDetails playerDetailsControl;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.TabControl tabControlPlayer;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TabPage tabPageTechTree;
        private Tech_Tree.TechTree techTree;
    }
}
