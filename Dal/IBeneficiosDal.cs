using System.Threading.Tasks;
using api.Models;

namespace api.Dal
{
    public interface IBeneficiosDal
    {
        /// <summary>
        /// Consulta dados do beneficio
        /// Sucesso: Retorna o beneficio consultado
        /// Insucesso: Retorna o beneficio vazio
        /// </summary>
        /// <param name="Serv">Servidores</param>
        /// <returns>Beneficios<Beneficios></returns>
        Task<Beneficios> PesquisarBeneficioPorMatricula(int matricula);

        /// <summary>
        /// Cria ou atualiza um beneficio
        /// </summary>
        /// <param name="Benf">Beneficio</param>
        /// <returns>Beneficios<Beneficios></returns>
        Task<Beneficios> criarBeneficio(Beneficios benef);
    }
}
