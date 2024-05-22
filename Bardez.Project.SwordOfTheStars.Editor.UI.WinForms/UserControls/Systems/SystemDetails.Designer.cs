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
            system_Details_Misc = new SystemDetailsMisc();
            system_Details_Von_Neumann = new SystemDetailsVonNeumann();
            system_Details_History = new SystemDetailsHistory();
            system_Detail_Summary = new SystemDetailSummary();
            tabControlDetails = new System.Windows.Forms.TabControl();
            tabPageHistory = new System.Windows.Forms.TabPage();
            tabPageMisc = new System.Windows.Forms.TabPage();
            tabControlDetails.SuspendLayout();
            tabPageHistory.SuspendLayout();
            tabPageMisc.SuspendLayout();
            SuspendLayout();
            // 
            // system_Details_Misc
            // 
            system_Details_Misc.Location = new System.Drawing.Point(0, 0);
            system_Details_Misc.Margin = new System.Windows.Forms.Padding(4);
            system_Details_Misc.Name = "system_Details_Misc";
            system_Details_Misc.ReadOnly = false;
            system_Details_Misc.Size = new System.Drawing.Size(931, 267);
            system_Details_Misc.TabIndex = 3;
            // 
            // system_Details_Von_Neumann
            // 
            system_Details_Von_Neumann.Location = new System.Drawing.Point(744, 0);
            system_Details_Von_Neumann.Margin = new System.Windows.Forms.Padding(4);
            system_Details_Von_Neumann.Name = "system_Details_Von_Neumann";
            system_Details_Von_Neumann.ReadOnly = false;
            system_Details_Von_Neumann.Size = new System.Drawing.Size(182, 137);
            system_Details_Von_Neumann.TabIndex = 2;
            // 
            // system_Details_History
            // 
            system_Details_History.Location = new System.Drawing.Point(0, 0);
            system_Details_History.Margin = new System.Windows.Forms.Padding(4);
            system_Details_History.Name = "system_Details_History";
            system_Details_History.ReadOnly = false;
            system_Details_History.Size = new System.Drawing.Size(737, 322);
            system_Details_History.TabIndex = 1;
            // 
            // system_Detail_Summary
            // 
            system_Detail_Summary.Location = new System.Drawing.Point(4, 4);
            system_Detail_Summary.Margin = new System.Windows.Forms.Padding(4);
            system_Detail_Summary.Name = "system_Detail_Summary";
            system_Detail_Summary.ReadOnly = false;
            system_Detail_Summary.Size = new System.Drawing.Size(926, 50);
            system_Detail_Summary.TabIndex = 0;
            // 
            // tabControlDetails
            // 
            tabControlDetails.Controls.Add(tabPageHistory);
            tabControlDetails.Controls.Add(tabPageMisc);
            tabControlDetails.Location = new System.Drawing.Point(0, 62);
            tabControlDetails.Margin = new System.Windows.Forms.Padding(4);
            tabControlDetails.Name = "tabControlDetails";
            tabControlDetails.Padding = new System.Drawing.Point(4, 4);
            tabControlDetails.SelectedIndex = 0;
            tabControlDetails.Size = new System.Drawing.Size(940, 357);
            tabControlDetails.TabIndex = 4;
            // 
            // tabPageHistory
            // 
            tabPageHistory.BackColor = System.Drawing.SystemColors.Control;
            tabPageHistory.Location = new System.Drawing.Point(4, 26);
            tabPageHistory.Margin = new System.Windows.Forms.Padding(4);
            tabPageHistory.Name = "tabPageHistory";
            tabPageHistory.Padding = new System.Windows.Forms.Padding(4);
            tabPageHistory.Size = new System.Drawing.Size(932, 327);
            tabPageHistory.TabIndex = 0;
            tabPageHistory.Text = "History";
            tabPageHistory.Controls.Add(system_Details_Von_Neumann);
            tabPageHistory.Controls.Add(system_Details_History);
            // 
            // tabPageMisc
            // 
            tabPageMisc.BackColor = System.Drawing.SystemColors.Control;
            tabPageMisc.Location = new System.Drawing.Point(4, 26);
            tabPageMisc.Name = "tabPageMisc";
            tabPageMisc.Padding = new System.Windows.Forms.Padding(3);
            tabPageMisc.Size = new System.Drawing.Size(932, 327);
            tabPageMisc.TabIndex = 1;
            tabPageMisc.Text = "Misc.";
            tabPageMisc.Controls.Add(system_Details_Misc);
            // 
            // SystemDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tabControlDetails);
            Controls.Add(system_Detail_Summary);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "SystemDetails";
            Size = new System.Drawing.Size(940, 420);
            tabControlDetails.ResumeLayout(false);
            tabPageHistory.ResumeLayout(false);
            tabPageMisc.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SystemDetailSummary system_Detail_Summary;
        private SystemDetailsHistory system_Details_History;
        private SystemDetailsVonNeumann system_Details_Von_Neumann;
        private SystemDetailsMisc system_Details_Misc;
        private System.Windows.Forms.TabControl tabControlDetails;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.TabPage tabPageMisc;
    }
}
