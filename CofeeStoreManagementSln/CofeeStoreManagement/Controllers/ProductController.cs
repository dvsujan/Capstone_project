using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.MenuDTO;
using CofeeStoreManagement.Models.DTO.ProductDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService; 
        private readonly ILogger<ProductController> _logger;
        public ProductController (IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// get the product info by product Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDataDto>> GetProductById(int id)
        {
            try
            {
                var res = await _productService.GetProductById(id);
                _logger.LogInformation($"Product with id {id} found");
                return res;
            }
            catch (EntityNotFoundException)
            {
                _logger.LogError($"Product with id {id} not found");
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "Product not found"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message
                });
            }
        }
        

        /// <summary>
        /// Get all product categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CategoryDataDto>>> GetAllCategories()
        {
            try
            {
                var res = await _productService.GetCategories();
                _logger.LogInformation("All categories found");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message
                });
            }
        }

        
        /// <summary>
        /// Get the product optins by the product Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Options")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductWithCategoriesDto>> GetProductOptions(int id)
        {
            try
            {
                var res = await _productService.GetProductWithCategories(id); 
                _logger.LogInformation($"Product with id {id} found");
                return Ok(res);

            }
            catch (EntityNotFoundException) {
                _logger.LogError($"Product with id {id} not found");
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Product not found"   
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message
                });
            }
        }

    }
}
