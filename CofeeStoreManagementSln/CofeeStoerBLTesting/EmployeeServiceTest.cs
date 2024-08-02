using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.EmployeeDto;
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
    public class EmployeeServiceTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private IRepository<int, Employee> _employeeRepository;
        private  ITokenService _tokenService;
        private IEmployeeService _employeeService; 

        [SetUp]
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _employeeRepository = new EmployeeRepository(_context);
            _tokenService = new TokenService(configuration); 
            _employeeService = new EmployeeService(_employeeRepository, _tokenService);
        }
         
        [Test]  
        public async Task LoginEmployeeTest()
        {
            var res = await _employeeService.Login(new EmployeeLoginDto
            {
                Email = "dvsujan@gmail.com",
                Password = "Sujan@2003"
            });
            Assert.IsNotNull(res);
        } 
        [Test]
        public async Task RegisterEmployeeTest()
        {
            var res = await _employeeService.Register(new EmployeeRegisterDto
            {
                Name = "Sujan",
                Email = "test@test.com",
                Password = "p@p.com", 
                StoreId=2
            }); 
            Assert.IsNotNull(res);
            await _employeeRepository.Delete(res.EmployeeId); 
        }
        [Test]
        public async Task EmployeeAlreadyExistThrow()
        {
            Assert.ThrowsAsync<UserAlreadyExistsException>(async()=>await _employeeService.Register(new EmployeeRegisterDto
            {
                Name = "Sujan",
                Email = "dvsujan@gmail.com",
                Password = "p@p.com",
                StoreId = 2
            })); 
        }
    }
}
