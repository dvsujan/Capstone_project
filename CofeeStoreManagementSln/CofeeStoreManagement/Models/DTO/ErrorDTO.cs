namespace CofeeStoreManagement.Models.DTO
{
    public class ErrorDTO
    {
        public bool Success { get; set; } = false; 
        public string Message { get; set; } = string.Empty;
    }
}
