using Shared;

namespace Server.Interfaces
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task RegisterCustomerAsync(Customer customer);
        Task <Customer> LoginCustomerAsync(string email, string password);      
        Task DeleteCustomerAsync(Customer customer);

    }
}
