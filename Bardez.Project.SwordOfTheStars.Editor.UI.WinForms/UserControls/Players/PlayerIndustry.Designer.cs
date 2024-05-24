namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Players
{
    partial class PlayerIndustry
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
            textBoxIndOutScl = new System.Windows.Forms.TextBox();
            labelIndOutScl = new System.Windows.Forms.Label();
            textBoxIndOutReb = new System.Windows.Forms.TextBox();
            labelIndOutReb = new System.Windows.Forms.Label();
            textBoxIndOutMod = new System.Windows.Forms.TextBox();
            labelIndOutMod = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // textBoxIndOutScl
            // 
            textBoxIndOutScl.Location = new System.Drawing.Point(139, 66);
            textBoxIndOutScl.Margin = new System.Windows.Forms.Padding(4);
            textBoxIndOutScl.Name = "textBoxIndOutScl";
            textBoxIndOutScl.Size = new System.Drawing.Size(116, 23);
            textBoxIndOutScl.TabIndex = 25;
            // 
            // labelIndOutScl
            // 
            labelIndOutScl.AutoSize = true;
            labelIndOutScl.Location = new System.Drawing.Point(37, 70);
            labelIndOutScl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelIndOutScl.Name = "labelIndOutScl";
            labelIndOutScl.Size = new System.Drawing.Size(98, 15);
            labelIndOutScl.TabIndex = 20;
            labelIndOutScl.Text = "Ind. Output Scale";
            // 
            // textBoxIndOutReb
            // 
            textBoxIndOutReb.Location = new System.Drawing.Point(139, 35);
            textBoxIndOutReb.Margin = new System.Windows.Forms.Padding(4);
            textBoxIndOutReb.Name = "textBoxIndOutReb";
            textBoxIndOutReb.Size = new System.Drawing.Size(116, 23);
            textBoxIndOutReb.TabIndex = 15;
            // 
            // labelIndOutReb
            // 
            labelIndOutReb.AutoSize = true;
            labelIndOutReb.Location = new System.Drawing.Point(2, 39);
            labelIndOutReb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelIndOutReb.Name = "labelIndOutReb";
            labelIndOutReb.Size = new System.Drawing.Size(133, 15);
            labelIndOutReb.TabIndex = 10;
            labelIndOutReb.Text = "Ind. Output Reb(ellion?)";
            // 
            // textBoxIndOutMod
            // 
            textBoxIndOutMod.Location = new System.Drawing.Point(139, 4);
            textBoxIndOutMod.Margin = new System.Windows.Forms.Padding(4);
            textBoxIndOutMod.Name = "textBoxIndOutMod";
            textBoxIndOutMod.Size = new System.Drawing.Size(116, 23);
            textBoxIndOutMod.TabIndex = 5;
            // 
            // labelIndOutMod
            // 
            labelIndOutMod.AutoSize = true;
            labelIndOutMod.Location = new System.Drawing.Point(19, 8);
            labelIndOutMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelIndOutMod.Name = "labelIndOutMod";
            labelIndOutMod.Size = new System.Drawing.Size(116, 15);
            labelIndOutMod.TabIndex = 0;
            labelIndOutMod.Text = "Ind. Output Modifier";
            // 
            // PlayerIndustry
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new System.Drawing.Size(258, 92);
            Controls.Add(textBoxIndOutScl);
            Controls.Add(labelIndOutScl);
            Controls.Add(textBoxIndOutReb);
            Controls.Add(labelIndOutReb);
            Controls.Add(textBoxIndOutMod);
            Controls.Add(labelIndOutMod);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "PlayerIndustry";
            Size = new System.Drawing.Size(258, 92);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIndOutScl;
        private System.Windows.Forms.Label labelIndOutScl;
        private System.Windows.Forms.TextBox textBoxIndOutReb;
        private System.Windows.Forms.Label labelIndOutReb;
        private System.Windows.Forms.TextBox textBoxIndOutMod;
        private System.Windows.Forms.Label labelIndOutMod;
    }
}
