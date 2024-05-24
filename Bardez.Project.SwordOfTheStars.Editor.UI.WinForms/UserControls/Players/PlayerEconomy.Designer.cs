namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    partial class PlayerEconomy
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
            textBoxPvSav = new System.Windows.Forms.TextBox();
            labelPvSav = new System.Windows.Forms.Label();
            textBoxSav = new System.Windows.Forms.TextBox();
            labelSav = new System.Windows.Forms.Label();
            checkBoxCnRad = new System.Windows.Forms.CheckBox();
            checkBoxCnTrd = new System.Windows.Forms.CheckBox();
            textBoxIncMod = new System.Windows.Forms.TextBox();
            labelIncMod = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // textBoxPvSav
            // 
            textBoxPvSav.Enabled = false;
            textBoxPvSav.Location = new System.Drawing.Point(433, 2);
            textBoxPvSav.Margin = new System.Windows.Forms.Padding(4);
            textBoxPvSav.Name = "textBoxPvSav";
            textBoxPvSav.Size = new System.Drawing.Size(116, 23);
            textBoxPvSav.TabIndex = 205;
            // 
            // labelPvSav
            // 
            labelPvSav.AutoSize = true;
            labelPvSav.Location = new System.Drawing.Point(334, 6);
            labelPvSav.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelPvSav.Name = "labelPvSav";
            labelPvSav.Size = new System.Drawing.Size(95, 15);
            labelPvSav.TabIndex = 200;
            labelPvSav.Text = "Previous Savings";
            // 
            // textBoxSav
            // 
            textBoxSav.Location = new System.Drawing.Point(202, 2);
            textBoxSav.Margin = new System.Windows.Forms.Padding(4);
            textBoxSav.Name = "textBoxSav";
            textBoxSav.Size = new System.Drawing.Size(116, 23);
            textBoxSav.TabIndex = 105;
            // 
            // labelSav
            // 
            labelSav.AutoSize = true;
            labelSav.Location = new System.Drawing.Point(105, 6);
            labelSav.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSav.Name = "labelSav";
            labelSav.Size = new System.Drawing.Size(93, 15);
            labelSav.TabIndex = 100;
            labelSav.Text = "Imperial Savings";
            // 
            // checkBoxCnRad
            // 
            checkBoxCnRad.AutoSize = true;
            checkBoxCnRad.Location = new System.Drawing.Point(9, 35);
            checkBoxCnRad.Margin = new System.Windows.Forms.Padding(4);
            checkBoxCnRad.Name = "checkBoxCnRad";
            checkBoxCnRad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            checkBoxCnRad.Size = new System.Drawing.Size(73, 19);
            checkBoxCnRad.TabIndex = 10;
            checkBoxCnRad.Text = "Can Raid";
            checkBoxCnRad.UseVisualStyleBackColor = true;
            // 
            // checkBoxCnTrd
            // 
            checkBoxCnTrd.AutoSize = true;
            checkBoxCnTrd.Location = new System.Drawing.Point(4, 4);
            checkBoxCnTrd.Margin = new System.Windows.Forms.Padding(4);
            checkBoxCnTrd.Name = "checkBoxCnTrd";
            checkBoxCnTrd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            checkBoxCnTrd.Size = new System.Drawing.Size(78, 19);
            checkBoxCnTrd.TabIndex = 0;
            checkBoxCnTrd.Text = "Can Trade";
            checkBoxCnTrd.UseVisualStyleBackColor = true;
            // 
            // textBoxIncMod
            // 
            textBoxIncMod.Location = new System.Drawing.Point(202, 33);
            textBoxIncMod.Margin = new System.Windows.Forms.Padding(4);
            textBoxIncMod.Name = "textBoxIncMod";
            textBoxIncMod.Size = new System.Drawing.Size(116, 23);
            textBoxIncMod.TabIndex = 105;
            // 
            // labelIncMod
            // 
            labelIncMod.AutoSize = true;
            labelIncMod.Location = new System.Drawing.Point(103, 37);
            labelIncMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelIncMod.Name = "labelIncMod";
            labelIncMod.Size = new System.Drawing.Size(95, 15);
            labelIncMod.TabIndex = 110;
            labelIncMod.Text = "Income Modifier";
            // 
            // PlayerEconomy
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(textBoxPvSav);
            Controls.Add(labelPvSav);
            Controls.Add(textBoxSav);
            Controls.Add(labelSav);
            Controls.Add(checkBoxCnRad);
            Controls.Add(checkBoxCnTrd);
            Controls.Add(textBoxIncMod);
            Controls.Add(labelIncMod);
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(552, 60);
            Name = "PlayerEconomy";
            Size = new System.Drawing.Size(552, 60);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPvSav;
        private System.Windows.Forms.Label labelPvSav;
        private System.Windows.Forms.TextBox textBoxSav;
        private System.Windows.Forms.Label labelSav;
        private System.Windows.Forms.CheckBox checkBoxCnRad;
        private System.Windows.Forms.CheckBox checkBoxCnTrd;
        private System.Windows.Forms.TextBox textBoxIncMod;
        private System.Windows.Forms.Label labelIncMod;
    }
}
