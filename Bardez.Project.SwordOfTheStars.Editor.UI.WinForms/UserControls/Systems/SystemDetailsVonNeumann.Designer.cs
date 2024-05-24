namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
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
            checkBoxVonNeumannHomeWorld = new System.Windows.Forms.CheckBox();
            groupBoxDetails = new System.Windows.Forms.GroupBox();
            checkBoxVnpex3 = new System.Windows.Forms.CheckBox();
            checkBoxVnex3 = new System.Windows.Forms.CheckBox();
            checkBoxVnd = new System.Windows.Forms.CheckBox();
            colorDialog1 = new System.Windows.Forms.ColorDialog();
            groupBoxDetails.SuspendLayout();
            SuspendLayout();
            // 
            // checkBoxVonNeumannHomeWorld
            // 
            checkBoxVonNeumannHomeWorld.AutoSize = true;
            checkBoxVonNeumannHomeWorld.Location = new System.Drawing.Point(4, 3);
            checkBoxVonNeumannHomeWorld.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            checkBoxVonNeumannHomeWorld.Name = "checkBoxVonNeumannHomeWorld";
            checkBoxVonNeumannHomeWorld.Size = new System.Drawing.Size(168, 19);
            checkBoxVonNeumannHomeWorld.TabIndex = 0;
            checkBoxVonNeumannHomeWorld.Text = "Von Neumann Homeworld";
            checkBoxVonNeumannHomeWorld.UseVisualStyleBackColor = true;
            checkBoxVonNeumannHomeWorld.CheckedChanged += checkBoxVonNeumannHomeWorld_CheckedChanged;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Controls.Add(checkBoxVnpex3);
            groupBoxDetails.Controls.Add(checkBoxVnex3);
            groupBoxDetails.Controls.Add(checkBoxVnd);
            groupBoxDetails.Location = new System.Drawing.Point(4, 30);
            groupBoxDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            groupBoxDetails.Size = new System.Drawing.Size(175, 104);
            groupBoxDetails.TabIndex = 1;
            groupBoxDetails.TabStop = false;
            groupBoxDetails.Text = "Homeworld Details";
            groupBoxDetails.Visible = false;
            // 
            // checkBoxVnpex3
            // 
            checkBoxVnpex3.AutoSize = true;
            checkBoxVnpex3.Enabled = false;
            checkBoxVnpex3.Location = new System.Drawing.Point(7, 75);
            checkBoxVnpex3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            checkBoxVnpex3.Name = "checkBoxVnpex3";
            checkBoxVnpex3.Size = new System.Drawing.Size(64, 19);
            checkBoxVnpex3.TabIndex = 2;
            checkBoxVnpex3.Text = "vnpex3";
            checkBoxVnpex3.UseVisualStyleBackColor = true;
            // 
            // checkBoxVnex3
            // 
            checkBoxVnex3.AutoSize = true;
            checkBoxVnex3.Enabled = false;
            checkBoxVnex3.Location = new System.Drawing.Point(7, 48);
            checkBoxVnex3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            checkBoxVnex3.Name = "checkBoxVnex3";
            checkBoxVnex3.Size = new System.Drawing.Size(57, 19);
            checkBoxVnex3.TabIndex = 1;
            checkBoxVnex3.Text = "vnex3";
            checkBoxVnex3.UseVisualStyleBackColor = true;
            // 
            // checkBoxVnd
            // 
            checkBoxVnd.AutoSize = true;
            checkBoxVnd.Enabled = false;
            checkBoxVnd.Location = new System.Drawing.Point(7, 22);
            checkBoxVnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            checkBoxVnd.Name = "checkBoxVnd";
            checkBoxVnd.Size = new System.Drawing.Size(46, 19);
            checkBoxVnd.TabIndex = 0;
            checkBoxVnd.Text = "vnd";
            checkBoxVnd.UseVisualStyleBackColor = true;
            // 
            // SystemDetailsVonNeumann
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBoxDetails);
            Controls.Add(checkBoxVonNeumannHomeWorld);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "SystemDetailsVonNeumann";
            Size = new System.Drawing.Size(182, 136);
            groupBoxDetails.ResumeLayout(false);
            groupBoxDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
