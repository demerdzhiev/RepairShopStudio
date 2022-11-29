using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.VehicleComponent;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("The components/parts of the vehicle, which can be affected by the services")]
    public class VehicleComponent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(VehicleComponentNameMaxLength)]
        [Comment("Name of vehicle component")]
        public string Name { get; set; } = null!;

    }
}
