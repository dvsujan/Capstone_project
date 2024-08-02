using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Repositories;
using CofeeStoreManagement.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeStoerBLTesting
{
    public class StoreServiceTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private  IRepository<int, Store> _storeRepository;
        private  IRepository<int, Product> _productRepository;
        private  IRepository<int, ProductOptionValue> _productOptionValueRepository;
        private  IRepository<int, ProductOption> _productOptionRepository;
        private  IRepository<int, OrderItem> _orderItemRepository;
        private IRepository<int, User> _userRepository;
        private  IRepository<int, Order> _orderRepository;
        private IStoreService _storeService;
        [SetUp] 
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _storeRepository = new StoreRepository(_context); 
            _productRepository = new ProductRepository(_context);
            _productOptionValueRepository = new ProductOptionValueRepository(_context);
            _productOptionRepository = new ProductOptionRepository(_context);
            _orderItemRepository = new OrderItemRepository(_context);
            _userRepository = new UserRepository(_context);
            _orderRepository = new OrderRepository(_context);
            _storeService = new StoreService(_storeRepository, _productRepository, _productOptionValueRepository, _productOptionRepository, _orderItemRepository, _userRepository, _orderRepository);
        } 

        [Test] 
        public async Task GetStoreOrdersTest()
        {
            var result = _storeService.GetStoreOrders(2);
            Assert.IsNotNull(result);
        }
        
        [Test] 
        public async Task GetUserOrdersTest()
        {
            var result = _storeService.GetUserOrders(2,2);
            Assert.IsNotNull(result);
        }

        [Test] 
        public async Task GetStoresByCityTest()
        { 
            var result = _storeService.GetStoresByCity("Hyderabad");  
            Assert.IsNotNull(result);
        }

        [Test] 
        public async Task GetAllStoresTest()
        { 
            var result = _storeService.GetAllStores();  
            Assert.IsNotNull(result);
        }
        [Test]
        public async Task AcceptOrder()
        {
            var order = await _orderRepository.Insert(new Order
            { 
                UserId=2 , 
                StoreId=2 , 
                TotalAmount=100 , 
                Status="Pending" , 
                CreatedAt = DateTime.Now, 
                UpdatedAt = DateTime.Now, 
            });
            var res = await _storeService.AcceptOrder(order.OrderId, 2);
            Assert.IsNotNull(res);  
            await _orderRepository.Delete(order.OrderId);
        }
        
        [Test]
        public async Task DeclineOrderTest()
        {
            var order = await _orderRepository.Insert(new Order
            { 
                UserId=2 , 
                StoreId=2 , 
                TotalAmount=100 , 
                Status="Pending" , 
                CreatedAt = DateTime.Now, 
                UpdatedAt = DateTime.Now, 
            });
            var res =  await _storeService.DeclineOrder(order.OrderId, 2);
            Assert.IsNotNull(res);  
            await _orderRepository.Delete(order.OrderId);
        }
        [Test] 
        public async Task AcceptOrderThrowsError() {
            var order = await _orderRepository.Insert(new Order
            {
                UserId = 2,
                StoreId = 2,
                TotalAmount = 100,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }); 
            Assert.ThrowsAsync<OrderNotFoundException> (async ()=> await _storeService.AcceptOrder(order.OrderId, 5));
            await _orderRepository.Delete(order.OrderId);
        }
        [Test] 
        public async Task DeclineOrderThrowsError() {
            var order = await _orderRepository.Insert(new Order
            {
                UserId = 2,
                StoreId = 2,
                TotalAmount = 100,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }); 
            Assert.ThrowsAsync<OrderNotFoundException> (async ()=> await _storeService.DeclineOrder(order.OrderId, 5));
            await _orderRepository.Delete(order.OrderId);
        }

        [Test]
        public async Task MakeOrderReadyTest()
        {
            var order = await _orderRepository.Insert(new Order
            {
                UserId = 2,
                StoreId = 2,
                TotalAmount = 100,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });
            var accept = await _storeService.AcceptOrder(order.OrderId, 2);
            var res = await _storeService.MakeOrderReady(order.OrderId, 2);
            Assert.IsNotNull(res);
            await _orderRepository.Delete(order.OrderId);
        }
        
        [Test]
        public async Task MakeOrderReadythrowsTest()
        {
            var order = await _orderRepository.Insert(new Order
            {
                UserId = 2,
                StoreId = 2,
                TotalAmount = 100,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });
            Assert.ThrowsAsync<InvalidOrderStatusException>( async()=>await _storeService.MakeOrderReady(order.OrderId, 2));
            await _orderRepository.Delete(order.OrderId);
        }
    }
}
