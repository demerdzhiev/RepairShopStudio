using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.ApplicationUser;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;

namespace RepairShopStudio.Infrastructure.Data.Models.User
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

        [Comment("Job title of the employee")]
        public string JobTitleId { get; set; } = null!;
        [ForeignKey(nameof(JobTitleId))]
        public JobTitle? JobTitle { get; set; }
    }
}
