using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models.DTO.CartDTO
{
    public class CartDto
    {
        [Required]
        public int UserId { get; set;  }
        [Required]
        public int ProductId { get; set;  } 
        [Required]
        public int Quantity { get; set;  }
        [Required]
        public IList<int> Options { get; set; } 
    }
}