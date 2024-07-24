using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class ProductOptionCategoryRepository:AbstractRepositoryClass<int, ProductOptionCategory>
    {
        public ProductOptionCategoryRepository(CofeeStoreManagementContext context) : base(context) { }


    }
}
