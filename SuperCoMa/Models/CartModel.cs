using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string Status { get; set; }
        //nog toevoegen: Product-Cart
    }
}
