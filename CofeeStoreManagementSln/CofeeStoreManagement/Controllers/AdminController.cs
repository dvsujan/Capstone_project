using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO.AdminDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        [Route("addproduct")]
        public async Task<ActionResult<AddProductReturnDto>> AddProduct(AddProductDto productdto)
        {
            try
            { 
                var res = await _adminService.AddNewProduct(productdto);
                return res; 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
