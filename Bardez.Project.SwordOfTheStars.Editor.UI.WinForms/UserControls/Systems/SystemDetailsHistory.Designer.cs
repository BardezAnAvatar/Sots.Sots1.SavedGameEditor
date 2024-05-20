namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
{
    partial class SystemDetailsHistory
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
            this.groupBoxCurrent = new System.Windows.Forms.GroupBox();
            this.system_Details_History_Data_Current = new Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.SystemDetailsHistoryData();
            this.groupBoxPrevious = new System.Windows.Forms.GroupBox();
            this.system_Details_History_Data_Previous = new Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.SystemDetailsHistoryData();
            this.groupBoxCurrent.SuspendLayout();
            this.groupBoxPrevious.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCurrent
            // 
            this.groupBoxCurrent.Controls.Add(this.system_Details_History_Data_Current);
            this.groupBoxCurrent.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCurrent.Name = "groupBoxCurrent";
            this.groupBoxCurrent.Size = new System.Drawing.Size(309, 273);
            this.groupBoxCurrent.TabIndex = 0;
            this.groupBoxCurrent.TabStop = false;
            this.groupBoxCurrent.Text = "Current";
            // 
            // system_Details_History_Data_Current
            // 
            this.system_Details_History_Data_Current.Location = new System.Drawing.Point(6, 19);
            this.system_Details_History_Data_Current.Name = "system_Details_History_Data_Current";
            this.system_Details_History_Data_Current.Size = new System.Drawing.Size(296, 249);
            this.system_Details_History_Data_Current.TabIndex = 0;
            // 
            // groupBoxPrevious
            // 
            this.groupBoxPrevious.Controls.Add(this.system_Details_History_Data_Previous);
            this.groupBoxPrevious.Location = new System.Drawing.Point(318, 3);
            this.groupBoxPrevious.Name = "groupBoxPrevious";
            this.groupBoxPrevious.Size = new System.Drawing.Size(311, 273);
            this.groupBoxPrevious.TabIndex = 0;
            this.groupBoxPrevious.TabStop = false;
            this.groupBoxPrevious.Text = "Previous";
            // 
            // system_Details_History_Data_Previous
            // 
            this.system_Details_History_Data_Previous.Enabled = false;
            this.system_Details_History_Data_Previous.Location = new System.Drawing.Point(9, 18);
            this.system_Details_History_Data_Previous.Name = "system_Details_History_Data_Previous";
            this.system_Details_History_Data_Previous.Size = new System.Drawing.Size(296, 249);
            this.system_Details_History_Data_Previous.TabIndex = 0;
            // 
            // System_Details_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxPrevious);
            this.Controls.Add(this.groupBoxCurrent);
            this.Name = "System_Details_History";
            this.Size = new System.Drawing.Size(632, 281);
            this.groupBoxCurrent.ResumeLayout(false);
            this.groupBoxPrevious.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCurrent;
        private System.Windows.Forms.GroupBox groupBoxPrevious;
        private SystemDetailsHistoryData system_Details_History_Data_Current;
        private SystemDetailsHistoryData system_Details_History_Data_Previous;
    }
}
