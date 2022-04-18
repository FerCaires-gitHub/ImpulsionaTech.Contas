using AutoMapper;
using ImpulsionaTech.Contas.Application.DTOs.Clientes;
using ImpulsionaTech.Contas.Application.Interfaces;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImpulsionaTech.Contas.Application.Services.Clientes
{
    public class ClienteService : ServiceBase<ClienteRequest, ClienteResponse, Cliente>, IClienteService
    {

        public ClienteService(IMapper mapper, IUnitOfWork<Cliente> unitOfWork) : base(mapper,unitOfWork)
        {

        }
    }
}
