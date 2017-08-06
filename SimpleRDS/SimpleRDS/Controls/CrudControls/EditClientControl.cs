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
        private AccountRepository _userRepository;
        private InvoiceRepository _invoiceRepository;

        private readonly IList<Subscription> _localSubscriptions;
        private int _localSubscriptionsId = -1;

        public Client Client { get; set; }

        public Action<Client, IEnumerable<Subscription>> OnConfirm { get; set; }

        public EditClientControl()
        {
            InitializeComponent();
            _localSubscriptions = new List<Subscription>();
        }

        private void EditClientControl_Load(object sender, EventArgs e)
        {
            _subscriptionRepository = Program.Resolver.Resolve<SubscriptionRepository>();
            _planRepository = Program.Resolver.Resolve<PlanRepository>();
            _invoiceRepository = Program.Resolver.Resolve<InvoiceRepository>();
            _userRepository = Program.Resolver.Resolve<AccountRepository>();

            btnEditInvoice.Visible = AccountRepository.User.Access >= AccessLevel.Manager;

            BindEntityToGui();

            lblCreated.Visible = Client != null;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(!ValidateUi())
                return;

            BindGuiToEntity();

            OnConfirm?.Invoke(Client, _localSubscriptions);

            ParentForm?.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var client = Client != null
                             ? $" client {Client.FullName}"
                             : string.Empty;

            UiHelper.ShowEditSubscription(null, sub =>
                                          {
                                              if (Client != null)
                                              {
                                                  sub.ClientId = Client.Id;
                                                  _subscriptionRepository.Add(sub);
                                              }
                                              else
                                              {
                                                  sub.LocalId = _localSubscriptionsId--;
                                                  _localSubscriptions.Add(sub);
                                              }
                                            FillSubscriptions();
                                          },
                                          $"Adaugare abonament{client}");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var subscription = GetSelectedSubscription();

            if (subscription == null)
                return;

            var client = Client != null 
                            ? $" client {Client.FullName}"
                            : string.Empty;

            UiHelper.ShowEditSubscription(subscription, sub =>
                                         {
                                             if(Client != null)
                                                _subscriptionRepository.Update(sub);
                                            FillSubscriptions();
                                         }, 
                                         $"Modificare abonament {subscription.Id}{client}");
        }

        private void btnCloseContract_Click(object sender, EventArgs e)
        {
            var subscription = GetSelectedSubscription();

            if (subscription == null)
                return;

            var result = UiHelper.ShowQuestion($"Esti sigur ca vrei sa stergi abonamentul {subscription.Id.DefaultIfZero(subscription.LocalId)}? " +
                                               "Actiunea de stergere este ireversibila", parent: ParentForm);

            if (result != DialogResult.Yes)
                return;

            if (subscription.Id != 0)
                _subscriptionRepository.Delete(subscription.Id);
            else
                _localSubscriptions.Remove(subscription);

            FillSubscriptions();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var invoice = GetSelectedInvoice();

            if (invoice == null)
                return;

            sfdPrint.FileName = $"{invoice.Serie}_{invoice.Numar}";

            if(sfdPrint.ShowDialog(ParentForm) != DialogResult.Yes)
                return;

            Printer.ToPdf(invoice, sfdPrint.FileName);
        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            var invoice = GetSelectedInvoice();

            if (invoice == null)
                return;

            UiHelper.ShowEditInvoice(invoice, inv =>
                                    {
                                        _invoiceRepository.Update(inv);
                                        FillInvoices();
                                    });
        }

        private Subscription GetSelectedSubscription()
        {
            if (lvSubscriptions.SelectedIndices.Count <= 0)
            {
                UiHelper.ShowMessage("Selectati un abonament", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            if (lvSubscriptions.SelectedIndices.Count != 1)
            {
                UiHelper.ShowMessage("Selectati un singur abonament", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            var selSubscriptionId = lvSubscriptions.SelectedItems[0].Tag as int? ?? 0;

            if (selSubscriptionId == 0)
            {
                UiHelper.ShowMessage("Selectie incorecta", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            var subscription = _subscriptionRepository.GetById(selSubscriptionId) ?? _localSubscriptions.FirstOrDefault(s => s.LocalId == selSubscriptionId);

            if (subscription == null)
            {
                UiHelper.ShowMessage("Abonament incorect", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            return subscription;
        }

        private Invoice GetSelectedInvoice()
        {
            if (lvInvoices.SelectedIndices.Count <= 0)
            {
                UiHelper.ShowMessage("Selectati o factura", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            if (lvInvoices.SelectedIndices.Count != 1)
            {
                UiHelper.ShowMessage("Selectati o singura factura", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            var selInvoiceId = lvInvoices.SelectedItems[0].Tag as int? ?? 0;

            if (selInvoiceId == 0)
            {
                UiHelper.ShowMessage("Selectie incorecta", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            var invoice = _invoiceRepository.GetById(selInvoiceId);

            if (invoice == null)
            {
                UiHelper.ShowMessage("Factura incorecta", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            return invoice;
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

            var user = _userRepository.GetById(Client.CreatedBy);

            lblCreated.Text = $"Creat de {user?.FullName ?? "necunoscut"} la data de {Client.CreatedAt:g}";
        }

        private void BindGuiToEntity()
        {
            if(Client == null)
                Client = new Client
                         {
                             CreatedAt = DateTime.Now,
                             CreatedBy = AccountRepository.User.Id
                         };

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

                var subscriptions = (Client == null 
                                          ? _localSubscriptions ?? Enumerable.Empty<Subscription>()  
                                          : _subscriptionRepository.GetAllSubscriptions(s => s.ClientId == Client.Id)
                                     ).ToList();

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

        private ListViewItem CreateSubscriptionItem(Subscription subscription, IEnumerable<Plan> plans)
        {
            return new ListViewItem(CreateSubscriptionName(subscription, plans))
            {
                Tag = Client != null 
                        ? subscription.Id
                        : subscription.LocalId,
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
