using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(CreateCustomer());
        }

        private List<Customer> CreateCustomer()
        {
            var customers = new List<Customer>();

            var customer = new Customer()
            {
                Id = "94eb73a3-e208-4409-bbed-4fc326255fdc",
                Name = "Ivan Ivanov",
                PhoneNumber = "099999999",
                Email = "ivan.ivanov@abv.bg",
                IsCorporate = true,
                Uic = "1234543421234",
                AddressId = "6a27fcd0-81f5-412d-80c8-39cc0f6c81f0",
                ResponsiblePerson = "Ivan Ivanov"
            };

            customers.Add(customer);

            var customer2 = new Customer()
            {
                Id = "38dea0ea-cd19-49b9-a280-b869461def95",
                Name = "Boris Borisov",
                PhoneNumber = "0898888888",
                Email = "boris.borisov@abv.bg",
                IsCorporate = false
            };

            customers.Add(customer2);

            return customers;
        }
    }
}
