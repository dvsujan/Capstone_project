namespace CofeeStoreManagement.Models.DTO.ProductDTO
{
    public class ProductOptionDto
    {
        public int OptionId { get; set; }
        public string OptionName { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal AdditionalCost { get; set; }
        public List<OptionValueDto> OptionValues { get; set; }

    }
}
