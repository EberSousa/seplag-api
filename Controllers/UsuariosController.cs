using api.Models;
using api.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using api.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/Usuarios")]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticate(
        [FromServices] IUsuariosDal usuariosDal,
        [FromBody] Usuarios usuario)
        {
            try
            {
                Usuarios retorno = await usuariosDal.Consultar(usuario.NomeUsuario, usuario.Senha);
                if (retorno != null)
                {
                    var token = TokenService.GerarToken(retorno);

                    return new
                    {
                    Messagem = "Autenticação realizada com sucesso!",
                    Usuario = retorno.NomeUsuario,
                    token_type = "Bearer",
                    token = token
                    };
                }
                else
                {
                    return NotFound(new { message = "Usuário não foi encontrado ou senha inválida." });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("eMail/{eMail}/Senha/{senha}")]
        [Authorize]
        public async Task<IActionResult> Consultar(
            [FromServices] IUsuariosDal usuariosDal,
            string eMail,
            string senha
        )
        {
            try
            {
                Usuarios retorno = await usuariosDal.Consultar(eMail, senha);
                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return NotFound(new { message = "Usuário não foi encontrado ou senha inválida." });
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
