using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Dal
{
    public interface ITramitacaoDal
    {
        /// <summary>
        /// Consulta dados do Tramitacao pelo beneficio
        /// Sucesso: Retorna uma lista de Tramitacao
        /// </summary>
        /// <param name="Benef">Servidores</param>
        /// <returns>Tramitacao<List<Tramitacao>></returns>
        Task<List<Tramitacao>> pesquisarTramitacaoPorBeneficio(int idBeneficio);

        /// <summary>
        /// Cria ou atualiza uma Tramitacao
        /// </summary>
        /// <param name="tramit">Tramitacao</param>
        /// <returns>Tramitacao<Tramitacao></returns>
        Task<Tramitacao> criarTramitacao(Tramitacao tramit);
    }
}
