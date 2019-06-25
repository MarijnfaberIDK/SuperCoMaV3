using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Areas.Identity.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Infix { get; set; }

        public string Postalcode { get; set; }

        public string Streetname { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }
    }
}
