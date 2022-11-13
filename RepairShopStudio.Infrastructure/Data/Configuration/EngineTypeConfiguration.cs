using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class EngineTypeConfiguration : IEntityTypeConfiguration<EngineType>
    {
        public void Configure(EntityTypeBuilder<EngineType> builder)
        {
            builder.HasData(CreateEngineType());
        }

        List<EngineType> CreateEngineType()
        {
            var engineTypes = new List<EngineType>();

            var gasolineEngine = new EngineType()
            {
                Id = "545F6ADA-C535-476A-8B65-A8E2ADEE5F7C",
                Name = "Gasoline"
            };

            engineTypes.Add(gasolineEngine);

            var dieselEngine = new EngineType()
            {
                Id = "026c3f78-94d5-4f4e-8e8f-fea783a8a93f",
                Name = "Diesel"
            };

            engineTypes.Add(dieselEngine);

            var hybridEngine = new EngineType()
            {
                Id = "e6c84886-dba7-4a1c-8448-60fcf66a71e0",
                Name = "Hybrid"
            };

            engineTypes.Add(hybridEngine);

            var electricEngine = new EngineType()
            {
                Id = "35cc3d9b-f93d-490e-9eb5-7b05548b6de8",
                Name = "Electric"
            };

            return engineTypes;
        }
    }
}
