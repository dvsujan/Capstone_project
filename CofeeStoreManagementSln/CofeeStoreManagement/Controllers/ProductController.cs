using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.MenuDTO;
using CofeeStoreManagement.Models.DTO.ProductDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService; 
        public ProductController (IProductService productService)
        {
            _productService = productService; 
        }

        
        [HttpGet]
        public async Task<ActionResult<ProductDataDto>> GetProductById(int id)
        {
            try
            {
                var res = await _productService.GetProductById(id);
                return res; 
            }
            catch (EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "Product not found"
                });  
            }
        }
        
        [HttpGet]
        [Route("Options")]
        public async Task<ActionResult<ProductWithCategoriesDto>> GetProductOptions(int id)
        {
            try
            {
                var res = await _productService.GetProductWithCategories(id); 
                return Ok(res);

            }
            catch (EntityNotFoundException) {
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Product not found"   
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message
                });
            }
        }

    }
}
