using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models.User;
using System.ComponentModel.DataAnnotations;
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

        //[Required]
        //[Comment("Services, applied to current vehicle")]
        //public ICollection<ShopService> ShopServices { get; set; } = new List<ShopService>();
        
        public int? PartId { get; set; }
        public Part Part { get; set; }

        public int? ServiceId { get; set; }
        public ShopService Service { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }


        public Guid ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }


        //[Required]
        //[Comment("Parts, needed for current repair")]
        //public ICollection<Part> Parts { get; set; } = new List<Part>();

        //public ICollection<OperatingCardShopService> OperatingCardShopServices { get; set; } = new List<OperatingCardShopService>();

        public bool IsActive { get; set; } = true;

        public int VehicleId { get; set; }
    }
}