using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.DataLayer.Utils;
using SimpleRDS.Utils;

namespace SimpleRDS.Forms
{
    public partial class MainForm : BaseForm
    {
        private SubscriptionRepository _subscriptionRepository;
        private InvoiceRepository _invoiceRepository;
        private PlanRepository _planRepository;
        private CancellationTokenSource _invoiceIssuerCancelationToken;
        private IInvoiceNumberFactory _invoiceNumberFactory;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
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

            _invoiceIssuerCancelationToken = new CancellationTokenSource();

            _subscriptionRepository = Program.Resolver.Resolve<SubscriptionRepository>();
            _invoiceRepository = Program.Resolver.Resolve<InvoiceRepository>();
            _planRepository = Program.Resolver.Resolve<PlanRepository>();
            _invoiceNumberFactory = Program.Resolver.Resolve<IInvoiceNumberFactory>();

            var invoiceIssued = await _subscriptionRepository.IssueInvoices(_invoiceRepository, _planRepository, _invoiceNumberFactory, _invoiceIssuerCancelationToken.Token);

            if(invoiceIssued > 0)
                ucClients.LoadUi();

            tmrInvoice.Start();
        }

        private async void tmrInvoice_Tick(object sender, EventArgs e)
        {
            if(_subscriptionRepository.IssuingInvoices)
                return;

            lblIssueInvoices.Visible = true;

            var invoiceIssued = await _subscriptionRepository.IssueInvoices(_invoiceRepository, _planRepository, _invoiceNumberFactory, _invoiceIssuerCancelationToken.Token);

            lblIssueInvoices.Visible = false;

            if(invoiceIssued >= 0)
                ucClients.LoadUi();
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
            if(AccountRepository.User.Access < AccessLevel.Regular)
                tcMain.TabPages.Remove(tpClients);

            if(AccountRepository.User.Access < AccessLevel.Manager)
                tcMain.TabPages.Remove(tpUsers);


            if (AccountRepository.User.Access < AccessLevel.Admin)
            {
                tcMain.TabPages.Remove(tpPlans);
                tcMain.TabPages.Remove(tpSettings);
            }

            tcMain.Visible = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _invoiceIssuerCancelationToken.Cancel();
        }
    }
}
