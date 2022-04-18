using ImpulsionaTech.Contas.Application.DTOs.TiposConta;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.TiposConta;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Contas.Application.Interfaces
{
    public interface ITipoContaService : IServiceBase<TipoContaRequest,TipoContaResponse, TipoConta>
    {

    }
}
