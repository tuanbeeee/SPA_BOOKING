using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        void Update(T entity);
        Task<bool> IsExist(long id);
        Task<bool> SaveChangeAsync();
        bool SaveChange();
    }
}
