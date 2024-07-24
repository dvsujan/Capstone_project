using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO.UserDTOs;
using CofeeStoreManagement.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<LoginReturnDto>> Login(UserLoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorDTO
                {
                    Message = "Invalid Data"
                });
            }
            try
            {
                var login = await _userService.Login(user);
                return Ok(login);
            }
            catch (EntityNotFoundException)
            {
                return NotFound(new ErrorDTO
                {
                    Message = "User not found"
                });
            }
            catch (IncorrectPasswordException)
            {
                return Conflict(new ErrorDTO
                {
                    Message = "Incorrect Password"
                });
            }
            
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RegisterReturnDto>> Register(UserRegisterDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorDTO
                {
                    Message = "Invalid Data"
                });
            }
            try
            {
                var register = await _userService.Register(user);
                return Ok(register);
            }
            catch (UserAlreadyExistsException)
            {
                return BadRequest(new ErrorDTO
                {
                    Message = "User already exists"
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
