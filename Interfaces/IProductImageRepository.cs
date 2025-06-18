using e_commerce_api.Models;

namespace e_commerce_api.Interfaces
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(int productId);
    }
}