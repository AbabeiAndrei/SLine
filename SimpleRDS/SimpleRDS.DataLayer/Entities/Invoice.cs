using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace SimpleRDS.DataLayer.Entities
{
    public class Invoice : IHasId<int>
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string Serie { get; set; }

        public string Numar { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(typeof(Client), OnDelete = "RESTRICT", OnUpdate = "RESTRICT")]
        public int ClientId { get; set; }

        [ForeignKey(typeof(Subscription), OnDelete = "RESTRICT", OnUpdate = "RESTRICT")]
        public int SubscriptionId { get; set; }

        //only manager
        public string StornoFor { get; set; }

        public string PaidWith { get; set; }

        public RowState RowState { get; set; }
    }
}
