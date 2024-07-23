using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class CartRepository:AbstractRepositoryClass<int , Cart>
    {
        public CartRepository(CofeeStoreManagementContext context) : base(context)
        {
        }

    }
}
