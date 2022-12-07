using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Models.Address;
using RepairShopStudio.Core.Models.Vehicle;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Customer;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Custommer;

namespace RepairShopStudio.Core.Models.CustomerModels
{
    [Comment(AddViewModelMain)]
    public class CustomerAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        [Comment(AddViewModelName)]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Comment(AddViewModelPhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength)]
        [Comment(AddViewModelEmail)]
        public string Email { get; set; } = null!;

        [Required]
        [Comment(AddViewModelIsCorporate)]
        public bool IsCorporate { get; set; }

        [StringLength(UicMaxLength)]
        [Comment(AddViewModelUic)]
        public string? Uic { get; set; }

        [StringLength(ResponsiblePersonNameMaxLength)]
        [Comment(AddViewModelResponsiblePerson)]
        public string? ResponsiblePerson { get; set; }

        [Comment(AddViewModelVehicle)]
        public VehicleAddViewModel? Vehicle { get; set; } = null!;

        [Comment(AddViewModelAddress)]
        public AddressAddViewModel? Address { get; set; }
    }
}
