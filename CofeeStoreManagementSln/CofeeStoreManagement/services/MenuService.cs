using CofeeStoreManagement.Interfaces;
using CofeeStoreManagement.Models;
using CofeeStoreManagement.Models.DTO.MenuDTO;

namespace CofeeStoreManagement.services
{
    public class MenuService : IMenuService
    {
        private readonly IRepository<int, SuperCategory> _superCategoryRepository;
        private readonly IRepository<int, Category> _categoryRepository;
        private readonly IRepository<int, ProductCategory> _productCategoryRepository;
        private readonly IRepository<int, Product> _productRepository;

        public MenuService(
            IRepository<int, SuperCategory> superCategoryRepository,
            IRepository<int, Category> categoryRepository,
            IRepository<int, ProductCategory> productCategoryRepository,
            IRepository<int, Product> productRepository)
        {
            _superCategoryRepository = superCategoryRepository;
            _categoryRepository = categoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
        }

        public async Task<MenuDto> GetMenu()
        {
            var superCategories = await _superCategoryRepository.Get();
            var categories = await _categoryRepository.Get();
            var productCategories = await _productCategoryRepository.Get();
            var products = await _productRepository.Get();

            var menu = new MenuDto
            {
                SuperCategories = superCategories.GroupJoin(
                categories,
                sc => sc.SuperCategoryId,
                c => c.SuperCategoryId,
                (superCategory, categoryGroup) => new SuperCategoryDto
                {
                    Name = superCategory.Name,
                    Categories = categoryGroup.Select(category => new CategoryDto
                    {
                        Name = category.Name,
                        Products = productCategories.Where(pc => pc.CategoryId == category.CategoryId)
                            .Join(products,
                                pc => pc.ProductId,
                                p => p.ProductId,
                                (productCategory, product) => new ProductDataDto
                                {
                                    ProductId = product.ProductId,
                                    Name = product.Name,
                                    Description = product.Description,
                                    Calories = product.Calories,
                                    Cost = product.StarCost,
                                    ImageUrl = product.ImageUri
                                }).ToList()
                    }).ToList()
                }).ToList()
            };
            return menu;
        }
    }
}
