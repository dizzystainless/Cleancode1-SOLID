using Server.DataAccess;
using Server.Interfaces;
using Shared;

namespace Server.Services
{
    public class CustomerCartService : GenericRepository<CustomerCart>, ICustomerCartService
    {
        public CustomerCartService(ShopContext context) : base(context)
        {

        }
    }
}
