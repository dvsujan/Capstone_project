using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }

    }
}
