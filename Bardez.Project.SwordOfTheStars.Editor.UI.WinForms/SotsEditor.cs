using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
//using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.IO;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms
{
    public partial class SotsEditor : Form
    {
        public SotsEditor()
        {
            InitializeComponent();
            SetStyles();

            ////takes time
            //ExceptionHandler.ExceptionManager.LogException(new Exception("Malarky"));
            //throw new Exception("Malarky");
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //Gzip.Uncompress();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //SaveFileOffsetCollector.collectOffsets();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    //saveGameData = SaveFileIO.ReadSaveFileFormat();
        //    //MessageBox.Show("Read Complete");
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    //saveGameData = SaveFileIO.ReadSaveFileFormat();
        //    //SaveFileIO.WriteSaveFileFormat(saveGameData);
        //    //MessageBox.Show("Write Complete");
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    this.editorSaveGame.ReadSaveFile();
        ////}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    //List<Package> pkg = Registry.GetSystemPath();
        //}
        
        protected void ProcessResources()
        {
        }

        protected void SetStyles()
        {
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.DoubleBuffered = true;
        }

        /// <remarks>http://social.msdn.microsoft.com/forums/en-US/winforms/thread/aaed00ce-4bc9-424e-8c05-c30213171c2c/</remarks>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}