using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Address;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Address;

namespace RepairShopStudio.Core.Models.Address
{
    [Comment(AddViewModelMain)]
    public class AddressAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(AddressTextMaxLength, MinimumLength = AddressTextMinLength)]
        [Comment(AddViewModelAddressText)]
        public string AddressText { get; set; } = null!;

        [Required]
        [StringLength(AddressTextMaxLength, MinimumLength = AddressTextMinLength)]
        [Comment(AddViewModelTownName)]
        public string TownName { get; set; } = null!;

        [Required]
        [MaxLength(ZipCodeMaxLength)]
        [Comment(AddViewModelZipCode)]
        public string ZipCode { get; set; } = null!;
    }
}
