using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using SimpleRDS.DataLayer.Entities;

namespace SimpleRDS.Utils
{
    public static class Translator
    {
        public static string Translate(this AccessLevel access)
        {
            switch (access)
            {
                case AccessLevel.Regular:
                    return "Opearator";
                case AccessLevel.Manager:
                    return "Manager";
                case AccessLevel.Admin:
                    return "Administrator";
                default:
                    throw new ArgumentOutOfRangeException(nameof(access), access, null);
            }
        }

        public static string Translate(this PricePlan pricePlan)
        {
            switch (pricePlan)
            {
                case PricePlan.None:
                    return "Niciunul";
                case PricePlan.OneTime:
                    return "O singura data";
                case PricePlan.EveryDay:
                    return "In fiecare zi";
                case PricePlan.EveryWeek:
                    return "In fiecare saptamana";
                case PricePlan.EveryMonth:
                    return "In fiecare luna";
                case PricePlan.EveryThreeMoths:
                    return "La fiecare 3 luni";
                case PricePlan.TwiceAYear:
                    return "De doua ori pe an";
                case PricePlan.Yearly:
                    return "Anual";
                default:
                    throw new ArgumentOutOfRangeException(nameof(pricePlan), pricePlan, null);
            }
        }

        public static string Translate(this PlanState state)
        {
            switch (state)
            {
                case PlanState.Active:
                    return "Activ";
                case PlanState.Suspended:
                    return "Suspendat";
                case PlanState.Closed:
                    return "Inchis";
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public static string Translate(this SubscriptionState state)
        {
            switch (state)
            {
                case SubscriptionState.Created:
                    return "Creata";
                case SubscriptionState.Active:
                    return "Actvia";
                case SubscriptionState.Suspended:
                    return "Suspendata";
                case SubscriptionState.Deleted:
                    return "Stearsa";
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}
