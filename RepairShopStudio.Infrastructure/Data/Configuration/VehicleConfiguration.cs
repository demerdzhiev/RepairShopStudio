using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(CreateVehicle());
        }

        List<Vehicle> CreateVehicle()
        {
            var vehicles = new List<Vehicle>();

            var vehicle = new Vehicle()
            {
                Id = "6e3cb03f-7a41-426a-9c72-0cd609511ccd",
                Make = "Mercedes-Benz",
                Model = "W164 350",
                LicensePLate = "B5466HA",
                FIrstRegistration = DateTime.Parse("2013-06-23"),
                EngineTypeId = "545F6ADA-C535-476A-8B65-A8E2ADEE5F7C",
                Power = 272,
                VinNumber = "12312324125",
                CustomerId = "94eb73a3-e208-4409-bbed-4fc326255fdc"
            };

            vehicles.Add(vehicle);

            return vehicles;
        }
    }
}
