using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.EngineType;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Type of the vehicle's engine")]
    public class EngineType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(EngineTypeNameMaxLength)]
        [Comment("Name of engine type")]
        public string Name { get; set; } = null!;

    }
}
