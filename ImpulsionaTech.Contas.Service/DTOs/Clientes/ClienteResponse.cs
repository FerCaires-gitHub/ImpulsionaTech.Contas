using ImpulsionaTech.Contas.Application.DTOs.Contas;
using ImpulsionaTech.Contas.Domain.Base;
using ImpulsionaTech.Contas.Domain.Models.Contas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ImpulsionaTech.Contas.Application.DTOs.Clientes
{
    public class ClienteResponse : BaseEntity
    {
        public int ClienteId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ContaResponse> Contas { get; set; }
    }
}
