using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Dal
{
    public interface ICategoriasDocumentosDal
    {
        /// <summary>
        /// Consulta dados de CategoriasDocumentos
        /// Sucesso: Retorna uma lista de CategoriasDocumentos
        /// </summary>
        /// <returns>CategoriasDocumentos<IList<CategoriasDocumentos>></returns>
        Task<List<CategoriasDocumentos>> listarCategoriasDocumentos();
    }
}
