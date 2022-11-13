using RepairShopStudio.Core.Models.Part;

namespace RepairShopStudio.Core.Contracts
{
    public interface IPartService
    {
        Task<IEnumerable<PartViewModel>> GetAllAsync();
    }
}
