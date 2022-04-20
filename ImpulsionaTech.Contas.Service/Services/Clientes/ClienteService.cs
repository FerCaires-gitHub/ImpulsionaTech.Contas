using AutoMapper;
using ImpulsionaTech.Contas.Application.DTOs.Clientes;
using ImpulsionaTech.Contas.Application.DTOs.Contas;
using ImpulsionaTech.Contas.Application.Interfaces;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Models.Contas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Application.Services.Clientes
{
    public class ClienteService : ServiceBase<ClienteRequest, ClienteResponse, Cliente>, IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Cliente> _unitOfWork;
        private readonly IUnitOfWork<Conta> _unitOfConta;
        private readonly IAsyncRepository<Conta> _repository;
        private readonly IAsyncRepository<Cliente> _clienteRepository;

        public ClienteService(IMapper mapper, IUnitOfWork<Cliente> unitOfWork, IUnitOfWork<Conta> unitOfConta) : base(mapper,unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _unitOfConta = unitOfConta;
            _repository = _unitOfConta.Repository();
            _clienteRepository = _unitOfWork.Repository();
        }

        public async Task<ClienteResponse> GetContasByClientAsync(int id)
        {
            var cliente = await _clienteRepository.GetAsync(id);
            if (cliente == null) throw new Exception($"Cliente de Id:{id} não encontrado");
            var contas = await _repository.GetByIdAsync(x => x.ClienteId == id);
            cliente.Contas = contas;
            return _mapper.Map<ClienteResponse>(cliente);

        }
    }
}
