using AutoMapper;
using ImpulsionaTech.Contas.Application.DTOs.Contas;
using ImpulsionaTech.Contas.Application.Interfaces;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.Contas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Contas.Application.Services.Contas
{
    public class ContaService : ServiceBase<ContaRequest, ContaResponse, Conta>, IContaService
    {
        public ContaService(IMapper mapper, IUnitOfWork<Conta> unitOfWork)
            :base(mapper,unitOfWork)
        {

        }
    }
}
