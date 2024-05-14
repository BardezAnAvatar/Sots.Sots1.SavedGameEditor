using System.Windows.Forms;

namespace Bardez.Project.SwordOfTheStars.Editor.User_Controls
{
    public abstract class UserControlBase : UserControl
    {
        public UserControlBase()
        {
            SetStyles();
        }

        protected void SetStyles()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            this.DoubleBuffered = true;
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