using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.SparePart;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Part;

namespace RepairShopStudio.Core.Models.Part
{
    [Comment(EditViewModelMain)]
    public class EditPartViewModel
    {
        [Required]
        [Comment(EditViewModelId)]
        public int Id { get; set; }

        [Comment(EditViewModelName)]
        [StringLength(SparePartNameMaxLength, MinimumLength = SparePartNameMinLength)]
        public string Name { get; set; } = null!;

        [Comment(EditViewModelImageUrl)]
        [StringLength(SparePartImageUrlMaxLength, MinimumLength = SparePartImageUrlMinLength)]
        public string? ImageUrl { get; set; }

        [Comment(EditViewModelStock)]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Comment(EditViewModelManufacturer)]
        [StringLength(SparePartManufacturerNameMaxLength, MinimumLength = SparePartManufacturerNameMinLength)]
        public string Manufacturer { get; set; } = null!;

        [Comment(EditViewModelOriginalMpn)]
        [StringLength(SparePartOriginalMpnMaxLength, MinimumLength = SparePartOriginalMpnMinLength)]
        public string OriginalMpn { get; set; } = null!;

        [Comment(EditViewModelDescription)]
        [StringLength(SparePartDescriptionMaxLength, MinimumLength = SparePartDescriptionMinLength)]
        public string? Description { get; set; }

        [Comment(EditViewModelPriceBuy)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        public decimal PriceBuy { get; set; }

        [Comment(EditViewModelPriceSell)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        public decimal PriceSell { get; set; }

        [Comment(EditViewModelVehicleComponentId)]
        public int VehicleComponentId { get; set; }

        [Comment(EditViewModelVehicleComponents)]
        public IEnumerable<VehicleComponent> VehicleComponents { get; set; } = new List<VehicleComponent>();
    }
}
