using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Models
{
    public class SalesClass
    {
        public int SaleId { get; set; }
        public string Title { get; set; }
        public string EAN { get; set; }
        public Decimal DiscountPrice { get; set; }
        public string ValidUntil { get; set; }
    }
}
