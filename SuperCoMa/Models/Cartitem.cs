using SuperCoMa.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public ProductsModel Product { get; set; }

    }
}
