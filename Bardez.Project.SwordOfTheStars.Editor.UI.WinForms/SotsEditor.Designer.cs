namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms
{
    partial class SotsEditor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SotsEditor));
            this.editorSaveGame = new Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Editor.Editor();
            this.SuspendLayout();
            // 
            // editorSaveGame
            // 
            this.editorSaveGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorSaveGame.Location = new System.Drawing.Point(-2, -2);
            this.editorSaveGame.Margin = new System.Windows.Forms.Padding(0);
            this.editorSaveGame.MinimumSize = new System.Drawing.Size(1725, 1385);
            this.editorSaveGame.Name = "editorSaveGame";
            this.editorSaveGame.ReadOnly = false;
            this.editorSaveGame.Size = new System.Drawing.Size(1725, 1431);
            this.editorSaveGame.TabIndex = 7;
            // 
            // SotsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1724, 1170);
            this.Controls.Add(this.editorSaveGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1736, 1138);
            this.Name = "SotsEditor";
            this.Text = "Sword of the Stars - Save Game Editor - Version [SemVer]";
            this.Load += new System.EventHandler(this.SotsEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Editor.Editor editorSaveGame;
    }
}
