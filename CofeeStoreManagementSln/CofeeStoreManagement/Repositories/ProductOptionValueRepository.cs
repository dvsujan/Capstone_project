using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class ProductOptionValueRepository:AbstractRepositoryClass<int , ProductOptionValue>
    {
        public ProductOptionValueRepository(CofeeStoreManagementContext context): base(context) { }

    }
}
