using System.Threading.Tasks;

namespace InstagramApi.Utils
{
    public interface IRepository<T>
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
    }
}