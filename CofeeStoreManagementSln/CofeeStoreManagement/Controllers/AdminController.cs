using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.AdminDTO;
using CofeeStoreManagement.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CofeeStoreManagement.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly ILogger<AdminController> _logger;
        public AdminController(IAdminService adminService, ILogger<AdminController> logger)
        {
            _adminService = adminService;
            _logger = logger;
        }

        /// <summary>
        /// Used to test if the admin token is valid
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("tst")]
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Test()
        {
            _logger.LogInformation("Admin Test"); 
            return Ok();  
        }
        
        /// <summary>
        /// gets the analytics of the previous week
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("analytics")]
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AnalyticsReturnDto>> GetAnalytics()
        {
            try
            {
                var res = await _adminService.GetPrevWeekAnalytics();
                _logger.LogInformation("Admin analytics Request");
                return res;
            }
            catch (Exception ex)
            {
                 _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        /// <summary>
        /// route to add new product by admin
        /// </summary>
        /// <param name="productdto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addproduct")]
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AddProductReturnDto>> AddProduct(AddProductDto productdto)
        {
            try
            { 
                var res = await _adminService.AddNewProduct(productdto);
                _logger.LogInformation($"Admin Uploaded New Product {res.ProductId}"); 
                return res; 
            }
            catch (CategoryDoesNotExistException)
            {
                _logger.LogWarning($"Category {productdto.CategoryId} does not exist");
                return Conflict(new ErrorDTO
                {
                    Message = "Category Does Not Exist"
                });
            }
            catch (Exception ex)
            { 
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// used to login admin
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AdminLoginReturnDto>> AdminLogin(AdminLoginDto dto)
        {
            try
            {
                var res = await _adminService.Login(dto);
                _logger.LogInformation($"Admin Login: {res}");
                return res;
            } 
            catch (IncorrectPasswordException)
            {
                _logger.LogWarning("Incorrect Password Entred by Admin");
                return BadRequest(new ErrorDTO
                {
                    Message = "Incorrect Password"
                });
            }
            catch (Exception ex)
            { 
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// upload a file and get the url of that file in this case image of product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("upload")]
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UploadImage([FromForm] FileUploadDto dto)
        {
            try
            {

                if (dto.File == null || dto.File.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.File.FileName);
                
                using (var stream = dto.File.OpenReadStream())
                {
                    var url = await _adminService.GetUploadedFileUrl(stream, fileName);
                    _logger.LogInformation($"Admin Uploaded Image {url}");
                    return Ok(new { Url = url });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
    }
}
