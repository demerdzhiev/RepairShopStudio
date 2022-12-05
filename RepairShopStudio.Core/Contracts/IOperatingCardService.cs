using RepairShopStudio.Core.Models.OperatingCard;
using RepairShopStudio.Infrastructure.Data.Models;
using RepairShopStudio.Infrastructure.Data.Models.User;


namespace RepairShopStudio.Core.Contracts
{
    public interface IOperatingCardService
    {
        Task<IEnumerable<OperatingCardViewModel>> GetAllAsync();
        IEnumerable<Part> GetParts();
        IEnumerable<ShopService> GetShopServices();
        Task AddOperatingCardAsync(OperatingCardAddViewModel model);
        Task<IEnumerable<ApplicationUser>> GetMechanicsAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<IEnumerable<Vehicle>> GetVehicles();
    }
}
