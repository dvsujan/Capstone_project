using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Repositories;
using CofeeStoreManagement.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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
    public class ProductServiceTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private IRepository<int, Product> _productRepository;
        private  IRepository<int, ProductCategory> _productCategoryRepository;
        private  IRepository<int, Category> _categoryRepository;
        private  IRepository<int, ProductOption> _productOptionRepository;
        private  IRepository<int, ProductOptionCategory> _productOptionCategoryRepository;
        private  IRepository<int, ProductOptionValue> _productOptionValueRepository;
        private IProductService _productService;

        [SetUp]
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _productRepository = new ProductRepository(_context);  
            _productCategoryRepository = new ProductCategoryRepository(_context);
            _categoryRepository = new CategoryRepository(_context);
            _productOptionRepository = new ProductOptionRepository(_context);
            _productOptionCategoryRepository = new ProductOptionCategoryRepository(_context);
            _productOptionValueRepository = new ProductOptionValueRepository(_context);
            _productService = new ProductService(_productRepository, _productCategoryRepository, _categoryRepository, _productOptionRepository, _productOptionCategoryRepository, _productOptionValueRepository);
        }

        [Test]  
        public async Task GetCategoriesTest()
        {
            var categories =await  _productService.GetCategories();
            Assert.IsNotNull(categories); 
        }

        [Test] 
        public async Task GetProductByIdTest()
        {
            var res = await _productService.GetProductById(2);
            Assert.IsNotNull(res); 
        }
        [Test] 
        public async Task GetProductByIdThrowsTest()
        {
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _productService.GetProductById(2200)); 
        }
        [Test] 
        public async Task GetProdcutWithCategoriesTest() {
            var res = await _productService.GetProductWithCategories(2);
            Assert.IsNotNull(res); 
        } 
         [Test] 
        public async Task GetProductCategorsThrosTest()
        {
            Assert.ThrowsAsync<EntityNotFoundException>(async () => await _productService.GetProductWithCategories(2200)); 
        }
    }
}
