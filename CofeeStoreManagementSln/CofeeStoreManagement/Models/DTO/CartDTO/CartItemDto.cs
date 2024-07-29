using CofeeStoreManagement.Models.DTO.ProductDTO;

namespace CofeeStoreManagement.Models.DTO.CartDTO
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public int Cost { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }   
        public List<ProductOptionDto> SelectedOptions { get; set; }
    }
}
