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
        [StringLength(VehicleMakeMaxLength)]
        [Comment("Vehicle make name")]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(VehicleModelMaxLength)]
        [Comment("Vehicle model name")]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(LicensePlateMaxLength)]
        [Comment("License plate of the vehicle")]
        public string LicensePLate { get; set; } = null!;

        [Required]
        [Comment("Date of the first registration of the vehicle")]
        public DateTime FIrstRegistration { get; set; }

        public string EngineType { get; set; } = null!;

        [Required]
        [Range(EngineMinPower, EngineMaxPower)]
        [Comment("Enginge power in Hp")]
        public int Power { get; set; }

        [Required]
        [StringLength(VinNumberLength)]
        [Comment("VIN number of the vehicle")]
        public string VinNumber { get; set; } = null!;

        public int EngineTypeId { get; set; }
        public IEnumerable<EngineTypeViewModel> EngineTypes { get; set; } = new List<EngineTypeViewModel>();
    }
}
