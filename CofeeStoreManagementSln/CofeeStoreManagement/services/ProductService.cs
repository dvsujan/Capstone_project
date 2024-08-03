using CofeeStoreManagement.Exceptions;
using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.MenuDTO;
using CofeeStoreManagement.Models.DTO.ProductDTO;
using Microsoft.Identity.Client;

namespace CofeeStoreManagement.services
{
    public class ProductService:IProductService
    {
        private readonly IRepository<int, Product> _productRepository;
        private readonly IRepository<int, ProductCategory> _productCategoryRepository;
        private readonly IRepository<int, Category> _categoryRepository;
        private readonly IRepository<int, ProductOption> _productOptionRepository;
        private readonly IRepository<int, ProductOptionCategory> _productOptionCategoryRepository;
        private readonly IRepository<int, ProductOptionValue> _productOptionValueRepository;

        public ProductService(
            IRepository<int, Product> productRepository,
            IRepository<int, ProductCategory> productCategoryRepository,
            IRepository<int, Category> categoryRepository,
            IRepository<int, ProductOption> productOptionRepository,
            IRepository<int, ProductOptionCategory> productOptionCategoryRepository,
            IRepository<int, ProductOptionValue> productOptionValueRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _categoryRepository = categoryRepository;
            _productOptionRepository = productOptionRepository;
            _productOptionCategoryRepository = productOptionCategoryRepository;
            _productOptionValueRepository = productOptionValueRepository;
        }

        public async Task<ProductDataDto> ArchiveProduct(int id)
        {
            try
            { 
                var product = await _productRepository.GetOneById(id);    
                if (product.Archived == true)
                {
                    throw new ProductAlreadyArchivedException();  
                }
                product.Archived = true;
                product = await _productRepository.Update(product);
                return new ProductDataDto
                {  
                    ProductId = product.ProductId, 
                    Name = product.Name,
                    Description = product.Description , 
                    Calories = product.Calories , 
                    Cost = product.StarCost , 
                    ImageUrl = product.ImageUri
                }; 
            }
            catch
            {
                throw; 
            }
        }

        /// <summary>
        /// get all the product categories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryDataDto>> GetCategories()
        {
            try
            {  
                var categories = await _categoryRepository.Get(); 

                var categoryDataDtos = categories.Select(c => new CategoryDataDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.Name, 
                    CategoryDescription = c.Description
                });
                return categoryDataDtos;
            }
            catch
            {
                throw; 
            }
        }
        
        /// <summary>
        /// get product infor based on Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductDataDto> GetProductById(int id)
        {
            try
            {
                var product = await _productRepository.GetOneById(id);
                if (product == null)
                {
                    throw new ProductNotFoundException(); 
                }
                ProductDataDto dto = new ProductDataDto
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Cost = product.StarCost,
                    Calories= product.Calories,
                    ImageUrl = product.ImageUri
                };
                return dto; 
            }
            catch
            {
                throw; 
            }
        }
        
        /// <summary>
        /// Get the products 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ProductNotFoundException"></exception>
        public async Task<ProductWithCategoriesDto> GetProductWithCategories(int  id)
        {
            var product = await _productRepository.GetOneById(id);
            if (product == null)
            {
                throw new ProductNotFoundException(); 
            }

            var productCategories = (await _productCategoryRepository.Get())
                .Where(pc => pc.ProductId == id)
                .ToList();

            var categories = await _categoryRepository.Get();
            var productOptions = await _productOptionRepository.Get();
            var productOptionCategories = await _productOptionCategoryRepository.Get();
            var productOptionValues = await _productOptionValueRepository.Get();
            
            var categoriesWithOptions = productCategories
                .Join(categories,
                    pc => pc.CategoryId,
                    c => c.CategoryId,
                    (pc, category) => new CategoryWithOptionsDto
                    {
                        CategoryName = category.Name,
                        Options = productOptionCategories
                            .Where(poc => poc.CategoryId == category.CategoryId)
                            .Join(productOptions,
                                poc => poc.OptionId,
                                po => po.OptionId,
                                (poc, option) => new ProductOptionDto
                                {
                                    OptionId = option.OptionId,
                                    OptionName = option.Name,
                                    UnitOfMeasure = option.UnitOfMeasure,
                                    AdditionalCost = option.AdditionalCost,
                                    OptionValues = productOptionValues
                                        .Where(pov => pov.OptionId == option.OptionId)
                                        .Select(pov => new OptionValueDto
                                        {
                                            Value = pov.Value,
                                            AdditionalCost = pov.AdditionalCost , 
                                            OptionId = pov.OptionValueId,
                                        }).ToList()
                                }).ToList()
                    }).ToList();

            return new ProductWithCategoriesDto
            {
                ProductName = product.Name,
                ProductDescription = product.Description,
                Categories = categoriesWithOptions
            };

        }
    }
}
