using Shared;

namespace Server.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetNewProductByNameAsync(Product newProd);
        Task AddProductAsync(Product newProd);
    }
}
