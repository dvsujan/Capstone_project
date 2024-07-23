using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class StoreRepository:AbstractRepositoryClass<int, Store>
    {
        public StoreRepository(CofeeStoreManagementContext context) : base(context) { }
    }
}
