using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    public class OperatingCardParts : BaseModel
    {
        [Required]
        public string OperatingCardId { get; set; } = null!;

        [ForeignKey(nameof(OperatingCardId))]
        public OperatingCard? OperatingCard { get; set; }

        [Required]
        public string PartId { get; set; } = null!;

        [ForeignKey(nameof(PartId))]
        public Part? Part { get; set; }
    }
}
