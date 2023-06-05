using Shared;
using Server.Interfaces;
using static Server.Interfaces.IGenericRepository;

namespace Server.Interfaces
{
    public interface ICustomerService : IGenericRepository<Customer>   
    {
        Task<List<Customer>> GetAllAsync();    
        Task<Customer> GetByIdAsync(int id);
        Task<bool> CreateAsync(Customer customer); 
        Task<bool> DeleteAsync(int id);

        ////--------------------------------------------------
        ////Nedan förberett för framtida funktioner
        //Task<Customer> GetByEmailAsync(string email);
        //Task <Customer> LoginCustomerAsync(string email, string password);    
    }
}
