using CofeeStoreManagement.Contexts;

namespace CofeeStoreManagement.Repositories
{
    public class EmployeeRepository:AbstractRepositoryClass<int , EmployeeRepository>
    {
        public EmployeeRepository(CofeeStoreManagementContext context) : base(context)
        {

        }
    }
}
