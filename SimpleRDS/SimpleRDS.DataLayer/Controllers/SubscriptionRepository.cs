﻿using System;
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
                    return connection.Select(predicate.And(c => c.State != SubscriptionState.Deleted));

                return connection.Select<Subscription>(c => c.State != SubscriptionState.Deleted);
            }
        }
    }
}
