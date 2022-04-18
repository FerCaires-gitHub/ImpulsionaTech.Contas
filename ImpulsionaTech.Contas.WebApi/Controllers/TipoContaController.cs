using ImpulsionaTech.Contas.Application.DTOs.TiposConta;
using ImpulsionaTech.Contas.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ImpulsionaTech.Contas.WebApi.Controllers
{
    [ApiController]
    [Route("TiposConta")]
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
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var response = await _service.GetAsync(id);
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var response = await _service.ListAsync();
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                 await _service.DeletetAsync(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(TipoContaRequest request)
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
