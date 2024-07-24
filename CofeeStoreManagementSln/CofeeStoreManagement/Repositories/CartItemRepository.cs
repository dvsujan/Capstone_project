using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class CartItemRepository:AbstractRepositoryClass<int , CartItem>
    {
        public CartItemRepository(CofeeStoreManagementContext context):base(context) { }
    }
}
