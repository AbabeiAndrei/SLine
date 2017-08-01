using System.Linq;
using System.Net.Http.Headers;
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
    }
}
