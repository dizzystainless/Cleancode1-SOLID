using Shared;
using static Server.Interfaces.IGenericRepository;

namespace Server.Interfaces
{
    public interface IProductService : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByNameAsync(Product newProd);
        Task<bool> CreateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
