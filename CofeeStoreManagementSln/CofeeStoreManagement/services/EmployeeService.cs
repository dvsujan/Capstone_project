using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.EmployeeDto;
using CofeeStoreManagement.Models.DTO.UserDTOs;
using CofeeStoreManagement.Repositories;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace CofeeStoreManagement.services
{ 
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly ITokenService _tokenService; 
        public EmployeeService(IRepository<int, Employee> employeeRepository, ITokenService tokenService)
        {
            _employeeRepository = employeeRepository;
            _tokenService = tokenService;
        }
        
        /// <summary>
        /// generate employee token from username and password
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<EmployeeLoginReturnDto> Login(EmployeeLoginDto dto)
        {
            try
            {
                var Emp = await((EmployeeRepository)_employeeRepository).GetEmployeeByEmail(dto.Email);
                HMACSHA512 hMACSHA = new HMACSHA512(Emp.HashKey);
                var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                bool isPasswordSame = ComparePassword(encrypterPass, Emp.Password);
                if (isPasswordSame)
                {
                    var token = _tokenService.GenerateEmployeeToken(Emp);
                    return new EmployeeLoginReturnDto 
                    { 
                        EmployeeId = Emp.EmployeeId,
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
        /// checks if employee already exists searches by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> isEmployeeExist(string email)
        {
            var employee = await ((EmployeeRepository)_employeeRepository).GetEmployeeByEmail(email);
            if (employee == null)
            {
                return false; 
            }
            return true;  
        }
        
        /// <summary>
        /// register new employee by admin 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<EmployeeRegisterReturnDto> Register(EmployeeRegisterDto dto)
        {
            Employee empReg = null; 
            try
            {
                if (await isEmployeeExist (dto.Email))
                {
                    throw new UserAlreadyExistsException();
                }
                empReg = new Employee 
                { 
                    Email = dto.Email,
                    Name= dto.Name,
                    StoreId = dto.StoreId, 
                };
                HMACSHA512 hMACSHA = new HMACSHA512();
                empReg.HashKey = hMACSHA.Key;
                empReg.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
                await _employeeRepository.Insert(empReg);
                return new EmployeeRegisterReturnDto
                {
                    EmployeeId = empReg.EmployeeId,
                    Email = empReg.Email,
                    Name = empReg.Name,
                };
            }
            catch
            {
                throw; 
            }
           
        }

        /// <summary>
        /// reverses the employee created object if any error occurs
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        async Task ReverseEmployeeCreation(int employeeId)
        {
            await _employeeRepository.Delete(employeeId);
        }
    }
}

