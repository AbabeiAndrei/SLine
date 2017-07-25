using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRDS.DataLayer.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        public string Serie { get; set; }

        public string Numar { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public int SubscriptionId { get; set; }

        //only manager
        public bool IsStorno { get; set; }

        public RowState RowState { get; set; }
    }
}
