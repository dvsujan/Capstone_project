using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class ProductOptionValue
    {
        [Key]
        public int OptionValueId { get; set; }
        public int OptionId { get; set; }
        public string Value { get; set; }
        public decimal AdditionalCost { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}
