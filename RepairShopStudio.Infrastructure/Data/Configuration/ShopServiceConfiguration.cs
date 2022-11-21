﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class ShopServiceConfiguration : IEntityTypeConfiguration<ShopService>
    {
        public void Configure(EntityTypeBuilder<ShopService> builder)
        {
            builder.HasData(CreateShopService());
        }

        List<ShopService> CreateShopService()
        {
            var shopServices = new List<ShopService>();

            var shopService = new ShopService()
            {
                Id = "7BDDE324-8E4A-4BBC-BF95-92DCF598A7A6",
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = "6e3cb03f-7a41-426a-9c72-0cd609511ccd"
            };
            shopServices.Add(shopService);

            return shopServices;
        }
    }
}
