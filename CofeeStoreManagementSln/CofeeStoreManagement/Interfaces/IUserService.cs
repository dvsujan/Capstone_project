using CofeeStoreManagement.Models.DTO.UserDTOs;

namespace CofeeStoreManagement.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDto> Login(UserLoginDTO dto);
        public Task<RegisterReturnDto> Register(UserRegisterDto dto);

    }
}
