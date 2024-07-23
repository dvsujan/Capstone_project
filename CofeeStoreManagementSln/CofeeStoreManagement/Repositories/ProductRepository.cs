using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Models;
using Microsoft.Identity.Client;

namespace CofeeStoreManagement.Repositories
{
    public class ProductRepository:AbstractRepositoryClass<int , Product>
    {
        public ProductRepository(CofeeStoreManagementContext context) : base(context) { }
        
    }
}
