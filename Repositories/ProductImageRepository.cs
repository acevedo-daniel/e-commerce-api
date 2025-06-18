using e_commerce_api.Data;
using e_commerce_api.Models;
using e_commerce_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Repositories
{
    public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductImage>> GetImagesByProductIdAsync(int productId)
        {
            return await _dbSet.Where(pi => pi.ProductId == productId).ToListAsync();
        }
    }
}