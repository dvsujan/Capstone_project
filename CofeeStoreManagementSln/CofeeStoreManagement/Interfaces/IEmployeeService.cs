using CofeeStoreManagement.Models.DTO.EmployeeDto;

namespace CofeeStoreManagement.Interfaces
{
    public interface IEmployeeService
    {
        public Task<EmployeeLoginReturnDto> Login(EmployeeLoginDto dto);
        public Task<EmployeeRegisterReturnDto> Register(EmployeeRegisterDto dto); 
    }
}
