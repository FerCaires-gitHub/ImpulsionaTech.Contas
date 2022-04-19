using AutoMapper;
using ImpulsionaTech.Contas.Application.DTOs.Contas;
using ImpulsionaTech.Contas.Application.Interfaces;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Models.Contas;
using ImpulsionaTech.Contas.Domain.Models.TiposConta;
using ImpulsionaTech.Contas.Domain.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Application.Services.Contas
{
    public class ContaService : ServiceBase<ContaRequest, ContaResponse, Conta>, IContaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<Conta> _unitOfWork;
        private readonly IUnitOfWork<Cliente> _unitOfCliente;
        private readonly IUnitOfWork<TipoConta> _unitOfTipoConta;

        public ContaService(IMapper mapper, IUnitOfWork<Conta> unitOfWork, IUnitOfWork<Cliente> unitOfCliente, IUnitOfWork<TipoConta> unitOfTipoConta)
            :base(mapper,unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _unitOfCliente = unitOfCliente;
            _unitOfTipoConta = unitOfTipoConta;
        }

        //public override async Task<ContaResponse> InsertAsync(ContaRequest entity)
        //{
        //    var cliente = await _unitOfCliente.Repository().GetAsync(entity.ClienteId);
        //    if (cliente == null) 
        //        throw new Exception($"Cliente de id: {entity.ClienteId} não encontrado");
        //    var tipoConta = await _unitOfTipoConta.Repository().GetAsync(entity.TipoContaId);
        //    if (tipoConta == null)
        //        throw new Exception($"Tipo Conta de id:{entity.TipoContaId} não encontrado");
        //    var conta = new Conta { ClienteId = cliente.ClienteId, TipoContaId = tipoConta.TipoContaId, Status = Status.Ativo, Saldo = 0 };
        //    await _unitOfWork.Repository().AddAsync(conta);
        //    await _unitOfWork.SaveChangesAsync();
        //    return _mapper.Map<ContaResponse>(conta);
        //}
    }
}
