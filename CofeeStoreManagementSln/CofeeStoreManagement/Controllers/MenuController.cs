using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models.DTO;
using CofeeStoreManagement.Models.DTO.MenuDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace CofeeStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService; 
        private readonly ILogger<MenuController> _logger;

        public MenuController (IMenuService menuService,ILogger<MenuController>logger)
        {
            _menuService = menuService;
            _logger = logger; 
        } 
        /// <summary>
        /// get all items in the menu with their respective categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MenuDto>> Menu()
        {
            try
            {
                var res = await _menuService.GetMenu();
                _logger.LogInformation("Menu was retrieved successfully");
                return Ok(res); 

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured while retrieving menu");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO
                {
                    Message = ex.Message,
                });
            }
        }
    }
}
