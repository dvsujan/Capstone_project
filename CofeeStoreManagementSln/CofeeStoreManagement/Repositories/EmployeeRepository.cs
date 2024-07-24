using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;

namespace CofeeStoreManagement.Repositories
{
    public class EmployeeRepository:AbstractRepositoryClass<int , Employee>
    {
        public EmployeeRepository(CofeeStoreManagementContext context) : base(context)
        {

        }
    }
}
