using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeStoreManagementRepositoryTest
{
    public class StoreRepoTEst
    {
         private DbContextOptionsBuilder _optionBuilder;
        private IRepository<int, Store> _storeRepository;
        [SetUp]
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
            _storeRepository = new StoreRepository(_context);
        }
        [Test]
        public async Task GetAllStoresOfCityTest()
        {
            var stores = await ((StoreRepository)_storeRepository).GetAllStoresOfCity("Hyderabad"); 
            Assert.IsNotNull(stores);
        } 
    }
}
