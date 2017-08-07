using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Base;
using SimpleRDS.DataLayer.Entities;
using SimpleRDS.DataLayer.Utils;

namespace SimpleRDS.DataLayer.Controllers
{
    public class SubscriptionRepository
    {
        private readonly IContext _context;

        public bool IssuingInvoices { get; private set; }


        public SubscriptionRepository(IContext context)
        {
            _context = context;
        }


        public IEnumerable<Subscription> GetAllSubscriptions(Expression<Func<Subscription, bool>> predicate = null)
        {
            using (var connection = _context.Connection)
            {
                if (predicate != null)
                    return connection.Select(predicate.And(s => s.State != SubscriptionState.Deleted));

                return connection.Select<Subscription>(s => s.State != SubscriptionState.Deleted);
            }
        }

        public Subscription GetById(int subscriptionId)
        {
            using (var connection = _context.Connection)
            {
                return connection.SingleById<Subscription>(subscriptionId);
            }
        }

        public void Add(Subscription subscription)
        {
            using (var connection = _context.Connection)
            {
                connection.Insert(subscription);
            }
        }

        public void Update(Subscription subscription)
        {
            using (var connection = _context.Connection)
            {
                connection.Update(subscription);
            }
        }

        public void Delete(int subscriptionId)
        {
            using (var connection = _context.Connection)
            {
                var subscription = connection.SingleById<Subscription>(subscriptionId);
                subscription.State = SubscriptionState.Deleted;
                connection.Update(subscription);
            }
        }

        public async Task<int> IssueInvoices(InvoiceRepository invoiceRepository, PlanRepository planRepository, IInvoiceNumberFactory invoiceNumberFactory, CancellationToken cancelationToken)
        {
            int invoiceIssued = 0;

            try
            {
                IssuingInvoices = true;
                
                using (var connection = _context.Connection)
                {
                    var subscriptions = await connection.SelectAsync<Subscription>(s => s.State != SubscriptionState.Suspended && 
                                                                                        s.State != SubscriptionState.Deleted, cancelationToken);
                    foreach (var subscription in subscriptions)
                    {
                        if (cancelationToken.IsCancellationRequested)
                            return invoiceIssued;

                        var plan = await planRepository.GetByIdAsync(subscription.PlanId, connection, cancelationToken);

                        var invoices = await invoiceRepository.GetAllInvoicesAsync(connection, cancelationToken, i => i.SubscriptionId == subscription.Id);

                        var needInvoice = NeedInvoice(plan, subscription, invoices);

                        if (!needInvoice)
                            continue;

                        var invoiceNumber = await invoiceNumberFactory.GenerateNumberAsync(connection, cancelationToken);

                        var invoice = new Invoice
                        {
                            ClientId = subscription.ClientId,
                            Date = DateTime.Now,
                            Serie = invoiceNumberFactory.Series,
                            Numar = invoiceNumber.ToString(),
                            SubscriptionId = subscription.Id,
                            RowState = RowState.Created,
                            StornoFor = string.Empty
                        };

                        await invoiceRepository.AddAsync(invoice, connection, cancelationToken);
                        invoiceIssued++;
                    }
                }
            }
            finally
            {
                IssuingInvoices = false;
            }

            return invoiceIssued;
        }

        private static bool NeedInvoice(Plan plan, Subscription subscription, IReadOnlyCollection<Invoice> invoices)
        {
            DateTime date;

            switch (plan.PricePlan)
            {
                case PricePlan.None:
                    return false;
                case PricePlan.OneTime:
                    return invoices.Count <= 0;
                case PricePlan.EveryDay:
                    date = DateTime.Now.Date;
                    break;
                case PricePlan.EveryWeek:
                    date = DateTime.Now.AddDays(-7).Date;
                    break;
                case PricePlan.EveryMonth:
                    date = DateTime.Now.AddMonths(-1).Date;
                    break;
                case PricePlan.EveryThreeMoths:
                    date = DateTime.Now.AddMonths(-3).Date;
                    break;
                case PricePlan.TwiceAYear:
                    date = DateTime.Now.AddMonths(-6).Date;
                    break;
                case PricePlan.Yearly:
                    date = DateTime.Now.AddYears(-1).Date;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return subscription.ActiveFrom < date && invoices.All(i => i.Date.Date < date);
        }
    }
}
