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
                Id = "badc0c29-a923-4f82-9f07-42417bf97c58",
                Date = DateTime.Now.Date,
                DocumentNumber = $"0001{DateTime.Now.Date}",
                CustomerId = "B1CF313C-26BE-47F9-AFC5-48C7C40296E3",
                ApplicationUserId = "trg12856-c198-2563-b3f3-b893d8398710",
                Parts = new List<Part>()
                {
                    new Part()
                    {
                        Id = "7349E46E-0F79-4D5A-8F09-A30B44BEDFA2"
                    }
                },
                ShopServices = new List<ShopService>()
                {
                    new ShopService()
                    {
                        Id = "7BDDE324-8E4A-4BBC-BF95-92DCF598A7A6"
                    }
                },
                Discount = 10,
                TotalAmount = (114.56M + 99.99M) * 0.9M 
            };

            return operatingCards;
        }
    }
}
