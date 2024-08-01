using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CofeeStoreManagement.services
{
    public class TokenService:ITokenService
    { 
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;
        private readonly IKeyVaultService _keyVaultService;
        
        public TokenService(IConfiguration configuration, IKeyVaultService keyvaultservice)
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            _keyVaultService = keyvaultservice; 
        }

         /// <summary>
        /// Generates a token for the employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public string GenerateEmployeeToken(Employee employee)
        {
            string token = string.Empty;
            var claims = new List<Claim>(){
                new Claim("EmployeeId",employee.EmployeeId.ToString()),
                new Claim("StoreId", employee.StoreId.ToString()) ,
                new Claim(ClaimTypes.Role, "Employee")
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(7), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken); 
            return token;
        }
        
        /// <summary>
        /// Geerates 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GenerateUserToken(User user)
        {
            string token = string.Empty;
            var claims = new List<Claim>(){
                new Claim("UserId",user.Id.ToString()),
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddHours(5), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }
        
        /// <summary>
        /// generate a token for admin
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<string> GenerateAdminToken(string username , string password)
        {
            string token = string.Empty;
            var claims = new List<Claim>(){
                new Claim("AdminName",username),
                new Claim(ClaimTypes.Role, "Admin")
            }; 
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(7), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }

    }
}
