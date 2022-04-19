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
        [ForeignKey("TipoContaId")]
        public int TipoContaId { get; set; }
        public decimal Saldo { get; set; }
        
        [Required]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
    }
}

