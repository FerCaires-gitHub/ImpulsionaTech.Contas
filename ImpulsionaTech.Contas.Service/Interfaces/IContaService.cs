using ImpulsionaTech.Contas.Application.DTOs.Contas;
using ImpulsionaTech.Contas.Application.DTOs.MovimentacoesBancarias;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.Contas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Application.Interfaces
{
    public interface IContaService : IServiceBase<ContaRequest, ContaResponse, Conta>
    {
        Task<bool> AtualizaSaldoBancario(MovimentacaoBancariaRequest movimentacaoBancariaRequest);
    }
}
