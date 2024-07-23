using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] HashKey { get; set; }
        public int StoreId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Store Store { get; set; }
    }
}
