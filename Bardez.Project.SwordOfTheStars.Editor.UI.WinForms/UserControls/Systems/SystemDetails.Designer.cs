namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls
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
            this.system_Details_Misc = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.SystemDetailsMisc();
            this.system_Details_Von_Neumann = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.SystemDetailsVonNeumann();
            this.system_Details_History = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.SystemDetailsHistory();
            this.system_Detail_Summary = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.SystemDetailSummary();
            this.SuspendLayout();
            // 
            // system_Details_Misc1
            // 
            this.system_Details_Misc.Location = new System.Drawing.Point(3, 360);
            this.system_Details_Misc.Name = "system_Details_Misc1";
            this.system_Details_Misc.Size = new System.Drawing.Size(798, 231);
            this.system_Details_Misc.TabIndex = 3;
            // 
            // system_Details_Von_Neumann1
            // 
            this.system_Details_Von_Neumann.Location = new System.Drawing.Point(641, 73);
            this.system_Details_Von_Neumann.Name = "system_Details_Von_Neumann1";
            this.system_Details_Von_Neumann.Size = new System.Drawing.Size(156, 119);
            this.system_Details_Von_Neumann.TabIndex = 2;
            // 
            // system_Details_History1
            // 
            this.system_Details_History.Location = new System.Drawing.Point(3, 73);
            this.system_Details_History.Name = "system_Details_History1";
            this.system_Details_History.Size = new System.Drawing.Size(632, 281);
            this.system_Details_History.TabIndex = 1;
            // 
            // system_Detail_Summary1
            // 
            this.system_Detail_Summary.Location = new System.Drawing.Point(3, 3);
            this.system_Detail_Summary.Name = "system_Detail_Summary1";
            this.system_Detail_Summary.Size = new System.Drawing.Size(762, 64);
            this.system_Detail_Summary.TabIndex = 0;
            // 
            // System_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.system_Details_Misc);
            this.Controls.Add(this.system_Details_Von_Neumann);
            this.Controls.Add(this.system_Details_History);
            this.Controls.Add(this.system_Detail_Summary);
            this.Name = "System_Details";
            this.Size = new System.Drawing.Size(807, 598);
            this.ResumeLayout(false);

        }

        #endregion

        private SystemDetailSummary system_Detail_Summary;
        private SystemDetailsHistory system_Details_History;
        private SystemDetailsVonNeumann system_Details_Von_Neumann;
        private SystemDetailsMisc system_Details_Misc;
    }
}
