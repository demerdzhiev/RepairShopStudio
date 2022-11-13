﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Address;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Addres properties")]
    public class Address : BaseModel
    {
        public Address()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(AddressTextMaxLength)]
        [Comment("Adrres text - street, number, etc.")]
        public string AddressText { get; set; } = null!;

        [Required]
        [MaxLength(AddressTextMaxLength)]
        [Comment("Town name")]
        public string TownName { get; set; } = null!;

        [Required]
        [MaxLength(ZipCodeMaxLength)]
        [Comment("ZIP code of the town")]
        public string ZipCode { get; set; } = null!;
    }
}
