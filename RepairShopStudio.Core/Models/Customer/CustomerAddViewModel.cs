using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Models.Address;
using RepairShopStudio.Core.Models.Vehicle;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Customer;

namespace RepairShopStudio.Core.Models.Customer
{
    public class CustomerAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength)]
        [Comment("Name of the customer")]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [Comment("Phone number of the cusotmer")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength)]
        [Comment("Email of the customer")]
        public string Email { get; set; } = null!;

        [Required]
        [Comment("Defines if the customer is corporate or individual")]
        public bool IsCorporate { get; set; }

        [StringLength(UicMaxLength)]
        [Comment("The Unit Identification Code of the customer's company")]
        public string? Uic { get; set; }

        [StringLength(ResponsiblePersonNameMaxLength)]
        [Comment("Name of the responsible person of the customer's company")]
        public string? ResponsiblePerson { get; set; }

        public VehicleAddViewModel? Vehicle { get; set; } = null!;
        public AddressAddViewModel? Address { get; set; }

        //[Comment("Vehicle owned by the customer")]
        //public Vehicle Vehicle { get; set; } = null!;

        //[Comment("The address of the customer's office")]
        //public Address? Address { get; set; }

        //[Comment("Collection of vehicles, owned by the customer")]
        //public ICollection<Infrastructure.Data.Models.EngineType> EngineTypes { get; set; }
        //    = new List<Infrastructure.Data.Models.EngineType>();
    }
}
