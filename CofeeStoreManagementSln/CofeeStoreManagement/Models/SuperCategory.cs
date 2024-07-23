using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class SuperCategory
    {
        [Key]
        public int SuperCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
