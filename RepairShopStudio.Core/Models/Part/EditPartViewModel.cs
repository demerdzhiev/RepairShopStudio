using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.SparePart;

namespace RepairShopStudio.Core.Models.Part
{
    public class EditPartViewModel : BaseModel
    {
        public EditPartViewModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Comment("The name of the part")]
        [StringLength(SparePartNameMaxLength, MinimumLength = SparePartNameMinLength)]
        public string Name { get; set; } = null!;

        [Comment("ImageURl of the part")]
        [StringLength(SparePartImageUrlMaxLength, MinimumLength = SparePartImageUrlMinLength)]
        public string? ImageUrl { get; set; }

        [Comment("Part's availability")]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Comment("Manufacturer's name of the part")]
        [StringLength(SparePartManufacturerNameMaxLength, MinimumLength = SparePartManufacturerNameMinLength)]
        public string Manufacturer { get; set; } = null!;

        [Comment("Part's MPN by the car manufacturer")]
        [StringLength(SparePartOriginalMpnMaxLength, MinimumLength = SparePartOriginalMpnMinLength)]
        public string OriginalMpn { get; set; } = null!;

        [Comment("Description of the part")]
        [StringLength(SparePartDescriptionMaxLength, MinimumLength = SparePartDescriptionMinLength)]
        public string? Description { get; set; }

        [Comment("Delivery price (by the supplier)")]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        public decimal PriceBuy { get; set; }

        [Comment("Selling price (by the repair shop)")]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        public decimal PriceSell { get; set; }

        public string VehicleComponentId { get; set; } = null!;

        [Comment("Name of vehicle component")]
        public IEnumerable<VehicleComponent> VehicleComponents { get; set; } = new List<VehicleComponent>();
    }
}
