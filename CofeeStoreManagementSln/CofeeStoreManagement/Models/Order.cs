using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public Store Store { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
