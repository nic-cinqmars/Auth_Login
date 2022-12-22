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
    public partial class NoAccess : Form
    {
        public NoAccess()
        {
            InitializeComponent();
        }

        private void NoAccess_Load(object sender, EventArgs e)
        {
            noAccessTextBox.Text = noAccessTextBox.Text.Replace("{username}", Authentifier.GetCurrentUsername());
        }
    }
}
