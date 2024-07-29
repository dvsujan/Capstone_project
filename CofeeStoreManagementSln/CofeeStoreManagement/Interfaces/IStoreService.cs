using CofeeStoreManagement.Models.DTO.OrderDTO;
using CofeeStoreManagement.Models.DTO.StoreDTO;

namespace CofeeStoreManagement.Interfaces
{
    public interface IStoreService
    {
        public Task<IEnumerable<OrderReturnDto>> GetStoreOrders(int storeId);
        public Task<ModifyOrderReturnDTO> AcceptOrder(int orderid, int storeId);
        public Task<ModifyOrderReturnDTO> DeclineOrder(int OrderId ,int storeId);
        public Task<ModifyOrderReturnDTO> MakeOrderReady(int ordreId, int storeId); 
        public Task<IEnumerable<ReturnStoreinfoDto>> GetStoresByCity(string city); 

    }
}
