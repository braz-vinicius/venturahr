using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VenturaHR.Application.Authorization;
using VenturaHR.Domain.Entities.Resposta;
using VenturaHR.Domain.Services;

namespace VenturaHR.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : ControllerBase
    {
        private readonly IRespostaService respostaService;

        public RespostaController(IRespostaService respostaService)
        {
            this.respostaService = respostaService;
        }
        
        [HttpGet]
        public IEnumerable<Resposta> Get()
        {
            return respostaService.RetrieveAllRespostas();
        }

        [HttpGet("{id}")]
        public Resposta Get(int id)
        {
            return respostaService.GetResposta(id);
        }

        [HttpPost]
        public void Post([FromBody] Resposta value)
        {
            respostaService.CreateResposta(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Resposta value)
        {
            respostaService.UpdateResposta(id, value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            respostaService.DeleteResposta(id);
        }
    }
}
