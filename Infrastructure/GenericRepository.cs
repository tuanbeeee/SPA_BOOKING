using Domain;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SpaBookingDBContext _dbContext;

        public GenericRepository(SpaBookingDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public async Task<bool> IsExist(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id) is not null;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public bool SaveChange()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
