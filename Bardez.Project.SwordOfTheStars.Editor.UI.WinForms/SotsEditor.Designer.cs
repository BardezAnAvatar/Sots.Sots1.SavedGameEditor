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
            editorSaveGame = new UserControls.Editor.Editor();
            SuspendLayout();
            // 
            // editorSaveGame
            // 
            editorSaveGame.Dock = System.Windows.Forms.DockStyle.Fill;
            editorSaveGame.Location = new System.Drawing.Point(0, 0);
            editorSaveGame.Margin = new System.Windows.Forms.Padding(0);
            editorSaveGame.MinimumSize = new System.Drawing.Size(150, 100);
            editorSaveGame.Name = "editorSaveGame";
            editorSaveGame.ReadOnly = false;
            editorSaveGame.Size = new System.Drawing.Size(999, 586);
            editorSaveGame.TabIndex = 7;
            // 
            // SotsEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(999, 586);
            Controls.Add(editorSaveGame);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(998, 578);
            Name = "SotsEditor";
            Text = "Sword of the Stars - Save Game Editor - Version [SemVer]";
            Load += SotsEditor_Load;
            ResumeLayout(false);
        }

        #endregion

        private UserControls.Editor.Editor editorSaveGame;
    }
}
