using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T:BaseEntity
    {
        private readonly EFContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(EFContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            try
            {
                if (entity == null)
                    throw new Exception($"{typeof(T).Name} está nula ou não informada");
                await _dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new Exception($"{typeof(T).Name} está nula ou não informada");
            _dbSet.Remove(entity);
            return Task.FromResult(true);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetByIdAsync(Expression<Func<T,bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new Exception($"{typeof(T).Name} está nula ou não informada");
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
