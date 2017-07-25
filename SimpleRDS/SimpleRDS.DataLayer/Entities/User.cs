using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRDS.DataLayer.Entities
{
    public enum AccessLevel : short
    {
        Regular = 0,
        Manager,
        Admin = 1
    }

    public enum RowState : short
    {
        Created = 0,
        Deleted = 1
    }

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public AccessLevel Access { get; set; }

        public RowState RowState { get; set; }
    }
}
