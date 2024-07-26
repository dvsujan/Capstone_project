using CofeeStoreManagement.Models.DTO.OrderDTO;
using CofeeStoreManagement.Models.DTO.StoreDTO;

namespace CofeeStoreManagement.Interfaces
{
    public interface IStoreService
    {
        public Task<IEnumerable<OrderReturnDto>> GetStoreOrders(int storeId);
        public Task<ModifyOrderReturnDTO> AcceptOrder(int orderid);
        public Task<ModifyOrderReturnDTO> DeclineOrder(int OrderId);
        public Task<ModifyOrderReturnDTO> MakeOrderReady(int ordreId); 
        public Task<IEnumerable<ReturnStoreinfoDto>> GetStoresByCity(string city); 

    }
}
