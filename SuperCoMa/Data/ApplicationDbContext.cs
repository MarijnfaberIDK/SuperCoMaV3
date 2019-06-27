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
        public DbSet<ProductsModel> OrderLine { get; set; }
        public DbSet<ProductsModel> Order { get; set; }
        public DbSet<ProductsModel> CheckOutViewModel { get; set; } //als er iets niet werkt moet deze weg
        public DbSet<ProductsModel> ProductsModel { get; set; }
    }
}
