using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace SimpleRDS.DataLayer.Entities
{
    public enum AccessLevel : short
    {
        Regular = 0,
        Manager = 1,
        Admin = 2
    }

    public enum RowState : short
    {
        Created = 0,
        Deleted = 1
    }

    public class User : IHasId<int>
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public AccessLevel Access { get; set; }

        public RowState RowState { get; set; }
    }
}
