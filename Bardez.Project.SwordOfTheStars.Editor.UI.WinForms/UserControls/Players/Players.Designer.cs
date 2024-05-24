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
            dataGridViewPlayers = new System.Windows.Forms.DataGridView();
            tabControlPlayer = new System.Windows.Forms.TabControl();
            tabPageDetails = new System.Windows.Forms.TabPage();
            playerInfoControl = new PlayerInfo();
            tabPageTechTree = new System.Windows.Forms.TabPage();
            techTree = new Tech_Tree.TechTree();
            tableLayoutPanelSplit = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlayers).BeginInit();
            tabControlPlayer.SuspendLayout();
            tabPageDetails.SuspendLayout();
            tabPageTechTree.SuspendLayout();
            tableLayoutPanelSplit.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewPlayers
            // 
            dataGridViewPlayers.AllowUserToAddRows = false;
            dataGridViewPlayers.AllowUserToDeleteRows = false;
            dataGridViewPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridViewPlayers.Location = new System.Drawing.Point(4, 4);
            dataGridViewPlayers.Margin = new System.Windows.Forms.Padding(4);
            dataGridViewPlayers.Name = "dataGridViewPlayers";
            dataGridViewPlayers.Size = new System.Drawing.Size(1176, 126);
            dataGridViewPlayers.TabIndex = 0;
            dataGridViewPlayers.CellEndEdit += dataGridViewPlayers_CellEndEdit;
            dataGridViewPlayers.CurrentCellChanged += dataGridViewPlayers_CurrentCellChanged;
            // 
            // tabControlPlayer
            // 
            tabControlPlayer.Controls.Add(tabPageDetails);
            tabControlPlayer.Controls.Add(tabPageTechTree);
            tabControlPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPlayer.Location = new System.Drawing.Point(4, 138);
            tabControlPlayer.Margin = new System.Windows.Forms.Padding(4);
            tabControlPlayer.Name = "tabControlPlayer";
            tabControlPlayer.SelectedIndex = 0;
            tabControlPlayer.Size = new System.Drawing.Size(1176, 538);
            tabControlPlayer.TabIndex = 3;
            // 
            // tabPageDetails
            // 
            tabPageDetails.BackColor = System.Drawing.SystemColors.Control;
            tabPageDetails.Controls.Add(playerInfoControl);
            tabPageDetails.Location = new System.Drawing.Point(4, 24);
            tabPageDetails.Margin = new System.Windows.Forms.Padding(4);
            tabPageDetails.Name = "tabPageDetails";
            tabPageDetails.Padding = new System.Windows.Forms.Padding(4);
            tabPageDetails.Size = new System.Drawing.Size(1168, 510);
            tabPageDetails.TabIndex = 0;
            tabPageDetails.Text = "Details";
            // 
            // playerInfoControl
            // 
            playerInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
            playerInfoControl.Location = new System.Drawing.Point(4, 4);
            playerInfoControl.Margin = new System.Windows.Forms.Padding(4);
            playerInfoControl.MinimumSize = new System.Drawing.Size(772, 372);
            playerInfoControl.Name = "playerInfoControl";
            playerInfoControl.ReadOnly = false;
            playerInfoControl.Size = new System.Drawing.Size(1160, 502);
            playerInfoControl.TabIndex = 2;
            // 
            // tabPageTechTree
            // 
            tabPageTechTree.BackColor = System.Drawing.SystemColors.Control;
            tabPageTechTree.Controls.Add(techTree);
            tabPageTechTree.Location = new System.Drawing.Point(4, 24);
            tabPageTechTree.Margin = new System.Windows.Forms.Padding(4);
            tabPageTechTree.Name = "tabPageTechTree";
            tabPageTechTree.Padding = new System.Windows.Forms.Padding(4);
            tabPageTechTree.Size = new System.Drawing.Size(1168, 510);
            tabPageTechTree.TabIndex = 1;
            tabPageTechTree.Text = "Tech Tree";
            // 
            // techTree
            // 
            techTree.Dock = System.Windows.Forms.DockStyle.Fill;
            techTree.Location = new System.Drawing.Point(4, 4);
            techTree.Margin = new System.Windows.Forms.Padding(4);
            techTree.Name = "techTree";
            techTree.Player = null;
            techTree.ReadOnly = false;
            techTree.Size = new System.Drawing.Size(1160, 502);
            techTree.TabIndex = 0;
            techTree.ValidTechTree = null;
            // 
            // tableLayoutPanelSplit
            // 
            tableLayoutPanelSplit.ColumnCount = 1;
            tableLayoutPanelSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSplit.Controls.Add(tabControlPlayer, 0, 1);
            tableLayoutPanelSplit.Controls.Add(dataGridViewPlayers, 0, 0);
            tableLayoutPanelSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelSplit.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelSplit.Margin = new System.Windows.Forms.Padding(4);
            tableLayoutPanelSplit.Name = "tableLayoutPanelSplit";
            tableLayoutPanelSplit.RowCount = 2;
            tableLayoutPanelSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            tableLayoutPanelSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelSplit.Size = new System.Drawing.Size(1184, 680);
            tableLayoutPanelSplit.TabIndex = 4;
            // 
            // Players
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelSplit);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Players";
            Size = new System.Drawing.Size(1184, 680);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlayers).EndInit();
            tabControlPlayer.ResumeLayout(false);
            tabPageDetails.ResumeLayout(false);
            tabPageTechTree.ResumeLayout(false);
            tableLayoutPanelSplit.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPlayers;
        private System.Windows.Forms.TabControl tabControlPlayer;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TabPage tabPageTechTree;
        private Tech_Tree.TechTree techTree;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSplit;
        private PlayerInfo playerInfoControl;
    }
}
