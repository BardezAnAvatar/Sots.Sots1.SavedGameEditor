namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
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
            groupBoxDetails = new System.Windows.Forms.GroupBox();
            playerDetailsControl = new PlayerDetails();
            dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            tabControlPlayer = new System.Windows.Forms.TabControl();
            tabPageDetails = new System.Windows.Forms.TabPage();
            tabPageTechTree = new System.Windows.Forms.TabPage();
            techTree = new Tech_Tree.TechTree();
            groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlayers).BeginInit();
            tabControlPlayer.SuspendLayout();
            tabPageDetails.SuspendLayout();
            tabPageTechTree.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxDetails.Controls.Add(playerDetailsControl);
            groupBoxDetails.Location = new System.Drawing.Point(7, 7);
            groupBoxDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxDetails.Size = new System.Drawing.Size(1288, 888);
            groupBoxDetails.TabIndex = 2;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Player Details";
            // 
            // playerDetailsControl
            // 
            playerDetailsControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            playerDetailsControl.Location = new System.Drawing.Point(0, 0);
            playerDetailsControl.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            playerDetailsControl.Name = "playerDetailsControl";
            playerDetailsControl.ReadOnly = false;
            playerDetailsControl.Size = new System.Drawing.Size(1150, 488);
            playerDetailsControl.TabIndex = 1;
            // 
            // dataGridViewPlayers
            // 
            dataGridViewPlayers.AllowUserToAddRows = false;
            dataGridViewPlayers.AllowUserToDeleteRows = false;
            dataGridViewPlayers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridViewPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlayers.Location = new System.Drawing.Point(8, 0);
            dataGridViewPlayers.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewPlayers.Name = "dataGridViewPlayers";
            dataGridViewPlayers.Size = new System.Drawing.Size(1300, 109);
            dataGridViewPlayers.TabIndex = 0;
            dataGridViewPlayers.CellEndEdit += dataGridViewPlayers_CellEndEdit;
            dataGridViewPlayers.CurrentCellChanged += dataGridViewPlayers_CurrentCellChanged;
            // 
            // tabControlPlayer
            // 
            tabControlPlayer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControlPlayer.Controls.Add(tabPageDetails);
            tabControlPlayer.Controls.Add(tabPageTechTree);
            tabControlPlayer.Location = new System.Drawing.Point(7, 115);
            tabControlPlayer.Margin = new System.Windows.Forms.Padding(4);
            tabControlPlayer.Name = "tabControlPlayer";
            tabControlPlayer.SelectedIndex = 0;
            tabControlPlayer.Size = new System.Drawing.Size(1311, 932);
            tabControlPlayer.TabIndex = 3;
            // 
            // tabPageDetails
            // 
            tabPageDetails.BackColor = System.Drawing.SystemColors.Control;
            tabPageDetails.Controls.Add(groupBoxDetails);
            tabPageDetails.Location = new System.Drawing.Point(4, 24);
            tabPageDetails.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageDetails.Name = "tabPageDetails";
            tabPageDetails.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageDetails.Size = new System.Drawing.Size(1303, 904);
            tabPageDetails.TabIndex = 0;
            tabPageDetails.Text = "Details";
            // 
            // tabPageTechTree
            // 
            tabPageTechTree.BackColor = System.Drawing.SystemColors.Control;
            tabPageTechTree.Controls.Add(techTree);
            tabPageTechTree.Location = new System.Drawing.Point(4, 24);
            tabPageTechTree.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageTechTree.Name = "tabPageTechTree";
            tabPageTechTree.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPageTechTree.Size = new System.Drawing.Size(1303, 904);
            tabPageTechTree.TabIndex = 1;
            tabPageTechTree.Text = "Tech Tree";
            // 
            // techTree
            // 
            techTree.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            techTree.Location = new System.Drawing.Point(7, 7);
            techTree.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            techTree.Name = "techTree";
            techTree.Player = null;
            techTree.ReadOnly = false;
            techTree.Size = new System.Drawing.Size(1288, 345);
            techTree.TabIndex = 0;
            techTree.ValidTechTree = null;
            // 
            // Players
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabControlPlayer);
            Controls.Add(dataGridViewPlayers);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Players";
            Size = new System.Drawing.Size(1318, 898);
            groupBoxDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlayers).EndInit();
            tabControlPlayer.ResumeLayout(false);
            tabPageDetails.ResumeLayout(false);
            tabPageTechTree.ResumeLayout(false);
            ResumeLayout(false);
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
