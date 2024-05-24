using System;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

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
            this.systemDetailSummary.LoadFromStruct(System);
            this.systemDetailsHistory.LoadFromStruct(System.Details);
            this.systemDetailsMisc.LoadFromStruct(System.Details);
            this.systemDetailsVonNeumann.LoadFromStruct(System.Details.Vnm);
        }

        public void UpdateStruct(SimSystemSaveStruct System)
        {
            this.systemDetailSummary.UpdateStruct(System);
            this.systemDetailsHistory.UpdateStruct(System.Details);
            this.systemDetailsMisc.UpdateStruct(System.Details);
            this.systemDetailsVonNeumann.UpdateStruct(System.Details.Vnm);
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.systemDetailSummary.ReadOnly = ReadOnlyFlag;
            this.systemDetailsHistory.ReadOnly = ReadOnlyFlag;
            this.systemDetailsMisc.ReadOnly = ReadOnlyFlag;
            this.systemDetailsVonNeumann.ReadOnly = ReadOnlyFlag;
        }

        public void Clear()
        {
            this.systemDetailSummary.Clear();
            this.systemDetailsHistory.Clear();
            this.systemDetailsVonNeumann.Clear();
            this.systemDetailsMisc.Clear();
        }
    }
}