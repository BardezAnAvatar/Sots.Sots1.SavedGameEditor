using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
{
    public partial class SystemDetailsHistory : DisplayUserControl
    {
        public SystemDetailsHistory() : base()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimSystemDetailsSaveStruct System)
        {
            
            this.system_Details_History_Data_Current.LoadFromStruct(System, false);
            this.system_Details_History_Data_Previous.LoadFromStruct(System, true);
        }

        public void UpdateStruct(SimSystemDetailsSaveStruct System)
        {
            this.system_Details_History_Data_Current.UpdateStruct(System, false);
            this.system_Details_History_Data_Previous.UpdateStruct(System, true);
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.system_Details_History_Data_Current.ReadOnly = ReadOnlyFlag;
            //this.system_Details_History_Data_Previous.ReadOnly = ReadOnlyFlag;
        }

        public void Clear()
        {
            this.system_Details_History_Data_Current.Clear();
            this.system_Details_History_Data_Previous.Clear();
        }
    }
}