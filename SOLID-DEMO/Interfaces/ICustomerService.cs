using Shared;
using Server.Interfaces;
using static Server.Interfaces.IGenericRepository;

namespace Server.Interfaces
{
    public interface ICustomerService : IGenericRepository<Customer>   
    {
        Task<List<Customer>> GetAllAsync();
        //Task<Customer> GetCustomerByEmailAsync(string email);
        //Task<Customer> GetCustomerByIdAsync(int id);
        //Task RegisterCustomerAsync(Customer customer);
        //Task <Customer> LoginCustomerAsync(string email, string password);      
        //Task DeleteCustomerAsync(Customer customer);

    }
}
