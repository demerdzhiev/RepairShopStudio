using RepairShopStudio.Core.Models.Customer;
using RepairShopStudio.Core.Models.EngineType;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllAsync();

        Task<IEnumerable<EngineTypeViewModel>> AllEngineTypesAsync();

        Task AddRegularCutomerAsync(CustomerAddViewModel customerModel);

        Task AddCorporateCutomerAsync(CustomerAddViewModel customerModel);

        Task<IEnumerable<EngineType>> GetEngineTypesAsync();
    }
}
