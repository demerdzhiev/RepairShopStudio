﻿using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using System.ComponentModel.DataAnnotations;

namespace RepairShopStudio.Core.Models.ShopService
{
    public class ShopServiceViewModel : IServiceModel
    {
        public int Id { get; set; }

        [Comment("Name of the service")]
        public string Name { get; set; } = null!;

        [Comment("Description of the service")]
        public string Description { get; set; } = null!;

        [Comment("Price of the service")]
        public decimal Price { get; set; }

        [Display(Name = "Vehicle component")]
        public int VehicleComponentId { get; set; }

        [Comment("Name of vehicle component")]
        public string VehicleComponent { get; set; } = null!;

        public IEnumerable<ShopServiceVehicleComponentModel> VehicleComponents { get; set; } 
            = new List<ShopServiceVehicleComponentModel>();
    }
}
