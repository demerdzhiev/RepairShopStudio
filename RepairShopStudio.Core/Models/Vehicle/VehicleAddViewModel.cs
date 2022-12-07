using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Vehicle;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Vehicle;

namespace RepairShopStudio.Core.Models.Vehicle
{
    [Comment(AddViewModelMain)]
    public class VehicleAddViewModel
    {
        [Comment(AddViewModelId)]
        public int Id { get; set; }

        [Required]
        [StringLength(VehicleMakeMaxLength, MinimumLength = VehicleMakeMinLength)]
        [Comment(AddViewModelMake)]
        public string? Make { get; set; }

        [Required]
        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength)]
        [Comment(AddViewModelModel)]
        public string? Model { get; set; }

        [Required]
        [StringLength(LicensePlateMaxLength, MinimumLength = LicensePlateMinLength)]
        [Comment(AddViewModelLicensePLate)]
        public string? LicensePLate { get; set; }

        [Required]
        [Comment(AddViewModelFIrstRegistration)]
        public DateTime FIrstRegistration { get; set; }

        [Comment(AddViewModelEngineTypeId)]
        public int EngineTypeId { get; set; }

        [Required]
        [Range(EngineMinPower, EngineMaxPower)]
        [Comment(AddViewModelPower)]
        public int Power { get; set; }

        [Required]
        [StringLength(VinNumberLength)]
        [Comment(AddViewModelVinNumber)]
        public string? VinNumber { get; set; }

        [Comment(AddViewModelEngineTypes)]
        public ICollection<Infrastructure.Data.Models.EngineType> EngineTypes { get; set; }
            = new List<Infrastructure.Data.Models.EngineType>();

    }
}
