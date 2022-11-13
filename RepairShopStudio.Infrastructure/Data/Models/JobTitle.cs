using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.JobTitle;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Possible job titles")]
    public class JobTitle : BaseModel
    {
        public JobTitle()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(JobTitleNameMaxLength)]
        [Comment("Job title")]
        public string Name { get; set; } = null!;
    }
}
