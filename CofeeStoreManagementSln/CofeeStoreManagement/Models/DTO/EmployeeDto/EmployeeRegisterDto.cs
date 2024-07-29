using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models.DTO.EmployeeDto
{
    public class EmployeeRegisterDto
    {
        [Required]
        public int StoreId {get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password {get; set;} 
    }
}