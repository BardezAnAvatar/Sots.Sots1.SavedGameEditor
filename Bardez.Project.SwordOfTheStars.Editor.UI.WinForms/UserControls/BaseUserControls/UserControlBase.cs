using System.Windows.Forms;
using UC = System.Windows.Forms.UserControl;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.BaseUserControls
{
    public abstract class UserControlBase : UC
    {
        public UserControlBase()
        {
            SetStyles();
        }

        protected void SetStyles()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.EnableNotifyMessage, true);
            DoubleBuffered = true;
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}