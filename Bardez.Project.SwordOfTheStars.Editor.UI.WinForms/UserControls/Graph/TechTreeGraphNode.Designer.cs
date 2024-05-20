namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Graph
{
    partial class TechTreeGraphNode
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
            this.labelTechName = new System.Windows.Forms.Label();
            this.pictureBoxTechImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTechImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTechName
            // 
            this.labelTechName.AutoSize = true;
            this.labelTechName.Location = new System.Drawing.Point(3, 70);
            this.labelTechName.Name = "labelTechName";
            this.labelTechName.Size = new System.Drawing.Size(69, 13);
            this.labelTechName.TabIndex = 0;
            this.labelTechName.Text = "[Tech Name]";
            this.labelTechName.TextChanged += new System.EventHandler(this.labelTechName_TextChanged);
            this.labelTechName.Click += new System.EventHandler(this.labelTechName_Click);
            this.labelTechName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTechName_MouseDown);
            this.labelTechName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTechName_MouseMove);
            this.labelTechName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelTechName_MouseUp);
            // 
            // pictureBoxTechImage
            // 
            this.pictureBoxTechImage.Location = new System.Drawing.Point(5, 3);
            this.pictureBoxTechImage.Name = "pictureBoxTechImage";
            this.pictureBoxTechImage.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxTechImage.TabIndex = 1;
            this.pictureBoxTechImage.TabStop = false;
            this.pictureBoxTechImage.Click += new System.EventHandler(this.pictureBoxTechImage_Click);
            this.pictureBoxTechImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTechImage_MouseDown);
            this.pictureBoxTechImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTechImage_MouseMove);
            this.pictureBoxTechImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxTechImage_MouseUp);
            // 
            // TechTreeGraphNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBoxTechImage);
            this.Controls.Add(this.labelTechName);
            this.Name = "TechTreeGraphNode";
            this.Size = new System.Drawing.Size(75, 89);
            this.SizeChanged += new System.EventHandler(this.TechTreeGraphNode_SizeChanged);
            this.Click += new System.EventHandler(this.TechTreeGraphNode_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TechTreeGraphNode_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TechTreeGraphNode_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TechTreeGraphNode_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTechImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTechName;
        private System.Windows.Forms.PictureBox pictureBoxTechImage;
    }
}
