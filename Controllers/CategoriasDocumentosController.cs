using api.Models;
using api.Dal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("v1/CategoriasDocumentos")]
    public class CategoriasDocumentosController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Consultar(
            [FromServices] ICategoriasDocumentosDal categoriasDocumentosDal
        )
        {
            try
            {
                List<CategoriasDocumentos> retorno = await categoriasDocumentosDal.listarCategoriasDocumentos();
                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return NotFound(new { message = "Categorias de documentos não foi encontradas." });
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
