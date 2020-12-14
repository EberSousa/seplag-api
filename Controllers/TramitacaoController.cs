using api.Models;
using api.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/Tramitacao")]
    public class TramitacaoController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Inserir(
            [FromServices] ITramitacaoDal tramitacaoDal,
            [FromBody] Tramitacao body
        )
        {
            try
            {
                Tramitacao retorno = await tramitacaoDal.criarTramitacao(body);
                if (retorno.IdTramitacao != 0)
                {
                    return Ok(retorno);
                }
                else
                {
                    return  Ok(new { message = "Nenhuma tramitação inserida." });
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("idBeneficio/{idBeneficio}")]
        [Authorize]
        public async Task<IActionResult> Consultar(
            [FromServices] ITramitacaoDal tramitacaoDal,
            int idBeneficio
        )
        {
            try
            {
                List<Tramitacao> retorno = await tramitacaoDal.pesquisarTramitacaoPorBeneficio(idBeneficio);
                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return NotFound(new { message = "Beneficio não foi encontrado." });
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
