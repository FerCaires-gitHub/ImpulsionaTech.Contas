using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Models.TiposConta;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Contas.Application.DTOs.Contas
{
    public class ContaResponse : BaseEntity
    {
        public int ContaId { get; set; }
        public int TipoContaId { get; set; }
        public decimal Saldo { get; set; }
        public int ClienteId { get; set; }
    }
}
