using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImpulsionaTech.Contas.Application.DTOs.TiposConta
{
    public class TipoContaRequest
    {
        [Required]
        [StringLength(50,ErrorMessage ="Máximo de 50 caracteres")]
        public string Descricao { get; set; }
    }
}
