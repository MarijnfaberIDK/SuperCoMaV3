using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperCoMa.Models;

[assembly: HostingStartup(typeof(SuperCoMa.Areas.Identity.IdentityHostingStartup))]
namespace SuperCoMa.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SuperCoMaContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SuperCoMaContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<SuperCoMaContext>();
            });
        }
    }
}