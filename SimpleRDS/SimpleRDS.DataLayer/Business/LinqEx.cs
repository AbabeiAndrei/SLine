using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRDS.DataLayer.Business
{
    public static class LinqEx
    {
        public static IEnumerable<IQuantityGrouping<TSource>> GroupByQuantity<TSource>(this IEnumerable<TSource> source)
        {
            return GroupByQuantity(source, i => i);
        }
        public static IEnumerable<IQuantityGrouping<TSource>> GroupByQuantity<TSource, TSelector>(this IEnumerable<TSource> source,
                                                                                                  Func<TSource, TSelector> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return source.GroupBy(selector)
                         .Select(g => new QuantityGrouping<TSource>(g.Count(), g.First()));
        }
    }
}
