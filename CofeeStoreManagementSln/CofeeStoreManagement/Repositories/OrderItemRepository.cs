using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class OrderItemRepository:AbstractRepositoryClass<int, OrderItem>
    {
        public OrderItemRepository(CofeeStoreManagementContext context) : base(context) {  }
    }
}
