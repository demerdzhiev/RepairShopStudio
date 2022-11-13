using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class VehicleComponentConfiguration : IEntityTypeConfiguration<VehicleComponent>
    {
        public void Configure(EntityTypeBuilder<VehicleComponent> builder)
        {
            builder.HasData(CreateVehicleComponent());
        }

        List<VehicleComponent> CreateVehicleComponent()
        {
            var vehicleComponents = new List<VehicleComponent>();

            var engnie = new VehicleComponent()
            {
                Id = "46e751d0-07fc-4859-b95a-51048d4aeb1c",
                Name = "Engine"
            };
            vehicleComponents.Add(engnie);

            var transmissionSystem = new VehicleComponent()
            {
                Id = "6588d450-bda4-440d-a207-82ebe875c64f",
                Name = "Tranmission system"
            };
            vehicleComponents.Add(transmissionSystem);

            var frontAndRearAxle = new VehicleComponent()
            {
                Id = "88fb6d39-5500-48dd-893e-138cfde5b816",
                Name = "Front and rear axle"
            };
            vehicleComponents.Add(frontAndRearAxle);

            var steeringSystem = new VehicleComponent()
            {
                Id = "13ea9388-052b-4760-bd7d-3ad3eb04897a",
                Name = "Steering system"
            };
            vehicleComponents.Add(steeringSystem);

            var suspensionSystem = new VehicleComponent()
            {
                Id = "eac3af63-bd7b-47a2-bde4-32987fe21ad2",
                Name = "Suspenssion system"
            };
            vehicleComponents.Add(suspensionSystem);


            var tyresAndBrakes = new VehicleComponent()
            {
                Id = "E8210DF4-AB11-461A-8084-DBCECCB5F340",
                Name = "Tyres and brakes"
            };
            vehicleComponents.Add(tyresAndBrakes);

            var body = new VehicleComponent()
            {
                Id = "eeb24e1e-7978-4748-8591-466fdb72954e",
                Name = "Body"
            };
            vehicleComponents.Add(body);

            return vehicleComponents;
        }
    }
}
