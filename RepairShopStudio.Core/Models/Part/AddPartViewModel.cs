using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.SparePart;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Part;

namespace RepairShopStudio.Core.Models.Part
{
    [Comment(AddViewModelMain)]
    public class AddPartViewModel
    {
        [Required]
        [Comment(AddViewModelId)]
        public int Id { get; set; }

        [Comment(AddViewModelName)]
        [StringLength(SparePartNameMaxLength, MinimumLength = SparePartNameMinLength)]
        public string Name { get; set; } = null!;

        [Comment(AddViewModelImageUrl)]
        [StringLength(SparePartImageUrlMaxLength, MinimumLength = SparePartImageUrlMinLength)]
        public string? ImageUrl { get; set; }

        [Comment(AddViewModelStock)]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Comment(AddViewModelManufacturer)]
        [StringLength(SparePartManufacturerNameMaxLength, MinimumLength = SparePartManufacturerNameMinLength)]
        public string Manufacturer { get; set; } = null!;

        [Comment(AddViewModelOriginalMpn)]
        [StringLength(SparePartOriginalMpnMaxLength, MinimumLength = SparePartOriginalMpnMinLength)]
        public string OriginalMpn { get; set; } = null!;

        [Comment(AddViewModelDescription)]
        [StringLength(SparePartDescriptionMaxLength, MinimumLength = SparePartDescriptionMinLength)]
        public string? Description { get; set; }

        [Comment(AddViewModelPriceBuy)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        public decimal PriceBuy { get; set; }

        [Comment(AddViewModelPriceSell)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        public decimal PriceSell { get; set; }

        [Comment(AddViewModelVehicleComponentId)]
        public int VehicleComponentId { get; set; }

        [Comment(AddViewModelVehicleComponents)]
        public IEnumerable<VehicleComponent> VehicleComponents { get; set; } = new List<VehicleComponent>();
    }
}
