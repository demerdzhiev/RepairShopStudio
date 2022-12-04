using RepairShopStudio.Core.Models.OperatingCard;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Core.Contracts
{
    public interface IOperatingCardService
    {
        Task<IEnumerable<OperatingCardViewModel>> GetAllAsync();
    }
}
