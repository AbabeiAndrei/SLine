using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Business;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.DataLayer.Exceptions;
using SimpleRDS.Utils;

namespace SimpleRDS.Controls
{
    public partial class ClientsUserControl : BaseUserControl
    {
        private const string ALL = "Toate";
        private const int PAGE_SIZE = 30;

        private ClientsRepository _clientsRepository;
        private SubscriptionRepository _subscriptionRepository;
        private PlanRepository _planRepository;
        private InvoiceRepository _invoiceRepository;

        private int _page;

        public ClientsUserControl()
        {
            InitializeComponent();
            _page = 0;
        }

        private void cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillClients(_page);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillClients();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UiHelper.ShowEditClient(null, u =>
            {
                _clientsRepository.Add(u);
                FillCombBox();
                FillClients();
            });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var client = GetSelectedClient();

            if (client == null)
                return;

            UiHelper.ShowEditClient(client, u =>
            {
                _clientsRepository.Update(u);
                FillCombBox();
                FillClients();
            });
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var client = GetSelectedClient();

            if (client == null)
                return;

            var result = UiHelper.ShowQuestion($"Esti sigur ca vrei sa stergi clientul {client.FullName} [{client.Cnp}]? " +
                                               "Actiunea de stergere este ireversibila", parent: ParentForm);

            if (result != DialogResult.Yes)
                return;

            _clientsRepository.Delete(client.Id);
            FillClients();
        }

        public void LoadUi()
        {
            _clientsRepository = Program.Resolver.Resolve<ClientsRepository>();
            _subscriptionRepository = Program.Resolver.Resolve<SubscriptionRepository>();
            _planRepository = Program.Resolver.Resolve<PlanRepository>();
            _invoiceRepository = Program.Resolver.Resolve<InvoiceRepository>();
            
            FillCombBox();
            FillClients();

            btnDelete.Visible = AccountRepository.User.Access >= AccessLevel.Admin;
        }

        private void FillCombBox()
        {
            var clientCities = _clientsRepository.GetAllClientCities().ToList();

            clientCities.Insert(0, ALL);

            cbCity.DataSource = clientCities;
            cbCity.SelectedIndex = 0;
        }

        private void FillClients(int page = 0)
        {
            try
            {
                lvClients.BeginUpdate();
                lvClients.Items.Clear();

                var filter = PredicateBuilder.True<Client>();

                if (!string.IsNullOrEmpty(txtSearch.Text))
                    filter = filter.And(c => c.FullName.Contains(txtSearch.Text) ||
                                             c.Email.Contains(txtSearch.Text) ||
                                             c.Cnp.Contains(txtSearch.Text));

                if (!string.IsNullOrEmpty(cbCity.Text) && cbCity.Text != ALL)
                    filter = filter.And(c => c.City.Contains(cbCity.Text));

                var clients = _clientsRepository.GetAllClients(filter, page, PAGE_SIZE).ToList();
                var clientIds = clients.Select(c => c.Id).ToArray();

                var subscriptions = _subscriptionRepository.GetAllSubscriptions(s => Sql.In(s.ClientId, clientIds)).ToList();
                var planIds = subscriptions.Select(s => s.PlanId).Distinct().ToArray();
                var plans = _planRepository.GetAllPlans(p => Sql.In(p.Id, planIds)).ToList();

                List<Invoice> invoices = new List<Invoice>();
                if (clientIds.Length > 0)
                    invoices = _invoiceRepository.GetAllInvoices(i => Sql.In(i.ClientId, clientIds))
                                                 .Where(i => !string.IsNullOrEmpty(i.PaidWith))
                                                 .ToList();

                lvClients.Items.AddRange(clients.Select(c => CreateListViewItem(c, subscriptions, plans, invoices)).ToArray());
            }
            finally
            {
                lvClients.EndUpdate();
            }
        }

        private static ListViewItem CreateListViewItem(Client client, 
                                                       IEnumerable<Subscription> subsciptions, 
                                                       IEnumerable<Plan> plans, 
                                                       IEnumerable<Invoice> invoices)
        {
            return new ListViewItem(client.FullName)
            {
                Tag = client.Id,
                SubItems =
                {
                    client.Address,
                    CreateSubscriptionItem(subsciptions.Where(s => s.ClientId == client.Id), plans),
                    CreateInvoices(client, invoices)
                }
            };
        }

        private static string CreateSubscriptionItem(IEnumerable<Subscription> subscriptions, IEnumerable<Plan> plans)
        {
            return string.Join(", ", subscriptions.Select(s => GetPlanName(s, plans))
                                                  .Where(s => !string.IsNullOrEmpty(s))
                                                  .GroupByQuantity()
                                                  .Select(g => $"{g.Quantity} {g.Item}"));
        }

        private static string GetPlanName(Subscription subscription, IEnumerable<Plan> plans)
        {
            var plan = plans.FirstOrDefault(p => p.Id == subscription.PlanId);

            return plan?.Name;
        }

        private static string CreateInvoices(Client client, IEnumerable<Invoice> invoices)
        {
            var invoiceDates = invoices.Where(i => i.ClientId == client.Id)
                                       .Select(i => i.Date)
                                       .ToList();

            if (invoiceDates.Count <= 0)
                return "-";

            if (invoiceDates.Count == 1)
                return invoiceDates[0].ToString("d", CultureInfo.CurrentCulture);

            return $"{invoiceDates.Count} facturi";
        }

        private Client GetSelectedClient()
        {
            if (lvClients.SelectedIndices.Count <= 0)
            {
                UiHelper.ShowMessage("Selectati un client", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            if (lvClients.SelectedIndices.Count != 1)
            {
                UiHelper.ShowMessage("Selectati un singur client", icon: MessageBoxIcon.Warning, parent: ParentForm);
                return null;
            }

            var selClientId = lvClients.SelectedItems[0].Tag as int? ?? -1;

            if (selClientId <= 0)
            {
                UiHelper.ShowMessage("Selectie incorecta", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            var user = _clientsRepository.GetById(selClientId);

            if (user == null)
            {
                UiHelper.ShowMessage("Client incorect", icon: MessageBoxIcon.Error, parent: ParentForm);
                return null;
            }

            return user;
        }
    }
}
