using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Order;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment("Order of parts properties")]
    public class Order
    {
        [Key]
        [Comment("Id of the order")]
        public Guid Id { get; set; }

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
        public Guid SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }
    }
}
