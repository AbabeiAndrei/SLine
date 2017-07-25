using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.DataLayer.Business
{
    public class PasswordHasher : IPasswordHasher<User>
    {
        public string HashPassword(User salt, string password)
        {
            SHA256Managed crypt = new SHA256Managed();
            var passWithSalt = password + "-" + salt.Email.GetHashCode();


            var hash = string.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(passWithSalt), 0, Encoding.ASCII.GetByteCount(passWithSalt));
            foreach (byte theByte in crypto)
                hash += theByte.ToString("x2");

            return hash;
        }

        public bool IsValidHash(User salt, string password, string hash)
        {
            return HashPassword(salt, password) == hash;
        }
    }
}
