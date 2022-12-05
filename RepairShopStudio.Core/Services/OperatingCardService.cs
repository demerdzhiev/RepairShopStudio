using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.OperatingCard;
using RepairShopStudio.Core.Models.Part;
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
                DocumentNumber = model.DocumentNumber,
                Discount = (double)model.Discount,
                CustomerId = model.CustomerId,
                Date = model.IssueDate,
                VehicleId = model.VehicleId,
                IsActive = model.IsActive,
                Parts = (ICollection<Part>)model.Parts,
                ShopServices = (ICollection<ShopService>)model.Services,
                TotalAmount = model.TotalAmount
            };

            await context.OperatingCards.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OperatingCardViewModel>> GetAllAsync()
        {
            var entities = await context.OperatingCards
                .Include(c => c.Customer)
                .Include(cv => cv.Customer.Vehicles)
                .Include(au => au.ApplicationUser)
                .ToListAsync();

            return entities
                .Select(oc => new OperatingCardViewModel
                {
                    Id = oc.Id,
                    CustomerName = oc.Customer.Name,
                    MechanicName = $"{oc.ApplicationUser.FirstName} {oc.ApplicationUser.LastName}",
                    Parts = oc.Parts,
                    Services = oc.ShopServices,
                    IsActive = oc.IsActive,
                    IssueDate = oc.Date.ToString(),
                    VehicleLicensePlate = oc.Customer.Vehicles.FirstOrDefault(v => v.Id == oc.VehicleId).LicensePLate,
                    TotalAmount = oc.TotalAmount,
                    DocumentNumber = oc.DocumentNumber,
                    Discount = (decimal)oc.Discount
                });
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await context.Vehicles.ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetMechanicsAsync()
        {
            return await context.Users.Where(u => u.UserName.ToLower().Contains("mechanic")).ToListAsync();
        }

        public IEnumerable<Part> GetParts()
        {
            return context.Parts.ToList();
        }

        public IEnumerable<ShopService> GetShopServices()
        {
            return  context.ShopServices.ToList();
        }
    }
}
