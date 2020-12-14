using System.Threading.Tasks;
using api.Models;

namespace api.Dal
{
    public interface IServidoresDal
    {
        /// <summary>
        /// Consulta dados do beneficio
        /// Sucesso: Retorna o beneficio consultado
        /// Insucesso: Retorna o beneficio vazio
        /// </summary>
        /// <param name="Serv">Servidores</param>
        /// <returns>Servidores<Servidores></returns>
        Task<Servidores> pesquisarServidorPorMatricula(int matricula);

        /// <summary>
        /// Cria ou atualiza um beneficio
        /// </summary>
        /// <param name="serv">Servidores</param>
        /// <returns>Servidores<Servidores></returns>
        Task<Servidores> criarServidor(Servidores serv);
    }
}
