using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Interfaces
{
    public interface ITokenService
    {
        public string GenerateUserToken(User user);
        public string GenerateEmployeeToken(Employee employee);
        public Task<string> GenerateAdminToken(string username, string password); 
    }
}
