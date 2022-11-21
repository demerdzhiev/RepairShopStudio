using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Contracts
{
    public interface IPartService
    {
        Task<IEnumerable<PartViewModel>> GetAllAsync();
        Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync();
        Task AddPartAsync(AddPartViewModel model);
    }
}
