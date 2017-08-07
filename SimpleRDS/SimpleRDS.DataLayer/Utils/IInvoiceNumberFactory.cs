using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleRDS.DataLayer.Utils
{
    public interface IInvoiceNumberFactory
    {
        string Series { get; }
        Task<string> GetSeriesAsync(CancellationToken cancellationToken);
        Task<string> GetSeriesAsync(IDbConnection connection, CancellationToken cancellationToken);

        int GenerateNumber();
        Task<int> GenerateNumberAsync(CancellationToken cancellationToken);
        Task<int> GenerateNumberAsync(IDbConnection connection, CancellationToken cancellationToken);
    }
}
