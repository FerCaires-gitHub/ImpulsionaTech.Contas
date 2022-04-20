using ImpulsionaTech.Contas.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Domain.Interfaces
{
    public interface IAsyncRepository<T> where T:BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> ListAsync();
        Task<IEnumerable<T>> GetByIdAsync(Expression<Func<T, bool>> expression);

    }
}
