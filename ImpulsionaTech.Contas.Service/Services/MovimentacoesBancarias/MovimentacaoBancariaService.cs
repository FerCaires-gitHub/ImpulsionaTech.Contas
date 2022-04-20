using AutoMapper;
using ImpulsionaTech.Contas.Application.DTOs.MovimentacoesBancarias;
using ImpulsionaTech.Contas.Application.Interfaces;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.MovimentacoesBancarias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Application.Services.MovimentacoesBancarias
{
    public class MovimentacaoBancariaService : ServiceBase<MovimentacaoBancariaRequest, MovimentacaoBancariaResponse, MovimentacaoBancaria>, 
        IMovimentacaoBancariaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<MovimentacaoBancaria> _unitOfWork;
        private readonly IContaService _contaService;        

        public MovimentacaoBancariaService(IMapper mapper, IUnitOfWork<MovimentacaoBancaria> unitOfWork, IContaService contaService)
            :base(mapper,unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _contaService = contaService;
        }

        public async Task<IEnumerable<MovimentacaoBancariaResponse>> GetByClienteAsync(int id)
        {
            var response = await _unitOfWork.Repository().GetByIdAsync(x => x.ClienteId == id);
            return response.Select(x => _mapper.Map<MovimentacaoBancariaResponse>(x));
        }

        public async Task<IEnumerable<MovimentacaoBancariaResponse>> GetByContaAsync(int id)
        {
            var response = await _unitOfWork.Repository().GetByIdAsync(x => x.ContaId == id);
            return response.Select(x => _mapper.Map<MovimentacaoBancariaResponse>(x));
        }

        public override async Task<MovimentacaoBancariaResponse> InsertAsync(MovimentacaoBancariaRequest entity)
        {
            await _contaService.AtualizaSaldoBancario(entity);
            var response = await base.InsertAsync(entity);
            return response;
        }

        public async Task<MovimentacaoBancariaResponse> ReverteMovimentacaoAsync(int id)
        {
            var movimentacao = await _unitOfWork.Repository().GetAsync(id);
            if (movimentacao == null) throw new Exception($"Movimentacao de id {id} não encontrada");
            movimentacao.ReverteDadosMovimentacao();
            var request = _mapper.Map<MovimentacaoBancariaRequest>(movimentacao);
            await _contaService.AtualizaSaldoBancario(request);
            var response  = await base.InsertAsync(request);
            return response;

        }
    }
}
