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
    public class EmployeeRepositoryTest
    {
        private DbContextOptionsBuilder _optionBuilder;
        private IRepository<int, Employee> _employeeRepository;

        [SetUp]
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
             _employeeRepository = new EmployeeRepository(_context);
        } 
        [Test]
        public async Task GetEmployeeByEmployeeTest()
        {
            var employee = await ((EmployeeRepository)_employeeRepository).GetEmployeeByEmail("dvsujan@gmail.com");
            Assert.IsNotNull(employee);
        }

    }
}
