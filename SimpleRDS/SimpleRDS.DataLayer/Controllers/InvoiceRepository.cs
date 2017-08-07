using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
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

        public Invoice GetById(int invoiceId)
        {
            using (var connection = _context.Connection)
            {
                return connection.SingleById<Invoice>(invoiceId);
            }
        }

        public void Update(Invoice invoice)
        {
            using (var connection = _context.Connection)
            {
                connection.Update(invoice);
            }
        }

        public void Add(Invoice invoice)
        {
            using (var connection = _context.Connection)
            {
                Add(invoice, connection);
            }
        }

        public void Add(Invoice invoice, IDbConnection connection)
        {
            connection.Insert(invoice);
        }

        public async Task AddAsync(Invoice invoice)
        {
            using (var connection = _context.Connection)
            {
                await AddAsync(invoice, connection);
            }
        }

        public async Task AddAsync(Invoice invoice, IDbConnection connection)
        {
            await connection.InsertAsync(invoice);
        }
        public async Task AddAsync(Invoice invoice, IDbConnection connection, CancellationToken cancellationToken)
        {
            await connection.InsertAsync(invoice, token: cancellationToken);
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync(Expression<Func<Invoice, bool>> predicate = null)
        {
            return await GetAllInvoicesAsync(CancellationToken.None, predicate);
        }
        public async Task<List<Invoice>> GetAllInvoicesAsync(CancellationToken cancelationToken, Expression<Func<Invoice, bool>> predicate = null)
        {
            using (var connection = _context.Connection)
            {
                return await GetAllInvoicesAsync(connection, cancelationToken, predicate);
            }
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync(IDbConnection connection, CancellationToken cancelationToken, Expression<Func<Invoice, bool>> predicate = null)
        {
            if (predicate != null)
                return await connection.SelectAsync(predicate.And(i => i.RowState != RowState.Deleted), cancelationToken);

            return await connection.SelectAsync<Invoice>(c => c.RowState != RowState.Deleted, cancelationToken);
        }
    }
}
