using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VenturaHR.Application.Authorization;
using VenturaHR.Domain.Entities.Vaga;
using VenturaHR.Domain.Services;

namespace VenturaHR.Api.Controllers
{
    [Authorize]
    [Route("api/vaga/{vagaId:int}/criterio")]
    [ApiController]
    public class VagaCriterioController : ControllerBase
    {
        private readonly IVagaService vagaService;

        public VagaCriterioController(IVagaService vagaService)
        {
            this.vagaService = vagaService;
        }

        // GET: api/<VagaCriterio>
        [HttpGet]
        public IEnumerable<VagaCriterio> Get([FromRoute] int vagaId)
        {
            return vagaService.GetVagaCriterios(vagaId);
        }

        // GET api/<VagaCriterio>/5
        [HttpGet("{id}")]
        public VagaCriterio Get([FromRoute] int vagaId, int id)
        {
            return vagaService.GetVagaCriterio(vagaId, id);
        }

        // POST api/<VagaCriterio>
        [HttpPost]
        public void Post([FromRoute] int vagaId, [FromBody] VagaCriterio value)
        {
            vagaService.PostVagaCriterio(value);
        }

        // DELETE api/<VagaCriterio>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            vagaService.DeleteVagaCriterio(id);
        }
    }
}
