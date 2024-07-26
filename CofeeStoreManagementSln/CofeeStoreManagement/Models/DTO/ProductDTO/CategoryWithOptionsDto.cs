namespace CofeeStoreManagement.Models.DTO.ProductDTO
{
    public class CategoryWithOptionsDto
    {
        public string CategoryName { get; set; }
        public List<ProductOptionDto> Options { get; set; }

    }
}
