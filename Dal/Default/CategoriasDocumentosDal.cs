using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Context;
using api.Models;
using System.Collections.Generic;

namespace api.Dal.Default
{
    public class CategoriasDocumentosDal : ICategoriasDocumentosDal
    {
        private ApiDbContext _contexto;

        public CategoriasDocumentosDal(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<CategoriasDocumentos>> listarCategoriasDocumentos()
        {
            List<CategoriasDocumentos> categoriasDocumentosLinq = await _contexto.CategoriasDocumentos
            .AsNoTracking()
            .ToListAsync();
            return categoriasDocumentosLinq;
        }
    }
}
