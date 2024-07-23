using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class CategoryRepository:AbstractRepositoryClass<int , Category>
    {
        public CategoryRepository(CofeeStoreManagementContext context) : base(context)
        {
        }
    }
}
