using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Models.TiposConta;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImpulsionaTech.Contas.Domain.Models.Contas
{
    [Table("TB_CONTAS")]
    public class Conta : BaseEntity
    {
        [Key]
        public int ContaId { get; set; }

        [Required]
        public int TipoContaId { get; set; }
        public TipoConta TipoConta { get; set; }
        public decimal Saldo { get; set; }
        
        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}

