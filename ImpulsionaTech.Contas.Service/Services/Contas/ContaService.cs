using AutoMapper;
using ImpulsionaTech.Contas.Application.DTOs.Contas;
using ImpulsionaTech.Contas.Application.DTOs.MovimentacoesBancarias;
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
        private readonly IUnitOfWork<Conta> _unitOfWork;
        private readonly IAsyncRepository<Conta> _contaRepository;

        public ContaService(IMapper mapper, IUnitOfWork<Conta> unitOfWork)
            : base(mapper, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _contaRepository = _unitOfWork.Repository();
        }

        public async Task<bool> AtualizaSaldoBancario(MovimentacaoBancariaRequest movimentacaoBancariaRequest)
        {
            if (movimentacaoBancariaRequest == null) throw new Exception($"Objeto do tipo {typeof(MovimentacaoBancariaRequest).Name} nulo ou não informado");
            var conta = await RecuperaConta(movimentacaoBancariaRequest);
            await AtualizaSaldo(movimentacaoBancariaRequest, conta);
            return true;
        }

        private async Task<Conta> RecuperaConta(MovimentacaoBancariaRequest movimentacaoBancariaRequest)
        {
            var conta = await _unitOfWork.Repository().GetAsync(movimentacaoBancariaRequest.ContaId);
            if (conta == null) throw new Exception($"Conta de id :{movimentacaoBancariaRequest.ContaId} não encontrada");
            return conta;
        }

        private async Task AtualizaSaldo(MovimentacaoBancariaRequest movimentacaoBancariaRequest, Conta conta)
        {
            if (movimentacaoBancariaRequest.TipoMovimentacao == TipoMovimentacao.Deposito)
                conta.Saldo += movimentacaoBancariaRequest.Valor;
            else
            {
                if (conta.Saldo <= 0)
                    throw new Exception("Saldo da conta menor ou igual a zero");
                else if (conta.Saldo - movimentacaoBancariaRequest.Valor <= 0)
                    throw new Exception("Saldo da conta ficará negativo em caso de saque realizado");
                conta.Saldo -= movimentacaoBancariaRequest.Valor;
            }
            await _contaRepository.UpdateAsync(conta);
        }
    }
}
