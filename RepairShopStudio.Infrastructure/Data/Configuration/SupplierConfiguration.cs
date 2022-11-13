using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(CreateSupplier());
        }

        List<Supplier> CreateSupplier()
        {
            var suppliers = new List<Supplier>();

            var supplier = new Supplier()
            {
                Id = "EDD4D809-A15C-4C6C-BC01-E6B4E9D23616",
                Name = "Garvan",
                CompanyName = "Garvan EOOD",
                Uic = "123456789876",
                PhoneNumber = "0898888888",
                Email = "garvan@abv.bg",
                AddressId = "f03b1057-88f7-47e2-a745-580c6150e371"
            };

            suppliers.Add(supplier);

            return suppliers;
        }
    }
}
