using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite.Legacy;
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Base;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.DataLayer.Controllers
{
    public class ClientsRepository
    {
        private readonly IContext _context;

        public ClientsRepository(IContext context)
        {
            _context = context;
        }

        public IEnumerable<string> GetAllClientCities()
        {
            using (var connection = _context.Connection)
            {
                return connection.Select<Client>($"SELECT * FROM Client WHERE RowState = {(int)RowState.Created} GROUP BY City")
                                 .Select(c => c.City)
                                 .Distinct();
            }
        }

        public IEnumerable<Client> GetAllClients(Expression<Func<Client, bool>> predicate = null)
        {
            using (var connection = _context.Connection)
            {
                if (predicate != null)
                    return connection.Select(predicate.And(c => c.RowState != RowState.Deleted));

                return connection.Select<Client>(c => c.RowState != RowState.Deleted);
            }
        }
    }
}
