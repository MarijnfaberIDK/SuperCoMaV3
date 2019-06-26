using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperCoMa.Areas.Identity.Data
{
    public class Seed
    {
        public static void SeedUsers(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole { Name = "Admin" };
                roleManager.CreateAsync(role).Wait();
            }

            if (roleManager.FindByNameAsync("Webredacteur").Result == null)
            {
                IdentityRole role = new IdentityRole { Name = "Webredacteur" };
                roleManager.CreateAsync(role).Wait();
            }

            //if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            //{
            //    IdentityUser user = new IdentityUser
            //    {
            //        UserName = "admin@admin.com",
            //        Email = "admin@admin.com"
            //    };

            //    IdentityResult result = userManager.CreateAsync(user, "Admin!23").Result;

            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRoleAsync(user, "Admin").Wait();
            //    }
            //}    
            
            //if (userManager.FindByEmailAsync("hans@webredacteur.com").Result == null)
            //{
            //    IdentityUser user = new IdentityUser
            //    {
            //        UserName = "hans@webredacteur.com",
            //        Email = "hans@webredacteur.com"
            //    };

            //    IdentityResult result = userManager.CreateAsync(user, "Webredacteur!23").Result;

            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRoleAsync(user, "Webredacteur").Wait();
            //    }
            //}
        }
    }
}
