using Shared;

namespace Server.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}
