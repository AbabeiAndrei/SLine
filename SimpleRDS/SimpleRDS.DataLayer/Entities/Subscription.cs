using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace SimpleRDS.DataLayer.Entities
{
    public enum SubscriptionState : short
    {
        Created = 0,
        Active = 1,
        Suspended = 2,
        Deleted = 3
    }

    public class Subscription : IHasId<int>
    {
        [AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Client), OnDelete = "RESTRICT", OnUpdate = "RESTRICT")]
        public int ClientId { get; set; }

        [ForeignKey(typeof(Plan), OnDelete = "RESTRICT", OnUpdate = "RESTRICT")]
        public int PlanId { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey(typeof(User), OnDelete = "RESTRICT", OnUpdate = "RESTRICT")]
        public int CreatedBy { get; set; }

        public string Address { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime? SubscriptionEnd { get; set; }

        public DateTime? ExpireAt { get; set; }

        public SubscriptionState State { get; set; }
    }
}
