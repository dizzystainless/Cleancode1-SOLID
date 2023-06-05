using Shared;

namespace Server.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetNewProductByNameAsync(Product newProd);
        Task AddProductAsync(Product newProd);
    }
}
