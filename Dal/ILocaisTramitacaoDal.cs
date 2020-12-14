using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Dal
{
    public interface ILocaisTramitacaoDal
    {
        /// <summary>
        /// Consulta dados de CategoriasDocumentos
        /// Sucesso: Retorna uma lista de CategoriasDocumentos
        /// </summary>
        /// <returns>CategoriasDocumentos<List<CategoriasDocumentos>></returns>
        Task<List<LocaisTramitacao>> listarLocaisTramitacao();
    }
}
