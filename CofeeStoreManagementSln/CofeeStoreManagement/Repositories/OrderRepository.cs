using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CofeeStoreManagement.Repositories
{
    public class OrderRepository:AbstractRepositoryClass<int , Order>
    {
        public OrderRepository(CofeeStoreManagementContext context) : base(context) { }
        public async Task<IEnumerable<Order>> GetAllValidOrdersByStore(int storeId)
        {
            try
            { 
                var orders = await _dbSet.Where(o => o.StoreId == storeId&& (o.Status=="Pending"||o.Status=="Accepted")).ToListAsync();
                return orders; 
            }
            catch
            {
                throw;
            }
        } 
        public async Task<IEnumerable<Order>> GetAllValidOrdersByUser(int userId, int storeId)
        {
            try
            {  
                var orders = await _dbSet.Where(o => o.UserId == userId && (o.CreatedAt.Date == DateTime.Now.Date)&& o.StoreId == storeId).ToListAsync();
                return orders;  
            }
            catch
            {
                throw; 
            }
        }
    }
}
