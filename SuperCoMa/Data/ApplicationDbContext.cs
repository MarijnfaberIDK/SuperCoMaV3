using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperCoMa.Areas.Admin.Models;
using SuperCoMa.Areas.Identity.Data;
using SuperCoMa.Models;

namespace SuperCoMa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductsModel> ProductsModel { get; set; }
    }
}
