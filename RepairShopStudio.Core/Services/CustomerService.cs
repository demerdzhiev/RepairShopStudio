using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Customer;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;

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
