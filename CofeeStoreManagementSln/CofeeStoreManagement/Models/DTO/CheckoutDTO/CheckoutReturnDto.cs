namespace CofeeStoreManagement.Models.DTO.CheckoutDTO
{
    public class CheckoutReturnDto
    {
        public decimal FinalPrice { get; set;}
        public int UserId { get; set; }  
        public decimal Discount { get; set; } 
    }
}