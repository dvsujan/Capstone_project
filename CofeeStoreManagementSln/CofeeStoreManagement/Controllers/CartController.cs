using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.CartDTO;
using CofeeStoreManagement.Models.DTO.CheckoutDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

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
        [Authorize]
        public async Task<ActionResult<CartReturnDto>> AddItemToCart(CartDto cartDto)
        {
            var userIdLogged = int.Parse(User.FindFirst("UserId").Value);
            if (userIdLogged != cartDto.UserId)
            { 
                return StatusCode(StatusCodes.Status403Forbidden,new ErrorDTO
                {
                    Message= "forbidden User"
                });
            }

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
        [Authorize]
        public async Task<ActionResult<IEnumerable<CartReturnDto>>> GetCartItems(int userId)
        {
            var userIdLogged = int.Parse(User.FindFirst("UserId").Value);
            if (userIdLogged != userId)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                { 
                    Message="Forbidden User"

                }); 
            }
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
        [Authorize]
        public async Task<ActionResult<CartReturnDto>> RemoveItemFromCart(int userId, int productId)
        {
            var userIdLogged = int.Parse(User.FindFirst("UserId").Value);
            if (userIdLogged != userId)
            { 
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
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
        [Authorize]
        public async Task<ActionResult<CheckoutReturnDto>> Checkout(CheckoutDto dto)
        {
            var userIdLogged = int.Parse(User.FindFirst("UserId").Value);
            if (userIdLogged != dto.UserId)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            } 
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
            catch (UserDoesNotExistException)
            { 
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "User Does Not Exist"
                });

            }
            catch (StoreDoesNotExistException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "Store Does Not Exist"
                });
            }
            catch (CartEmptyException)
            {
                return BadRequest(new ErrorDTO
                {
                    Message="Cart is empty Cannot Checkout"
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
