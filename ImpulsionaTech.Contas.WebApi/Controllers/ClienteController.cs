using ImpulsionaTech.Contas.Application.DTOs.Clientes;
using ImpulsionaTech.Contas.Application.DTOs.TiposConta;
using ImpulsionaTech.Contas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.WebApi.Controllers
{
    [ApiController]
    [Route("v1/Clientes")]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _service;

        public ClienteController(ILogger<ClienteController> logger, IClienteService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ClienteResponse>> GetById(int id)
        {
            try
            {
                var response = await _service.GetByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/contas")]
        public async Task<ActionResult<ClienteResponse>> GetContasByCliente(int id)
        {
            try
            {
                var response = await _service.GetContasByClientAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteResponse>>> GetAll()
        {
            try
            {
                var response = await _service.ListAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeletetAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> Insert(ClienteRequest request)
        {

            try
            {
                var response = await _service.InsertAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
