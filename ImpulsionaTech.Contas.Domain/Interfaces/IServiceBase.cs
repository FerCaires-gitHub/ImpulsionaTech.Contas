using ImpulsionaTech.Contas.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Domain.Interfaces
{
    public interface IServiceBase<TSource, TDestination, T> where TSource:class 
                                                            where TDestination:class
                                                            where T: BaseEntity
    {
        Task<TDestination>  InsertAsync(TSource entity);
        Task<TDestination> UpdateAsync(TSource entity);
        Task<TDestination> GetByIdAsync(int id);
        Task DeletetAsync(int id);
        Task<IEnumerable<TDestination>> ListAsync();


    }
}
