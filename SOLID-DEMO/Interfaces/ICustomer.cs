using Shared;

namespace Server.Interfaces
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerByEmailAsync(string email);

        Task AddUser(Customer customer);

    }
}
