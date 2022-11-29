using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class OperatingCardConfiguration : IEntityTypeConfiguration<OperatingCard>
    {
        public void Configure(EntityTypeBuilder<OperatingCard> builder)
        {
            builder.HasData(CreateOperatingCard());
        }

        List<OperatingCard> CreateOperatingCard()
        {
            var operatingCards = new List<OperatingCard>();

            var operatingCard = new OperatingCard()
            {
                Id = 1,
                Date = DateTime.Now.Date,
                DocumentNumber = $"0001{DateTime.Now.Date}",
                CustomerId = 1,
                ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                Discount = 10,
                TotalAmount = (114.56M + 99.99M) * 0.9M 
            };

            operatingCards.Add(operatingCard);

            return operatingCards;
        }
    }
}
