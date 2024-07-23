using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class ProductOption
    {
        [Key]
        public int OptionId { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal AdditionalCost { get; set; }
        public ICollection<ProductOptionValue> ProductOptionValues { get; set; }

    }
}
