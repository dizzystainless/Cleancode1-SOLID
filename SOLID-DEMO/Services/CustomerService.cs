using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Server.Interfaces;
using Shared;

namespace Server.Services
{
    public class CustomerService : GenericRepository<Customer>, ICustomerService
    {
        //private readonly ShopContext _context;

        public CustomerService(ShopContext _context) : base(_context)
        {
            
        }

        public override async Task <List<Customer>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public override async Task<Customer> GetByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(c => c.Id == id);
        }

        //public async Task<Customer> GetByEmailAsync(string email)
        //{
        //    return await DbSet.FirstOrDefaultAsync(c => c.Email == mail);
        //}

        public override async Task<bool> CreateAsync(Customer customer)
        {
            try
            {
                await DbSet.AddAsync(customer);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //await _context.AddAsync(customer);
            //await _context.SaveChangesAsync();
        }

        //    public async Task<Customer> LoginCustomerAsync(string email, string password)
        //    {
        //        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name.Equals(email) && c.Password.Equals(password));
        //        return customer;
        //    }

        //    public async Task DeleteCustomerAsync(Customer customer)
        //    {
        //        _context.Customers.Remove(customer);
        //        await _context.SaveChangesAsync();
        //    }
    }
}
