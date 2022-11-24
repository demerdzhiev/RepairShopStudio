using Microsoft.EntityFrameworkCore;

namespace RepairShopStudio.Core.Models.ShopService
{
    public class ShopServiceViewModel
    {
        [Comment("Name of the service")]
        public string Name { get; set; } = null!;

        [Comment("Description of the service")]
        public string Description { get; set; } = null!;

        [Comment("Price of the service")]
        public decimal Price { get; set; }

        [Comment("Affected part of the vehicle")]
        public string VehicleComponent { get; set; } = null!;
    }
}
