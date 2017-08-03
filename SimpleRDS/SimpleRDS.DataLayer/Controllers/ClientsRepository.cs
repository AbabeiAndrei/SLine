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
        private static Expression<Func<Client, bool>> _excludeDeletePredicate;

        private readonly IContext _context;

        public ClientsRepository(IContext context)
        {
            _context = context;
        }

        static ClientsRepository()
        {
            _excludeDeletePredicate = c => c.RowState != RowState.Deleted;
        }

        public IEnumerable<string> GetAllClientCities()
        {
            using (var connection = _context.Connection)
            {
                var query = connection.From<Client>()
                                      .Where(_excludeDeletePredicate)
                                      .Select(c => c.City);
                return connection.ColumnDistinct<string>(query);
            }
        }

        public IEnumerable<Client> GetAllClients(Expression<Func<Client, bool>> predicate = null)
        {
            using (var connection = _context.Connection)
            {
                predicate = predicate?.And(_excludeDeletePredicate) ?? _excludeDeletePredicate;

                return connection.Select(predicate);
            }
        }

        public IEnumerable<Client> GetAllClients(Expression<Func<Client, bool>> predicate, int page, int pageSize)
        {
            using (var connection = _context.Connection)
            {
                predicate = predicate?.And(_excludeDeletePredicate) ?? _excludeDeletePredicate; 

                var query = connection.From<Client>()
                                      .Where(predicate)
                                      .Limit(page * pageSize, pageSize);

                return connection.Select(query);
            }
        }

        public long Count(Expression<Func<Client, bool>> predicate)
        {
            using (var connection = _context.Connection)
            {
                predicate = predicate?.And(_excludeDeletePredicate) ?? _excludeDeletePredicate;

                return connection.Count(predicate);
            }
        }

        public Client GetById(int clientId)
        {
            using (var connection = _context.Connection)
            {
                return connection.SingleById<Client>(clientId);
            }
        }

        public void Add(Client client)
        {
            using (var connection = _context.Connection)
            {
                connection.Insert(client);
            }
        }

        public void Update(Client client)
        {
            using (var connection = _context.Connection)
            {
                connection.Update(client);
            }
        }

        public void Delete(int clientId)
        {
            using (var connection = _context.Connection)
            {
                var client = connection.SingleById<Client>(clientId);
                client.RowState = RowState.Deleted;
                connection.Update(client);
            }
        }
    }
}
