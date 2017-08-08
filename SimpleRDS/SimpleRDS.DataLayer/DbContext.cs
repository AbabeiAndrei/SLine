using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using ServiceStack.OrmLite.MySql;
using SimpleRDS.DataLayer.Base;
using SimpleRDS.DataLayer.Business;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.DataLayer
{
    public class DbContext : IContext
    {
        private readonly OrmLiteConnectionFactory _dbContext;

        public IEnumerable<Subscription> Subscriptions => GetAll<Subscription>();

        public IDbConnection Connection => _dbContext.OpenDbConnection();
        public IEnumerable<User> Users => GetAll<User>();
        public IEnumerable<Client> Clients => GetAll<Client>();
        public IEnumerable<Plan> Plans => GetAll<Plan>();
        public IEnumerable<Setting> Settings => GetAll<Setting>();

        public DbContext(string connectionString)
        {
            _dbContext = new OrmLiteConnectionFactory(connectionString, new MySqlDialectProvider());
        }

        public void UpdateDatabase()
        {
            using (var connection = _dbContext.OpenDbConnection())
            {
                connection.CreateTableIfNotExists<User>();
                connection.CreateTableIfNotExists<Plan>();
                connection.CreateTableIfNotExists<Client>();
                connection.CreateTableIfNotExists<Subscription>();
                connection.CreateTableIfNotExists<Invoice>();
                connection.CreateTableIfNotExists<Setting>();
            }
        }

        public async Task SeedData(IPasswordHasher<User> hasher)
        {
            using (var connection = _dbContext.OpenDbConnection())
            {
                if(connection.Select<User>(u => u.RowState == RowState.Created).Any())
                    return;

                var user = new User
                {
                    FullName = "Admin - System User",
                    Access = AccessLevel.Admin,
                    Email = "admin@system.local",
                    Username = "admin",
                    RowState = RowState.Created
                };


                                                        //todo change to more secure
                user.Password = hasher.HashPassword(user, "password");

                await connection.InsertAsync(user);
            }
        }

        public IEnumerable<T> GetAll<T>()
        {
            using (var connection = _dbContext.OpenDbConnection())
            {
                return connection.Select<T>();
            }
        }
    }
}
