using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyFoodOnlineShop.Data
{
    public class SetRoles
    {
        public static async Task InitializeAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var roleNames = new[] { "Admin" };
            IdentityResult roleResult;
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            foreach (var i in roleNames)
            {
                var exist = await roleManager.RoleExistsAsync(i);
                if (!exist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(i));
                }
            }

        }

    }

}
