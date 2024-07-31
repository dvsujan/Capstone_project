using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.AdminDTO;
using CofeeStoreManagement.Repositories;
using Microsoft.Identity.Client;

namespace CofeeStoreManagement.services
{
    public class AdminService : IAdminService
    {
        private IRepository<int, Product> _productRepository;   
        private IRepository<int , Category> _categoryRepository;
        private IRepository<int, ProductCategory> _productCategoryRepository; 
        private ITokenService _tokenService;
        public AdminService(IRepository<int, Product> productRepository, IRepository<int, Category> categoryRepository, IRepository<int, ProductCategory> productCategoryRepository, ITokenService tokenService)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _tokenService = tokenService;
        }
        public async Task<bool> IsValidCategoryId(int categoryId)
        {
            try
            {  
                var category = await _categoryRepository.GetOneById(categoryId);
                return true; 
            
            }
            catch (EntityNotFoundException)
            {

                throw new CategoryDoesNotExistException(); 
            }

        }

        public async Task<AddProductReturnDto> AddNewProduct(AddProductDto addProductDto)
        {
            try
            {
                await IsValidCategoryId(addProductDto.CategoryId); 
                
                var product = new Product
                {
                    Name = addProductDto.Name,
                    Description = addProductDto.Description,
                    Calories = addProductDto.Calories,
                    StarCost = addProductDto.Cost,
                    ImageUri = addProductDto.ImageUrl, 
                    CreatedAt = DateTime.Now, 
                    UpdatedAt = DateTime.Now
                };  
                product = await _productRepository.Insert(product);
                var productCategory = new ProductCategory
                {
                    ProductId = product.ProductId,
                    CategoryId = addProductDto.CategoryId, 
                    CreatedAt = DateTime.Now, 
                    UpdatedAt = DateTime.Now
                };  
                var productCategoryReturn = await _productCategoryRepository.Insert(productCategory);
                return new AddProductReturnDto
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    CategoryId = productCategoryReturn.CategoryId
                }; 
            }
            catch
            {
                throw; 
            }
        }
        
        public async Task<AdminLoginReturnDto> LoginReturnDto(AdminLoginDto adminLoginDto)
        {
            try
            {
                var username = "admin";
                var password = "password"; 
                if (adminLoginDto.Username.Equals(username) && adminLoginDto.Password.Equals(password))
                {
                    var token = _tokenService.GenerateAdminToken(adminLoginDto.Username, adminLoginDto.Password);
                    var adminLoginReturnDto = new AdminLoginReturnDto
                    {
                        token = token
                    }; 
                    return adminLoginReturnDto;
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
    }
}
