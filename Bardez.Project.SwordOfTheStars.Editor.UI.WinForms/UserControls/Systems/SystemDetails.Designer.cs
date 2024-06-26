namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
{
    partial class SystemDetails
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
            tabControlDetails = new System.Windows.Forms.TabControl();
            tabPageHistory = new System.Windows.Forms.TabPage();
            systemDetailsVonNeumann = new SystemDetailsVonNeumann();
            systemDetailsHistory = new SystemDetailsHistory();
            tabPageMisc = new System.Windows.Forms.TabPage();
            systemDetailsMisc = new SystemDetailsMisc();
            systemDetailSummary = new SystemDetailSummary();
            tableLayoutPanel.SuspendLayout();
            tabControlDetails.SuspendLayout();
            tabPageHistory.SuspendLayout();
            tabPageMisc.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(tabControlDetails, 0, 1);
            tableLayoutPanel.Controls.Add(systemDetailSummary, 0, 0);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.Size = new System.Drawing.Size(948, 420);
            tableLayoutPanel.TabIndex = 5;
            // 
            // tabControlDetails
            // 
            tabControlDetails.Controls.Add(tabPageHistory);
            tabControlDetails.Controls.Add(tabPageMisc);
            tabControlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlDetails.Location = new System.Drawing.Point(4, 62);
            tabControlDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            tabControlDetails.Name = "tabControlDetails";
            tabControlDetails.Padding = new System.Drawing.Point(0, 0);
            tabControlDetails.SelectedIndex = 0;
            tabControlDetails.Size = new System.Drawing.Size(940, 358);
            tabControlDetails.TabIndex = 5;
            // 
            // tabPageHistory
            // 
            tabPageHistory.AutoScroll = true;
            tabPageHistory.AutoScrollMinSize = new System.Drawing.Size(932, 324);
            tabPageHistory.BackColor = System.Drawing.SystemColors.Control;
            tabPageHistory.Controls.Add(systemDetailsVonNeumann);
            tabPageHistory.Controls.Add(systemDetailsHistory);
            tabPageHistory.Location = new System.Drawing.Point(4, 24);
            tabPageHistory.Margin = new System.Windows.Forms.Padding(4);
            tabPageHistory.Name = "tabPageHistory";
            tabPageHistory.Padding = new System.Windows.Forms.Padding(4);
            tabPageHistory.Size = new System.Drawing.Size(932, 330);
            tabPageHistory.TabIndex = 0;
            tabPageHistory.Text = "History";
            // 
            // systemDetailsVonNeumann
            // 
            systemDetailsVonNeumann.Location = new System.Drawing.Point(744, 0);
            systemDetailsVonNeumann.Margin = new System.Windows.Forms.Padding(4);
            systemDetailsVonNeumann.Name = "systemDetailsVonNeumann";
            systemDetailsVonNeumann.ReadOnly = false;
            systemDetailsVonNeumann.Size = new System.Drawing.Size(182, 137);
            systemDetailsVonNeumann.TabIndex = 2;
            // 
            // systemDetailsHistory
            // 
            systemDetailsHistory.Location = new System.Drawing.Point(0, 0);
            systemDetailsHistory.Margin = new System.Windows.Forms.Padding(4);
            systemDetailsHistory.Name = "systemDetailsHistory";
            systemDetailsHistory.ReadOnly = false;
            systemDetailsHistory.Size = new System.Drawing.Size(737, 322);
            systemDetailsHistory.TabIndex = 1;
            // 
            // tabPageMisc
            // 
            tabPageMisc.AutoScroll = true;
            tabPageMisc.AutoScrollMinSize = new System.Drawing.Size(931, 267);
            tabPageMisc.BackColor = System.Drawing.SystemColors.Control;
            tabPageMisc.Controls.Add(systemDetailsMisc);
            tabPageMisc.Location = new System.Drawing.Point(4, 24);
            tabPageMisc.Margin = new System.Windows.Forms.Padding(4);
            tabPageMisc.Name = "tabPageMisc";
            tabPageMisc.Padding = new System.Windows.Forms.Padding(4);
            tabPageMisc.Size = new System.Drawing.Size(940, 334);
            tabPageMisc.TabIndex = 1;
            tabPageMisc.Text = "Misc.";
            // 
            // systemDetailsMisc
            // 
            systemDetailsMisc.Location = new System.Drawing.Point(0, 0);
            systemDetailsMisc.Margin = new System.Windows.Forms.Padding(4);
            systemDetailsMisc.Name = "systemDetailsMisc";
            systemDetailsMisc.ReadOnly = false;
            systemDetailsMisc.Size = new System.Drawing.Size(931, 267);
            systemDetailsMisc.TabIndex = 3;
            // 
            // systemDetailSummary
            // 
            systemDetailSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            systemDetailSummary.Location = new System.Drawing.Point(4, 4);
            systemDetailSummary.Margin = new System.Windows.Forms.Padding(4);
            systemDetailSummary.Name = "systemDetailSummary";
            systemDetailSummary.ReadOnly = false;
            systemDetailSummary.Size = new System.Drawing.Size(940, 50);
            systemDetailSummary.TabIndex = 1;
            // 
            // SystemDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Margin = new System.Windows.Forms.Padding(0);
            MaximumSize = new System.Drawing.Size(948, 420);
            Name = "SystemDetails";
            Size = new System.Drawing.Size(948, 420);
            tableLayoutPanel.ResumeLayout(false);
            tabControlDetails.ResumeLayout(false);
            tabPageHistory.ResumeLayout(false);
            tabPageMisc.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private SystemDetailSummary systemDetailSummary;
        private System.Windows.Forms.TabControl tabControlDetails;
        private System.Windows.Forms.TabPage tabPageHistory;
        private SystemDetailsVonNeumann systemDetailsVonNeumann;
        private SystemDetailsHistory systemDetailsHistory;
        private System.Windows.Forms.TabPage tabPageMisc;
        private SystemDetailsMisc systemDetailsMisc;
    }
}
