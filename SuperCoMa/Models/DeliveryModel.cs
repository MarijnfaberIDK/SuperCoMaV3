using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Models
{
    public class DeliveryModel
    {
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public Decimal Price { get; set; }
    }
}
