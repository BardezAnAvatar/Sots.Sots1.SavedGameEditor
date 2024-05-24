namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    partial class PlayerInfo
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
            tabControlPlayer = new System.Windows.Forms.TabControl();
            tabPagePlayerDetails = new System.Windows.Forms.TabPage();
            tabPageHabitability = new System.Windows.Forms.TabPage();
            playerHabitability = new PlayerHabitability();
            tabPageEconomy = new System.Windows.Forms.TabPage();
            playerEconomy = new PlayerEconomy();
            tabPageResearch = new System.Windows.Forms.TabPage();
            playerResearch = new PlayerResearch();
            tabPageIndustry = new System.Windows.Forms.TabPage();
            playerIndustry = new PlayerIndustry();
            tabPageUnknowns = new System.Windows.Forms.TabPage();
            playerUnknowns = new PlayerUnknowns();
            playerDetail = new PlayerDetail();
            tabControlPlayer.SuspendLayout();
            tabPagePlayerDetails.SuspendLayout();
            tabPageHabitability.SuspendLayout();
            tabPageEconomy.SuspendLayout();
            tabPageResearch.SuspendLayout();
            tabPageIndustry.SuspendLayout();
            tabPageUnknowns.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlPlayer
            // 
            tabControlPlayer.Controls.Add(tabPagePlayerDetails);
            tabControlPlayer.Controls.Add(tabPageHabitability);
            tabControlPlayer.Controls.Add(tabPageEconomy);
            tabControlPlayer.Controls.Add(tabPageResearch);
            tabControlPlayer.Controls.Add(tabPageIndustry);
            tabControlPlayer.Controls.Add(tabPageUnknowns);
            tabControlPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPlayer.Location = new System.Drawing.Point(0, 0);
            tabControlPlayer.Name = "tabControlPlayer";
            tabControlPlayer.SelectedIndex = 0;
            tabControlPlayer.Size = new System.Drawing.Size(772, 372);
            tabControlPlayer.TabIndex = 0;
            // 
            // tabPagePlayerDetails
            // 
            tabPagePlayerDetails.BackColor = System.Drawing.SystemColors.Control;
            tabPagePlayerDetails.Controls.Add(playerDetail);
            tabPagePlayerDetails.Location = new System.Drawing.Point(4, 24);
            tabPagePlayerDetails.Margin = new System.Windows.Forms.Padding(4);
            tabPagePlayerDetails.Name = "tabPagePlayerDetails";
            tabPagePlayerDetails.Padding = new System.Windows.Forms.Padding(4);
            tabPagePlayerDetails.Size = new System.Drawing.Size(764, 344);
            tabPagePlayerDetails.TabIndex = 0;
            tabPagePlayerDetails.Text = "Player Details";
            // 
            // tabPageHabitability
            // 
            tabPageHabitability.BackColor = System.Drawing.SystemColors.Control;
            tabPageHabitability.Controls.Add(playerHabitability);
            tabPageHabitability.Location = new System.Drawing.Point(4, 24);
            tabPageHabitability.Margin = new System.Windows.Forms.Padding(4);
            tabPageHabitability.Name = "tabPageHabitability";
            tabPageHabitability.Padding = new System.Windows.Forms.Padding(4);
            tabPageHabitability.Size = new System.Drawing.Size(764, 344);
            tabPageHabitability.TabIndex = 1;
            tabPageHabitability.Text = "Habitability";
            // 
            // playerHabitability
            // 
            playerHabitability.Dock = System.Windows.Forms.DockStyle.Fill;
            playerHabitability.Location = new System.Drawing.Point(4, 4);
            playerHabitability.Margin = new System.Windows.Forms.Padding(4);
            playerHabitability.MinimumSize = new System.Drawing.Size(744, 60);
            playerHabitability.Name = "playerHabitability";
            playerHabitability.ReadOnly = false;
            playerHabitability.Size = new System.Drawing.Size(756, 336);
            playerHabitability.TabIndex = 0;
            // 
            // tabPageEconomy
            // 
            tabPageEconomy.BackColor = System.Drawing.SystemColors.Control;
            tabPageEconomy.Controls.Add(playerEconomy);
            tabPageEconomy.Location = new System.Drawing.Point(4, 24);
            tabPageEconomy.Margin = new System.Windows.Forms.Padding(4);
            tabPageEconomy.Name = "tabPageEconomy";
            tabPageEconomy.Padding = new System.Windows.Forms.Padding(4);
            tabPageEconomy.Size = new System.Drawing.Size(764, 344);
            tabPageEconomy.TabIndex = 2;
            tabPageEconomy.Text = "Economy";
            // 
            // playerEconomy
            // 
            playerEconomy.Dock = System.Windows.Forms.DockStyle.Fill;
            playerEconomy.Location = new System.Drawing.Point(4, 4);
            playerEconomy.Margin = new System.Windows.Forms.Padding(4);
            playerEconomy.MinimumSize = new System.Drawing.Size(552, 60);
            playerEconomy.Name = "playerEconomy";
            playerEconomy.ReadOnly = false;
            playerEconomy.Size = new System.Drawing.Size(756, 336);
            playerEconomy.TabIndex = 0;
            // 
            // tabPageResearch
            // 
            tabPageResearch.BackColor = System.Drawing.SystemColors.Control;
            tabPageResearch.Controls.Add(playerResearch);
            tabPageResearch.Location = new System.Drawing.Point(4, 24);
            tabPageResearch.Margin = new System.Windows.Forms.Padding(4);
            tabPageResearch.Name = "tabPageResearch";
            tabPageResearch.Padding = new System.Windows.Forms.Padding(4);
            tabPageResearch.Size = new System.Drawing.Size(764, 344);
            tabPageResearch.TabIndex = 3;
            tabPageResearch.Text = "Research";
            // 
            // playerResearch
            // 
            playerResearch.Dock = System.Windows.Forms.DockStyle.Fill;
            playerResearch.Location = new System.Drawing.Point(4, 4);
            playerResearch.Margin = new System.Windows.Forms.Padding(4);
            playerResearch.MinimumSize = new System.Drawing.Size(224, 120);
            playerResearch.Name = "playerResearch";
            playerResearch.ReadOnly = false;
            playerResearch.Size = new System.Drawing.Size(756, 336);
            playerResearch.TabIndex = 0;
            // 
            // tabPageIndustry
            // 
            tabPageIndustry.BackColor = System.Drawing.SystemColors.Control;
            tabPageIndustry.Controls.Add(playerIndustry);
            tabPageIndustry.Location = new System.Drawing.Point(4, 24);
            tabPageIndustry.Margin = new System.Windows.Forms.Padding(4);
            tabPageIndustry.Name = "tabPageIndustry";
            tabPageIndustry.Padding = new System.Windows.Forms.Padding(4);
            tabPageIndustry.Size = new System.Drawing.Size(764, 344);
            tabPageIndustry.TabIndex = 4;
            tabPageIndustry.Text = "Industry";
            // 
            // playerIndustry
            // 
            playerIndustry.Dock = System.Windows.Forms.DockStyle.Fill;
            playerIndustry.Location = new System.Drawing.Point(4, 4);
            playerIndustry.Margin = new System.Windows.Forms.Padding(4);
            playerIndustry.MinimumSize = new System.Drawing.Size(258, 92);
            playerIndustry.Name = "playerIndustry";
            playerIndustry.ReadOnly = false;
            playerIndustry.Size = new System.Drawing.Size(756, 336);
            playerIndustry.TabIndex = 0;
            // 
            // tabPageUnknowns
            // 
            tabPageUnknowns.BackColor = System.Drawing.SystemColors.Control;
            tabPageUnknowns.Controls.Add(playerUnknowns);
            tabPageUnknowns.Location = new System.Drawing.Point(4, 24);
            tabPageUnknowns.Margin = new System.Windows.Forms.Padding(4);
            tabPageUnknowns.Name = "tabPageUnknowns";
            tabPageUnknowns.Padding = new System.Windows.Forms.Padding(4);
            tabPageUnknowns.Size = new System.Drawing.Size(764, 344);
            tabPageUnknowns.TabIndex = 5;
            tabPageUnknowns.Text = "Unknowns";
            // 
            // playerUnknowns
            // 
            playerUnknowns.Dock = System.Windows.Forms.DockStyle.Fill;
            playerUnknowns.Location = new System.Drawing.Point(4, 4);
            playerUnknowns.Margin = new System.Windows.Forms.Padding(4);
            playerUnknowns.MinimumSize = new System.Drawing.Size(766, 346);
            playerUnknowns.Name = "playerUnknowns";
            playerUnknowns.ReadOnly = false;
            playerUnknowns.Size = new System.Drawing.Size(766, 346);
            playerUnknowns.TabIndex = 0;
            // 
            // playerDetail
            // 
            playerDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            playerDetail.Location = new System.Drawing.Point(4, 4);
            playerDetail.Margin = new System.Windows.Forms.Padding(4);
            playerDetail.MinimumSize = new System.Drawing.Size(610, 150);
            playerDetail.Name = "playerDetail";
            playerDetail.ReadOnly = false;
            playerDetail.Size = new System.Drawing.Size(756, 336);
            playerDetail.TabIndex = 0;
            // 
            // PlayerInfo
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabControlPlayer);
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(772, 372);
            Name = "PlayerInfo";
            Size = new System.Drawing.Size(772, 372);
            tabControlPlayer.ResumeLayout(false);
            tabPagePlayerDetails.ResumeLayout(false);
            tabPageHabitability.ResumeLayout(false);
            tabPageEconomy.ResumeLayout(false);
            tabPageResearch.ResumeLayout(false);
            tabPageIndustry.ResumeLayout(false);
            tabPageUnknowns.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlPlayer;
        private System.Windows.Forms.TabPage tabPagePlayerDetails;
        private System.Windows.Forms.TabPage tabPageHabitability;
        private System.Windows.Forms.TabPage tabPageEconomy;
        private System.Windows.Forms.TabPage tabPageResearch;
        private System.Windows.Forms.TabPage tabPageIndustry;
        private System.Windows.Forms.TabPage tabPageUnknowns;
        private System.Windows.Forms.GroupBox groupBoxUnknowns;
        private PlayerUnknowns playerUnknowns;
        private PlayerIndustry playerIndustry;
        private PlayerResearch playerResearch;
        private PlayerEconomy playerEconomy;
        private PlayerHabitability playerHabitability;
        private PlayerDetail playerDetail;
    }
}
