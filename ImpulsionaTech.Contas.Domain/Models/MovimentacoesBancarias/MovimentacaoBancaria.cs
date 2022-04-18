using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ImpulsionaTech.Contas.Domain.Models.MovimentacoesBancarias
{
    [Table("TB_MOVIMENTACAO_BANCARIA")]
    public class MovimentacaoBancaria : BaseEntity
    {
        [Key]
        public int MovimentacaoBancariaId { get; set; }

        [ForeignKey("TipoContaId")]
        public int TipoContaId { get; set; }

        [Required]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
