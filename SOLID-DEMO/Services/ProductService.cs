using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Server.Interfaces;
using Shared;

namespace Server.Services
{
    public class ProductService : IProduct
    {
        private readonly ShopContext _context;

        public ProductService(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Name.Equals(id));
            return product;
        }

        public async Task<Product> GetNewProductByNameAsync(Product newProd)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Name.Equals(newProd.Name));
            return prod;
        }

        public async Task AddProductAsync(Product newProd)
        {
            await _context.Products.AddAsync(newProd);
            await _context.SaveChangesAsync();
        }
    }
}
