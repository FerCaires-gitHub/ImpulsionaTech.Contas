using AutoMapper;
using ImpulsionaTech.Contas.Application.DTOs.TiposConta;
using ImpulsionaTech.Contas.Application.Interfaces;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.TiposConta;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Application.Services.TiposConta
{
    public class TipoContaService : ServiceBase<TipoContaRequest, TipoContaResponse,TipoConta>, ITipoContaService
    {

        public TipoContaService(IMapper mapper, IUnitOfWork<TipoConta> unitOfWork) : 
            base(mapper,unitOfWork)
        {

        }
       
    }
}
