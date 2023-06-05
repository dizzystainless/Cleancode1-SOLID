namespace Server.Interfaces
{
    public interface IGenericRepository
    {
        //Here, we are creating the IGenericRepository interface as a Generic Interface
        //Here, we are applying the Generic Constraint 
        //The constraint is T which is going to be a class
        public interface IGenericRepository<T> where T : class
        {
            Task<List<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            //void Insert(T obj);
            //void Update(T obj);
            //void Delete(T obj);
        }
    }
}
