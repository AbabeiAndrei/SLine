using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace SimpleRDS.DataLayer.Entities
{
    public enum PricePlan : short
    {
        None = 0,
        OneTime = 1,
        EveryDay = 2,
        EveryWeek = 3,
        EveryMonth = 4,
        EveryThreeMoths = 5,
        TwiceAYear = 6,
        Yearly = 7 
    }

    public enum PlanState : short
    {
        Active = 0,
        Suspended = 1,
        Closed = 2
    }

    public class Plan : IHasId<int>
    {
        [AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public PricePlan PricePlan {get; set; }

        public DateTime? ActiveFrom { get; set; }

        public DateTime? ActiveUntil { get; set; }

        public PlanState State { get; set; }
    }
}
