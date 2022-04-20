using ImpulsionaTech.Contas.Application.DTOs.Clientes;
using ImpulsionaTech.Contas.Domain.Interfaces;
using ImpulsionaTech.Contas.Domain.Models.Clientes;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.Application.Interfaces
{
    public interface IClienteService: IServiceBase<ClienteRequest, ClienteResponse, Cliente>
    {
        public Task<ClienteResponse> GetContasByClientAsync(int id);
    }
}
