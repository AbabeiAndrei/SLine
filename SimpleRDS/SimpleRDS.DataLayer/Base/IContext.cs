using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleRDS.DataLayer.Business;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.DataLayer.Base
{
    public interface IContext
    {
        IDbConnection Connection { get; }
        IEnumerable<User> Users { get; }
        IEnumerable<Client> Clients { get; }
        IEnumerable<Plan> Plans { get; }
        IEnumerable<Setting> Settings { get; }
        IEnumerable<Subscription> Subscriptions { get; }
        
        void UpdateDatabase();
        Task SeedData(IPasswordHasher<User> hasher);
        IEnumerable<T> GetAll<T>();
    }
}
