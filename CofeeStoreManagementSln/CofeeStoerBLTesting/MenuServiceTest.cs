using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Repositories;
using CofeeStoreManagement.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CofeeStoerBLTesting
{
    public class MenuServiceTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private  IRepository<int, SuperCategory> _superCategoryRepository;
        private  IRepository<int, Category> _categoryRepository;
        private  IRepository<int, ProductCategory> _productCategoryRepository;
        private  IRepository<int, Product> _productRepository;
        private IMenuService _menuService; 

        [SetUp] 
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); 
            _superCategoryRepository = new SuperCategoryRepository(_context);
            _categoryRepository = new CategoryRepository(_context);
            _productCategoryRepository = new ProductCategoryRepository(_context);
            _productRepository = new ProductRepository(_context);
            _menuService = new MenuService(_superCategoryRepository, _categoryRepository, _productCategoryRepository, _productRepository); 
        }
        [Test] 
        public async Task GetMenuData()
        {
            var res = await _menuService.GetMenu();
            Assert.IsNotNull(res); 
        }
    }
}
