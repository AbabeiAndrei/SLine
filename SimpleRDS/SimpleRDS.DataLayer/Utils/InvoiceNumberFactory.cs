using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleRDS.DataLayer.Base;
using SimpleRDS.DataLayer.Controllers;
using SimpleRDS.DataLayer.Entities;
using ServiceStack.OrmLite;

namespace SimpleRDS.DataLayer.Utils
{
    public class InvoiceNumberFactory : IInvoiceNumberFactory
    {
        private readonly IContext _context;
        private readonly SettingsRepository _settingsRepository;

        public InvoiceNumberFactory(IContext context, SettingsRepository settingsRepository)
        {
            _context = context;
            _settingsRepository = settingsRepository;
        }

        public string Series => _settingsRepository.GetValue(Setting.Keys.INVOICE_SERIES);

        public async Task<string> GetSeriesAsync(CancellationToken cancellationToken)
        {
            return await _settingsRepository.GetValueAsync(Setting.Keys.INVOICE_SERIES, cancellationToken);
        }

        public async Task<string> GetSeriesAsync(IDbConnection connection, CancellationToken cancellationToken)
        {
            return await _settingsRepository.GetValueAsync(Setting.Keys.INVOICE_SERIES, connection, cancellationToken);
        }

        public int GenerateNumber()
        {
            using (var connection = _context.Connection)
            {
                var query = connection.From<Invoice>()
                                      .Select(c => c.Numar);
                var result = connection.Column<string>(query);

                return GenerateNumber(result);
            }
        }

        public async Task<int> GenerateNumberAsync(CancellationToken cancellationToken)
        {
            using (var connection = _context.Connection)
            {
                return await GenerateNumberAsync(connection, cancellationToken);
            }
        }

        public async Task<int> GenerateNumberAsync(IDbConnection connection, CancellationToken cancellationToken)
        {
            var query = connection.From<Invoice>()
                                    .Select(c => c.Numar);
            var result = await connection.ColumnAsync<string>(query, cancellationToken);

            return GenerateNumber(result);
        }

        private static int GenerateNumber(IEnumerable<string> result)
        {
            return result.Select(s =>
                         {
                             int i;
                             if (int.TryParse(s, out i))
                                 return i;

                             return (int?)null;
                         }).Where(i => i.HasValue)
                         .Select(i => i.Value)
                         .DefaultIfEmpty(0)
                         .Max() + 1;
        }
    }
}
