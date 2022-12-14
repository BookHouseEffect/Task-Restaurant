using Restaurant.DataAccess.Entities;

namespace Restaurant.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task InsertAsync(Product product);
    }
}
