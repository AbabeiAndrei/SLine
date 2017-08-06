using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRDS.Utils
{
    public static class Extensions
    {
        public static int DefaultIfZero(this int value, int defaultValue)
        {
            return value == 0
                       ? defaultValue
                       : value;
        }
    }
}
