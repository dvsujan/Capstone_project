using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set;}
        public string Address { get; set;}
        public string PhoneNumber { get; set;}
        public string Email { get; set;}
        public string City { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
