using ImpulsionaTech.Contas.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ImpulsionaTech.Contas.Application.DTOs.TiposConta
{
    public class TipoContaResponse : BaseEntity
    {
        public int TipoContaId { get; set; }
        public string Descricao { get; set; }
    }
}
