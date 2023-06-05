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

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name.Equals(email));
            return customer;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task RegisterCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> LoginCustomerAsync(string email, string password)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name.Equals(email) && c.Password.Equals(password));
            return customer;
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
