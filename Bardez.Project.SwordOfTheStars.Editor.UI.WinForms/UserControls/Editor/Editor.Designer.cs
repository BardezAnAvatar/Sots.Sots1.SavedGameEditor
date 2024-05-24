namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Editor
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
            checkBoxReadOnly = new System.Windows.Forms.CheckBox();
            tabControlOptions = new System.Windows.Forms.TabControl();
            tabPageSpecies = new System.Windows.Forms.TabPage();
            speciesDetails = new Species.Species_Details();
            tabPagePlayers = new System.Windows.Forms.TabPage();
            playersControl = new Players.Players();
            tabPageSystems = new System.Windows.Forms.TabPage();
            systemsControl = new Systems();
            tabPageNodeLines = new System.Windows.Forms.TabPage();
            nodeGridControl = new Node_Grid.NodeGrid();
            openFileDialogSaveFile = new System.Windows.Forms.OpenFileDialog();
            saveFileDialogSaveFile = new System.Windows.Forms.SaveFileDialog();
            labelSourceFile = new System.Windows.Forms.Label();
            labelSourceFilePath = new System.Windows.Forms.Label();
            buttonLoad = new System.Windows.Forms.Button();
            buttonSave = new System.Windows.Forms.Button();
            statusStripLoadSave = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabelMessage = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripProgressBarLoadSave = new System.Windows.Forms.ToolStripProgressBar();
            tabControlOptions.SuspendLayout();
            tabPageSpecies.SuspendLayout();
            tabPagePlayers.SuspendLayout();
            tabPageSystems.SuspendLayout();
            tabPageNodeLines.SuspendLayout();
            statusStripLoadSave.SuspendLayout();
            SuspendLayout();
            // 
            // checkBoxReadOnly
            // 
            checkBoxReadOnly.AutoSize = true;
            checkBoxReadOnly.Location = new System.Drawing.Point(192, 30);
            checkBoxReadOnly.Margin = new System.Windows.Forms.Padding(4);
            checkBoxReadOnly.Name = "checkBoxReadOnly";
            checkBoxReadOnly.Size = new System.Drawing.Size(80, 19);
            checkBoxReadOnly.TabIndex = 9;
            checkBoxReadOnly.Text = "Read Only";
            checkBoxReadOnly.UseVisualStyleBackColor = true;
            checkBoxReadOnly.CheckedChanged += checkBoxReadOnly_CheckedChanged;
            // 
            // tabControlOptions
            // 
            tabControlOptions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControlOptions.Controls.Add(tabPageSpecies);
            tabControlOptions.Controls.Add(tabPagePlayers);
            tabControlOptions.Controls.Add(tabPageSystems);
            tabControlOptions.Controls.Add(tabPageNodeLines);
            tabControlOptions.Location = new System.Drawing.Point(4, 59);
            tabControlOptions.Margin = new System.Windows.Forms.Padding(4);
            tabControlOptions.Name = "tabControlOptions";
            tabControlOptions.SelectedIndex = 0;
            tabControlOptions.Size = new System.Drawing.Size(1196, 612);
            tabControlOptions.TabIndex = 8;
            // 
            // tabPageSpecies
            // 
            tabPageSpecies.BackColor = System.Drawing.SystemColors.Control;
            tabPageSpecies.Controls.Add(speciesDetails);
            tabPageSpecies.Location = new System.Drawing.Point(4, 24);
            tabPageSpecies.Margin = new System.Windows.Forms.Padding(4);
            tabPageSpecies.Name = "tabPageSpecies";
            tabPageSpecies.Size = new System.Drawing.Size(1188, 584);
            tabPageSpecies.TabIndex = 1;
            tabPageSpecies.Text = "Species";
            // 
            // speciesDetails
            // 
            speciesDetails.Location = new System.Drawing.Point(4, 4);
            speciesDetails.Margin = new System.Windows.Forms.Padding(4);
            speciesDetails.Name = "speciesDetails";
            speciesDetails.ReadOnly = false;
            speciesDetails.Size = new System.Drawing.Size(442, 258);
            speciesDetails.TabIndex = 0;
            // 
            // tabPagePlayers
            // 
            tabPagePlayers.BackColor = System.Drawing.SystemColors.Control;
            tabPagePlayers.Controls.Add(playersControl);
            tabPagePlayers.Location = new System.Drawing.Point(4, 24);
            tabPagePlayers.Margin = new System.Windows.Forms.Padding(4);
            tabPagePlayers.Name = "tabPagePlayers";
            tabPagePlayers.Size = new System.Drawing.Size(192, 72);
            tabPagePlayers.TabIndex = 2;
            tabPagePlayers.Text = "Players";
            // 
            // playersControl
            // 
            playersControl.Dock = System.Windows.Forms.DockStyle.Fill;
            playersControl.Location = new System.Drawing.Point(0, 0);
            playersControl.Margin = new System.Windows.Forms.Padding(4);
            playersControl.Name = "playersControl";
            playersControl.ReadOnly = false;
            playersControl.Size = new System.Drawing.Size(192, 72);
            playersControl.TabIndex = 0;
            playersControl.ValidTechTree = null;
            // 
            // tabPageSystems
            // 
            tabPageSystems.BackColor = System.Drawing.SystemColors.Control;
            tabPageSystems.Controls.Add(systemsControl);
            tabPageSystems.Location = new System.Drawing.Point(4, 24);
            tabPageSystems.Margin = new System.Windows.Forms.Padding(4);
            tabPageSystems.Name = "tabPageSystems";
            tabPageSystems.Size = new System.Drawing.Size(192, 72);
            tabPageSystems.TabIndex = 0;
            tabPageSystems.Text = "Systems";
            // 
            // systemsControl
            // 
            systemsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            systemsControl.Location = new System.Drawing.Point(0, 0);
            systemsControl.Margin = new System.Windows.Forms.Padding(4);
            systemsControl.Name = "systemsControl";
            systemsControl.ReadOnly = true;
            systemsControl.Size = new System.Drawing.Size(192, 72);
            systemsControl.TabIndex = 4;
            // 
            // tabPageNodeLines
            // 
            tabPageNodeLines.BackColor = System.Drawing.SystemColors.Control;
            tabPageNodeLines.Controls.Add(nodeGridControl);
            tabPageNodeLines.Location = new System.Drawing.Point(4, 24);
            tabPageNodeLines.Margin = new System.Windows.Forms.Padding(4);
            tabPageNodeLines.Name = "tabPageNodeLines";
            tabPageNodeLines.Size = new System.Drawing.Size(1188, 584);
            tabPageNodeLines.TabIndex = 3;
            tabPageNodeLines.Text = "Node Lines";
            // 
            // nodeGridControl
            // 
            nodeGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            nodeGridControl.Location = new System.Drawing.Point(0, 0);
            nodeGridControl.Margin = new System.Windows.Forms.Padding(4);
            nodeGridControl.MinimumSize = new System.Drawing.Size(608, 342);
            nodeGridControl.Name = "nodeGridControl";
            nodeGridControl.ReadOnly = false;
            nodeGridControl.Size = new System.Drawing.Size(1188, 584);
            nodeGridControl.TabIndex = 0;
            // 
            // openFileDialogSaveFile
            // 
            openFileDialogSaveFile.Filter = "SotS Save Games (*.sav)|*.sav";
            // 
            // saveFileDialogSaveFile
            // 
            saveFileDialogSaveFile.Filter = "SotS Save Games (*.sav)|*.sav";
            // 
            // labelSourceFile
            // 
            labelSourceFile.AutoSize = true;
            labelSourceFile.Location = new System.Drawing.Point(6, 7);
            labelSourceFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSourceFile.Name = "labelSourceFile";
            labelSourceFile.Size = new System.Drawing.Size(94, 15);
            labelSourceFile.TabIndex = 1;
            labelSourceFile.Text = "Source Save File:";
            // 
            // labelSourceFilePath
            // 
            labelSourceFilePath.AutoSize = true;
            labelSourceFilePath.Location = new System.Drawing.Point(119, 7);
            labelSourceFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSourceFilePath.Name = "labelSourceFilePath";
            labelSourceFilePath.Size = new System.Drawing.Size(127, 15);
            labelSourceFilePath.TabIndex = 10;
            labelSourceFilePath.Text = "[Source File Path Here]";
            labelSourceFilePath.Visible = false;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new System.Drawing.Point(4, 25);
            buttonLoad.Margin = new System.Windows.Forms.Padding(4);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new System.Drawing.Size(88, 27);
            buttonLoad.TabIndex = 11;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new System.Drawing.Point(98, 25);
            buttonSave.Margin = new System.Windows.Forms.Padding(4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new System.Drawing.Size(88, 27);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Visible = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // statusStripLoadSave
            // 
            statusStripLoadSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabelMessage, toolStripProgressBarLoadSave });
            statusStripLoadSave.Location = new System.Drawing.Point(0, 676);
            statusStripLoadSave.Name = "statusStripLoadSave";
            statusStripLoadSave.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStripLoadSave.Size = new System.Drawing.Size(1204, 24);
            statusStripLoadSave.TabIndex = 13;
            statusStripLoadSave.Text = "statusStripLoadSave";
            // 
            // toolStripStatusLabelMessage
            // 
            toolStripStatusLabelMessage.Name = "toolStripStatusLabelMessage";
            toolStripStatusLabelMessage.Size = new System.Drawing.Size(61, 19);
            toolStripStatusLabelMessage.Text = "[Message]";
            // 
            // toolStripProgressBarLoadSave
            // 
            toolStripProgressBarLoadSave.Name = "toolStripProgressBarLoadSave";
            toolStripProgressBarLoadSave.Size = new System.Drawing.Size(350, 18);
            // 
            // Editor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(statusStripLoadSave);
            Controls.Add(buttonSave);
            Controls.Add(buttonLoad);
            Controls.Add(labelSourceFilePath);
            Controls.Add(labelSourceFile);
            Controls.Add(checkBoxReadOnly);
            Controls.Add(tabControlOptions);
            Margin = new System.Windows.Forms.Padding(4);
            MinimumSize = new System.Drawing.Size(500, 700);
            Name = "Editor";
            Size = new System.Drawing.Size(1204, 700);
            tabControlOptions.ResumeLayout(false);
            tabPageSpecies.ResumeLayout(false);
            tabPagePlayers.ResumeLayout(false);
            tabPageSystems.ResumeLayout(false);
            tabPageNodeLines.ResumeLayout(false);
            statusStripLoadSave.ResumeLayout(false);
            statusStripLoadSave.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
