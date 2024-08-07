﻿using CofeeStoreManagement.Interfaces;
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
        
        /// <summary>
        /// get the menu data by joining the supercateogry with category with product and selecting the details
        /// </summary>
        /// <returns></returns>
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
                    (productCategory, product) => new { productCategory, product })
                .Where(joined => !joined.product.Archived) 
                .Select(joined => new ProductDataDto
                {
                    ProductId = joined.product.ProductId,
                    Name = joined.product.Name,
                    Description = joined.product.Description,
                    Calories = joined.product.Calories,
                    Cost = joined.product.StarCost,
                    ImageUrl = joined.product.ImageUri
                }).ToList()
        }).ToList()
    }).ToList()
            }; 
            return menu;
        }
    }
}
