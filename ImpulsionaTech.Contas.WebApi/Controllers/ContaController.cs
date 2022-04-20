using ImpulsionaTech.Contas.Application.DTOs.Contas;
using ImpulsionaTech.Contas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.WebApi.Controllers
{
    [ApiController]
    [Route("v1/Contas")]
    public class ContaController : ControllerBase
    {

        private readonly ILogger<ContaController> _logger;
        private readonly IContaService _service;

        public ContaController(ILogger<ContaController> logger, IContaService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ContaResponse>> GetById(int id)
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
        public async Task<ActionResult<List<ContaResponse>>> GetAll()
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
        public async Task<ActionResult<ContaResponse>> Insert(ContaRequest request)
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
