using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.CustomerModels;
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

        /// <summary>
        /// Add new user, vehicle and address to Data-Base
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>Create new customer with it's vehicle and Address</returns>
        public async Task AddCorporateCutomerAsync(CustomerAddViewModel customerModel)
        {
            var address = new Address()
            {
                Id = customerModel.Address.Id,
                AddressText = customerModel.Address.AddressText,
                ZipCode = customerModel.Address.ZipCode,
                TownName = customerModel.Address.TownName
            };

            await context.AddAsync<Address>(address);
            await context.SaveChangesAsync();

            var customer = new Customer()
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Email = customerModel.Email,
                PhoneNumber = customerModel.PhoneNumber,
                IsCorporate = true,
                ResponsiblePerson = customerModel.ResponsiblePerson,
                Uic = customerModel.Uic,
                AddressId = address.Id
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

        /// <summary>
        /// Add new user and vehicle to Data-Base
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>Create new customer (without Uic and Responsible person) and Vehicle</returns>
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

        /// <summary>
        /// Get all engine types
        /// </summary>
        /// <returns>List of EngyneTypesViewModel for all engine types</returns>
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


        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all customers</returns>
        public async Task<IEnumerable<CustomerViewModel>> GetAllAsync()
        {
            var entities = await context.Customers
                .Include(c => c.Address)
                .Include(c => c.Vehicles)
                .OrderByDescending(c => c.IsCorporate)
                .ThenBy(c => c.Name)
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

        /// <summary>
        /// Get all engine types
        /// </summary>
        /// <returns>List of all engine types</returns>
        public async Task<IEnumerable<EngineType>> GetEngineTypesAsync()
        {
            return await context.EngineTypes.ToListAsync();
        }

    }
}
