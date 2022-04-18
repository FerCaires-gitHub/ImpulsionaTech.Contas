using ImpulsionaTech.Contas.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Contas.Application.DTOs.Clientes
{
    public class ClienteResponse : BaseEntity
    {
        public int ClienteId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
    }
}
