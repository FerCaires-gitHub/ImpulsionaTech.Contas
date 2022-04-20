using ImpulsionaTech.Contas.Application.DTOs.MovimentacoesBancarias;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.MovimentacoesBancarias;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Application.Interfaces
{
    public interface IMovimentacaoBancariaService : IServiceBase<MovimentacaoBancariaRequest, MovimentacaoBancariaResponse, MovimentacaoBancaria>
    {
        Task<IEnumerable<MovimentacaoBancariaResponse>> GetByClienteAsync(int id);
        Task<IEnumerable<MovimentacaoBancariaResponse>> GetByContaAsync(int id);
        Task<MovimentacaoBancariaResponse> ReverteMovimentacaoAsync(int id);

    }
}
