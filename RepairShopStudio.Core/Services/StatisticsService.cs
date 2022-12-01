using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Statistics;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository repo;
        public StatisticsService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<StatisticsServiceModel> Total()
        {
            int totalParts = await repo.AllReadonly<Part>()
                .CountAsync(p => p.IsActive);

            int totalServices = await repo.AllReadonly<ShopService>()
                .CountAsync(s => s.IsActive);

            return new StatisticsServiceModel()
            {
                TotalParts = totalParts,
                TotalServices = totalServices
            };
        }
    }
}
