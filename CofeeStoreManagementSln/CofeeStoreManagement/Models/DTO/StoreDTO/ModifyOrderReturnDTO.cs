using Microsoft.Identity.Client;

namespace CofeeStoreManagement.Models.DTO.StoreDTO
{
    public class ModifyOrderReturnDTO
    {  
        public int UserId { get; set;  } 
        public int StoreId { get; set;  }
        public decimal TotalAmount { get; set; } 
        public string UpdatedStatus { get; set;}
    }
}