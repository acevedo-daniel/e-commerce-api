using e_commerce_api.Data;
using e_commerce_api.Models;
using e_commerce_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_api.Repositories
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ProductCategory?> GetCategoryByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}