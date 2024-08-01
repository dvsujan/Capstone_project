using CofeeStoreManagement.Models.DTO.AdminDTO;
using CofeeStoreManagement.Models.DTO.UserDTOs;

namespace CofeeStoreManagement.Interfaces
{
    public interface IAdminService
    {
        public Task<AdminLoginReturnDto> Login (AdminLoginDto adminLoginDto);   
        public Task<AddProductReturnDto> AddNewProduct (AddProductDto addProductDto);
        public Task<string> GetUploadedFileUrl(Stream fileStream, string fileName);
        public Task<AnalyticsReturnDto> GetPrevWeekAnalytics();   
    }
}
