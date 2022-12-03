using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.EngineType;

namespace RepairShopStudio.Core.Models.EngineType
{
    public class EngineTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(EngineTypeNameMaxLength)]
        [Comment("Name of engine type")]
        public string Name { get; set; } = null!;
    }
}
