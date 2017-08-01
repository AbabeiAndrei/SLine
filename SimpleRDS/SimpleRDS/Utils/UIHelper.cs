using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using SimpleRDS.BaseTypes;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.Forms;
using SimpleRDS.Properties;

namespace SimpleRDS.Utils
{
    public static class UiHelper
    {
        public static void ShowMessage(string message, string title = null, MessageBoxIcon icon = MessageBoxIcon.None, IWin32Window parent = null)
        {
            MessageBox.Show(parent, message, title ?? Settings.Default.ApplicationName, MessageBoxButtons.OK, icon);
        }

        public static ILoginForm ShowLogin()
        {
            var form = new LoginForm(Program.Resolver.Resolve<AccountRepository>());

            form.ShowDialog();

            return form;
        }
    }
}
