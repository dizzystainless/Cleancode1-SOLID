namespace Server.Interfaces
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : class
        {
            Task<List<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task<List<T>> GetAllByIdAsync(int customerId);
            Task<bool> CreateAsync(T entity);
            Task<bool> DeleteAsync(int id);

            //Task<T> GetByEmailAsync(string email);
        }
    }
}
