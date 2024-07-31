using CofeeStoreManagement.Models.DTO.AdminDTO;
using CofeeStoreManagement.Models.DTO.UserDTOs;

namespace CofeeStoreManagement.Interfaces
{
    public interface IAdminService
    {
        public Task<AdminLoginReturnDto> LoginReturnDto (AdminLoginDto adminLoginDto);   
        public Task<AddProductReturnDto> AddNewProduct (AddProductDto addProductDto);
    }
}
