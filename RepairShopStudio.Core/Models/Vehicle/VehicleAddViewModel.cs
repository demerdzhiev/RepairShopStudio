using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Models.EngineType;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Vehicle;

namespace RepairShopStudio.Core.Models.Vehicle
{
    public class VehicleAddViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(VehicleMakeMaxLength, MinimumLength = VehicleMakeMinLength)]
        [Comment("Vehicle make name")]
        public string? Make { get; set; }

        [Required]
        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength)]
        [Comment("Vehicle model name")]
        public string? Model { get; set; }

        [Required]
        [StringLength(LicensePlateMaxLength, MinimumLength = LicensePlateMinLength)]
        [Comment("License plate of the vehicle")]
        public string? LicensePLate { get; set; }

        [Required]
        [Comment("Date of the first registration of the vehicle")]
        public DateTime FIrstRegistration { get; set; }

        public int EngineTypeId { get; set; }

        [Required]
        [Range(EngineMinPower, EngineMaxPower)]
        [Comment("Enginge power in Hp")]
        public int Power { get; set; }

        [Required]
        [StringLength(VinNumberLength)]
        [Comment("VIN number of the vehicle")]
        public string? VinNumber { get; set; }

        public ICollection<Infrastructure.Data.Models.EngineType> EngineTypes { get; set; }
            = new List<Infrastructure.Data.Models.EngineType>();

        //public int EngineTypeId { get; set; }
        //public IEnumerable<EngineTypeViewModel> EngineTypes { get; set; } = new List<EngineTypeViewModel>();
    }
}
