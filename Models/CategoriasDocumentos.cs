using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class CategoriasDocumentos
    {
        public CategoriasDocumentos()
        {
            DocumentosBeneficios = new HashSet<DocumentosBeneficios>();
        }

        public int IdCategoriaDocumento { get; set; }
        public string AbreviacaoCategoria { get; set; }
        public string DescricaoCategoria { get; set; }

        public virtual ICollection<DocumentosBeneficios> DocumentosBeneficios { get; set; }
    }
}
