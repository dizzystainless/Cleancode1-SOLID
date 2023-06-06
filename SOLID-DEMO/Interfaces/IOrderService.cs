using Shared;
using static Server.Interfaces.IGenericRepository;

namespace Server.Interfaces
{
    public interface IOrderService : IGenericRepository<Order>
    {
        public Task<List<Order>> GetAllAsync();
        public Task<Order> GetByIdAsync(int id);
        public Task<List<Order>> GetAllByIdAsync(int id);

        //samma som getbyIdasync?
        //public Task<Order> GetOrderByCustomerAsync(int id);

        public Task<Customer> GetCustomerCartAsync(CustomerCart cart);
        //public Task<List<Product>> AddToCartAsync(CustomerCart cart);
        //public Task<Order> CreateOrderAsync(Order order);    
        //public Task CancelOrderAsync(Order order);

        ////Add to order
        //public Task<Customer> GetCustomerForItemsToAddAsync(CustomerCart itemsToAdd, int id);
        //public Task<List<Product>> GetItemsToAddAsync(CustomerCart itemsToAdd);
        //public Task AddToOrderAsync(Order order, List<Product> products);

        ////Remove from order
        //public Task<Customer> GetCustomerForItemsToRemoveAsync(CustomerCart itemsToRemove, int id);
        //public Task RemoveFromOrderAsync(CustomerCart itemsToRemove, Order order);
    }
}
