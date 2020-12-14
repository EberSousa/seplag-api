using api.Models;
using api.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/Servidor")]
    public class ServidorController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Inserir(
            [FromServices] IServidoresDal servidoresDal,
            [FromBody] Servidores body
        )
        {
            try
            {
                Servidores retorno = await servidoresDal.criarServidor(body);
                if (retorno.Matricula != 0)
                {
                    return Ok(retorno);
                }
                else
                {
                    return  Ok(new { message = "Nenhuma servidor inserido." });
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
            [FromServices] IServidoresDal servidoresDal,
            int matricula
        )
        {
            try
            {
                Servidores retorno = await servidoresDal.pesquisarServidorPorMatricula(matricula);
                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return NotFound(new { message = "Servidor não foi encontrado." });
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
