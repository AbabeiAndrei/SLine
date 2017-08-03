using System;
using System.Windows.Forms;
using SimpleRDS.BaseTypes;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Properties;
using SimpleRDS.Utils;

namespace SimpleRDS.Forms
{
    public partial class LoginForm : BaseForm, ILoginForm
    {
        private readonly AccountRepository _accountController;

        public bool IsLoggedIn { get; protected set; }

        public LoginForm(AccountRepository accountController)
        {
            InitializeComponent();
            _accountController = accountController;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(Settings.Default.SavedUser) ||
                    !string.IsNullOrEmpty(Settings.Default.SavedPassword))
                    chkRemeberMe.Checked = true;
                else
                    return;

                txtUser.Text = Settings.Default.SavedUser;
                txtPassword.Text = Settings.Default.SavedPassword;
            }
            finally
            {
                base.OnLoad(e);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                UiHelper.ShowMessage("Completati emailul.", icon: MessageBoxIcon.Error, parent: this);
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                UiHelper.ShowMessage("Introduceti parola.", icon: MessageBoxIcon.Error, parent: this);
                return;
            }

            var user = _accountController.Login(txtUser.Text, txtPassword.Text);

            if (user == null)
            {
                UiHelper.ShowMessage("Emailul sau parola sunt gresite.", icon: MessageBoxIcon.Error, parent: this);
                return;
            }

            if (chkRemeberMe.Checked)
            {
                Settings.Default.SavedUser = txtUser.Text;
                Settings.Default.SavedPassword = txtPassword.Text;
                Settings.Default.Save();
            }
            else if (!string.IsNullOrEmpty(Settings.Default.SavedUser) ||
                     !string.IsNullOrEmpty(Settings.Default.SavedPassword))
            {
                Settings.Default.SavedUser = null;
                Settings.Default.SavedPassword = null;
                Settings.Default.Save();
            }

            IsLoggedIn = true;

            Close();
        }
    }
}
