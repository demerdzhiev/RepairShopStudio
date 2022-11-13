using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(CreateOrder());
        }

        List<Order> CreateOrder()
        {
            var orders = new List<Order>();

            var order = new Order()
            {
                Id = "9961AF43-3CC2-48EE-B760-89FC2CFACF20",
                IssueDate = DateTime.Now.Date,
                Number = $"0001/{DateTime.Now.Date}",
                Note = "To arrive today",
                SupplierId = "EDD4D809-A15C-4C6C-BC01-E6B4E9D23616"
            };
            orders.Add(order);

            return orders;
        }
    }
}
