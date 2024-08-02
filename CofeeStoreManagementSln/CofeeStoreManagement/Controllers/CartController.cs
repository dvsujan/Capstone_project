using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.CartDTO;
using CofeeStoreManagement.Models.DTO.CheckoutDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;  
        private readonly ILogger<CartController> _logger;
        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }

        /// <summary>
        /// add a new item to the cart
        /// </summary>
        /// <param name="cartDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartReturnDto>> AddItemToCart(CartDto cartDto)
        {
            var userIdLogged = int.Parse(User.FindFirst("UserId").Value);
            if (userIdLogged != cartDto.UserId)
            { 
                _logger.LogWarning($"User {userIdLogged} tried to add item to cart {cartDto.UserId}");
                return StatusCode(StatusCodes.Status403Forbidden,new ErrorDTO
                {
                    Message= "forbidden User"
                });
            }
            try
            {
                var result = await _cartService.AddItemToCart(cartDto);
                _logger.LogInformation($"Item {cartDto.ProductId} added to cart {cartDto.UserId}");
                return Ok(result);
            }
            catch (UserDoesNotExistException)
            {
                _logger.LogError($"User {cartDto.UserId} does not exist");
                return BadRequest(new ErrorDTO
                {
                    Message = "User Does Not Exist"
                });
            }
            catch (ProductDoesNotExistException)
            {
                _logger.LogError($"Product {cartDto.ProductId} does not exist");
                return BadRequest(new ErrorDTO
                {
                    Message = "Product Does Not Exist"
                });
            }
            catch(EntityNotFoundException)
            {
                _logger.LogError($"Product {cartDto.ProductId} does not exist");
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "User Not Found"
                }); 
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = "Internal Server Error"
                });
            }
        } 
        /// <summary>
        /// Get all items in the cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CartReturnDto>>> GetCartItems(int userId)
        {
            var userIdLogged = int.Parse(User.FindFirst("UserId").Value);
            if (userIdLogged != userId)
            { 
                _logger.LogWarning($"User {userIdLogged} tried to get cart items {userId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                { 
                    Message="Forbidden User"

                }); 
            }
            try
            {
                var result = await _cartService.GetAllItemsInCart(userId);
                _logger.LogInformation($"Cart items {userId} retrieved successfully");
                return Ok(result);
            }
            catch (EntityNotFoundException)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "User Not Found"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error Message: {ex.Message}") ; 
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = "Internal Server Error"
                });
            }
        }
        
        /// <summary>
        /// remove an item from the cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CartReturnDto>> RemoveItemFromCart(int userId, int productId)
        {
            var userIdLogged = int.Parse(User.FindFirst("UserId").Value);
            if (userIdLogged != userId)
            { 
                _logger.LogWarning($"User {userIdLogged} tried to remove item from cart {userId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var result = await _cartService.DeleteItemFromCart(userId, productId);
                _logger.LogInformation($"Item {productId} removed from cart {userId}");
                return Ok(result);
            }
            catch (EntityNotFoundException)
            {
                _logger.LogWarning($"Item {productId} not found in cart {userId}");
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "Product Not Found In Cart"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal Server Error Message: {ex.Message}"); 
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = "Internal Server Error"
                }); 
            }
        }
        

        /// <summary>
        /// Checkout the User cart and send orders to store
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("checkout")]  
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CheckoutReturnDto>> Checkout(CheckoutDto dto)
        {
            var userIdLogged = int.Parse(User.FindFirst("UserId").Value);
            if (userIdLogged != dto.UserId)
            {
                _logger.LogWarning($"User {userIdLogged} tried to checkout {dto.UserId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            } 
            try
            {
                var result = await _cartService.Checkout(dto);
                _logger.LogInformation($"User {dto.UserId} checked out successfully");
                return Ok(result);
            }
            catch(EntityNotFoundException)
            {
                _logger.LogError($"User {dto.UserId} not found");
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "User Not Found"
                });
            }
            catch (UserDoesNotExistException)
            { 
                _logger.LogError($"User {dto.UserId} does not exist");
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "User Does Not Exist"
                });

            }
            catch (StoreDoesNotExistException)
            {
                _logger.LogError($"Store {dto.StoreId} does not exist");
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorDTO
                {
                    Message = "Store Does Not Exist"
                });
            }
            catch (CartEmptyException)
            {
                _logger.LogError($"Cart {dto.UserId} is empty");
                return BadRequest(new ErrorDTO
                {
                    Message="Cart is empty Cannot Checkout"
                });

            }
            catch(Exception ex)
            {
                _logger.LogError($"Internal Server Error Message: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message
                }); 
            }
        }
    }
}
