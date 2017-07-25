using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using SimpleRDS.DataLayer.Business;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.DataLayer
{
    public class DbContext
    {
        private readonly OrmLiteConnectionFactory _dbContext;

        public DbContext(string connectionString)
        {
            _dbContext = new OrmLiteConnectionFactory(connectionString, new MySqlDialectProvider());
        }

        public void ExecuteCodeFirstMigration()
        {
            using (var connection = _dbContext.OpenDbConnection())
            {
                connection.CreateTableIfNotExists<Client>();
                connection.CreateTableIfNotExists<Invoice>();
                connection.CreateTableIfNotExists<Plan>();
                connection.CreateTableIfNotExists<Setting>();
                connection.CreateTableIfNotExists<Subscription>();
                connection.CreateTableIfNotExists<User>();
            }
        }

        public void SeedData(IPasswordHasher<User> hasher)
        {
            using (var connection = _dbContext.OpenDbConnection())
            {
                if(connection.Select<User>().Any())
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

                connection.Insert(user);
            }
        }

        public IEnumerable<User> Users => GetAll<User>();

        private IEnumerable<T> GetAll<T>()
        {
            using (var connection = _dbContext.OpenDbConnection())
            {
                return connection.Select<T>();
            }
        }
    }
}
