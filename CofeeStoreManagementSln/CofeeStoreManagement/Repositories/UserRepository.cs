using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CofeeStoreManagement.Repositories
{
    public class UserRepository:AbstractRepositoryClass<int, User>
    {
        public UserRepository(CofeeStoreManagementContext context) : base(context) { }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
            return user == null ? throw new EntityNotFoundException() : user;
        }

    }
}
