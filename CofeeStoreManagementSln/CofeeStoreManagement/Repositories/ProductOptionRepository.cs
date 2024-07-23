using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class ProductOptionRepository:AbstractRepositoryClass<int , ProductOption>
    {
            public ProductOptionRepository(CofeeStoreManagementContext context) : base(context)
            {
            }
    }
}
