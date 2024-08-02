using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Repositories;
using Microsoft.EntityFrameworkCore;


namespace CofeeStoreManagementRepositoryTest
{
    public class Tests
    {
        private DbContextOptionsBuilder _optionBuilder;
        private IRepository<int, User> _userRepository; 
        [SetUp]
        public async Task Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True"); 
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options); 
            _userRepository = new UserRepository(_context); 
        }

        [Test]
        public async Task UserGetByIdTest()
        {
            var user = await _userRepository.GetOneById(2); 
            Assert.IsNotNull(user);
        }
        [Test] 
        public async Task UserGetAllTest()
        {
            var users = await  _userRepository.Get();
            Assert.IsNotNull(users);
        } 
        [Test]
        public async Task GetUserByEmailTest()
        {
            var user =await ((UserRepository)_userRepository).GetUserByEmail("dvsujan@gmail.com"); 
            Assert.IsNotNull(user);
        }
        
        [Test]
        public async Task GetUserByEmailThrowsEntityNotFoundExcpeption()
        {
            Assert.ThrowsAsync<EntityNotFoundException>(() => ((UserRepository)_userRepository).GetUserByEmail("")); 
        }
        [Test]
        public async Task GetUserByIdThrowEntityNotFoundException()
        {
            Assert.ThrowsAsync<EntityNotFoundException>(() => _userRepository.GetOneById(0));
        }

        [Test]
        public async Task InsertUserToDatabase()
        { 
            var user = await _userRepository.Insert(new User { Name = "Test", Email = "test@test.com", Password = new byte[] { 0x20, 0x20, 0x20, 0x20 }, HashKey = new byte[] { 0x20, 0x20, 0x20, 0x20 } });
            Assert.IsNotNull(user);
            await _userRepository.Delete(user.Id);
        } 
        [Test]
        public async Task DeleteUserFromDatabase()
        { 
            var inserteduser = await _userRepository.Insert(new User { Name = "Test", Email = "test@test.com", Password = new byte[] { 0x20, 0x20, 0x20, 0x20 }, HashKey = new byte[] { 0x20, 0x20, 0x20, 0x20 } }); 
            var deluser = _userRepository.Delete(inserteduser.Id); 
            Assert.IsNotNull(deluser);
        }
        
        [Test]
        public async Task EditUserFromDb()
        {
            var inuser = await _userRepository.Insert(new User { Name = "Test2", Email = "test@a.com", Password = new byte[] { 0x20, 0x20, 0x20, 0x20 }, HashKey = new byte[] { 0x20, 0x20, 0x20, 0x20 } });
            inuser.Name = "lol"; 
            var eduser = await _userRepository.Update(inuser);
            Assert.IsNotNull(eduser);
            await _userRepository.Delete(eduser.Id);
        }
    }
}