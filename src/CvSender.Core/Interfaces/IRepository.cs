namespace CvSender.Core.Interfaces
{
        public interface IRepository<T>
        {
                Task<List<T>> GetAllAsync();

                Task<T> GetByIdAsync(string id);

                Task AddAsync(T entity);

                Task UpdateAsync(string id, T entity);

                Task DeleteAsync(string id);
        }
}
