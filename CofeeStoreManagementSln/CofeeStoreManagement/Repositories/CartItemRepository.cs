using CofeeStoreManagement.Contexts;

namespace CofeeStoreManagement.Repositories
{
    public class CartItemRepository:AbstractRepositoryClass<int , CartItemRepository>
    {
        public CartItemRepository(CofeeStoreManagementContext context):base(context) { }
    }
}
