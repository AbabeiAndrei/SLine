using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace SimpleRDS.DataLayer.Entities
{
    public class Setting : IHasId<int>
    {
        [AutoIncrement]
        public int Id { get; set; }

        [Index(Unique = true)]
        [StringLength(40)]
        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime ChangedAt { get; set; }

        [ForeignKey(typeof(User), OnDelete = "RESTRICT", OnUpdate = "RESTRICT")]
        public int ChangedBy { get; set; }

        public static class Keys
        {
            public const string INVOICE_SERIES = "INVOICE_SERIES";

            public const string INVOICE_START_NUMBER = "INVOICE_START_NUMBER";
        }
    }
}
