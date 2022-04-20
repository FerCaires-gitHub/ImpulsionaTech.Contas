using ImpulsionaTech.Contas.Application.DTOs.TiposConta;
using ImpulsionaTech.Contas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.WebApi.Controllers
{
    [ApiController]
    [Route("v1/TiposConta")]
    public class TipoContaController : ControllerBase
    {

        private readonly ILogger<TipoContaController> _logger;
        private readonly ITipoContaService _service;

        public TipoContaController(ILogger<TipoContaController> logger, ITipoContaService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TipoContaResponse>> GetById(int id)
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
        public async Task<ActionResult<List<TipoContaResponse>>> GetAll()
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
        public async Task<ActionResult<TipoContaResponse>> Insert(TipoContaRequest request)
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
