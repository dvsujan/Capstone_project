namespace CofeeStoreManagement.Models.DTO.UserDTOs
{
    public class RegisterReturnDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

    }
}
