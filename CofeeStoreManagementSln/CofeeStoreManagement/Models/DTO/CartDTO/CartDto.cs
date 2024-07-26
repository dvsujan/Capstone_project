namespace CofeeStoreManagement.Models.DTO.CartDTO
{
    public class CartDto
    {
        public int UserId { get; set;  }
        public int ProductId { get; set;  } 
        public int Quantity { get; set;  }
        public IList<int> Options { get; set; } 
    }
}