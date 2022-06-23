using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<T, V> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(V id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(V id);
        Task<bool> UpdateAsync(T entity);
    }
}
