using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Server.Interfaces;
using Shared;

namespace Server.Services
{
    public class OrderService : GenericRepository<Order>, IOrderService
    {
        //private readonly ShopContext _context;

        public OrderService(ShopContext context) : base(context) 
        {
            
        }

        public override async Task <List<Order>> GetAllAsync()
        {
            //return await base.GetAllAsync();
            return await DbSet.Include(o => o.Customer).Include(o => o.Products).ToListAsync();

            //var orders = await _context.Orders.Include(o => o.Customer).Include(o => o.Products).ToListAsync();
            //return orders;
        }

        public override async Task<Order> GetByIdAsync(int id)
        {
             return await DbSet.Include(o => o.Customer).Include(o => o.Products).FirstOrDefaultAsync(o => o.Id == id);
            
            //var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            //return order;
        }

        public async Task<List<Order>> GetAllByIdAsync(int id)
        {
            return await DbSet.Include(o => o.Customer).Where(c => c.Customer.Id == id).Include(o => o.Products).ToListAsync();
            //var orders = await context.Orders.Include(o => o.Customer).Where(c => c.Customer.Id == id).Include(o => o.Products).ToListAsync();
            //return orders;
        }

        //samma som getbyidasync?
        //public async Task<Order> GetOrderByCustomerAsync(int id)
        //{
        //    var order = await DbSet.Include(o => o.Customer).Include(o => o.Products).FirstOrDefaultAsync(o => o.Id == id);
        //    return order;
        //}

        //    public async Task<Customer> GetCustomerCartAsync(CustomerCart cart)
        //    {
        //        var customerCart = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(cart.CustomerId));
        //        return customerCart;
        //    }

        //    public async Task<List<Product>> AddToCartAsync(CustomerCart cart)
        //    {
        //        var products = new List<Product>();

        //        foreach (var prodId in cart.ProductIds)
        //        {
        //            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == prodId);
        //            products.Add(prod);
        //        }
        //        return products;
        //    }

        //    public async Task<Order> CreateOrderAsync(Order order)
        //    {
        //        var now = DateTime.Now;
        //        order.ShippingDate = now.AddDays(5);
        //        await _context.Orders.AddAsync(order);
        //        await _context.SaveChangesAsync();
        //        return order;
        //    }

        //    public async Task CancelOrderAsync(Order order)
        //    {
        //        _context.Orders.Remove(order);
        //        await _context.SaveChangesAsync();
        //    }

        //    public async Task<Customer> GetCustomerForItemsToAddAsync(CustomerCart itemsToAdd, int id)
        //    {
        //        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(itemsToAdd.CustomerId));
        //        return customer;
        //    }

        //    public async Task<List<Product>> GetItemsToAddAsync(CustomerCart itemsToAdd)
        //    {
        //        var products = new List<Product>();

        //        foreach (var prodId in itemsToAdd.ProductIds)
        //        {
        //            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == prodId);
        //            products.Add(prod);
        //        }
        //        return products;
        //    }

        //    public async Task AddToOrderAsync(Order order, List<Product> products)
        //    {
        //        order.ShippingDate = DateTime.Now.AddDays(5);
        //        order.Products.AddRange(products);
        //        await _context.SaveChangesAsync();
        //    }

        //    public async Task<Customer> GetCustomerForItemsToRemoveAsync (CustomerCart itemsToRemove, int id)
        //    {
        //        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id.Equals(itemsToRemove.CustomerId));
        //        return customer;
        //    }

        //    public async Task RemoveFromOrderAsync(CustomerCart itemsToRemove, Order order)
        //    {
        //        foreach (var prodId in itemsToRemove.ProductIds)
        //        {
        //            var prod = order.Products.FirstOrDefault(p => p.Id == prodId);
        //            if (prod is null)
        //            {
        //                continue;
        //            }
        //            order.Products.Remove(prod);
        //        }
        //        await _context.SaveChangesAsync();
        //    }
    }
}
