using CofeeStoreManagement.Models.DTO.CartDTO;
using CofeeStoreManagement.Models.DTO.CheckoutDTO;

namespace CofeeStoreManagement.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<CartItemDto>> GetAllItemsInCart(int userId);
        public Task<CartReturnDto> AddItemToCart(CartDto dto);
        public Task<CartReturnDto> DeleteItemFromCart(int userId , int productId);
        public Task<CheckoutReturnDto> Checkout(CheckoutDto dto); 
    }
}
