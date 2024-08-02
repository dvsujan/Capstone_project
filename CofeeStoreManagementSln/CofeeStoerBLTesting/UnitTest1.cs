using CofeeStoreManagement.Contexts;
using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.UserDTOs;
using CofeeStoreManagement.Repositories;
using CofeeStoreManagement.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CofeeStoerBLTesting
{
    public class Tests
    {
        private DbContextOptionsBuilder _optionBuilder; 
        private IUserService _userService;
        private IRepository<int, User> _userRepository; 
        private IRepository<int, Cart> _cartRepositoy; 
        private ITokenService _tokenService;

        [SetUp]
        public void Setup()
        {
            _optionBuilder = new DbContextOptionsBuilder().UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=CofeeTest; TrustServerCertificate=True");
            var _context = new CofeeStoreManagementContext(_optionBuilder.Options);
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _userRepository = new UserRepository(_context);
            _cartRepositoy = new CartRepository(_context);
            _tokenService = new TokenService(configuration);
            _userService = new UserService(_userRepository , _tokenService , _cartRepositoy);
        }

        [Test]
        public async Task UserLoginTest()
        {
            var userlogin =await  _userService.Login(new UserLoginDTO
            {
                Email = "dvsujan@gmail.com",
                Password = "Sujan@2003"
            });
            Assert.That("dvsujan@gmail.com", Is.EqualTo(userlogin.Email));
        }
        [Test] 
        public async Task UserLoginFailTest()
        {
            Assert.ThrowsAsync<IncorrectPasswordException>(async () => await _userService.Login(new UserLoginDTO
            {
                Email = "dvsujan@gmail.com",
                Password = "XXXXXXXXX"
            })
            ); 
        }
        [Test]
        public async Task RegisterNewUserTest()
        {
            var newUser = await _userService.Register(new UserRegisterDto 
            {
                Name = "ramu",
                Email = "ramu@ramu.com",
                Password = "pass1234",
            });  
            Assert.That("ramu@ramu.com", Is.EqualTo(newUser.Email));
            await _userRepository.Delete(newUser.Id);
        }
        [Test]
        public async Task RegisterUserThrowsException()
        {
            Assert.ThrowsAsync<UserAlreadyExistsException>(async () => await _userService.Register(new UserRegisterDto
            {
                Name = "sujan",
                Email = "dvsujan@gmail.com",
                Password = "pass1234",
            })); 
        }

    }
}