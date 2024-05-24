using System;
using System.Windows.Forms;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls
{
#if false
    public abstract class DisplayUserControl : UserControlBase
#else
    public class DisplayUserControl : UserControlBase
#endif
    {
        protected bool readOnly;

        public bool ReadOnly
        {
            get { return readOnly; }
            set
            {
                readOnly = value;
                PercolateReadOnlyFlag(readOnly);
            }
        }

        public DisplayUserControl() : base()
        {
            SetStyles();
            readOnly = false;
        }

        protected virtual void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
        }
    }
}