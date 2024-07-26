using CofeeStoreManagement.Models.DTO.OrderDTO;
using CofeeStoreManagement.Models.DTO.StoreDTO;

namespace CofeeStoreManagement.Interfaces
{
    public interface IStoreService
    {
        public Task<IEnumerable<OrderReturnDto>> GetStoreOrders(string storeId);
        public Task<AcceptOrderReturnDTO> AcceptOrder(int orderid);
        public Task<DeclineOrderReturnDto> DeclineOrder(int OrderId);
        public Task<ReadyOrderReturnDto> MakeOrderReady(int ordreId); 
        public Task<ReturnStoreinfoDto> GetStoresByCity(string city); 

    }
}
