namespace CofeeStoreManagement.Models.DTO.MenuDTO
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public List<ProductDataDto> Children { get; set; }

    }
}
