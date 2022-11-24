using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Services
{
    public class PartService : IPartService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;

        public PartService(
            ApplicationDbContext _context,
            IRepository _repo)
        {
            context = _context;
            repo = _repo;
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

        public async Task<bool> Exists(string id)
        {
            return await repo.AllReadonly<Part>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }


        public async Task<IEnumerable<PartViewModel>> GetAllAsync()
        {
            var entities = await context.Parts
                .Include(p => p.VehicleComponent)
                .ToListAsync();

            return entities
                .Select(p => new PartViewModel
                {
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

        public async Task<string> GetVehicleComponentId(string partId)
        {
            return (await repo.GetByIdAsync<Part>(partId)).VehicleComponentId;
        }

        public async Task<PartViewModel> PartDetailsById(string id)
        {
            return await repo.AllReadonly<Part>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Select(p => new PartViewModel()
                {
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Manufacturer = p.Manufacturer,
                    OriginalMpn = p.OriginalMpn,
                    PriceSell= p.PriceSell,
                    Stock = p.Stock,
                    VehicleComponent = p.VehicleComponent.Name
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<PartVehicleCopmonent>> AllVehicleComponents()
        {
            return await repo.AllReadonly<VehicleComponent>()
                .OrderBy(c => c.Name)
                .Select(c => new PartVehicleCopmonent()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<bool> VehicleComponentExists(string componentId)
        {
            return await repo.AllReadonly<VehicleComponent>()
                .AnyAsync(c => c.Id == componentId);
        }

        public async Task Edit(string partId, PartViewModel model)
        {
            var part = await repo.GetByIdAsync<Part>(partId);

            part.Name = model.Name;
            part.OriginalMpn = model.OriginalMpn;
            part.Manufacturer = model.Manufacturer;
            part.PriceSell = model.PriceSell;
            part.Stock = model.Stock;
            part.Description = model.Description;
            part.ImageUrl = model.ImageUrl;
            part.VehicleComponentId = model.VehicleComponentId;

            await repo.SaveChangesAsync();
        }
    }
}
