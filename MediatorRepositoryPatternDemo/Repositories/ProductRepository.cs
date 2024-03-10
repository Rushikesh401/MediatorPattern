using MediatorRepositoryPatternDemo.Context;
using MediatorRepositoryPatternDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorRepositoryPatternDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public async Task<Product> AddProductAsync(Product product)
        {
           var result = _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var filtredData = _dbContext.Products.Where(x => x.Id == id).FirstOrDefault();
            _dbContext.Products.Remove(filtredData);
            await _dbContext.SaveChangesAsync();
            return filtredData;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task<List<Product>> GetProductsListAsync()
        {
           return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
