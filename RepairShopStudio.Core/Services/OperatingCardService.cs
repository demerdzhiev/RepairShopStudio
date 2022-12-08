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

        /// <summary>
        /// Create new operating card
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Add new operating card to Data-Base</returns>
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

        /// <summary>
        /// Get all operating cards from Data-Base
        /// </summary>
        /// <returns>List of all operating cards</returns>
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

        /// <summary>
        /// Get all operating cards with property IsActive == false from Data-Base
        /// </summary>
        /// <returns>List of all completed operating cards</returns>
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

        /// <summary>
        /// Get a customer with a certain Id from Data-Base
        /// </summary>
        /// <param name="cutomerId"></param>
        /// <returns>Customer</returns>
        public async Task<string> GetCustomerNameById(int cutomerId)
        {
            var customer = context.Customers
                .Where(c => c.Id == cutomerId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync();

            return await customer;
        }

        /// <summary>
        /// Get all customers from Data-Base
        /// </summary>
        /// <returns>A list of all customers</returns>
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await context.Customers.ToListAsync();
        }

        /// <summary>
        /// Get vehicles of a certain customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>List of vehicles owned by a certain customer</returns>
        public async Task<IEnumerable<Vehicle>> GetCustomerVehicles(int customerId)
        {
            return await context.Vehicles.Where(v => v.CustomerId == customerId).ToListAsync();
        }

        /// <summary>
        /// Get all users in role "Mechanic"
        /// </summary>
        /// <returns>List of all users in role "Mechanic"</returns>
        public async Task<IEnumerable<ApplicationUser>> GetMechanicsAsync()
        {
            return await context.Users.Where(u => u.UserName.ToLower().Contains("mechanic")).ToListAsync();
        }

        /// <summary>
        /// Get all parts from Data-Base
        /// </summary>
        /// <returns>List of all parts</returns>
        public async Task<IEnumerable<Part>> GetPartsAsync()
        {
            return await context.Parts.ToListAsync();
        }

        /// <summary>
        /// Get all shop services from Data-Base
        /// </summary>
        /// <returns>List of all shop services</returns>
        public async Task<IEnumerable<ShopService>> GetShopServicesAsync()
        {
            return await context.ShopServices.ToListAsync();
        }

        /// <summary>
        /// Check if the curren user is the same as the mechanic with assigned certain operating card, set the card's status to complete and removes 1ps of the part from the Data-Base
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="userId"></param>
        /// <returns>Set the operating card's status to Complete and update part's stock</returns>
        /// <exception cref="ArgumentException"></exception>
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

            if (card != null && card.ApplicationUserId == Guid.Parse(userId))
            {
                card.IsActive = false;
            }

            var part = await context.Parts.FirstOrDefaultAsync(p => p.Id == card.PartId);
            if (part != null)
            {
                part.Stock -= 1;
            }

            await context.SaveChangesAsync();
        }
    }
}
