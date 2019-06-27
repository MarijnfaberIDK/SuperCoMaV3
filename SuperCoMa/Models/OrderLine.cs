using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperCoMa.Areas.Admin.Models;
using SuperCoMa.Models;

namespace SuperCoMa.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; } //prijs per product


        public ProductsModel Product { get; set; }
        public int ProductId { get; set; }

        public Order Order { get; set; }
        public int Orderid { get; set; }
    }
}
