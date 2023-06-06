using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Server.Interfaces;
using Shared;

namespace Server.Services
{
    public class ProductService : GenericRepository<Product>, IProductService
    {
        //private readonly ShopContext _context;

        public ProductService(ShopContext context) : base(context)
        {

        }

        public override async Task<List<Product>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<Product> GetByNameAsync(Product newProd)
        {
            var prod = await DbSet.FirstOrDefaultAsync(p => p.Name.Equals(newProd.Name));
            return prod;
        }

        public override async Task<bool> CreateAsync(Product product)
        {
            try
            {
                await DbSet.AddAsync(product);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var existdata = await DbSet.FirstOrDefaultAsync(c => c.Id == id);
            if (existdata != null)
            {
                DbSet.Remove(existdata);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
