using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Context;
using api.Models;

namespace api.Dal.Default
{
    public class BeneficiosDal : IBeneficiosDal
    {
        private ApiDbContext _contexto;

        public BeneficiosDal(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Beneficios> PesquisarBeneficioPorMatricula(int matricula)
        {
            Beneficios beneficioLinq =
                await _contexto
                    .Beneficios
                    .AsNoTracking()
                    .Where(reg => reg.Matricula == matricula)
                    .FirstOrDefaultAsync();

            return beneficioLinq;
        }

        public async Task<Beneficios> criarBeneficio(Beneficios benef)
        {
            if (benef != null)
            {
                _contexto.Update(benef);
                await _contexto.SaveChangesAsync();
            }

            return benef;
        }
    }
}
