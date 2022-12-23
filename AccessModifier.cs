using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auth_Login
{
    public partial class AccessModifier : Form
    {
        private User user;

        public AccessModifier(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void AccessModifier_Load(object sender, EventArgs e)
        {
            topLabel.Text = topLabel.Text.Replace("{username}", user.GetUsername());
            List<ACCESS> userAccess = user.GetAccess();
            foreach (ACCESS access in Enum.GetValues(typeof(ACCESS)))
            {
                bool hasAccess = false;
                if (userAccess.Contains(access))
                {
                    hasAccess = true;
                }
                accessGridView.Rows.Add(access, hasAccess);
            }
        }

        private void accessGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataGridViewRow row = accessGridView.Rows[e.RowIndex];
                ACCESS access = (ACCESS)row.Cells[0].Value;
                DataGridViewCheckBoxCell? checkBox = row.Cells[1] as DataGridViewCheckBoxCell;
                if (checkBox != null)
                {
                    if ((bool)checkBox.Value)
                    {
                        checkBox.Value = false;
                        user.RemoveAccess(access);
                    }
                    else
                    {
                        checkBox.Value = true;
                        user.AddAccess(access);
                    }
                }
            }
        }

        private void AccessModifier_FormClosed(object sender, FormClosedEventArgs e)
        {
            user.SaveAccess();
        }
    }
}
