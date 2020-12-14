using api.Models;
using api.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/LocaisTramitacao")]
    public class LocaisTramitacaoController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Consultar(
            [FromServices] ILocaisTramitacaoDal locaisTramitacaoDal
        )
        {
            try
            {
                List<LocaisTramitacao> retorno = await locaisTramitacaoDal.listarLocaisTramitacao();
                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return NotFound(new { message = "Locais de tramitação não foi encontrados." });
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
