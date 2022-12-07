using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.ShopService;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.ShopService;

namespace RepairShopStudio.Core.Models.ShopService
{
    [Comment(AddViewModelMain)]
    public class AddShopServiceViewModel
    {
        [Comment(AddViewModelName)]
        [StringLength(RepairServiceNameMaxLength, MinimumLength = RepairServiceNameMinLength)]
        public string Name { get; set; } = null!;

        [Comment(AddViewModelDescription)]
        [StringLength (RepairServiceDescriptionMaxLength, MinimumLength = RepairServiceDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Comment(AddViewModelPrice)]
        [Range(typeof(decimal), ShopServicePriceMinValue, ShopServicePriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Comment(AddViewModelVehicleComponentId)]
        public int VehicleComponentId { get; set; }

        [Comment(AddViewModelVehicleComponents)]
        public IEnumerable<VehicleComponent> VehicleComponents { get; set; } = new List<VehicleComponent>();
    }
}
