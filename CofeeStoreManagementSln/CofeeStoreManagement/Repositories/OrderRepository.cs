using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class OrderRepository:AbstractRepositoryClass<int , Order>
    {
        public OrderRepository(CofeeStoreManagementContext context) : base(context) { }
    }
}
