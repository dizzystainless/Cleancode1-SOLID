using Shared;

namespace Server.Interfaces
{
    public interface IOrder
    {
        public Task<List<Order>> GetAllOrderssAsync();
        public Task<List<Order>> GetOrdersForCustomerAsync(int id);
        public Task<Customer> GetCustomerCart(CustomerCart cart);
    }
}
