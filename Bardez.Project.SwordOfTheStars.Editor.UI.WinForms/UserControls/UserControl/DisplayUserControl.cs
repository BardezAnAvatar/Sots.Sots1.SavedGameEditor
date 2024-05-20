using System;
using System.Windows.Forms;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.UserControl
{
#if false
    public abstract class DisplayUserControl : UserControlBase
#else
    public class DisplayUserControl : UserControlBase
#endif
    {
        protected Boolean readOnly;

        public Boolean ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                this.PercolateReadOnlyFlag(this.readOnly);
            }
        }

        public DisplayUserControl() : base()
        {
            SetStyles();
            readOnly = false;
        }

        protected virtual void PercolateReadOnlyFlag(Boolean ReadOnlyFlag)
        {
        }
    }
}