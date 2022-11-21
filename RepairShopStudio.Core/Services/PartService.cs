using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Core.Services
{
    public class PartService : IPartService
    {
        private readonly ApplicationDbContext context;

        public PartService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddPartAsync(AddPartViewModel model)
        {
            var entity = new Part()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Manufacturer = model.Manufacturer,
                OriginalMpn = model.OriginalMpn,
                PriceSell = model.PriceSell,
                PriceBuy = model.PriceBuy,
                Stock = model.Stock,
                VehicleComponentId = model.VehicleComponentId
            };

            await context.Parts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PartViewModel>> GetAllAsync()
        {
            var entities = await context.Parts
                .Include(p => p.VehicleComponent)
                .ToListAsync();

            return entities
                .Select(p => new PartViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock,
                    Manufacturer = p.Manufacturer,
                    OriginalMpn = p.OriginalMpn,
                    Description = p.Description,
                    PriceSell = p.PriceSell,
                    VehicleComponent = p.VehicleComponent.Name
                });
        }

        public async Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync()
        {
            return await context.VehicleComponents.ToListAsync();
        }
    }
}
