using ImpulsionaTech.Contas.Domain.Base;
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
        [ForeignKey("TipoConta")]
        public int TipoContaId { get; set; }
        public decimal Saldo { get; set; }
        [Required]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
    }
}

