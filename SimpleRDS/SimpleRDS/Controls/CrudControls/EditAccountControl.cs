using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using SimpleRDS.DataLayer.Business;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls.CrudControls
{
    public partial class EditAccountControl : BaseUserControl
    {
        private IPasswordHasher<User> _passwordHasher;
        public User User { get; set; }

        public Action<User> OnConfirm { get; set; }

        public EditAccountControl()
        {
            InitializeComponent();
            cbAccess.DisplayMember = "Name";
            cbAccess.ValueMember = "Value";
        }

        private void EditAccountControl_Load(object sender, EventArgs e)
        {
            _passwordHasher = Program.Resolver.Resolve<IPasswordHasher<User>>();
            FillAccess();
            BindEntityToGui();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!ValidateUi())
                return;

            BindGuiToEntity();

            OnConfirm?.Invoke(User);

            ParentForm?.Close();
        }

        private void FillAccess()
        {
            var accessList = new List<AccessLevel>
            {
                AccessLevel.Regular,
                AccessLevel.Manager
            };

            if(AccountRepository.User.Access >= AccessLevel.Admin)
                accessList.Add(AccessLevel.Admin);

            try
            {
                cbAccess.BeginUpdate();
                cbAccess.Items.Clear();
                
                cbAccess.Items.AddRange(accessList.Select(a => new {Value = a, Name = a.Translate()}).Cast<object>().ToArray());

                cbAccess.SelectedIndex = 0;
            }
            finally
            {
                cbAccess.EndUpdate();
            }
        }

        private void BindEntityToGui()
        {
            if (User == null)
                return;

            txtMail.Text = User.Email;
            txtFullName.Text = User.FullName;
            cbAccess.SelectedIndex = (int) User.Access;
        }

        private void BindGuiToEntity()
        {
            if(User == null)
                User = new User();

            User.Email = txtMail.Text;
            User.FullName = txtFullName.Text;
            User.Access = (AccessLevel)cbAccess.SelectedIndex;

            if (!string.IsNullOrEmpty(txtPassword.Text))
                User.Password = _passwordHasher.HashPassword(User, txtPassword.Text);
        }

        private bool ValidateUi()
        {
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                UiHelper.ShowMessage("Email-ul nu este completat", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                UiHelper.ShowMessage("Numele nu este completat", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (cbAccess.SelectedIndex < 0)
            {
                UiHelper.ShowMessage("Accesul nu este selectat", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (User == null && string.IsNullOrEmpty(txtPassword.Text))
            {
                UiHelper.ShowMessage("Parola nu este completata", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            return true;
        }
    }
}
