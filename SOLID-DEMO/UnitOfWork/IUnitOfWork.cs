using Microsoft.EntityFrameworkCore;
using Server.Interfaces;

namespace Server.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerService customerService { get; }
        IOrderService orderService { get; }

        Task CompleteAsync();

        ////The following Property is going to hold the context object
        //TContext Context { get; }
        ////Start the database Transaction
        //void CreateTransaction();
        ////Commit the database Transaction
        //void Commit();
        ////Rollback the database Transaction
        //void Rollback();
        ////DbContext Class SaveChanges method
        //void Save();
    }
}
