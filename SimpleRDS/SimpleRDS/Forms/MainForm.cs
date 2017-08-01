using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Utils;

namespace SimpleRDS.Forms
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Visible = false;
            var form = UiHelper.ShowLogin();
            
            if (!form.IsLoggedIn)
            {
                Close();
                Application.Exit();
                return;
            }

            Visible = true;

            LoadUi();
        }

        private void LoadUi()
        {
            LoadUserDetails();
            SetPagesVisibility();
            LoadPages();
        }

        private void LoadPages()
        {
            if (AccountRepository.User.Access >= AccessLevel.Regular)
                ucClients.LoadUi();

            if (AccountRepository.User.Access >= AccessLevel.Manager)
                ucAcounts.LoadUi();

            if (AccountRepository.User.Access >= AccessLevel.Admin)
                ucPlans.LoadUi();

            if (AccountRepository.User.Access >= AccessLevel.Admin)
                ucSettings.LoadUi();
        }

        private void LoadUserDetails()
        {
            lblHello.Text = "Salut " + AccountRepository.User.FullName;
            lblHello.Visible = true;
        }

        private void SetPagesVisibility()
        {
            tpClients.Visible = AccountRepository.User.Access >= AccessLevel.Regular;
            tpUsers.Visible = AccountRepository.User.Access >= AccessLevel.Manager;
            tpPlans.Visible = AccountRepository.User.Access >= AccessLevel.Admin;
            tpSettings.Visible = AccountRepository.User.Access >= AccessLevel.Admin;

            tcMain.Visible = true;
        }
    }
}
