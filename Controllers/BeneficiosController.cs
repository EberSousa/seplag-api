using api.Models;
using api.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/Beneficio")]
    public class BeneficiosController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Inserir(
            [FromServices] IBeneficiosDal beneficiosDal,
            [FromBody] Beneficios body
        )
        {
            try
            {
                Beneficios retorno = await beneficiosDal.criarBeneficio(body);
                if (retorno.IdBeneficio != 0)
                {
                    return Ok(retorno);
                }
                else
                {
                    return  Ok(new { message = "Nenhum beneficio inserido." });
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("matricula/{matricula}")]
        [Authorize]
        public async Task<IActionResult> Consultar(
            [FromServices] IBeneficiosDal beneficiosDal,
            int matricula
        )
        {
            try
            {
                Beneficios retorno = await beneficiosDal.PesquisarBeneficioPorMatricula(matricula);
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
