using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Base;
using SimpleRDS.DataLayer.Business;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.DataLayer.Controllers
{
    public class AccountRepository
    {
        private readonly IContext _context;
        private readonly IPasswordHasher<User> _hasher;

        public static User User { get; protected set; }

        public AccountRepository(IContext context, IPasswordHasher<User> hasher)
        {
            _context = context;
            _hasher = hasher;
        }

        public User Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
                return null;

            if (!_hasher.IsValidHash(user, password, user.Password))
                return null;

            if (user.RowState == RowState.Deleted)
                return null;

            return User = user;
        }

        public void Logout()
        {
            User = null;
        }

        public IEnumerable<User> GetAllUsers(Expression<Func<User, bool>> predicate = null)
        {
            using (var connection = _context.Connection)
            {
                if (predicate != null)
                    return connection.Select(predicate.And(u => u.RowState != RowState.Deleted));

                return connection.Select<User>(u => u.RowState != RowState.Deleted);
            }
        }

        public User GetById(int userId)
        {
            using (var connection = _context.Connection)
            {
                return connection.SingleById<User>(userId);
            }
        }

        public void Add(User user)
        {
            using (var connection = _context.Connection)
            {
                connection.Insert(user);
            }
        }

        public void Update(User user)
        {
            using (var connection = _context.Connection)
            {
                connection.Update(user);
            }
        }

        public void Delete(int userId)
        {
            using (var connection = _context.Connection)
            {
                var user = connection.SingleById<User>(userId);
                user.RowState = RowState.Deleted;
                connection.Update(user);
            }
        }
    }
}
