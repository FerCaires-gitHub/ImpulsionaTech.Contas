using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Models.Contas;
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
        
        [Required]
        public int ContaId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public DateTime Data { get; set; }
        [Required]
        public TipoMovimentacao TipoMovimentacao { get; set; }
        [Required]
        public decimal Valor { get; set; }


        public void ReverteDadosMovimentacao()
        {
            UpdateStatus();
            UpdateTipoMovimentacao();
        }

        public void UpdateTipoMovimentacao()
        {
            if (this.TipoMovimentacao == TipoMovimentacao.Deposito)
                this.TipoMovimentacao = TipoMovimentacao.Saque;
            else
                this.TipoMovimentacao = TipoMovimentacao.Deposito;
        }

        public void UpdateStatus()
        {
            if (this.Status == Status.Ativo)
                this.Status = Status.Inativo;
            else
                this.Status = Status.Ativo;
        }
    }
}
