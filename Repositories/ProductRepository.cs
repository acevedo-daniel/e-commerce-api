using e_commerce_api.Data;
using e_commerce_api.Models;
using e_commerce_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Product?> GetProductBySKUAsync(string sku)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.SKU == sku);
        }

        public async Task<Product?> GetProductWithCategoryAndImagesAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}