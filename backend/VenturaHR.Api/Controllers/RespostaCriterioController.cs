using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VenturaHR.Application.Authorization;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Domain.Services;

namespace VenturaHR.Api.Controllers
{
    [Authorize]
    [Route("api/resposta/{respostaId:int}/criterio")]
    [ApiController]
    public class RespostaCriterioController : ControllerBase
    {
        private readonly IRespostaService respostaService;

        public RespostaCriterioController(IRespostaService respostaService)
        {
            this.respostaService = respostaService;
        }

        // GET: api/<RespostaCriterio>
        [HttpGet]
        public IEnumerable<RespostaCriterio> Get([FromRoute] int respostaId)
        {
            return respostaService.GetCriteriosByRespostaId(respostaId);
        }

        // GET api/<RespostaCriterio>/5
        [HttpGet("{id}")]
        public RespostaCriterio Get([FromRoute] int respostaId, int id)
        {
            return respostaService.GetRespostaCriterio(id);
        }

        // POST api/<RespostaCriterio>
        [HttpPost]
        public void Post([FromBody] RespostaCriterio value)
        {
            respostaService.CreateRespostaCriterio(value);
        }

        // PUT api/<RespostaCriterio>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RespostaCriterio value)
        {
            respostaService.UpdateRespostaCriterio(id, value);
        }

        // DELETE api/<RespostaCriterio>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            respostaService.DeleteRespostaCriterio(id);
        }
    }
}
