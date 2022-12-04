using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Address;

namespace RepairShopStudio.Core.Models.Address
{
    public class AddressAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(AddressTextMaxLength, MinimumLength = AddressTextMinLength)]
        [Comment("Adrres text - street, number, etc.")]
        public string AddressText { get; set; } = null!;

        [Required]
        [StringLength(AddressTextMaxLength, MinimumLength = AddressTextMinLength)]
        [Comment("Town name")]
        public string TownName { get; set; } = null!;

        [Required]
        [MaxLength(ZipCodeMaxLength)]
        [Comment("ZIP code of the town")]
        public string ZipCode { get; set; } = null!;
    }
}
