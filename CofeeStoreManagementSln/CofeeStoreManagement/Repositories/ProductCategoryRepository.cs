using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class ProductCategoryRepository:AbstractRepositoryClass<int, ProductCategory>
    {
        public ProductCategoryRepository(CofeeStoreManagementContext context) : base(context) { }
    }
}
