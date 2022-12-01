using Shared;

namespace Server.Interfaces
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task AddUser(Customer customer);
        Task <Customer> LoginCustomerAsync(string email, string password);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task DeleteCustomerAsync(Customer customer);

    }
}
