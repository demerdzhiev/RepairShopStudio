using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.SparePart;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Part, stored in the shop's warehouse")]
    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(SparePartNameMaxLength)]
        [Comment("The name of the part")]
        public string Name { get; set; } = null!;

        [StringLength(SparePartImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Part's availability")]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        [StringLength(SparePartManufacturerNameMaxLength)]
        [Comment("Manufacturer's name of the part")]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(SparePartOriginalMpnMaxLength)]
        [Comment("Part's MPN by the car manufacturer")]
        public string OriginalMpn { get; set; } = null!;

        [StringLength(SparePartDescriptionMaxLength)]
        [Comment("Description of the part")]
        public string? Description { get; set; }

        [Required]
        [Comment("Delivery price (by the supplier)")]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal PriceBuy { get; set; }

        [Required]
        [Comment("Selling price (by the repair shop)")]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal PriceSell { get; set; }

        [Required]
        [Comment("Affected part of the vehicle, where the part may be used")]
        public int VehicleComponentId { get; set; }

        [ForeignKey(nameof(VehicleComponentId))]
        public VehicleComponent VehicleComponent { get; set; } = null!;

        [Comment("Collection of suppliers, selling the part")]
        public ICollection<SupplierSparePart> SupplierSpareParts { get; set; } = new List<SupplierSparePart>();

        public bool IsActive { get; set; } = true;
    }
}