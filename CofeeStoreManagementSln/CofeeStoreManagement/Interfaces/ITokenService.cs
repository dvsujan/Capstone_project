using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Interfaces
{
    public interface ITokenService
    {
        public string GenerateUserToken(User user);
        public string GenerateEmployeeToken(Employee employee);
        public string GenerateAdminToken(string username, string password); 
    }
}
