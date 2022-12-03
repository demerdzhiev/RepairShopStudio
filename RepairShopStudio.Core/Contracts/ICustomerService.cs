using RepairShopStudio.Core.Models.Customer;
using RepairShopStudio.Core.Models.EngineType;
using RepairShopStudio.Core.Models.Part;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Core.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllAsync();

        Task<IEnumerable<EngineTypeViewModel>> AllEngineTypesAsync();

        Task AddCutomerAsync(CustomerAddViewModel model);
    }
}
