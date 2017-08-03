using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;

namespace SimpleRDS.DataLayer.Utils
{
    public static class PagingExtensions
    {
        public static SqlExpression<T> Page<T>(this SqlExpression<T> exp, int? page, int? pageSize)
        {
            if (!page.HasValue || !pageSize.HasValue)
                return exp;

            if (page <= 0)
                throw new ArgumentOutOfRangeException(nameof(page), "Page must be a number greater than 0.");
            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "PageSize must be a number greater than 0.");
            
            int skip = (page.Value - 1) * pageSize.Value;
            int take = pageSize.Value;

            return exp.Limit(skip, take);
        }


        public static int? LimitToRange(this int? value, int? inclusiveMinimum, int? inclusiveMaximum)
        {
            if (!value.HasValue)
                return null;

            if (inclusiveMinimum.HasValue && value < inclusiveMinimum)
                return inclusiveMinimum; 
            if (inclusiveMaximum.HasValue && value > inclusiveMaximum)
                return inclusiveMaximum; 

            return value;
        }
    }
}
