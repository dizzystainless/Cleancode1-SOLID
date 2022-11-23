using Microsoft.EntityFrameworkCore;
using Shared;

namespace Server.DataAccess;

public class ShopContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public ShopContext(DbContextOptions options) : base(options)
    {

    }
}