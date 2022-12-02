using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Contracts
{
    public interface IPartService
    {
        Task<IEnumerable<PartViewModel>> GetAllAsync();

        Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync();

        Task AddPartAsync(AddPartViewModel model);

        Task<bool> Exists(int id);

        Task<PartDetailsModel> PartDetailsById(int id);

        Task<int> GetVehicleComponentId(int partId);

        Task<IEnumerable<PartVehicleCopmonentModel>> AllVehicleComponents();

        Task<bool> VehicleComponentExists(int componentId);

        Task<bool> Edit(int partId, PartViewModel model);

        Task<EditPartViewModel> GetPartForEditAsync(int id);

        Task<Part> GetPartById(int id);

        Task Delete(int id);
    }
}
