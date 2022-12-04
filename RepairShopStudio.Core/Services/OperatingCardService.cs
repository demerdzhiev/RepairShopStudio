using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.OperatingCard;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

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
    }
}
