using RepairShopStudio.Infrastructure.Data.Models.User;
using System.ComponentModel.DataAnnotations;

namespace RepairShopStudio.Core.Models.OperatingCard
{
    public class OperatingCardAddViewModel
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        [Required]
        public int VehicleId { get; set; }
        public IEnumerable<Infrastructure.Data.Models.Vehicle> Vehicles { get; set; } = new List<Infrastructure.Data.Models.Vehicle>();

        public DateTime IssueDate { get; set; }

        public bool IsActive { get; set; } = true;

        public string ApplicationUserId { get; set; }
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

        [Required]
        public int PartId { get; set; }
        public IEnumerable<Infrastructure.Data.Models.Part> Parts { get; set; } 
            = new List<Infrastructure.Data.Models.Part>();

        [Required]
        public int ServiceId { get; set; }
        public IEnumerable<Infrastructure.Data.Models.ShopService> ShopServices { get; set; }
            = new List<Infrastructure.Data.Models.ShopService>();
    }
}
