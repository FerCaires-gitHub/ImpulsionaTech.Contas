using ImpulsionaTech.Contas.Domain.Shared.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImpulsionaTech.Contas.Application.DTOs.Clientes
{
    public class ClienteRequest
    {
        [Required]
        [ValidaCPFAtributte]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF informado não é válido")]
        public string CPF { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Nome não pode ter mais de 50 caracteres")]
        public string Nome { get; set; }
    }
}
