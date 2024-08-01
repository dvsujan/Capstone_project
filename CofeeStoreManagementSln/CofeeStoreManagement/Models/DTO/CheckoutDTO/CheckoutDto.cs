using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models.DTO.CheckoutDTO
{
    public class CheckoutDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int StoreId { get; set;  }
    }
}