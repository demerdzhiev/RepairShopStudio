using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Customer;
using RepairShopStudio.Core.Models.EngineType;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using Address = RepairShopStudio.Infrastructure.Data.Models.Address;
using Customer = RepairShopStudio.Infrastructure.Data.Models.Customer;
using EngineType = RepairShopStudio.Infrastructure.Data.Models.EngineType;
using Vehicle = RepairShopStudio.Infrastructure.Data.Models.Vehicle;

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

        public async Task AddCorporateCutomerAsync(CustomerAddViewModel customerModel)
        {
            var customer = new Customer()
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Email = customerModel.Email,
                PhoneNumber = customerModel.PhoneNumber,
                IsCorporate = true,
                Address = new Address()
                {
                    Id = customerModel.Address.Id,
                    AddressText = customerModel.Address.AddressText,
                    ZipCode = customerModel.Address.ZipCode,
                    TownName = customerModel.Address.TownName
                }
            };
            await context.AddAsync<Customer>(customer);
            await context.SaveChangesAsync();

            var vehicle = new Vehicle()
            {
                Id = customerModel.Vehicle.Id,
                Make = customerModel.Vehicle.Make,
                Model = customerModel.Vehicle.Model,
                VinNumber = customerModel.Vehicle.VinNumber,
                Power = customerModel.Vehicle.Power,
                EngineTypeId = customerModel.Vehicle.EngineTypeId,
                LicensePLate = customerModel.Vehicle.LicensePLate,
                FIrstRegistration = customerModel.Vehicle.FIrstRegistration,
                CustomerId = customer.Id
            };

            await context.AddAsync<Vehicle>(vehicle);
            await context.SaveChangesAsync();
        }

        public async Task AddRegularCutomerAsync(CustomerAddViewModel customerModel)
        {
            var customer = new Customer()
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Email = customerModel.Email,
                PhoneNumber = customerModel.PhoneNumber,
                IsCorporate = false,
            };

            await context.AddAsync<Customer>(customer);
            await context.SaveChangesAsync();

            var vehicle = new Vehicle()
            {
                Id = customerModel.Vehicle.Id,
                Make = customerModel.Vehicle.Make,
                Model = customerModel.Vehicle.Model,
                VinNumber = customerModel.Vehicle.VinNumber,
                Power = customerModel.Vehicle.Power,
                EngineTypeId = customerModel.Vehicle.EngineTypeId,
                LicensePLate = customerModel.Vehicle.LicensePLate,
                FIrstRegistration = customerModel.Vehicle.FIrstRegistration,
                CustomerId = customer.Id
            };

            await context.AddAsync<Vehicle>(vehicle);
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
                    Address = $"{p.Address?.ZipCode}, {p.Address?.AddressText}, {p.Address?.TownName}",
                    ResponsiblePerson = p.ResponsiblePerson,
                    Uic = p.Uic
                });
        }

        public async Task<IEnumerable<EngineType>> GetEngineTypesAsync()
        {
            return await context.EngineTypes.ToListAsync();
        }

    }
}
