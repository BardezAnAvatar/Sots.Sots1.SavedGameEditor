using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.User_Control;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
{
    public partial class SystemDetails : DisplayUserControl
    {
        /// <summary>Index to the array of systems that this control will reference</summary>
        protected Int32 systemIndex;

        public SystemDetails() : base()
        {
            InitializeComponent();
            this.systemIndex = -1;
        }

        public void LoadFromStruct(SimSystemSaveStruct System)
        {
            this.system_Detail_Summary.LoadFromStruct(System);
            this.system_Details_History.LoadFromStruct(System.Details);
            this.system_Details_Misc.LoadFromStruct(System.Details);
            this.system_Details_Von_Neumann.LoadFromStruct(System.Details.Vnm);
        }

        public void UpdateStruct(SimSystemSaveStruct System)
        {
            this.system_Detail_Summary.UpdateStruct(System);
            this.system_Details_History.UpdateStruct(System.Details);
            this.system_Details_Misc.UpdateStruct(System.Details);
            this.system_Details_Von_Neumann.UpdateStruct(System.Details.Vnm);
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.system_Detail_Summary.ReadOnly = ReadOnlyFlag;
            this.system_Details_History.ReadOnly = ReadOnlyFlag;
            this.system_Details_Misc.ReadOnly = ReadOnlyFlag;
            this.system_Details_Von_Neumann.ReadOnly = ReadOnlyFlag;
        }

        public void Clear()
        {
            this.system_Detail_Summary.Clear();
            this.system_Details_History.Clear();
            this.system_Details_Von_Neumann.Clear();
            this.system_Details_Misc.Clear();
        }
    }
}