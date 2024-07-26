using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now; 
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
