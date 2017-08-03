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
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls.CrudControls
{
    public partial class EditClientControl : BaseUserControl
    {
        private SubscriptionRepository _subscriptionRepository;
        private PlanRepository _planRepository;
        private InvoiceRepository _invoiceRepository;

        public Client Client { get; set; }

        public Action<Client> OnConfirm { get; set; }

        public EditClientControl()
        {
            InitializeComponent();
        }

        private void EditClientControl_Load(object sender, EventArgs e)
        {
            _subscriptionRepository = Program.Resolver.Resolve<SubscriptionRepository>();
            _planRepository = Program.Resolver.Resolve<PlanRepository>();
            _invoiceRepository = Program.Resolver.Resolve<InvoiceRepository>();

            btnEditInvoice.Visible = AccountRepository.User.Access >= AccessLevel.Manager;

            BindEntityToGui();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!ValidateUi())
                return;

            BindGuiToEntity();

            OnConfirm?.Invoke(Client);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseContract_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {

        }

        private void BindEntityToGui()
        {
            if(Client == null)
                return;

            txtFullName.Text = Client.FullName;
            chkIsCompany.Checked = Client.Type == ClientType.Company;
            txtCnp.Text = Client.Cnp;
            txtSerieNumar.Text = $"{Client.SerieCi}-{Client.NumarCi}";
            dtpBirthDay.Value = Client.BirthDate;
            txtPhone.Text = Client.Phone;
            txtMobile.Text = Client.Mobile;
            txtAddress.Text = Client.Address;
            txtCity.Text = Client.City;
            txtEmail.Text = Client.Email;

            FillSubscriptions();
            FillInvoices();
        }

        private void BindGuiToEntity()
        {
            if(Client == null)
                Client = new Client();

            Client.FullName = txtFullName.Text;
            Client.Type = chkIsCompany.Checked ? ClientType.Company : ClientType.Person;
            Client.Cnp = txtCnp.Text;

            var serieNumar = txtSerieNumar.Text.Split('-');
            Client.SerieCi = serieNumar[0];
            Client.NumarCi = serieNumar[1];

            Client.BirthDate = dtpBirthDay.Value;
            Client.Phone = txtPhone.Text;
            Client.Mobile = txtMobile.Text;
            Client.Address = txtAddress.Text;
            Client.City = txtCity.Text;
            Client.Email = txtEmail.Text;
        }

        private bool ValidateUi()
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                UiHelper.ShowMessage("Numele nu este completat", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (string.IsNullOrEmpty(txtCnp.Text))
            {
                UiHelper.ShowMessage("Cnp-ul nu este completat", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (!txtSerieNumar.MaskFull)
            {
                UiHelper.ShowMessage("Seria/Numarul nu sunt completate", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text) && string.IsNullOrEmpty(txtMobile.Text))
            {
                UiHelper.ShowMessage("Telefonul sau mobilul nu este completat", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                UiHelper.ShowMessage("Adresa nu este completat", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                UiHelper.ShowMessage("Orasul nu este completat", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return false;
            }

            return true;
        }

        private void FillSubscriptions()
        {
            try
            {
                lvSubscriptions.BeginUpdate();
                lvSubscriptions.Items.Clear();

                if(Client == null)
                    return;

                var subscriptions = _subscriptionRepository.GetAllSubscriptions(s => s.ClientId == Client.Id).ToList();
                var planIds = subscriptions.Select(s => s.PlanId).Distinct().ToArray();

                var plans = _planRepository.GetAllPlans(p => Sql.In(p.Id, planIds)).ToList();

                lvSubscriptions.Items.AddRange(subscriptions.Select(s => CreateSubscriptionItem(s, plans)).ToArray());
            }
            finally
            {
                lvSubscriptions.EndUpdate();
            }
        }

        private void FillInvoices()
        {
            try
            {
                lvInvoices.BeginUpdate();
                lvInvoices.Items.Clear();

                if (Client == null)
                    return;

                var invoices = _invoiceRepository.GetAllInvoices(i => i.ClientId == Client.Id)
                                                 .OrderBy(i => string.IsNullOrEmpty(i.PaidWith))
                                                 .ThenBy(i => i.Serie)
                                                 .ThenBy(i => i.Numar);

                lvInvoices.Items.AddRange(invoices.Select(CreateInvoiceItem).ToArray());
            }
            finally
            {
                lvInvoices.EndUpdate();
            }
        }

        private static ListViewItem CreateSubscriptionItem(Subscription subscription, IEnumerable<Plan> plans)
        {
            return new ListViewItem(CreateSubscriptionName(subscription, plans))
            {
                Tag = subscription.Id,
                SubItems =
                {
                    subscription.Address,
                    subscription.State.Translate(),
                    CreateSubscriptionDetails(subscription)
                }
            };
        }

        private static string CreateSubscriptionName(Subscription subscription, IEnumerable<Plan> plans)
        {
            var plan = plans.FirstOrDefault(p => p.Id == subscription.PlanId);

            return plan?.Name ?? "Plan";
        }

        private static string CreateSubscriptionDetails(Subscription subscription)
        {
            var str = $"Activ de la {subscription.ActiveFrom:d}";

            if (subscription.SubscriptionEnd.HasValue)
                str += $" pana la {subscription.SubscriptionEnd.Value:d}";

            if(subscription.ExpireAt.HasValue)
                str += $" expira la {subscription.ExpireAt.Value:d}";

            return str;
        }
        
        private static ListViewItem CreateInvoiceItem(Invoice invoice)
        {
            return new ListViewItem($"{invoice.Serie}/{invoice.Numar}")
            {
                Tag = invoice.Id,
                SubItems =
                {
                    invoice.Date.ToString("d"),
                    CreateInvoiceDetails(invoice)
                }
            };
        }

        private static string CreateInvoiceDetails(Invoice invoice)
        {
            if (!string.IsNullOrEmpty(invoice.StornoFor))
                return $"Storno pentru {invoice.StornoFor}";

            if (!string.IsNullOrEmpty(invoice.PaidWith))
                return $"Platita cu {invoice.PaidWith}";

            if (invoice.RowState == RowState.Deleted)
                return "Anulata";

            return string.Empty;
        }
    }
}
