using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Models.OperatingCard
{
    public class OperatingCardViewModel
    {
        public int Id { get; set; }

        public int PartId { get; set; }
        public string PartName { get; set; } = null!;

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string CustomerName { get; set; } = null!;

        public string VehicleLicensePlate { get; set; } = null!;

        public Infrastructure.Data.Models.Part Part { get; set; }

        public ICollection<Infrastructure.Data.Models.Part> Parts { get; set; }
            = new List<Infrastructure.Data.Models.Part>();

        public string MechanicName { get; set; } = null!;

        public string IssueDate { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public string DocumentNumber { get; set; } = null!;

        public Infrastructure.Data.Models.ShopService Service { get; set; }

        public ICollection<Infrastructure.Data.Models.ShopService> Services { get; set; }
            = new List<Infrastructure.Data.Models.ShopService>();
    }
}
