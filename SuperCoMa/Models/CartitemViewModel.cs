using SuperCoMa.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Models
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public string Category { get; set; }

        public double Price { get; set; }
        public double TotalPrice
        {
            get
            {
                return Price * Amount;
            }
        }
    }
}
