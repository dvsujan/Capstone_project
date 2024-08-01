using Azure.Storage.Blobs;
using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.AdminDTO;
using CofeeStoreManagement.Repositories;
using Microsoft.Identity.Client;
using System.IO;

namespace CofeeStoreManagement.services
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<int, Product> _productRepository;   
        private readonly IRepository<int , Category> _categoryRepository;
        private readonly IRepository<int, ProductCategory> _productCategoryRepository; 
        private readonly IRepository<int , Order> _orderRepository;
        private readonly ITokenService _tokenService;
        private readonly IKeyVaultService _keyVaultService;
        
        public AdminService(IRepository<int, Product> productRepository, IRepository<int, Category> categoryRepository, IRepository<int, ProductCategory> productCategoryRepository, ITokenService tokenService, IConfiguration configuration, IKeyVaultService keyVaultService, IRepository<int, Order> orderRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _tokenService = tokenService;
            _keyVaultService = keyVaultService;
            _orderRepository = orderRepository; 
        }

        /// <summary>
        /// checks if the category is valid based on the categoryId
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        /// <exception cref="CategoryDoesNotExistException"></exception>
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
        
        /// <summary>
        /// add new product to the datbase
        /// </summary>
        /// <param name="addProductDto"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// logins the admin based on the username and password from the valut
        /// </summary>
        /// <param name="adminLoginDto"></param>
        /// <returns></returns>
        public async Task<AdminLoginReturnDto> Login(AdminLoginDto adminLoginDto)
        {
            try
            {
                var username = await _keyVaultService.GetSecretAsync("username");
                var password = await _keyVaultService.GetSecretAsync("password");
                if (adminLoginDto.Username.Equals(username) && adminLoginDto.Password.Equals(password))
                {
                    var token = await _tokenService.GenerateAdminToken(adminLoginDto.Username, adminLoginDto.Password);
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
        
        /// <summary>
        /// upload file to blob and returns the url of that blob
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> GetUploadedFileUrl(Stream fileStream, string fileName)
        {
            var blobConnectionString = await _keyVaultService.GetSecretAsync("BlobUrl"); 
            var blobServiceClient = new BlobServiceClient(blobConnectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient("productimages");
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileStream, true);
            return blobClient.Uri.ToString();
        }
        
        /// <summary>
        /// get the previewous week analytics
        /// </summary>
        /// <returns></returns>
        public async Task<AnalyticsReturnDto> GetPrevWeekAnalytics()
        {
            try
            {
                var orders = await _orderRepository.Get();
                var startDate = DateTime.Now.AddDays(-7).Date;
                var endDate = DateTime.Now.Date;
                var ordersInPrevWeek = orders.Where(order => order.CreatedAt >= startDate && order.CreatedAt <= endDate).ToList();
                var groupedOrders = ordersInPrevWeek
                .GroupBy(order => order.CreatedAt.Date)
                .Select(group => group.Count())
                .ToList();
                var orderCounts = new Dictionary<DateTime, int>();
                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    orderCounts[date] = 0;
                }

                foreach (var order in ordersInPrevWeek)
                {
                    var orderDate = order.CreatedAt.Date;
                    if (orderCounts.ContainsKey(orderDate))
                    {
                        orderCounts[orderDate]++;
                    }
                }

                var analyticsReturnDto = new AnalyticsReturnDto
                {
                    Orders = orderCounts.Values.ToList()
                };

                return analyticsReturnDto;

            }
            catch {
                throw; 
            }
        }
    }
}
