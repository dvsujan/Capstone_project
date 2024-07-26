namespace CofeeStoreManagement.Models.DTO.ProductDTO
{
    public class ProductWithCategoriesDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public List<CategoryWithOptionsDto> Categories { get; set; }
    }
}
