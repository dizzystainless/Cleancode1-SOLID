using Shared;
using static Server.Interfaces.IGenericRepository;

namespace Server.Interfaces
{
    public interface IProductService : IGenericRepository<Product>
    {
        //Task<List<Product>> GetAllProductsAsync();
        //Task<Product> GetProductByIdAsync(int id);
        //Task<Product> GetNewProductByNameAsync(Product newProd);
        //Task AddProductAsync(Product newProd);
    }
}
