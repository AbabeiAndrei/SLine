using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRDS.DataLayer.Entities
{
    public enum SubscriptionState : short
    {
        Created = 0,
        Active = 1,
        Suspended = 2,
        Deleted = 3
    }

    public class Subscription
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int PlanId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime? SubscriptionEnd { get; set; }

        public DateTime? ExpireAt { get; set; }

        public SubscriptionState State { get; set; }
    }
}
