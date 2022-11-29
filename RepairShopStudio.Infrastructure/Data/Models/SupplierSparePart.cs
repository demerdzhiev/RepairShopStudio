using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Mapping entity between suppliers and parts")]
    public class SupplierSparePart
    {
        [Required]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }

        [Required]
        public int PartId { get; set; }

        [ForeignKey(nameof(PartId))]
        public Part? Part { get; set; }
    }
}
