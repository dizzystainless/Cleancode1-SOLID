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

        public async Task<Customer> GetCustomerCartAsync(CustomerCart cart)
        {
            var customerCart = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(cart.CustomerId));
            return customerCart;
        }

        public async Task<List<Product>> AddProductsForCartAsync(CustomerCart cart)
        {
            var products = new List<Product>();

            foreach (var prodId in cart.ProductIds)
            {
                var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == prodId);
                //if (prod is null)
                //{
                //    return;
                //}
                products.Add(prod);
            }
            return products;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            //var order = new Order() { Customer = customer, Products = products };
            var now = DateTime.Now;
            order.ShippingDate = now.AddDays(5);

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task <Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task CancelOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByItemsToAddAsync(CustomerCart itemsToAdd, int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(itemsToAdd.CustomerId));
            return customer;
        }


    }
}
