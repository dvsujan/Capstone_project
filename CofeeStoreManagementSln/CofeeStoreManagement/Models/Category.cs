using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public int SuperCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public SuperCategory SuperCategory { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
