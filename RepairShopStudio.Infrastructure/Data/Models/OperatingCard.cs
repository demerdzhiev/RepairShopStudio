using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Operating card for the current service")]
    public class OperatingCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Date of the creation of the document")]
        public DateTime Date { get; set; }

        [Required]
        [Comment("The number of current document")]
        [StringLength(DocumentNumberMaxLength)]
        public string DocumentNumber { get; set; } = null!;

        [Required]
        [Comment("Services, applied to current vehicle")]
        public ICollection<ShopService> ShopServices { get; set; } = new List<ShopService>();

        [Required]
        [Comment("The total amount of parts and services")]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }

      
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }


        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }


        [Required]
        [Range(1.0, 100.0)]
        public double Discount { get; set; }

        [Required]
        [Comment("Parts, needed for current repair")]
        public ICollection<Part> Parts { get; set; } = new List<Part>();

        public ICollection<OperatingCardShopService> OperatingCardShopServices { get; set; } = new List<OperatingCardShopService>();

        public bool IsActive { get; set; } = true;

        public int VehicleId { get; set; }
    }
}
