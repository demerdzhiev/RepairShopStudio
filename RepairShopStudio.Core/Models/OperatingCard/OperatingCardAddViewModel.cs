using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models.User;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Customer;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.OperatingCard;

namespace RepairShopStudio.Core.Models.OperatingCard
{
    [Comment(AddViewModelMain)]
    public class OperatingCardAddViewModel
    {
        [Comment(AddViewModelId)]
        public int Id { get; set; }

        [Required]
        [Comment(AddViewModelCustomerId)]
        public int CustomerId { get; set; }

        [Comment(AddViewModelCustomerName)]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        public string? CustomerName { get; set; }

        [Required]
        [Comment(AddViewModelVehicleId)]
        public int VehicleId { get; set; }

        [Comment(AddViewModelVehicles)]
        public IEnumerable<Infrastructure.Data.Models.Vehicle> Vehicles { get; set; } 
            = new List<Infrastructure.Data.Models.Vehicle>();

        [Comment(AddViewModelApplicationUserId)]
        public string? ApplicationUserId { get; set; }

        [Comment(AddViewModelApplicationUsers)]
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; } 
            = new List<ApplicationUser>();

        [Required]
        [Comment(AddViewModelPartId)]
        public int PartId { get; set; }

        [Comment(AddViewModelParts)]
        public IEnumerable<Infrastructure.Data.Models.Part> Parts { get; set; } 
            = new List<Infrastructure.Data.Models.Part>();

        [Required]
        [Comment(AddViewModelServiceId)]
        public int ServiceId { get; set; }

        [Comment(AddViewModelShopServices)]
        public IEnumerable<Infrastructure.Data.Models.ShopService> ShopServices { get; set; } 
            = new List<Infrastructure.Data.Models.ShopService>();

        [Comment(AddViewModelIssueDate)]
        public DateTime IssueDate { get; set; }

        [Comment(AddViewModelIsActive)]
        public bool IsActive { get; set; } = true;
    }
}
