using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models.DTO.AdminDTO
{
    public class AddProductDto
    {
        [Required]  
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Calories { get; set;  }
        [Required]
        public int Cost { get; set;  }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [Url]
        public string ImageUrl { get; set;  }
    }
}