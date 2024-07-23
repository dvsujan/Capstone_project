using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class SuperCategoryRepository:AbstractRepositoryClass<int , SuperCategory>
    {
        public SuperCategoryRepository(CofeeStoreManagementContext context): base(context) { }
    }
}
