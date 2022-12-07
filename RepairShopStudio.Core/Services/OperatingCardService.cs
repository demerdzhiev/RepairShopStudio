using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.OperatingCard;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;
using RepairShopStudio.Infrastructure.Data.Models.User;

namespace RepairShopStudio.Core.Services
{
    public class OperatingCardService : IOperatingCardService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        public OperatingCardService(
            ApplicationDbContext _context,
            IRepository _repo)
        {
            context = _context;
            repo = _repo;
        }

        public async Task AddOperatingCardAsync(OperatingCardAddViewModel model)
        {
            var entity = new OperatingCard()
            {
                Id = model.Id,
                ApplicationUserId = Guid.Parse(model.ApplicationUserId),
                CustomerId = model.CustomerId,
                Date = DateTime.Today,
                VehicleId = model.VehicleId,
                IsActive = true,
                PartId = model.PartId,
                ServiceId = model.ServiceId
            };

            entity.DocumentNumber 
                = $"{context.Vehicles.FirstOrDefault(v => v.Id == entity.VehicleId).LicensePLate}/{entity.Date.ToString("dd.MM.yyyy")}";

            await context.OperatingCards.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OperatingCardViewModel>> GetAllAsync()
        {
            var entities = await context.OperatingCards
                .Where(oc => oc.IsActive == true)
                .Include(c => c.Customer)
                .Include(p => p.Part)
                .Include(s => s.Service)
                .Include(cv => cv.Customer.Vehicles)
                .Include(au => au.ApplicationUser)
                .ToListAsync();

            return entities
                .Select(oc => new OperatingCardViewModel
                {
                    Id = oc.Id,
                    CustomerName = oc.Customer.Name,
                    MechanicName = $"{oc.ApplicationUser.FirstName} {oc.ApplicationUser.LastName}",
                    PartName = oc.Part.Name,
                    ServiceName = oc.Service.Name,
                    IsActive = oc.IsActive,
                    IssueDate = oc.Date.ToString("dd.MM.yyyy"),
                    VehicleLicensePlate = oc.Customer.Vehicles.FirstOrDefault(v => v.Id == oc.VehicleId).LicensePLate,
                    DocumentNumber = oc.DocumentNumber,
                });
        }

        public async Task<IEnumerable<OperatingCardViewModel>> GetAllFinishedAsync()
        {
            var entities = await context.OperatingCards
                .Where(oc => oc.IsActive == false)
                .Include(c => c.Customer)
                .Include(p => p.Part)
                .Include(s => s.Service)
                .Include(cv => cv.Customer.Vehicles)
                .Include(au => au.ApplicationUser)
                .ToListAsync();

            return entities
                .Select(oc => new OperatingCardViewModel
                {
                    Id = oc.Id,
                    CustomerName = oc.Customer.Name,
                    MechanicName = $"{oc.ApplicationUser.FirstName} {oc.ApplicationUser.LastName}",
                    PartName = oc.Part.Name,
                    ServiceName = oc.Service.Name,
                    IsActive = oc.IsActive,
                    IssueDate = oc.Date.ToString("dd.MM.yyyy"),
                    VehicleLicensePlate = oc.Customer.Vehicles.FirstOrDefault(v => v.Id == oc.VehicleId).LicensePLate,
                    DocumentNumber = oc.DocumentNumber,
                });
        }

        public async Task<string> GetCustomerNameById(int cutomerId)
        {
            var customer = context.Customers
                .Where(c => c.Id == cutomerId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync();

            return await customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetCustomerVehicles(int customerId)
        {
            return await context.Vehicles.Where(v => v.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetMechanicsAsync()
        {
            return await context.Users.Where(u => u.UserName.ToLower().Contains("mechanic")).ToListAsync();
        }

        public async Task<IEnumerable<Part>> GetPartsAsync()
        {
            return await context.Parts.ToListAsync();
        }

        public async Task<IEnumerable<ShopService>> GetShopServicesAsync()
        {
            return await context.ShopServices.ToListAsync();
        }

        public async Task MarkRepairAsFinishedAsync(int cardId, string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == Guid.Parse(userId))
               .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Invalid user ID");
            }

            var card = await context.OperatingCards.FirstOrDefaultAsync(m => m.Id == cardId);

            if (card == null)
            {
                throw new ArgumentException("Invalid card ID");
            }

            if (card.ApplicationUserId == Guid.Parse(userId))
            {
                card.IsActive = false;
            }

            var part = await context.Parts.FirstOrDefaultAsync(p => p.Id == card.PartId);
            if (part != null)
            {
                part.Stock -= 1;
            }

            if(card != null)
            {
                card.IsActive = false;
            }

            await context.SaveChangesAsync();
        }
    }
}
