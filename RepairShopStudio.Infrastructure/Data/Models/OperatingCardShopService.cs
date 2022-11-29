using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    public class OperatingCardShopService
    {
        [Required]
        public int OperatingCardId { get; set; }

        [ForeignKey(nameof(OperatingCardId))]
        public OperatingCard? OperatingCard { get; set; }

        [Required]
        public int ShopServiceId { get; set; }

        [ForeignKey(nameof(ShopServiceId))]
        public ShopService? ShopService { get; set; }
    }
}
