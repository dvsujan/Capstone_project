namespace CofeeStoreManagement.Models.DTO.OrderDTO
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }  
        public int Quantity { get; set;  }
        public string ImageUrl { get; set; }
        public List<OrderItemOptionDto> SelectedOptions { get; set; } = new List<OrderItemOptionDto>();

    }
}
