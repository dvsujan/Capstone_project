using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.EmployeeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        { 
            _employeeService = employeeService;
        }
        [HttpPost]
        [Route("login")] 
        public async Task<ActionResult<EmployeeLoginReturnDto>> EmployeeLogin(EmployeeLoginDto employeeLoginDto)
        {
            try
            {  
                 var res = await _employeeService.Login(employeeLoginDto);
                    return res; 

            } 
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                }); 
            }
        }

        [HttpPost]
        [Route("register")] 
        public async Task<ActionResult<EmployeeRegisterReturnDto>> EmployeeRegister(EmployeeRegisterDto employeeRegisterDto)
        {
            try
            {
                var res = await _employeeService.Register(employeeRegisterDto);
                return res;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
    }
}
