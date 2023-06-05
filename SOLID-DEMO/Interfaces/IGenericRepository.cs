namespace Server.Interfaces
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : class
        {
            Task<List<T>> GetAllAsync();
            Task<T> GetByIdAsync(int id);
            Task<bool> CreateAsync(T entity);
            Task<bool> DeleteAsync(int id);

            //Task<T> GetByEmailAsync(string email);
        }
    }
}
