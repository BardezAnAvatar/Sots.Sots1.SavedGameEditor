namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls.Editor
{
    partial class Editor
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
            this.checkBoxReadOnly = new System.Windows.Forms.CheckBox();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageSpecies = new System.Windows.Forms.TabPage();
            this.speciesDetails = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.Species.Species_Details();
            this.tabPagePlayers = new System.Windows.Forms.TabPage();
            this.playersControl = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.Players.Players();
            this.tabPageSystems = new System.Windows.Forms.TabPage();
            this.systemsControl = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.Systems();
            this.tabPageNodeLines = new System.Windows.Forms.TabPage();
            this.nodeGridControl = new Bardez.Project.SwordOfTheStars.Editor.User_Controls.Node_Grid.NodeGrid();
            this.openFileDialogSaveFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.labelSourceFile = new System.Windows.Forms.Label();
            this.labelSourceFilePath = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.statusStripLoadSave = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarLoadSave = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControlOptions.SuspendLayout();
            this.tabPageSpecies.SuspendLayout();
            this.tabPagePlayers.SuspendLayout();
            this.tabPageSystems.SuspendLayout();
            this.tabPageNodeLines.SuspendLayout();
            this.statusStripLoadSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxReadOnly
            // 
            this.checkBoxReadOnly.AutoSize = true;
            this.checkBoxReadOnly.Location = new System.Drawing.Point(165, 26);
            this.checkBoxReadOnly.Name = "checkBoxReadOnly";
            this.checkBoxReadOnly.Size = new System.Drawing.Size(76, 17);
            this.checkBoxReadOnly.TabIndex = 9;
            this.checkBoxReadOnly.Text = "Read Only";
            this.checkBoxReadOnly.UseVisualStyleBackColor = true;
            this.checkBoxReadOnly.CheckedChanged += new System.EventHandler(this.checkBoxReadOnly_CheckedChanged);
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlOptions.Controls.Add(this.tabPageSpecies);
            this.tabControlOptions.Controls.Add(this.tabPagePlayers);
            this.tabControlOptions.Controls.Add(this.tabPageSystems);
            this.tabControlOptions.Controls.Add(this.tabPageNodeLines);
            this.tabControlOptions.Location = new System.Drawing.Point(3, 51);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(1144, 859);
            this.tabControlOptions.TabIndex = 8;
            // 
            // tabPageSpecies
            // 
            this.tabPageSpecies.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSpecies.Controls.Add(this.speciesDetails);
            this.tabPageSpecies.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpecies.Name = "tabPageSpecies";
            this.tabPageSpecies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecies.Size = new System.Drawing.Size(1136, 833);
            this.tabPageSpecies.TabIndex = 1;
            this.tabPageSpecies.Text = "Species";
            // 
            // speciesDetails
            // 
            this.speciesDetails.Location = new System.Drawing.Point(6, 8);
            this.speciesDetails.Name = "speciesDetails";
            this.speciesDetails.ReadOnly = false;
            this.speciesDetails.Size = new System.Drawing.Size(379, 224);
            this.speciesDetails.TabIndex = 0;
            // 
            // tabPagePlayers
            // 
            this.tabPagePlayers.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePlayers.Controls.Add(this.playersControl);
            this.tabPagePlayers.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlayers.Name = "tabPagePlayers";
            this.tabPagePlayers.Size = new System.Drawing.Size(1136, 833);
            this.tabPagePlayers.TabIndex = 2;
            this.tabPagePlayers.Text = "Players";
            // 
            // playersControl
            // 
            this.playersControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playersControl.Location = new System.Drawing.Point(3, 8);
            this.playersControl.MinimumSize = new System.Drawing.Size(1130, 822);
            this.playersControl.Name = "playersControl";
            this.playersControl.ReadOnly = false;
            this.playersControl.Size = new System.Drawing.Size(1130, 822);
            this.playersControl.TabIndex = 0;
            this.playersControl.ValidTechTree = null;
            // 
            // tabPageSystems
            // 
            this.tabPageSystems.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSystems.Controls.Add(this.systemsControl);
            this.tabPageSystems.Location = new System.Drawing.Point(4, 22);
            this.tabPageSystems.Name = "tabPageSystems";
            this.tabPageSystems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSystems.Size = new System.Drawing.Size(1136, 833);
            this.tabPageSystems.TabIndex = 0;
            this.tabPageSystems.Text = "Systems";
            // 
            // systemsControl
            // 
            this.systemsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.systemsControl.Location = new System.Drawing.Point(3, 6);
            this.systemsControl.Name = "systemsControl";
            this.systemsControl.ReadOnly = true;
            this.systemsControl.Size = new System.Drawing.Size(1127, 824);
            this.systemsControl.TabIndex = 4;
            // 
            // tabPageNodeLines
            // 
            this.tabPageNodeLines.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageNodeLines.Controls.Add(this.nodeGridControl);
            this.tabPageNodeLines.Location = new System.Drawing.Point(4, 22);
            this.tabPageNodeLines.Name = "tabPageNodeLines";
            this.tabPageNodeLines.Size = new System.Drawing.Size(1136, 833);
            this.tabPageNodeLines.TabIndex = 3;
            this.tabPageNodeLines.Text = "Node Lines";
            // 
            // nodeGridControl
            // 
            this.nodeGridControl.Location = new System.Drawing.Point(3, 3);
            this.nodeGridControl.Name = "nodeGridControl";
            this.nodeGridControl.ReadOnly = false;
            this.nodeGridControl.Size = new System.Drawing.Size(1046, 308);
            this.nodeGridControl.TabIndex = 0;
            // 
            // openFileDialogSaveFile
            // 
            this.openFileDialogSaveFile.Filter = "SotS Save Games (*.sav)|*.sav";
            // 
            // saveFileDialogSaveFile
            // 
            this.saveFileDialogSaveFile.Filter = "SotS Save Games (*.sav)|*.sav";
            // 
            // labelSourceFile
            // 
            this.labelSourceFile.AutoSize = true;
            this.labelSourceFile.Location = new System.Drawing.Point(5, 6);
            this.labelSourceFile.Name = "labelSourceFile";
            this.labelSourceFile.Size = new System.Drawing.Size(91, 13);
            this.labelSourceFile.TabIndex = 1;
            this.labelSourceFile.Text = "Source Save File:";
            // 
            // labelSourceFilePath
            // 
            this.labelSourceFilePath.AutoSize = true;
            this.labelSourceFilePath.Location = new System.Drawing.Point(102, 6);
            this.labelSourceFilePath.Name = "labelSourceFilePath";
            this.labelSourceFilePath.Size = new System.Drawing.Size(117, 13);
            this.labelSourceFilePath.TabIndex = 10;
            this.labelSourceFilePath.Text = "[Source File Path Here]";
            this.labelSourceFilePath.Visible = false;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(3, 22);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 11;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(84, 22);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // statusStripLoadSave
            // 
            this.statusStripLoadSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelMessage,
            this.toolStripProgressBarLoadSave});
            this.statusStripLoadSave.Location = new System.Drawing.Point(0, 913);
            this.statusStripLoadSave.Name = "statusStripLoadSave";
            this.statusStripLoadSave.Size = new System.Drawing.Size(1150, 22);
            this.statusStripLoadSave.TabIndex = 13;
            this.statusStripLoadSave.Text = "statusStripLoadSave";
            // 
            // toolStripStatusLabelMessage
            // 
            this.toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            this.toolStripStatusLabelMessage.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabelMessage.Text = "[Message]";
            // 
            // toolStripProgressBarLoadSave
            // 
            this.toolStripProgressBarLoadSave.Name = "toolStripProgressBarLoadSave";
            this.toolStripProgressBarLoadSave.Size = new System.Drawing.Size(300, 16);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStripLoadSave);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.labelSourceFilePath);
            this.Controls.Add(this.labelSourceFile);
            this.Controls.Add(this.checkBoxReadOnly);
            this.Controls.Add(this.tabControlOptions);
            this.MinimumSize = new System.Drawing.Size(1150, 935);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(1150, 935);
            this.tabControlOptions.ResumeLayout(false);
            this.tabPageSpecies.ResumeLayout(false);
            this.tabPagePlayers.ResumeLayout(false);
            this.tabPageSystems.ResumeLayout(false);
            this.tabPageNodeLines.ResumeLayout(false);
            this.statusStripLoadSave.ResumeLayout(false);
            this.statusStripLoadSave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxReadOnly;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPageSpecies;
        private Species.Species_Details speciesDetails;
        private System.Windows.Forms.TabPage tabPagePlayers;
        private Players.Players playersControl;
        private System.Windows.Forms.TabPage tabPageSystems;
        private Systems systemsControl;
        private System.Windows.Forms.TabPage tabPageNodeLines;
        private Node_Grid.NodeGrid nodeGridControl;
        private System.Windows.Forms.OpenFileDialog openFileDialogSaveFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialogSaveFile;
        private System.Windows.Forms.Label labelSourceFile;
        private System.Windows.Forms.Label labelSourceFilePath;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.StatusStrip statusStripLoadSave;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelMessage;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarLoadSave;
    }
}
