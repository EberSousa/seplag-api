using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Context;
using api.Models;
using System.Collections.Generic;

namespace api.Dal.Default
{
    public class TramitacaoDal : ITramitacaoDal
    {
        private ApiDbContext _contexto;

        public TramitacaoDal(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Tramitacao>> pesquisarTramitacaoPorBeneficio(int idBeneficio)
        {
            List<Tramitacao> tramitacaoLinq =
                await _contexto
                    .Tramitacao
                    // .Include()
                    .AsNoTracking()
                    .Where(reg => reg.IdBeneficio == idBeneficio)
                    .ToListAsync();

            return tramitacaoLinq;
        }

        public async  Task<Tramitacao> criarTramitacao(Tramitacao tramit)
        {
            if (tramit != null)
            {
                _contexto.Update(tramit);
                await _contexto.SaveChangesAsync();
            }

            return tramit;
        }
    }
}
