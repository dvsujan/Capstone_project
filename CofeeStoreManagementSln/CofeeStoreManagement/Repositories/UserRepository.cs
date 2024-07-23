using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class UserRepository:AbstractRepositoryClass<int, User>
    {
        public UserRepository(CofeeStoreManagementContext context) : base(context) { }  
    }
}
