using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.CartDTO;
using CofeeStoreManagement.Models.DTO.CheckoutDTO;
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
    public class CartServiceTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private  IRepository<int, Cart> _cartRepository;
        private  IRepository<int, CartItem> _cartItemRepository;
        private  IRepository<int, Product> _productRepository;
        private  IRepository<int, User> _userRepository;
        private  IRepository<int, ProductOption> _productOptionRepository;
        private  IRepository<int, ProductOptionValue> _productOptionValueRepository;
        private  IRepository<int, Order> _orderRepository;
        private  IRepository<int, Store> _storeRepository;
        private  IRepository<int, OrderItem> _orderItemRepository;
        private ICartService _cartService; 
        [SetUp]
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _cartRepository = new CartRepository(_context);  
            _cartItemRepository = new CartItemRepository(_context);
            _productRepository = new ProductRepository(_context);
            _userRepository = new UserRepository(_context);
            _productOptionRepository = new ProductOptionRepository(_context);
            _productOptionValueRepository = new ProductOptionValueRepository(_context);
            _orderRepository = new OrderRepository(_context);
            _storeRepository = new StoreRepository(_context);
            _orderItemRepository = new OrderItemRepository(_context);
             _cartService = new CartService(_cartRepository, _cartItemRepository, _productRepository, _userRepository, _productOptionRepository, _productOptionValueRepository, _orderRepository, _storeRepository, _orderItemRepository);
        }
        
        [Test]   
        public async Task AddItemToCartTest()
        {
            var addToCart = await _cartService.AddItemToCart(new CartDto
            {
                UserId = 2,
                ProductId = 2,
                Quantity = 1,
                Options = new List<int> { }
            });
            var addToCart2 = await _cartService.AddItemToCart(new CartDto
            {
                UserId = 2,
                ProductId = 2,
                Quantity = 1,
                Options = new List<int> { }
            });
            Assert.IsNotNull(addToCart);
            await _cartService.DeleteItemFromCart(2, 2); 
        } 
        
        [Test]   
        public async Task GetItemsFromCart()
        {
            var addToCart = await _cartService.AddItemToCart(new CartDto
            {
                UserId = 2,
                ProductId = 2,
                Quantity = 1,
                Options = new List<int> {22}
            });
            var cartItems = await _cartService.GetAllItemsInCart(2); 
            Assert.IsNotNull(cartItems);
            await _cartService.DeleteItemFromCart(2, 2); 
        }
        [Test] 
        public async Task productThrowsError()
        {
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _cartService.DeleteItemFromCart(2, 2222)); 
        }
        [Test]   
        public async Task CheckoutCart()
        {
            var addToCart = await _cartService.AddItemToCart(new CartDto
            {
                UserId = 2,
                ProductId = 2,
                Quantity = 2,
                Options = new List<int> {22}
            }); 
            var checkout = await _cartService.Checkout(new CheckoutDto
            {
                UserId = 2 , 
                StoreId = 2 , 
            });
            Assert.IsNotNull(checkout); 
        }
        [Test] 
        public async Task CheckoutThrowsCartEmptyException()
        {
            Assert.ThrowsAsync<CartEmptyException> (async ()=>await _cartService.Checkout(new CheckoutDto
            {
                UserId = 2,
                StoreId = 2,
            }));
        }
    }
}
