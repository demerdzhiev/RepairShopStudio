namespace RepairShopStudio.Core.Models.OperatingCard
{
    public class OperatingCardViewModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = null!;

        public string VehicleLicensePlate { get; set; } = null!;

        public ICollection<Infrastructure.Data.Models.Part> Parts { get; set; }
            = new List<Infrastructure.Data.Models.Part>();

        public ICollection<Infrastructure.Data.Models.ShopService> Services { get; set; }
            = new List<Infrastructure.Data.Models.ShopService>();

        public string MechanicName { get; set; } = null!;

        public string IssueDate { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public bool IsActive { get; set; } = true;
        public string DocumentNumber { get; set; } = null!;

        public decimal Discount { get; set; }
    }
}
