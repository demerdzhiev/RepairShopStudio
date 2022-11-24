using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RepairShopStudio.Core.Models.Part
{
    public class PartViewModel
    {
        public string Id { get; set; } = null!;

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

        [Comment("Selling price (by the repair shop)")]
        public decimal PriceSell { get; set; }

        [Display(Name = "Vehicle controller")]
        public string VehicleComponentId { get; set; } = null!;

        [Comment("Name of vehicle component")]
        public string VehicleComponent { get; set; } = null!;

        public IEnumerable<PartVehicleCopmonent> VehicleCopmonents { get; set; } = new List<PartVehicleCopmonent>();
    }
}
