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
                Id = model.Id,
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

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Part>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<IEnumerable<PartViewModel>> GetAllAsync()
        {
            var entities = await context.Parts
                .Where(p => p.IsActive)
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
                    PriceBuy= p.PriceBuy,
                    VehicleComponent = p.VehicleComponent.Name
                });
        }

        public async Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync()
        {
            return await context.VehicleComponents.ToListAsync();
        }

        public async Task<int> GetVehicleComponentId(int partId)
        {
            return (await repo.GetByIdAsync<Part>(partId)).VehicleComponentId;
        }

        public async Task<PartDetailsModel> PartDetailsById(int id)
        {
            return await repo.AllReadonly<Part>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Select(p => new PartDetailsModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Manufacturer = p.Manufacturer,
                    OriginalMpn = p.OriginalMpn,
                    PriceSell = p.PriceSell,
                    PriceBuy = p.PriceBuy,
                    Stock = p.Stock,
                    VehicleComponent = p.VehicleComponent.Name
                })
                .FirstAsync();
        }

        public async Task<IEnumerable<PartVehicleCopmonentModel>> AllVehicleComponents()
        {
            return await repo.AllReadonly<VehicleComponent>()
                .OrderBy(c => c.Name)
                .Select(c => new PartVehicleCopmonentModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<bool> VehicleComponentExists(int componentId)
        {
            return await repo.AllReadonly<VehicleComponent>()
                .AnyAsync(c => c.Id == componentId);
        }

        public async Task<bool> Edit(int partId, PartViewModel model)
        {
            var part = await context.FindAsync<Part>(partId);

            if (part != null)
            {
                part.Name = model.Name;
                part.OriginalMpn = model.OriginalMpn;
                part.Manufacturer = model.Manufacturer;
                part.PriceSell = model.PriceSell;
                part.PriceBuy = model.PriceBuy;
                part.Stock = model.Stock;
                part.Description = model.Description;
                part.ImageUrl = model.ImageUrl;
                part.VehicleComponentId = model.VehicleComponentId;

                context.Update(part);
                context.SaveChanges();

                return true;
            }

            throw new InvalidOperationException("Part was not found");

        }

        public async Task<EditPartViewModel> GetPartForEditAsync(int id)
        {
            
            var part = context.Parts.Find(id);

            if (part != null)
            {
                var result = new EditPartViewModel()
                {
                    Name = part.Name,
                    Description = part.Description,
                    ImageUrl = part.ImageUrl,
                    VehicleComponentId = part.VehicleComponentId,
                    OriginalMpn = part.OriginalMpn,
                    Stock = part.Stock,
                    Manufacturer = part.Manufacturer,
                    PriceSell = part.PriceSell,
                    PriceBuy = part.PriceBuy,
                    VehicleComponents = await GetVehicleComponentsAsync()
                };

                return result;
            }

            throw new NullReferenceException("The part does not exist");
        }

        public async Task<Part> GetPartById(int id)
        {
            return await context.Parts.FirstOrDefaultAsync(p => p.Id == id);

        }

        public async Task Delete(int id)
        {
            var part = await repo.All<Part>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (part != null)
            {
                part.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }
    }
}
