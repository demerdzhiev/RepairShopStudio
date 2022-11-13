using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Customer;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Customer information")]
    public class Customer : BaseModel
    {
        public Customer()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(CustomerNameMaxLength)]
        [Comment("Name of the customer")]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength)]
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
        public string Uic { get; set; } = null!;

        [Comment("The address of the customer's office")]
        public string AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }

        [StringLength(ResponsiblePersonNameMaxLength)]
        [Comment("Name of the responsible person of the customer's company")]
        public string ResponsiblePerson { get; set; } = null!;

        [Comment("Collection of vehicles, owned by the customer")]
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
