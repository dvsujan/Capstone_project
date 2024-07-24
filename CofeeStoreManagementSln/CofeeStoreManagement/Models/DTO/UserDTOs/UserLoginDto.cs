using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models.DTO.UserDTOs
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty; 
    }
}
