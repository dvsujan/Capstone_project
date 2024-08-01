using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.EmployeeDto;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService employeeService,ILogger<EmployeeController> logger)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        /// <summary>
        /// route to test if employee token is valid
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("tst")]
        [Authorize(Roles = "Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Test()
        {
            _logger.LogInformation("Employee Tested"); 
            return Ok();
        }


        /// <summary>
        /// route to login in as employee
        /// </summary>
        /// <param name="employeeLoginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeLoginReturnDto>> EmployeeLogin(EmployeeLoginDto employeeLoginDto)
        {
            try
            {  
                 var res = await _employeeService.Login(employeeLoginDto);
                _logger.LogInformation($"Employee Logged in: {employeeLoginDto.Email}");
                    return res; 

            }
            catch (IncorrectPasswordException)
            {
                _logger.LogInformation($"Employee Login failed: {employeeLoginDto.Email}");
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "Incorrect password",
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error occured while logging in {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                }); 
            }
        }
        
        /// <summary>
        /// used to register employee to the orginization
        /// </summary>
        /// <param name="employeeRegisterDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeRegisterReturnDto>> EmployeeRegister(EmployeeRegisterDto employeeRegisterDto)
        {
            try
            {
                _logger.LogInformation($"Employee Registered: {employeeRegisterDto.Email}");
                var res = await _employeeService.Register(employeeRegisterDto);
                return res;
            }
            catch (UserAlreadyExistsException)
            {
                _logger.LogInformation($"Employee Registeration failed: {employeeRegisterDto.Email}");
                return StatusCode(StatusCodes.Status409Conflict, new ErrorDTO
                {
                    Message = "User already exists",
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured while registering {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
    }
}
