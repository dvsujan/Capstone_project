using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class ProductOptionCategoryRepository:AbstractRepositoryClass<int, ProductOption>
    {
        public ProductOptionCategoryRepository(CofeeStoreManagementContext context) : base(context) { }


    }
}
