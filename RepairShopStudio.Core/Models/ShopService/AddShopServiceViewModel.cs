using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.ShopService;

namespace RepairShopStudio.Core.Models.ShopService
{
    public class AddShopServiceViewModel
    {
        [Comment("Name of the service")]
        [StringLength(RepairServiceNameMaxLength, MinimumLength = RepairServiceNameMinLength)]
        public string Name { get; set; } = null!;

        [Comment("Description of the service")]
        [StringLength (RepairServiceDescriptionMaxLength, MinimumLength = RepairServiceDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Comment("Price of the service")]
        [Range(typeof(decimal), ShopServicePriceMinValue, ShopServicePriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public int VehicleComponentId { get; set; }

        [Comment("Name of vehicle component")]
        public IEnumerable<VehicleComponent> VehicleComponents { get; set; } = new List<VehicleComponent>();
    }
}
