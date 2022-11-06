using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.ShopService;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Services, offered by repair shop")]
    public class ShopService
    {
        [Key]
        [Comment("Id of the service")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(RepairServiceNameMaxLength)]
        [Comment("Name of the service")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(RepairServiceDescriptionMaxLength)]
        [Comment("Description of the service")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Price of the service")]
        [Range(typeof(decimal), ShopServicePriceMinValue, ShopServicePriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Comment("Affected part of the vehicle")]
        public VehicleComponent VehicleComponent { get; set; } = null!;

        [Required]
        [Comment("Spare parts needed for the service")]
        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
