using CofeeStoreManagement.Models.DTO.MenuDTO;

namespace CofeeStoreManagement.Interfaces
{
    public interface IMenuService
    {
        public Task<MenuDto> GetMenu(); 
    }
}
