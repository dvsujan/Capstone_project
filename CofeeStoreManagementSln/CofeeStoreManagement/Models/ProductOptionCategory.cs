using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class ProductOptionCategory
    {
        [Key]
        public int OptionCategoryId { get; set; }
        public int OptionId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Category Category { get; set; }
    }
}
