using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Vehicle;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Vehicle, owned by customer")]
    public class Vehicle : BaseModel
    {
        public Vehicle()
        {
            Id = Guid.NewGuid().ToString();
        }

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

        [Comment("Engine type of the vehicle")]
        public string EngineTypeId { get; set; } = null!;

        [ForeignKey(nameof(EngineTypeId))]
        public EngineType EngineType { get; set; } = null!;

        [Required]
        [Range(EngineMinPower, EngineMaxPower)]
        [Comment("Enginge power in Hp")]
        public int Power { get; set; }

        [Required]
        [StringLength(VinNumberLength)]
        [Comment("VIN number of the vehicle")]
        public string VinNumber { get; set; } = null!;

        public string CustomerId { get; set; } = null!;

        [ForeignKey(nameof(CustomerId))]
        [Comment("Customer/owner of the vehicle")]
        public Customer? Customer { get; set; }

    }
}
