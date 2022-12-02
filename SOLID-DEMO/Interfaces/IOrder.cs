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
        public Task<Order> GetOrderByIdAsync(int id);
        public Task CancelOrderAsync(Order order);
        public Task<Customer> GetCustomerByItemsToAddAsync(CustomerCart itemsToAdd, int id);
        public Task<List<Product>> GetProductsToAddToExistingOrderAsync(CustomerCart itemsToAdd);
        public Task<Order> GetOrderToAddProductsToAsync(int id);
        public Task AddToOrderAsync(Order order, List<Product> products);
    }
}
