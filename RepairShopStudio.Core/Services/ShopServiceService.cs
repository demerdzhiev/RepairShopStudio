using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Core.Models.ShopService;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Core.Services
{
    public class ShopServiceService : IShopServiceService
    {
        private readonly ApplicationDbContext context;

        public ShopServiceService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(AddShopServiceViewModel model)
        {
            var entity = new ShopService()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                VehicleComponentId = model.VehicleComponentId
            };

            await context.ShopServices.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShopServiceViewModel>> GetAllAsync()
        {
            var entities = await context.ShopServices
                .Include(p => p.VehicleComponent)
                .ToListAsync();

            return entities
                .Select(p => new ShopServiceViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    VehicleComponent = p.VehicleComponent.Name
                });

           
        }

        public async Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync()
        {
            return await context.VehicleComponents.ToListAsync();
        }
    }
}
