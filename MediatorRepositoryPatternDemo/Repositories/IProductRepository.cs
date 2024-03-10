using MediatorRepositoryPatternDemo.Models;

namespace MediatorRepositoryPatternDemo.Repositories
{
    public interface IProductRepository 
    {
        public Task<List<Product>> GetProductsListAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task<Product> AddProductAsync(Product product);
        public Task<Product> UpdateProductAsync(Product product);
        public Task<Product> DeleteProductAsync(int id);
    }
}
