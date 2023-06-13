using Shared;
using static Server.Interfaces.IGenericRepository;

namespace Server.Interfaces
{
    public interface ICustomerCartService : IGenericRepository<CustomerCart>
    {
    }
}
