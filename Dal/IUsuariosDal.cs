using System.Threading.Tasks;
using api.Models;

namespace api.Dal
{
    public interface IUsuariosDal
    {
         /// <summary>
        /// Consulta dados do usuário
        /// Sucesso: Retorna o usuário consultado
        /// Insucesso: Retorna o usuário vazio
        /// </summary>
        /// <param name="NomeUsuario">eMail</param>
        /// <param name="Senha">eMail</param>
        /// <returns>Usuarios<Usuarios></returns>
        Task<Usuarios> Consultar(string nomeUsuario, string senha);       
    }
}