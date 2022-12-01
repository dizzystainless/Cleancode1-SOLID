using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Server.Interfaces;
using Shared;

namespace Server.Services
{
    public class OrderService : IOrder
    {
        private readonly ShopContext _context;

        public OrderService(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrderssAsync()
        {
            var orders = await _context.Orders.Include(o => o.Customer).Include(o => o.Products).ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetOrdersForCustomerAsync(int id)
        {
            var orders = await _context.Orders.Include(o => o.Customer).Where(c => c.Customer.Id == id).Include(o => o.Products).ToListAsync();
            return orders;
        }

        public async Task<Customer> GetCustomerCart(CustomerCart cart)
        {
            var customerCart = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(cart.CustomerId));
            return customerCart;
        }
    }
}
