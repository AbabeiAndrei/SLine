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
                    return connection.Select(predicate.And(p => p.State != PlanState.Closed));

                return connection.Select<Plan>(p => p.State != PlanState.Closed);
            }
        }

        public Plan GetById(int planId)
        {
            using (var connection = _context.Connection)
            {
                return connection.SingleById<Plan>(planId);
            }
        }

        public void Add(Plan plan)
        {
            using (var connection = _context.Connection)
            {
                connection.Insert(plan);
            }
        }

        public void Update(Plan plan)
        {
            using (var connection = _context.Connection)
            {
                connection.Update(plan);
            }
        }

        public void Delete(int planId)
        {
            using (var connection = _context.Connection)
            {
                var user = connection.SingleById<Plan>(planId);
                user.State = PlanState.Closed;
                connection.Update(user);
            }
        }
    }
}
