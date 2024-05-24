using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;
using Bardez.Project.SwordOfTheStars.IO;
using Bardez.Project.SwordOfTheStars.UI.Abstractions.TechTree;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Editor
{
    public partial class Editor : DisplayUserControl
    {
        protected TechTreeManagement techTree;
        protected SaveGameData saveGameData;
        protected Boolean techTreeHasBeenRead;
        protected BackgroundWorker resourcesWorker;
        //protected BackgroundWorker loadWorker;
        //protected BackgroundWorker saveWorker;

        public Editor()
        {
            InitializeComponent();
            this.SetStyles();
            this.techTree = null;
            this.saveGameData = null;
            this.PercolateReadOnlyFlag(false);
            this.toolStripStatusLabelMessage.Text = "Editor Loaded";
            this.toolStripProgressBarLoadSave.Visible = false;
            this.openFileDialogSaveFile.FileName = String.Empty;
            this.saveFileDialogSaveFile.FileName = String.Empty;
            this.techTreeHasBeenRead = false;
            this.resourcesWorker = new BackgroundWorker();
            this.resourcesWorker.DoWork += new DoWorkEventHandler(LoadResourceThread);
            this.resourcesWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(resourcesWorker_RunWorkerCompleted);
            //this.loadWorker = new BackgroundWorker();
            //this.loadWorker.DoWork += new DoWorkEventHandler(LoadProcess);
            //this.saveWorker = new BackgroundWorker();
            //this.saveWorker.DoWork += new DoWorkEventHandler(SaveProcess);
        }

        void resourcesWorker_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                ExceptionHandler.ExceptionManager.LogException(e.Error);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Thread loadRecources = new Thread(new ThreadStart(LoadResourceThread));
            //loadRecources.Start();

            this.resourcesWorker.RunWorkerAsync();
        }

        public void ReadSaveFile()
        {
            this.toolStripStatusLabelMessage.Text = "Reading file...";
            this.saveGameData = SaveFileIO.ReadSaveFileFormat(String.Empty);
            this.ReadSaveFileContents();
        }

        public void ReadSaveFile(Stream Source)
        {
            this.toolStripStatusLabelMessage.Text = "Reading file...";
            this.saveGameData = SaveFileIO.ReadSaveFileFormat(Source);
            this.ReadSaveFileContents();
        }

        protected void ReadSaveFileContents()
        {
            this.ProcessStatusEvent(2, "Reading tech tree...");

            //previously read the tech tree here, but I want it loaded statically.
            lock (this.techTreeHasBeenRead as Object)
            {
                this.ProcessStatusEvent(1, "Loading tech tree...");
                //attach tree to graph
                this.techTree.PopulateGraph(this.playersControl.GraphTechTree);

                //var nameResults = from t in saveGameData.Sim.Players.Values[2].Details.TechTree.Techs.Values select t.TNm.Value.CharacterString;
                //var countResults = from v in saveGameData.Sim.Players.Values select v.Details.TechTree.Techs.Values.Length;
                //var oy = from v in saveGameData.Sim.Players.Values select v.Details.TechTree.Techs.Values;
            }

            this.ProcessStatusEvent(1, "Loading systems...");
            this.systemsControl.LoadFromStruct(saveGameData.Sim);

            this.ProcessStatusEvent(1, "Loading species...");
            this.speciesDetails.LoadFromStruct(saveGameData.Sim.Species);

            this.ProcessStatusEvent(1, "Loading players...");
            this.playersControl.LoadFromStruct(saveGameData);

            this.ProcessStatusEvent(1, "Loading node grid...");
            this.nodeGridControl.LoadFromStruct(saveGameData);
        }

        protected override void PercolateReadOnlyFlag(Boolean ReadOnlyFlag)
        {
            this.speciesDetails.ReadOnly = ReadOnlyFlag;
            this.systemsControl.ReadOnly = ReadOnlyFlag;
            this.playersControl.ReadOnly = ReadOnlyFlag;
            this.nodeGridControl.ReadOnly = ReadOnlyFlag;
        }

        private void checkBoxReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            this.ReadOnly = this.checkBoxReadOnly.Checked;
            this.toolStripStatusLabelMessage.Text = "Read only " + (this.checkBoxReadOnly.Checked ? "on" : "off");
        }

        protected void WriteSaveFile()
        {
            this.PersistBeforeSave();       //persist all edits

            this.ProcessStatusEvent(2, "Gathering latest edits...");
            SaveFileIO.WriteSaveFileFormat(this.saveGameData, String.Empty);    //write
        }

        protected void WriteSaveFile(Stream Destination)
        {
            this.PersistBeforeSave();       //persist all edits

            this.ProcessStatusEvent(2, "Gathering latest edits...");
            SaveFileIO.WriteSaveFileFormat(this.saveGameData, Destination);     //write
        }

        protected void PersistBeforeSave()
        {
            this.systemsControl.PersistBeforeSave();
            this.playersControl.PersistBeforeSave();
            this.nodeGridControl.PersistBeforeSave();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabelMessage.Text = "Loading...";
            if (this.openFileDialogSaveFile.ShowDialog() == DialogResult.OK)
            {
                //clear so events do not fire later
                this.systemsControl.Clear();
                this.speciesDetails.Clear();
                this.playersControl.Clear();
                this.nodeGridControl.Clear();


                this.toolStripProgressBarLoadSave.Minimum = 0;
                this.toolStripProgressBarLoadSave.Maximum = 8;
                this.toolStripProgressBarLoadSave.Step = 1;
                this.toolStripProgressBarLoadSave.Value = 0;
                this.toolStripProgressBarLoadSave.ForeColor = Color.Green;
                this.toolStripProgressBarLoadSave.Visible = true;
                this.labelSourceFilePath.Text = this.openFileDialogSaveFile.FileName;
                this.labelSourceFilePath.Visible = true;

                using (Stream source = Gzip.Uncompress(this.openFileDialogSaveFile.OpenFile()))
                    this.ReadSaveFile(source);

                this.toolStripProgressBarLoadSave.Visible = false;
                this.toolStripStatusLabelMessage.Text = "Load Complete.";
                this.buttonSave.Visible = true;
            }
            else
                this.toolStripStatusLabelMessage.Text = "Loading aborted.";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.toolStripStatusLabelMessage.Text = "Saving...";
            if (this.saveFileDialogSaveFile.ShowDialog() == DialogResult.OK)
            {
                this.toolStripProgressBarLoadSave.Minimum = 0;
                this.toolStripProgressBarLoadSave.Maximum = 8;
                this.toolStripProgressBarLoadSave.Step = 1;
                this.toolStripProgressBarLoadSave.Value = 0;
                this.toolStripProgressBarLoadSave.ForeColor = Color.Green;
                this.toolStripProgressBarLoadSave.Visible = true;

                MemoryStream memStream = new MemoryStream();
                this.WriteSaveFile(memStream);

                this.ProcessStatusEvent(4, "Raw save data written...");
                using (Stream compressed = Gzip.Compress(memStream)) //closes Memstream also?
                {
                    using (Stream destination = this.saveFileDialogSaveFile.OpenFile())
                    {
                        compressed.CopyTo(destination);
                    }
                }

                this.ProcessStatusEvent(2, "Compressed...");
                this.toolStripProgressBarLoadSave.Visible = false;
                this.toolStripStatusLabelMessage.Text = "Save Complete.";
            }
            else
                this.toolStripStatusLabelMessage.Text = "Saving aborted.";
        }

        protected void ProcessStatusEvent(Int32 Step, String Message)
        {
            Application.DoEvents();
            this.toolStripProgressBarLoadSave.Increment(Step);
            this.toolStripStatusLabelMessage.Text = Message;
        }

        protected void LoadResourceThread(object sender, DoWorkEventArgs e)
        {
            lock (this.techTreeHasBeenRead as Object)
            {
                if (! this.techTreeHasBeenRead)
                {
                    this.techTree = new TechTreeManagement();
                    this.techTree.ReadResources();
                    this.playersControl.ValidTechTree = this.techTree.JoinedTechTree;
                    this.techTreeHasBeenRead = true;
                }
            }
        }

        protected void SaveProcess(object sender, DoWorkEventArgs e)
        {
            //lock the UI
            this.Enabled = false;

            //unlcok the UI
            this.Enabled = true;
            throw new NotImplementedException();
        }

        protected void LoadProcess(object sender, DoWorkEventArgs e)
        {
            //lock the UI
            this.Enabled = false;

            //unlcok the UI
            this.Enabled = true;
            throw new NotImplementedException();
        }
    }
}