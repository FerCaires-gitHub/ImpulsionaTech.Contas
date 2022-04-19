using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Models.Contas;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImpulsionaTech.Contas.Domain.Models.TiposConta
{
    [Table("TB_TIPO_CONTAS")]
    public class TipoConta : BaseEntity
    {
        [Key]
        public int TipoContaId { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="Descrição deve apresentar no máximo 50 caracteres")]
        public string Descricao { get; set; }

        public Conta Conta { get; set; }
    }
}
