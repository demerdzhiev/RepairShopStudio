using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Core.Models.ShopService;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Services
{
    public class ShopServiceService : IShopServiceService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;

        public ShopServiceService(
            ApplicationDbContext _context,
            IRepository _repo)
        {
            context = _context;
            repo = _repo;
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

        public async Task<IEnumerable<ShopServiceVehicleComponentModel>> AllVehicleComponents()
        {
            return await repo.AllReadonly<VehicleComponent>()
                .OrderBy(c => c.Name)
                .Select(c => new ShopServiceVehicleComponentModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task Delete(int id)
        {
            var service = await repo.All<ShopService>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (service != null)
            {
                service.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        public async Task<bool> Edit(int serviceId, ShopServiceViewModel model)
        {
            var service = await context.FindAsync<ShopService>(serviceId);

            if (service != null)
            {
                service.Name = model.Name;
                service.Description = model.Description;
                service.Price = model.Price;
                service.VehicleComponentId = model.VehicleComponentId;

                context.Update(service);
                context.SaveChanges();

                return true;
            }

            throw new InvalidOperationException("Part was not found");
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<ShopService>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }

        public async Task<IEnumerable<ShopServiceViewModel>> GetAllAsync()
        {
            var entities = await context.ShopServices
                .Where(s => s.IsActive)
                .Include(s => s.VehicleComponent)
                .ToListAsync();

            return entities
                .Select(p => new ShopServiceViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    VehicleComponent = p.VehicleComponent.Name
                });

           
        }

        public async Task<int> GetVehicleComponentId(int serviceId)
        {
            return (await repo.GetByIdAsync<ShopService>(serviceId)).VehicleComponentId;
        }

        public async Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync()
        {
            return await context.VehicleComponents.ToListAsync();
        }

        public async Task<ShopServiceDetailsModel> ServiceDetailsById(int id)
        {
            return await repo.AllReadonly<ShopService>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Select(p => new ShopServiceDetailsModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    VehicleComponent = p.VehicleComponent.Name
                })
                .FirstAsync();
        }

        public async Task<bool> VehicleComponentExists(int componentId)
        {
            return await repo.AllReadonly<VehicleComponent>()
                .AnyAsync(c => c.Id == componentId);
        }
    }
}
