using ImpulsionaTech.Contas.Domain.Models.Clientes;
using ImpulsionaTech.Contas.Domain.Models.TiposConta;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Contas.Application.DTOs.Contas
{
    public class ContaRequest
    {
        public int ClienteId { get; set; }
        public int TipoContaId { get; set; }
    }
}
