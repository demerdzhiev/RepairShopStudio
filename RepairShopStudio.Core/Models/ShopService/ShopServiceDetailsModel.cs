using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RepairShopStudio.Core.Models.ShopService
{
    public class ShopServiceDetailsModel : IServiceModel
    {
        [Key]
        public int Id { get; set; }

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
