using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public int StarCost { get; set; }
        public string ImageUri { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
