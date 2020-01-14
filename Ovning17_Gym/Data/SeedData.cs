using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ovning17_Gym.Data;
using Ovning17_Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ovning17_Gym.Data
{
    public static class SeedData
    {
        internal static async Task InitializeAsync(IServiceProvider services, string adminPW)
        {
            var options = services.GetRequiredService<DbContextOptions<ApplicationDbContext>>();

            using (var context = new ApplicationDbContext(options))
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                var roleNames = new[] { "Admin", "Member" };


                foreach (var name in roleNames)
                {
                    //Om rollen finns fortsätt
                    if (await roleManager.RoleExistsAsync(name)) continue;

                    //Annars skapa rollen
                    var role = new IdentityRole { Name = name };

                    var result = await roleManager.CreateAsync(role);


                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join("\n", result.Errors));
                    }
                }

                var emails = new[] { "admin@gym.se" };

                foreach (var email in emails)
                {
                    var foundUser = await userManager.FindByEmailAsync(email);

                    if (foundUser != null) continue;

                    var user = new ApplicationUser { UserName = email, Email = email } ;

                    var addUserResult = await userManager.CreateAsync(user, adminPW);

                    if (!addUserResult.Succeeded)
                    {
                        throw new Exception(string.Join("\n", addUserResult.Errors));
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
