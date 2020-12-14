using System;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Dal.Default
{
    public class UsuariosDal : IUsuariosDal
    {
        private ApiDbContext _contexto;

        public UsuariosDal(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Usuarios> Consultar(string nomeUsuario, string senha)
        {
            Usuarios usuarioLinq = await _contexto.Usuarios.AsNoTracking().Where(
                reg => reg.NomeUsuario == nomeUsuario &&
                 reg.Senha == senha)
                .FirstOrDefaultAsync();

            if (usuarioLinq != null)
            {
                _contexto.Update(usuarioLinq);
                await _contexto.SaveChangesAsync();
                usuarioLinq.Senha = "**********";
            }

            return usuarioLinq;
        }
    }
}