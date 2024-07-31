using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models.DTO.AdminDTO
{
    public class AdminLoginDto
    {
        [Required]
        public string Username { get; set;  }
        [Required]
        public string Password { get; set;  }
    }
}
