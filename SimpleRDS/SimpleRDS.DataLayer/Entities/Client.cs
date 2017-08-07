using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace SimpleRDS.DataLayer.Entities
{
    public enum ClientType : short
    {
        Person = 0,
        Company = 1
    }

    public class Client : IHasId<int>
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Cnp { get; set; }

        public string SerieCi { get; set; }

        public string NumarCi { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public DateTime BirthDate { get; set; }

        public ClientType Type { get; set; }

        public DateTime CreatedAt { get; set; }

        //[ForeignKey(typeof(User), OnDelete = "RESTRICT", OnUpdate = "RESTRICT")]
        public int CreatedBy { get; set; }

        public RowState RowState { get; set; }


    }
}
