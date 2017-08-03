using System;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls
{
    public partial class AccountUserControl : BaseUserControl
    {
        private AccountRepository _userRepository;

        public AccountUserControl()
        {
            InitializeComponent();
        }

        public void LoadUi()
        {
            _userRepository = Program.Resolver.Resolve<AccountRepository>();
            FillUsers();
            btnDelete.Visible = AccountRepository.User.Access >= AccessLevel.Admin;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UiHelper.ShowEditUser(null, u =>
            {
                _userRepository.Add(u);
                FillUsers();
            });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();

            if (user == null)
                return;

            UiHelper.ShowEditUser(user, u =>
            {
                _userRepository.Update(u);
                FillUsers();
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var user = GetSelectedUser();

            if(user == null)
                return;

            var result = UiHelper.ShowQuestion($"Esti sigur ca vrei sa stergi utilizatorul {user.FullName} [{user.Email}]? " +
                                                "Actiunea de stergere este ireversibila", parent: ParentForm);

            if(result != DialogResult.Yes)
                return;

            _userRepository.Delete(user.Id);
            FillUsers();
        }

        private void FillUsers()
        {
            try
            {
                lvUsers.BeginUpdate();
                lvUsers.Items.Clear();

                var predicate = PredicateBuilder.True<User>();

                if (!string.IsNullOrEmpty(txtSearch.Text))
                    predicate = predicate.And(u => u.FullName.Contains(txtSearch.Text) ||
                                                   u.Email.Contains(txtSearch.Text));

                var users = _userRepository.GetAllUsers(predicate).ToList();

                lvUsers.Items.AddRange(users.Select(CreateListViewItems).ToArray());
            }
            finally
            {
                lvUsers.EndUpdate();
            }
        }

        private static ListViewItem CreateListViewItems(User user)
        {
            return new ListViewItem(user.Email)
            {
                Tag = user.Id,
                SubItems =
                {
                    user.FullName,
                    user.Access.Translate()
                }
            };
        }

        private User GetSelectedUser()
        {
            if (lvUsers.SelectedIndices.Count <= 0)
            {
                UiHelper.ShowMessage("Selectati un utilizator", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            if (lvUsers.SelectedIndices.Count != 1)
            {
                UiHelper.ShowMessage("Selectati un singur utilizator", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            var selUserId = lvUsers.SelectedItems[0].Tag as int? ?? -1;
            
            if (selUserId <= 0)
            {
                UiHelper.ShowMessage("Selectie incorecta", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            var user = _userRepository.GetById(selUserId);

            if(user == null)
            {
                UiHelper.ShowMessage("Utilizator incorect", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            if (user.Access > AccountRepository.User.Access)
            {
                UiHelper.ShowMessage("Nu ai acces pentru a modifica utilizatorul selectat", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            return user;
        }
    }
}
