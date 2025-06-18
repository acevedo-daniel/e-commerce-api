using e_commerce_api.Models;

namespace e_commerce_api.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task<ProductCategory?> GetCategoryByNameAsync(string name);
    }
}