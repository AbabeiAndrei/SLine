using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRDS.DataLayer.Entities
{
    public class Setting
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime ChangedAt { get; set; }

        public int ChangedBy { get; set; }

        public static class Keys
        {
            public const string INVOICE_SERIES = "INVOICE_SERIES";

            public const string INVOICE_START_NUMBER = "INVOICE_START_NUMBER";
        }
    }
}
