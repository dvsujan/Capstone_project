using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace CofeeStoreManagement.Models
{
    public class User
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; }
        
        public byte[] Password { get; set; }
        public byte[] HashKey { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
