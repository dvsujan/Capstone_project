using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models.DTO.UserDTOs
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty; 

    }
}
