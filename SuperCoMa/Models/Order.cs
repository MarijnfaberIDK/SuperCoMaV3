using Microsoft.AspNetCore.Identity;
using SuperCoMa.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }

        public DateTime OrderDate { get; set; }

        public IdentityUser Customer { get; set; }
        public string CustomerId { get; set; }

        public List<OrderLine> OrderLines { get; set; }

        public ProductsModel order { get; set; }

    }
}
