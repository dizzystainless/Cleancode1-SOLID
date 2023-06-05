using Shared;
using static Server.Interfaces.IGenericRepository;

namespace Server.Interfaces
{
    public interface ICustomer : IGenericRepository<Customer>   
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task RegisterCustomerAsync(Customer customer);
        Task <Customer> LoginCustomerAsync(string email, string password);      
        Task DeleteCustomerAsync(Customer customer);

    }
}
