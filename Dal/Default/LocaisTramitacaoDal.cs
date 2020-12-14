using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Context;
using api.Models;
using System.Collections.Generic;

namespace api.Dal.Default
{
    public class LocaisTramitacaoDal : ILocaisTramitacaoDal
    {
        private ApiDbContext _contexto;

        public LocaisTramitacaoDal(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<LocaisTramitacao>> listarLocaisTramitacao()
        {
            List<LocaisTramitacao> locaisTramitacaoLinq = await _contexto.LocaisTramitacao.AsNoTracking().ToListAsync();
            return locaisTramitacaoLinq;
        }
    }
}
