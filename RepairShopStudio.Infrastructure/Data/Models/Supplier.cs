using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Supplier;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Supplier, who delivers parts to the repair shop")]
    public class Supplier : BaseModel
    {
        public Supplier()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(SupplierNameMaxLength)]
        [Comment("Name of the supplier")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(SupplierCompanyNameMaxLength)]
        [Comment("Name of the supplier's company")]
        public string CompanyName { get; set; } = null!;

        [Required]
        [StringLength(UicMaxLength)]
        [Comment("Unit Identification Code of the supplier's company")]
        public string Uic { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength)]
        [Comment("Phone number of the supplier's office")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength)]
        [Comment("Email of the supplier")]
        public string Email { get; set; } = null!;

        [Comment("Collection of parts, selled by the supplier")]
        public ICollection<SupplierSparePart> SupplierSpareParts { get; set; } = new List<SupplierSparePart>();

        [Comment("Address of the supplier's office")]
        public string AddressId { get; set; } = null!;

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; } = null!;
    }
}
