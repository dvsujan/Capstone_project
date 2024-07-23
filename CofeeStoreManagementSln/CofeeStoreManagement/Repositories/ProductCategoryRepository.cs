using CofeeStoreManagement.Contexts;

namespace CofeeStoreManagement.Repositories
{
    public class ProductCategoryRepository:AbstractRepositoryClass<int, ProductRepository>
    {
        public ProductCategoryRepository(CofeeStoreManagementContext context) : base(context) { }
    }
}
