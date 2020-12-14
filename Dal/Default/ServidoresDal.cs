using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Context;
using api.Models;

namespace api.Dal.Default
{
    public class ServidoresDal : IServidoresDal
    {
        private ApiDbContext _contexto;

        public ServidoresDal(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Servidores> pesquisarServidorPorMatricula(int matricula)
        {
            Servidores servidoresLinq =
                await _contexto
                    .Servidores
                    .AsNoTracking()
                    .Where(reg => reg.Matricula == matricula)
                    .FirstOrDefaultAsync();

            return servidoresLinq;
        }

        public async Task<Servidores> criarServidor(Servidores serv)
        {
            if (serv != null)
            {
                _contexto.Update(serv);
                await _contexto.SaveChangesAsync();
            }

            return serv;
        }
    }
}
