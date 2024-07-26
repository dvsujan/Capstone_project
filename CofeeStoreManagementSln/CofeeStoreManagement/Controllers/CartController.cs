using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.CartDTO;
using CofeeStoreManagement.Models.DTO.CheckoutDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService; 
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<CartReturnDto>> AddItemToCart(CartDto cartDto)
        {
            try
            {
                var result = await _cartService.AddItemToCart(cartDto);
                return Ok(result);
            }
            catch(EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "User Not Found"
                }); 
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartReturnDto>>> GetCartItems(int userId)
        {
            try
            {

                var result = await _cartService.GetAllItemsInCart(userId);
                return Ok(result);
            }
            catch(EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "User Not Found"
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = "Internal Server Error"
                });
            }
        }
        [HttpDelete]
        public async Task<ActionResult<CartReturnDto>> RemoveItemFromCart(int userId, int productId)
        {
            try
            {
                var result = await _cartService.DeleteItemFromCart(userId , productId);
                return Ok(result);
            }
            catch(EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "Product Not Found In Cart"
                });
            }
        }
        [HttpPost]
        [Route("checkout")]  
        public async Task<ActionResult<CheckoutReturnDto>> Checkout(CheckoutDto dto)
        {
            try
            {
                var result = await _cartService.Checkout(dto);
                return Ok(result);
            }
            catch(EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "User Not Found"
                });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message
                });
            }
        }

    }
}
