using Microsoft.EntityFrameworkCore;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Statistics;

namespace RepairShopStudio.Core.Models.Statistics
{
    [Comment(ServiceViewModelMain)]
    public class StatisticsServiceModel
    {
        [Comment(ServiceViewModelTotalParts)]
        public int TotalParts { get; init; }

        [Comment(ServiceViewModelTotalServices)]
        public int TotalServices { get; init; }
    }
}
