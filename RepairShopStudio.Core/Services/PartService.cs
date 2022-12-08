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

        /// <summary>
        /// Create new part
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Add new part to Data-Base</returns>
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

        /// <summary>
        /// Check if a part with certain Id exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean wich defines if the certain part exits</returns>
        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Part>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }

        /// <summary>
        /// Get all parts from Data-Base
        /// </summary>
        /// <returns>List of all parts</returns>
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

        /// <summary>
        /// Get all vehicle components from Data-Base
        /// </summary>
        /// <returns>List of all vehicle components</returns>
        public async Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync()
        {
            return await context.VehicleComponents.ToListAsync();
        }

        /// <summary>
        /// Get a certain vehicle component by a part's Id
        /// </summary>
        /// <param name="partId"></param>
        /// <returns>Vehicle compnonent's Id</returns>
        public async Task<int> GetVehicleComponentId(int partId)
        {
            return (await repo.GetByIdAsync<Part>(partId)).VehicleComponentId;
        }

        /// <summary>
        /// Get details for a certain part by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PartDetailsModel with inormation about a certain Part</returns>
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

        /// <summary>
        /// Get all vehicle components
        /// </summary>
        /// <returns>List of PartVehicleCopmonentModel for all vehicle components</returns>
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

        /// <summary>
        /// Check if a vehicle component with certain Id exists
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns>Boolean wich defines if the certain vehicle componen exits</returns>
        public async Task<bool> VehicleComponentExists(int componentId)
        {
            return await repo.AllReadonly<VehicleComponent>()
                .AnyAsync(c => c.Id == componentId);
        }

        /// <summary>
        /// Get a certain part from Data-Base by it's Id and modifies it's properties value
        /// </summary>
        /// <param name="partId"></param>
        /// <param name="model"></param>
        /// <returns>Updated part</returns>
        /// <exception cref="InvalidOperationException"></exception>
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

        /// <summary>
        /// Get a certain part by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EditPartViewModel with loaded information about a certain part</returns>
        /// <exception cref="NullReferenceException"></exception>
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

        /// <summary>
        /// Get part from Data-Base by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Part</returns>
        public async Task<Part> GetPartById(int id)
        {
            return await context.Parts.FirstOrDefaultAsync(p => p.Id == id);

        }

        /// <summary>
        /// Get part from Data-Base by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Set the part's property IsActive to false</returns>
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
