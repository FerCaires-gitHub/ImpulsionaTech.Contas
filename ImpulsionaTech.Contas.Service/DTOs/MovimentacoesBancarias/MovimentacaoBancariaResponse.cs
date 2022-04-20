using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Contas.Application.DTOs.MovimentacoesBancarias
{
    public class MovimentacaoBancariaResponse : BaseEntity
    {
        public int MovimentacaoBancariaId { get; set; }
        public int ClienteId { get; set; }
        public int ContaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoMovimentacao TipoMovimentacao { get; set; }
    }
}
