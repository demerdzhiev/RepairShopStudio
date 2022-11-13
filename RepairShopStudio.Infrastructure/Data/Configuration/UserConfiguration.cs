using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models.User;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "General_Manager",
                NormalizedUserName = "GENERAL_MANAGER",
                Email = "manager_repair_shop@mail.com",
                NormalizedEmail = "MANAGER_REPAIR_SHOP@MAIL.COM",
                JobTitleId = "3bb29f58-330b-47d7-8c88-66e47a5fd4aa"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "Manager123!");

            users.Add(user);

            var user1 = new ApplicationUser()
            {
                Id = "trg12856-c198-2563-b3f3-b893d8398710",
                UserName = "Mechanic",
                NormalizedUserName = "MECHANIC",
                Email = "mechanic_repair_shop@mail.com",
                NormalizedEmail = "MECHANIC_REPAIR_SHOP@MAIL.COM",
                JobTitleId = "093fd016-778f-4043-b72e-827c1834c4e2"
            };

            user1.PasswordHash =
                 hasher.HashPassword(user, "Mechanic123!");

            users.Add(user1);

            var user2 = new ApplicationUser()
            {
                Id = "asd12856-c188-4659-b3f3-b893s1395192",
                UserName = "Service_Adviser",
                NormalizedUserName = "SERVICE_ADVISER",
                Email = "adviser_repair_shop@mail.com",
                NormalizedEmail = "ADVISER_REPAIR_SHOP@MAIL.COM",
                JobTitleId = "16afcac4-cb26-4c2e-9586-7cc4c2fab81c"
            };

            user2.PasswordHash =
                 hasher.HashPassword(user2, "Adviser123!");

            users.Add(user2);

            return users;
        }
    }
}
