using e_commerce_api.Models;

namespace e_commerce_api.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<Product?> GetProductBySKUAsync(string sku);
        Task<Product?> GetProductWithCategoryAndImagesAsync(int id);
    }
}