using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.ApplicationUser;

namespace RepairShopStudio.Infrastructure.Data.Models.Account
{
    [Comment("Additional user properties")]
    public class ApplicationUser : IdentityUser
    {
        [Comment("User's first name")]
        [StringLength(ApplicationUserFirstNameMaxLength)]
        public string? FirstName { get; set; }

        [Comment("User's last name")]
        [StringLength(ApplicationUserLastNameMaxLength)]
        public string? LastName { get; set; }
    }
}
