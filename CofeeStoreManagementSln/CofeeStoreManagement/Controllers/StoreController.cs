using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.OrderDTO;
using CofeeStoreManagement.Models.DTO.StoreDTO;
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
        public async Task<ActionResult<IEnumerable<OrderReturnDto>>> GetOrdersByStore(int storeId)
        {
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
        [HttpPost]
        [Route("AcceptOrder")] 
        public async Task<ActionResult> AcceptOrder(int orderId)
        {
            try
            {
                var res = await _storeService.AcceptOrder(orderId);
                return Ok(res);
            }
            catch (OrderNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
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
        public async Task<ActionResult> DeclineOrder(int orderId)
        {
            try
            {
                var res = await _storeService.DeclineOrder(orderId);
                return Ok(res);
            } 
            catch (OrderNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
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
        public async Task<ActionResult> MakeOrderReady(int orderId)
        {
            try
            {
                var res = await _storeService.MakeOrderReady(orderId);
                return Ok(res);
            }
            catch (OrderNotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
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
