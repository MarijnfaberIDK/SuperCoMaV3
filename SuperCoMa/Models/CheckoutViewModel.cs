using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Models
{
    public class CheckoutViewModel
    {
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        [Required]
        public string Postalcode { get; set; }
        [Required]
        public string City { get; set; }
    }
}
