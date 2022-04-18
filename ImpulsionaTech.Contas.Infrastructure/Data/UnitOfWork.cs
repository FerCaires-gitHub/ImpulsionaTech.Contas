using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Infrastructure.Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T:BaseEntity
    {
        private readonly EFContext _context;
        private RepositoryBase<T> _repository;

        public UnitOfWork(EFContext context)
        {
            _context = context;
        }
        public IAsyncRepository<T> Repository()
        {
            _repository = _repository ?? new RepositoryBase<T>(_context);
            return _repository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
