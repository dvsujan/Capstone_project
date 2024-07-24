using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CofeeStoreManagement.Repositories
{
    public class StoreRepository:AbstractRepositoryClass<int, Store>
    {
        public StoreRepository(CofeeStoreManagementContext context) : base(context) { }
        public async Task<IEnumerable<Store>> GetAllStoresOfCity(string city)
        {
            var stores = await _dbSet.Where(stores => stores.City == city).ToListAsync(); 
            return stores; 
        }
    }
}
