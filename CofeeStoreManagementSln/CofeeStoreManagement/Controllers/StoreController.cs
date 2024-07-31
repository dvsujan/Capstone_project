using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.OrderDTO;
using CofeeStoreManagement.Models.DTO.StoreDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    { 
        private readonly IStoreService _storeService; 
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnStoreinfoDto>>> GetStoresByCity(string city)
        {
            try
            {
                var res = await _storeService.GetStoresByCity(city);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        } 
        
        [HttpGet]
        [Route("orders")]
        [Authorize(Roles ="Employee")]
        public async Task<ActionResult<IEnumerable<OrderReturnDto>>> GetOrdersByStore(int storeId)
        { 
            int EmpLoggedStoreId = int.Parse(User.FindFirst("StoreId").Value);   
            if (EmpLoggedStoreId != storeId)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                }); 
            }
            
            try
            {  
                var res = await _storeService.GetStoreOrders(storeId); 
                return Ok(res);
            }
            catch (Exception ex)
            {  
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        [Route("userorders")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderReturnDto>>> GetOrdersByUser(int userId , int storeId)
        {
            int userLoggedin = int.Parse(User.FindFirst("UserId").Value);
            if (userLoggedin != userId)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var res = await _storeService.GetUserOrders(userId , storeId );
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
        
        [HttpPost]
        [Route("AcceptOrder")] 
        [Authorize(Roles ="Employee")]
        public async Task<ActionResult> AcceptOrder(int orderId, int storeId)
        {
            int EmpLoggedStoreId = int.Parse(User.FindFirst("StoreId").Value);
            if (EmpLoggedStoreId != storeId)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var res = await _storeService.AcceptOrder(orderId, storeId);
                return Ok(res);
            }
            catch (OrderNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
                });
            }
            catch (ForbiddenStoreException)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden Store",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }  
        
        [HttpPost]
        [Route("DeclineOrder")] 
        [Authorize(Roles ="Employee")]
        public async Task<ActionResult> DeclineOrder(int orderId, int storeId)
        {
            int EmpLoggedStoreId = int.Parse(User.FindFirst("StoreId").Value);   
            if (EmpLoggedStoreId != storeId)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var res = await _storeService.DeclineOrder(orderId, storeId);
                return Ok(res);
            } 
            catch (OrderNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
                });
            }catch (ForbiddenStoreException)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden Store",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
        
        [HttpPost]
        [Route("ReadyOrder")] 
        [Authorize(Roles ="Employee")]
        public async Task<ActionResult> MakeOrderReady(int orderId, int storeId)
        { 
            int EmpLoggedStoreId = int.Parse(User.FindFirst("StoreId").Value);    
            if (EmpLoggedStoreId != storeId)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var res = await _storeService.MakeOrderReady(orderId, storeId);
                return Ok(res);
            }   
            catch (OrderNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
                });
            }catch (ForbiddenStoreException)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden Store",
                });
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
