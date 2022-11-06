using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Employee;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Employee properties")]
    public class Employee
    {
        [Key]
        [Comment("Id of the employee")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(EmployeeNameMaxLength)]
        [Comment("Employee name")]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength)]
        [Comment("Phone number of the employee")]
        public string PhoneNumber { get; set; } = null!;


        [Comment("Job title of the employee")]
        public Guid JobTitleId { get; set; }
        [ForeignKey(nameof(JobTitleId))]
        public JobTitle? JobTitle { get; set; }
    }
}
