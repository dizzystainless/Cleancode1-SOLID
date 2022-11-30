using Microsoft.EntityFrameworkCore;
using Server.DataAccess;
using Server.Interfaces;
using Shared;

namespace Server.Services
{
    public class CustomerService : ICustomer
    {
        private readonly ShopContext _context;

        public CustomerService(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Name.Equals(email));
            return customer;
        }

        public async Task AddUser(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }


    }

}
