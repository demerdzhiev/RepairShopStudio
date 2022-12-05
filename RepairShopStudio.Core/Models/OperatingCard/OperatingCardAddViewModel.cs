using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepairShopStudio.Infrastructure.Data.Models;
using RepairShopStudio.Infrastructure.Data.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;

namespace RepairShopStudio.Core.Models.OperatingCard
{
    public class OperatingCardAddViewModel
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();

        [Required]
        public int VehicleId { get; set; }
        public IEnumerable<Infrastructure.Data.Models.Vehicle> Vehicles { get; set; } = new List<Infrastructure.Data.Models.Vehicle>();


        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal TotalAmount { get; set; }


        public bool IsActive { get; set; } = true;

        [Required]
        [StringLength(DocumentNumberMaxLength)]
        public string DocumentNumber { get; set; } = null!;

        [Required]
        [Range(1.0, 100.0)]
        public decimal Discount { get; set; }


        public int[] PartIds { get; set; }
        public IEnumerable<SelectListItem> Parts { get; set; } = new List<SelectListItem>();

        public string ApplicationUserId { get; set; }

        [Comment("Name of vehicle component")]
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

        public int[] ServiceIds { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; } = new List<SelectListItem>();
    }
}
