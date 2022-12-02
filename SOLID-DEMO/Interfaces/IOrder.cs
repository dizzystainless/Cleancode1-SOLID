using Shared;

namespace Server.Interfaces
{
    public interface IOrder
    {
        public Task<List<Order>> GetAllOrderssAsync();
        public Task<List<Order>> GetOrdersForCustomerAsync(int id);
        public Task<Customer> GetCustomerCartAsync(CustomerCart cart);
        public Task<List<Product>> AddProductsForCartAsync(CustomerCart cart);
        public Task<Order> CreateOrderAsync(Order order);
    }
}
