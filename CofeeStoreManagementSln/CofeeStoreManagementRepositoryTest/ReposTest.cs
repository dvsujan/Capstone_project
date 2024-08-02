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
    internal class ReposTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private IRepository<int, SuperCategory> _superCategoryRepository; 
        private IRepository<int, Product> _productRepository; 
        private IRepository<int, ProductOptionValue> _productOptionValueRepository; 
        private IRepository<int, ProductOption> _productOptionRepository;  
        private IRepository<int, ProductOptionCategory> _productOptionCategoryRepository;   
        private IRepository<int , ProductCategory> _productCategoryRepository;
        private IRepository<int , OrderItem> _orderItemRepository; 
        private IRepository<int , Category> _categoryRepository;
        private IRepository<int, Cart> _cartRepository;
        private IRepository<int, CartItem> _cartItemRepository;

        [SetUp]
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True"); 
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options); 
            _superCategoryRepository = new SuperCategoryRepository(_context);
            _productRepository = new ProductRepository(_context);
            _productOptionValueRepository = new ProductOptionValueRepository(_context);
            _productOptionRepository = new ProductOptionRepository(_context);
            _productOptionCategoryRepository = new ProductOptionCategoryRepository(_context);
            _productCategoryRepository = new ProductCategoryRepository(_context);
            _orderItemRepository = new OrderItemRepository(_context);   
            _categoryRepository = new CategoryRepository(_context);
            _cartRepository = new CartRepository(_context);
            _cartItemRepository = new CartItemRepository(_context);
        }
        [Test]
        public void initRepos()
        {
            Assert.Pass(); 
        }

    }
}
