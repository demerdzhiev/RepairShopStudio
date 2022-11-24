using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Contracts
{
    public interface IPartService
    {
        Task<IEnumerable<PartViewModel>> GetAllAsync();
        Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync();
        Task AddPartAsync(AddPartViewModel model);
        Task<bool> Exists(string id);
        Task<PartViewModel> PartDetailsById(string id);
        Task<string> GetVehicleComponentId(string partId);
        Task<IEnumerable<PartVehicleCopmonent>> AllVehicleComponents();
        Task<bool> VehicleComponentExists(string componentId);
        Task Edit(string partId, PartViewModel model);
    }
}
