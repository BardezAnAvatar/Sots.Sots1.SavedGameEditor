namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls
{
    partial class SystemDetailsVonNeumann
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
            this.checkBoxVonNeumannHomeWorld = new System.Windows.Forms.CheckBox();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.checkBoxVnpex3 = new System.Windows.Forms.CheckBox();
            this.checkBoxVnex3 = new System.Windows.Forms.CheckBox();
            this.checkBoxVnd = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxVonNeumannHomeWorld
            // 
            this.checkBoxVonNeumannHomeWorld.AutoSize = true;
            this.checkBoxVonNeumannHomeWorld.Location = new System.Drawing.Point(3, 3);
            this.checkBoxVonNeumannHomeWorld.Name = "checkBoxVonNeumannHomeWorld";
            this.checkBoxVonNeumannHomeWorld.Size = new System.Drawing.Size(150, 17);
            this.checkBoxVonNeumannHomeWorld.TabIndex = 0;
            this.checkBoxVonNeumannHomeWorld.Text = "Von Neumann Homeworld";
            this.checkBoxVonNeumannHomeWorld.UseVisualStyleBackColor = true;
            this.checkBoxVonNeumannHomeWorld.CheckedChanged += new System.EventHandler(this.checkBoxVonNeumannHomeWorld_CheckedChanged);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.checkBoxVnpex3);
            this.groupBoxDetails.Controls.Add(this.checkBoxVnex3);
            this.groupBoxDetails.Controls.Add(this.checkBoxVnd);
            this.groupBoxDetails.Location = new System.Drawing.Point(3, 26);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(150, 90);
            this.groupBoxDetails.TabIndex = 1;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Homeworld Details";
            this.groupBoxDetails.Visible = false;
            // 
            // checkBoxVnpex3
            // 
            this.checkBoxVnpex3.AutoSize = true;
            this.checkBoxVnpex3.Enabled = false;
            this.checkBoxVnpex3.Location = new System.Drawing.Point(6, 65);
            this.checkBoxVnpex3.Name = "checkBoxVnpex3";
            this.checkBoxVnpex3.Size = new System.Drawing.Size(61, 17);
            this.checkBoxVnpex3.TabIndex = 2;
            this.checkBoxVnpex3.Text = "vnpex3";
            this.checkBoxVnpex3.UseVisualStyleBackColor = true;
            // 
            // checkBoxVnex3
            // 
            this.checkBoxVnex3.AutoSize = true;
            this.checkBoxVnex3.Enabled = false;
            this.checkBoxVnex3.Location = new System.Drawing.Point(6, 42);
            this.checkBoxVnex3.Name = "checkBoxVnex3";
            this.checkBoxVnex3.Size = new System.Drawing.Size(55, 17);
            this.checkBoxVnex3.TabIndex = 1;
            this.checkBoxVnex3.Text = "vnex3";
            this.checkBoxVnex3.UseVisualStyleBackColor = true;
            // 
            // checkBoxVnd
            // 
            this.checkBoxVnd.AutoSize = true;
            this.checkBoxVnd.Enabled = false;
            this.checkBoxVnd.Location = new System.Drawing.Point(6, 19);
            this.checkBoxVnd.Name = "checkBoxVnd";
            this.checkBoxVnd.Size = new System.Drawing.Size(44, 17);
            this.checkBoxVnd.TabIndex = 0;
            this.checkBoxVnd.Text = "vnd";
            this.checkBoxVnd.UseVisualStyleBackColor = true;
            // 
            // System_Details_Von_Neumann
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.checkBoxVonNeumannHomeWorld);
            this.Name = "System_Details_Von_Neumann";
            this.Size = new System.Drawing.Size(156, 119);
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxVonNeumannHomeWorld;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.CheckBox checkBoxVnd;
        private System.Windows.Forms.CheckBox checkBoxVnex3;
        private System.Windows.Forms.CheckBox checkBoxVnpex3;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}
