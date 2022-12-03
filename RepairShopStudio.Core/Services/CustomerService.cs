using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Customer;
using RepairShopStudio.Core.Models.EngineType;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;

        public CustomerService(
            ApplicationDbContext _context,
            IRepository _repo)
        {
            context = _context;
            repo = _repo;
        }

        public async Task AddCutomerAsync(CustomerAddViewModel model)
        {
            var entity = new Customer()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                IsCorporate = model.IsCorporate,
                Address = new Address()
                {
                    Id = model.Address.Id,
                    ZipCode = model.Address.ZipCode,
                    AddressText = model.Address.AddressText,
                    TownName = model.Address.TownName,
                },
                ResponsiblePerson = model.ResponsiblePerson,
                Uic = model.Uic,
                //Vehicle = new Vehicle()
                //{
                //    Id = model.Vehicle.Id,
                //    Make = model.Vehicle.Make,
                //    Model = model.Vehicle.Model,
                //    VinNumber = model.Vehicle.VinNumber,
                //    FIrstRegistration = model.Vehicle.FIrstRegistration,
                //    EngineTypeId = model.Vehicle.EngineTypeId,
                //    LicensePLate = model.Vehicle.LicensePLate,
                //    Power = model.Vehicle.Power
                //}
            };

            await context.Customers.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EngineTypeViewModel>> AllEngineTypesAsync()
        {
            return await repo.AllReadonly<EngineType>()
                .Select(c => new EngineTypeViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllAsync()
        {
            var entities = await context.Customers
                .Include(c => c.Address)
                .Include(c => c.Vehicles)
                .ToListAsync();

            return entities
                .Select(p => new CustomerViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsCorporate = p.IsCorporate,
                    Vehicles = p.Vehicles,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    Address = $"{p.Address.ZipCode}, {p.Address.AddressText}, {p.Address.TownName}",
                    ResponsiblePerson = p.ResponsiblePerson,
                    Uic = p.Uic
                });
        }
    }
}
