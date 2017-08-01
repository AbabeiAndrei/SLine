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
    public class PlanRepository
    {
        private readonly IContext _context;

        public PlanRepository(IContext context)
        {
            _context = context;
        }

        public IEnumerable<Plan> GetAllPlans(Expression<Func<Plan, bool>> predicate = null)
        {
            using (var connection = _context.Connection)
            {
                if (predicate != null)
                    return connection.Select(predicate.And(c => c.State != PlanState.Closed));

                return connection.Select<Plan>(c => c.State != PlanState.Closed);
            }
        }
    }
}
