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
    public class OrderRepositoryTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private IRepository<int, Order> _orderRepository;

        [SetUp]
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options); 
            _orderRepository = new OrderRepository(_context);
        }
        [Test] 
        public async Task GetAllordersbystore()
        {
            var orders = await ((OrderRepository)_orderRepository).GetAllValidOrdersByStore(2);
            Assert.IsNotNull(orders);
        }
        [Test] 
        public async Task GetAllordersbyUser()
        {
            var orders = await ((OrderRepository)_orderRepository).GetAllValidOrdersByUser(2,2);
            Assert.IsNotNull(orders);
        }
    }
}
