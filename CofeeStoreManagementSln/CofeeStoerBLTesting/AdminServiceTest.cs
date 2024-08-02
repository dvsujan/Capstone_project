using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.AdminDTO;
using CofeeStoreManagement.Repositories;
using CofeeStoreManagement.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CofeeStoerBLTesting
{
    public class AdminServiceTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private IRepository<int, Product> _productRepository;
        private  IRepository<int, Category> _categoryRepository;
        private  IRepository<int, ProductCategory> _productCategoryRepository;
        private IRepository<int, Order> _orderRepository;
        private ITokenService _tokenService;  
        private IAdminService _adminService;
        
        [SetUp]  
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _productRepository = new ProductRepository(_context);   
            _categoryRepository = new CategoryRepository(_context);
            _productCategoryRepository = new ProductCategoryRepository(_context);
            _orderRepository = new OrderRepository(_context);   
             _tokenService = new TokenService(configuration);  
            _adminService = new AdminService(_productRepository, _categoryRepository, _productCategoryRepository, _tokenService, _orderRepository);
        }

        [Test] 
        public async Task AddNewProductTest()
        {
            var res = await _adminService.AddNewProduct(new AddProductDto
            {
                Name = "tstprod",
                Description = "dec",
                Calories = 10,
                Cost = 100,
                ImageUrl = "https://tst.com",
                CategoryId = 5
            });
            Assert.IsNotNull(res);
            await _productRepository.Delete(res.ProductId); 
        }

        [Test] 
        public async Task GetPrevWeekAnaliticsTest()
        {
            var res = await _adminService.GetPrevWeekAnalytics();
            Assert.IsNotNull(res);
        }
        
    }
}
