using CofeeStoreManagement.Models.DTO.CartDTO;

namespace CofeeStoreManagement.Models.DTO.OrderDTO
{
    public class OrderReturnDto
    {
        public int OrderId { get; set; }
        public string Username { get; set; }
        public decimal OrderAmount { get; set; } 
        public string Status { get; set;  }
        public IEnumerable<OrderItemDto> orderItems { get; set; }

    }
}