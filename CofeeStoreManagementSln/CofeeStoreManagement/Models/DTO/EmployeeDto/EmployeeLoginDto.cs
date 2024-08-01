using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models.DTO.EmployeeDto
{
    public class EmployeeLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set;  } 
        [Required]
        public string Password { get; set;  }
    }
}