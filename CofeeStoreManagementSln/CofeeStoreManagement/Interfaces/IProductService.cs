using CofeeStoreManagement.Models.DTO.MenuDTO;
using CofeeStoreManagement.Models.DTO.ProductDTO;

namespace CofeeStoreManagement.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDataDto> GetProductById(int id);
        public Task<IEnumerable<ProductDataDto>> GetTrendingProducts();
        public Task<ProductWithCategoriesDto> GetProductWithCategories(int id); 
    }
}
