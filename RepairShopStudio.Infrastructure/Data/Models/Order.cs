using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Order;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Order of parts properties")]
    public class Order : BaseModel
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Required]
        [Comment("Document number")]
        public string Number { get; set; } = null!;

        [Required]
        [Comment("Date of the creation of the order")]
        public DateTime IssueDate { get; set; }

        [Required]
        [Comment("Collection of ordered parts")]
        public ICollection<Part> Parts { get; set; } = new List<Part>();

        [Required]
        [StringLength(OrderNoteMaxLength)]
        public string Note { get; set; } = null!;


        [Comment("Supplier which will deliver the goods")]
        public string SupplierId { get; set; } = null!;

        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
