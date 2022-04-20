using ImpulsionaTech.Contas.Application.DTOs.MovimentacoesBancarias;
using ImpulsionaTech.Contas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.WebApi.Controllers
{
    [ApiController]
    [Route("v1/MovimentacoesBancarias")]
    public class MovimentacaoBancariaController:ControllerBase
    {
        private readonly ILogger<MovimentacaoBancariaController> _logger;
        private readonly IMovimentacaoBancariaService _service;

        public MovimentacaoBancariaController(ILogger<MovimentacaoBancariaController> logger, IMovimentacaoBancariaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("{id}/cliente")]
        public async Task<ActionResult<List<MovimentacaoBancariaResponse>>> GetByClienteIdAsync(int id)
        {
            try
            {
                var response = await _service.GetByClienteAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/conta")]
        public async Task<ActionResult<List<MovimentacaoBancariaResponse>>> GetByContaIdAsync(int id)
        {
            try
            {
                var response = await _service.GetByContaAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MovimentacaoBancariaResponse>> InserirAsync(MovimentacaoBancariaRequest request)
        {
            try
            {
                var response = await _service.InsertAsync(request);
                return StatusCode(201, response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<MovimentacaoBancariaResponse>> ReverteMovimentacaoBancariaAsync(int id)
        {
            try
            {
                var response = await _service.ReverteMovimentacaoAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }

}
