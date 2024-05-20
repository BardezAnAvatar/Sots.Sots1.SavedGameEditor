using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bardez.Project.SwordOfTheStars.DataStructures;
using Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.User_Control;

namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls.Node_Grid
{
    public partial class NodeGridDetails : DisplayUserControl
    {
        public NodeGridDetails() : base()
        {
            InitializeComponent();
        }

        public void LoadFromStruct(SimNodeGridPath NodePath)
        {
            this.textBoxNpt.Text = NodePath.Npt.Value.ToString();
            this.textBoxNpid.Text = NodePath.Npid.Value.ToString();
            this.textBoxNpfr.Text = NodePath.Npfr.Value.ToString();
            this.textBoxNpto.Text = NodePath.Npto.Value.ToString();
            this.textBoxNpctm.Text = NodePath.Npctm.Value.ToString();
            this.textBoxNpcby.Text = NodePath.Npcby.Value.ToString();
            this.textBoxNpdtn.Text = NodePath.Npdtn.Value.ToString();
            this.textBoxNpdtf.Text = NodePath.Npdtf.Value.ToString();
            this.textBoxNpenp.Text = NodePath.Npenp.Value.ToString();
            this.textBoxNpuse.Text = NodePath.Npuse.Value.ToString();
            this.textBoxNptf.Text = NodePath.Nptf.Value.ToString();
        }

        public void UpdateStruct(SimNodeGridPath NodePath)
        {
            try
            {
                this.TryInt32Parse("Npt", this.textBoxNpt.Text, NodePath.Npt);
                this.TryInt32Parse("Npid", this.textBoxNpid.Text, NodePath.Npid);
                this.TryInt32Parse("Npfr", this.textBoxNpfr.Text, NodePath.Npfr);
                this.TryInt32Parse("Npto", this.textBoxNpto.Text, NodePath.Npto);
                this.TryInt32Parse("Npctm", this.textBoxNpctm.Text, NodePath.Npctm);
                this.TryInt32Parse("Npcby", this.textBoxNpcby.Text, NodePath.Npcby);
                this.TryInt32Parse("Npdtn", this.textBoxNpdtn.Text, NodePath.Npdtn);
                this.TryInt32Parse("Npdtf", this.textBoxNpdtf.Text, NodePath.Npdtf);
                this.TryInt32Parse("Npenp", this.textBoxNpenp.Text, NodePath.Npenp);
                this.TryInt32Parse("Npuse", this.textBoxNpuse.Text, NodePath.Npuse);
                this.TryInt32Parse("Nptf", this.textBoxNptf.Text, NodePath.Nptf);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occured while updating " + e.Source + ":\n\n" + e.InnerException.Message, "Could not update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected override void PercolateReadOnlyFlag(bool ReadOnlyFlag)
        {
            this.textBoxNpt.Enabled = !ReadOnlyFlag;
            this.textBoxNpid.Enabled = !ReadOnlyFlag;
            this.textBoxNpfr.Enabled = !ReadOnlyFlag;
            this.textBoxNpto.Enabled = !ReadOnlyFlag;
            this.textBoxNpctm.Enabled = !ReadOnlyFlag;
            this.textBoxNpcby.Enabled = !ReadOnlyFlag;
            this.textBoxNpdtn.Enabled = !ReadOnlyFlag;
            this.textBoxNpdtf.Enabled = !ReadOnlyFlag;
            this.textBoxNpenp.Enabled = !ReadOnlyFlag;
            this.textBoxNpuse.Enabled = !ReadOnlyFlag;
            this.textBoxNptf.Enabled = !ReadOnlyFlag;
        }

        public void Clear()
        {
            this.textBoxNpt.Text = String.Empty;
            this.textBoxNpid.Text = String.Empty;
            this.textBoxNpfr.Text = String.Empty;
            this.textBoxNpto.Text = String.Empty;
            this.textBoxNpctm.Text = String.Empty;
            this.textBoxNpcby.Text = String.Empty;
            this.textBoxNpdtn.Text = String.Empty;
            this.textBoxNpdtf.Text = String.Empty;
            this.textBoxNpenp.Text = String.Empty;
            this.textBoxNpuse.Text = String.Empty;
            this.textBoxNptf.Text = String.Empty;
        }

        protected void TryInt32Parse(String FieldName, String ParseTarget, Int32SaveStruct Assignee)
        {
            try
            {
                Assignee.Value = Int32.Parse(ParseTarget);
            }
            catch (Exception e)
            {
                Exception ex = new Exception("Parse failed.", e);
                ex.Source = FieldName;
                throw ex;
            }
        }
    }
}