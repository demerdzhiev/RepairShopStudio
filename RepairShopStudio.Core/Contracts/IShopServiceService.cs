using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Core.Models.ShopService;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Contracts
{
    public interface IShopServiceService
    {
        Task<IEnumerable<ShopServiceViewModel>> GetAllAsync();
        Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync();
        Task AddAsync(AddShopServiceViewModel model);
    }
}
