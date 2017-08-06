using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Base;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.DataLayer.Controllers
{
    public class SubscriptionRepository
    {
        private readonly IContext _context;

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
    }
}
