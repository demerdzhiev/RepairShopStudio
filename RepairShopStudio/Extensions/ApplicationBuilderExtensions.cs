﻿using Microsoft.AspNetCore.Identity;
using RepairShopStudio.Common.Constants;
using RepairShopStudio.Infrastructure.Data.Models.User;
using static RepairShopStudio.Common.Constants.RoleConstants;

namespace RepairShopStudio.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedRolesInDatabase(this IApplicationBuilder app)
        {

            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            SeedAdmin(serviceProvider);
            SeedServiceAdivser(serviceProvider);
            SeedMechanic(serviceProvider);

            return app;
        }

        private static void SeedAdmin(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<ApplicationRole>>();

            Task.
                Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(Administrator))
                    {
                        return;
                    }

                    await roleManager.CreateAsync(new ApplicationRole(Administrator));

                    string email1 = "manager_repair_shop@mail.com";
                    var user = await userManager.FindByEmailAsync(email1);
                    await userManager.AddToRolesAsync(user, new string[] { Administrator, ServiceAdviser, Mechanic });
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedServiceAdivser(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<ApplicationRole>>();

            Task.
                Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(ServiceAdviser))
                    {
                        return;
                    }

                    await roleManager.CreateAsync(new ApplicationRole(ServiceAdviser));

                    string email2 = "adviser_repair_shop@mail.com";
                    var user2 = await userManager.FindByEmailAsync(email2);
                    await userManager.AddToRolesAsync(user2, new string[] { ServiceAdviser, Mechanic });
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedMechanic(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<ApplicationRole>>();

            Task.
                Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(Mechanic))
                    {
                        return;
                    }

                    await roleManager.CreateAsync(new ApplicationRole(Mechanic));

                    string email3 = "mechanic_repair_shop@mail.com";
                    var user3 = await userManager.FindByEmailAsync(email3);
                    await userManager.AddToRolesAsync(user3, new string[] { Mechanic });

                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
