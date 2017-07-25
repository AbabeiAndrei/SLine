using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRDS.DataLayer.Entities
{
    public enum ClientType : short
    {
        Person = 0,
        Company = 1
    }

    public class Client
    {
        public int Id { get; set; }

        public int FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Cnp { get; set; }

        public string SerieCi { get; set; }

        public string NumarCi { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public ClientType Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public RowState RowState { get; set; }


    }
}
