using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Models.Part
{
    public class PartServiceModel : IPartModel
    {
        public int Id { get; set; }

        [Comment("The name of the part")]
        public string Name { get; set; } = null!;

        [Comment("ImageURl of the part")]
        public string? ImageUrl { get; set; }

        [Comment("Part's availability")]
        public int Stock { get; set; }

        [Comment("Manufacturer's name of the part")]
        public string Manufacturer { get; set; } = null!;

        [Comment("Part's MPN by the car manufacturer")]
        public string OriginalMpn { get; set; } = null!;

        [Comment("Description of the part")]
        public string? Description { get; set; }

        [Comment("Delivery price (by the supplier)")]
        public decimal PriceBuy { get; set; }

        [Comment("Selling price (by the repair shop)")]
        public decimal PriceSell { get; set; }

        //public int VehicleComponentId { get; set; }

        //[Comment("Name of vehicle component")]
        //public IEnumerable<PartVehicleCopmonentModel> VehicleComponents { get; set; } = new List<PartVehicleCopmonentModel>();
    }
}
