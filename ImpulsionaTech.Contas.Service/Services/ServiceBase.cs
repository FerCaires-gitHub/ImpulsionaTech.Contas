using AutoMapper;
using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Application.Services
{
    public class ServiceBase<TSource, TDestination, T> : IServiceBase<TSource, TDestination, T> where TSource:class
                                                                                             where TDestination:class
                                                                                             where T:BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<T> _unitOfWork;
        private readonly IAsyncRepository<T> _repository;

        public ServiceBase(IMapper mapper, IUnitOfWork<T> unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository();
            
        }


        public async Task DeletetAsync(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null) 
                throw new Exception("id não encontrado");
            var request = _mapper.Map<T>(entity);
            await _repository.DeleteAsync(request);
            await _unitOfWork.SaveChangesAsync();
            
        }

        public virtual async Task<TDestination> GetByIdAsync(int id)
        {
            var response = await _repository.GetAsync(id);
            return _mapper.Map<TDestination>(response);
        }

        public virtual async Task<TDestination> InsertAsync(TSource entity)
        {
            try
            {
                var request = _mapper.Map<T>(entity);
                var response = await _repository.AddAsync(request);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<TDestination>(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual async Task<IEnumerable<TDestination>> ListAsync()
        {
            var response = await _repository.ListAsync();
            return response.Select(x => _mapper.Map<TDestination>(x));
        }

        public async Task<TDestination> UpdateAsync(TSource entity)
        {
            var request = _mapper.Map<T>(entity);
            var response = await _repository.UpdateAsync(request);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TDestination>(response);
        }
    }

}
