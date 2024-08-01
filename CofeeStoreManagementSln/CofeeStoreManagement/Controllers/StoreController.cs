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
        private readonly ILogger<StoreController> _logger;  
        public StoreController(IStoreService storeService, ILogger<StoreController> logger)
        {
            _storeService = storeService;
            _logger = logger;
        }


        /// <summary>
        /// used to get the stores of the specific city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("city")]
        public async Task<ActionResult<IEnumerable<ReturnStoreinfoDto>>> GetStoresByCity(string city)
        {
            try
            {
                var res = await _storeService.GetStoresByCity(city);
                _logger.LogInformation("GetStoresByCity called");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message); 
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
        
        /// <summary>
        /// Get all the store that are avalable
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ReturnStoreinfoDto>>> GetAllStores()
        {
            try
            {
                var res = await _storeService.GetAllStores();
                _logger.LogInformation("GetAllStores called");
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
       
        /// <summary>
        /// Get orders by store
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("orders")]
        [Authorize(Roles ="Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderReturnDto>>> GetOrdersByStore(int storeId)
        { 
            int EmpLoggedStoreId = int.Parse(User.FindFirst("StoreId").Value);   
            if (EmpLoggedStoreId != storeId)
            {
                _logger.LogError($"Forbidden User {EmpLoggedStoreId} for store {storeId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                }); 
            }
            try
            {  
                var res = await _storeService.GetStoreOrders(storeId); 
                _logger.LogInformation("GetStoreOrders called");
                return Ok(res);
            }
            catch (Exception ex)
            {  
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
        
        /// <summary>
        /// get orders that are orderd by user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("userorders")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderReturnDto>>> GetOrdersByUser(int userId , int storeId)
        {
            int userLoggedin = int.Parse(User.FindFirst("UserId").Value);
            if (userLoggedin != userId)
            {
                _logger.LogError($"Forbidden User {userLoggedin} for user {userId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var res = await _storeService.GetUserOrders(userId , storeId );
                _logger.LogInformation("GetUserOrders called"); 
                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
        
        /// <summary>
        /// Accept the order to the store
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AcceptOrder")] 
        [Authorize(Roles ="Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AcceptOrder(int orderId, int storeId)
        {
            int EmpLoggedStoreId = int.Parse(User.FindFirst("StoreId").Value);
            if (EmpLoggedStoreId != storeId)
            {
                _logger.LogError($"Forbidden User {EmpLoggedStoreId} for store {storeId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var res = await _storeService.AcceptOrder(orderId, storeId);
                _logger.LogInformation("AcceptOrder called");
                return Ok(res);
            }
            catch (OrderNotFoundException)
            {
                _logger.LogError("Store Does Not Exist");
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
                });
            }
            catch (ForbiddenStoreException)
            { 
                _logger.LogError("Forbidden Store");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden Store",
                });
            }
            catch (Exception ex)
            {_logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }  
        
        
        /// <summary>
        /// Decline the Order to the store
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DeclineOrder")] 
        [Authorize(Roles ="Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> DeclineOrder(int orderId, int storeId)
        {
            int EmpLoggedStoreId = int.Parse(User.FindFirst("StoreId").Value);   
            if (EmpLoggedStoreId != storeId)
            {

                _logger.LogError($"Forbidden User {EmpLoggedStoreId} for store {storeId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var res = await _storeService.DeclineOrder(orderId, storeId);
                _logger.LogInformation("DeclineOrder called");
                return Ok(res);
            } 
            catch (OrderNotFoundException)
            {
                _logger.LogError($"Store Does Not Exist storeId: {storeId} orderId: {orderId}");
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
                });
            }catch (ForbiddenStoreException)
            {
                _logger.LogError($"Forbidden Store storeId: {storeId} orderId: {orderId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden Store",
                });
            }
            catch (Exception ex)
            {_logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
        
        /// <summary>
        /// route to make the order ready
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ReadyOrder")] 
        [Authorize(Roles ="Employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> MakeOrderReady(int orderId, int storeId)
        { 
            int EmpLoggedStoreId = int.Parse(User.FindFirst("StoreId").Value);    
            if (EmpLoggedStoreId != storeId)
            {
                _logger.LogError($"Forbidden User {EmpLoggedStoreId} for store {storeId}");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden User"
                });
            }
            try
            {
                var res = await _storeService.MakeOrderReady(orderId, storeId);
                _logger.LogInformation("MakeOrderReady called");
                return Ok(res);
            }   
            catch (OrderNotFoundException)
            {
                _logger.LogError("Store Does Not Exist");
                return StatusCode(StatusCodes.Status404NotFound, new ErrorDTO
                {
                    Message = "Store Does Not Exist",
                });
            }catch (ForbiddenStoreException)
            {
                _logger.LogError("Forbidden Store");
                return StatusCode(StatusCodes.Status403Forbidden, new ErrorDTO
                {
                    Message = "Forbidden Store",
                });
            }
            catch (Exception ex)
            {_logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
    }
}
