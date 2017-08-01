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
    public class InvoiceRepository
    {
        private readonly IContext _context;

        public InvoiceRepository(IContext context)
        {
            _context = context;
        }

        public IEnumerable<Invoice> GetAllInvoices(Expression<Func<Invoice, bool>> predicate = null)
        {
            using (var connection = _context.Connection)
            {
                if (predicate != null)
                    return connection.Select(predicate.And(i => i.RowState != RowState.Deleted));

                return connection.Select<Invoice>(c => c.RowState != RowState.Deleted);
            }
        }
    }
}
