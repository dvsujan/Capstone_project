using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CofeeStoreManagement.Repositories
{
    public class EmployeeRepository:AbstractRepositoryClass<int , Employee>
    {
        public EmployeeRepository(CofeeStoreManagementContext context) : base(context)
        { 

        } 
        public async Task<Employee> GetEmployeeByEmail(string email)
        {
                var emp = await _context.Employees.Where(x => x.Email == email).FirstOrDefaultAsync(); 
                return emp;
        }
    }
}
