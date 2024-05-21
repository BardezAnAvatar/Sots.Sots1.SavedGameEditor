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
            SuspendLayout();
            // 
            // system_Details_Misc
            // 
            system_Details_Misc.Location = new System.Drawing.Point(4, 403);
            system_Details_Misc.Margin = new System.Windows.Forms.Padding(4);
            system_Details_Misc.Name = "system_Details_Misc";
            system_Details_Misc.ReadOnly = false;
            system_Details_Misc.Size = new System.Drawing.Size(931, 267);
            system_Details_Misc.TabIndex = 3;
            // 
            // system_Details_Von_Neumann
            // 
            system_Details_Von_Neumann.Location = new System.Drawing.Point(748, 72);
            system_Details_Von_Neumann.Margin = new System.Windows.Forms.Padding(4);
            system_Details_Von_Neumann.Name = "system_Details_Von_Neumann";
            system_Details_Von_Neumann.ReadOnly = false;
            system_Details_Von_Neumann.Size = new System.Drawing.Size(182, 137);
            system_Details_Von_Neumann.TabIndex = 2;
            // 
            // system_Details_History
            // 
            system_Details_History.Location = new System.Drawing.Point(4, 72);
            system_Details_History.Margin = new System.Windows.Forms.Padding(4);
            system_Details_History.Name = "system_Details_History";
            system_Details_History.ReadOnly = false;
            system_Details_History.Size = new System.Drawing.Size(737, 324);
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
            // SystemDetails
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(system_Details_Misc);
            Controls.Add(system_Details_Von_Neumann);
            Controls.Add(system_Details_History);
            Controls.Add(system_Detail_Summary);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "SystemDetails";
            Size = new System.Drawing.Size(941, 690);
            ResumeLayout(false);
        }

        #endregion

        private SystemDetailSummary system_Detail_Summary;
        private SystemDetailsHistory system_Details_History;
        private SystemDetailsVonNeumann system_Details_Von_Neumann;
        private SystemDetailsMisc system_Details_Misc;
    }
}
