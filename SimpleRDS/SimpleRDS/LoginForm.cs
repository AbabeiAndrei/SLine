using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleRDS.BaseTypes;
using SimpleRDS.Properties;

namespace SimpleRDS
{
    public partial class LoginForm : BaseForm
    {
        public override string Text => $"{Settings.Default.ApplicationName} - Login";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
