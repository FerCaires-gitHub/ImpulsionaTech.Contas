using ImpulsionaTech.Contas.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Domain.Interfaces
{
    public interface IUnitOfWork<T> where T: BaseEntity
    {
        Task SaveChangesAsync();
        IAsyncRepository<T> Repository();
    }
}
