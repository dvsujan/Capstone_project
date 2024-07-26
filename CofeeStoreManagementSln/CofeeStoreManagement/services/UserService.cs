using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.UserDTOs;
using CofeeStoreManagement.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace CofeeStoreManagement.services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IRepository<int, Cart> _cartRepository; 
        public UserService(IRepository<int, User> userRepository, ITokenService tokenService, IRepository<int , Cart> cartRepository)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _cartRepository = cartRepository; 
        }
        
        public  async Task<LoginReturnDto> Login(UserLoginDTO dto)
        {
            try
            {
                var userDB = await ((UserRepository)_userRepository).GetUserByEmail(dto.Email);
                HMACSHA512 hMACSHA = new HMACSHA512(userDB.HashKey);
                var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
                if (isPasswordSame)
                {
                    var token = _tokenService.GenerateUserToken(userDB);
                    return new LoginReturnDto
                    {
                        Id = userDB.Id,
                        Email = userDB.Email,
                        Token = token
                    };
                }
                else
                {
                    throw new IncorrectPasswordException();
                }
            }
            catch
            {
                throw; 
            }
        }
        /// <summary>
        /// used to check if password entered is correct
        /// </summary>
        /// <param name="encrypterPass"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// checks if user exists in the database
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private async Task<bool> isUserExists(string email)
        {
            try
            {
                var user = await ((UserRepository)_userRepository).GetUserByEmail(email);
                return true;
            }
            catch (EntityNotFoundException)
            {
                return false;
            }
        }
        
        private async Task ReverseUserCreation(int id)
        {
            await _userRepository.Delete(id);
        }

        /// <summary>
        /// registers a new user to the database   
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException"></exception>
        /// <exception cref="UserAlreadyExistsException"></exception>
        public async Task<RegisterReturnDto> Register(UserRegisterDto dto)
        {
            User userReg = null;
            Cart cartReg = null;  
            try
            {
                if (await isUserExists(dto.Email))
                {
                    throw new UserAlreadyExistsException();
                }
                userReg = new User
                {
                    Email = dto.Email,
                    Name = dto.Name,
                };
                HMACSHA512 hMACSHA = new HMACSHA512();
                userReg.HashKey = hMACSHA.Key;
                userReg.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                await _userRepository.Insert(userReg);
                cartReg = new Cart
                {
                    UserId = userReg.Id
                };
                await _cartRepository.Insert(cartReg); 
                return new RegisterReturnDto
                {
                    Id = userReg.Id,
                    Email = userReg.Email,
                    UserName = userReg.Name
                }; 
            }
            catch (EntityNotFoundException)
            {
                throw new EntityNotFoundException();
            }
            catch (UserAlreadyExistsException)
            {
                throw new UserAlreadyExistsException();
            }

            catch (Exception e)
            {
                if (userReg != null)
                {
                    await ReverseUserCreation(userReg.Id);
                }
                throw;
            }
        }
    }
}
