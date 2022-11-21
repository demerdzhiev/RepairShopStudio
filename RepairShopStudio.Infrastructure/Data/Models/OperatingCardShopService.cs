using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    public class OperatingCardShopService
    {
        [Required]
        public string OperatingCardId { get; set; } = null!;

        [ForeignKey(nameof(OperatingCardId))]
        public OperatingCard? OperatingCard { get; set; }

        [Required]
        public string ShopServiceId { get; set; } = null!;

        [ForeignKey(nameof(ShopServiceId))]
        public ShopService? ShopService { get; set; }
    }
}
