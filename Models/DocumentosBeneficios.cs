using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class DocumentosBeneficios
    {
        public int IdDocumentoBeneficio { get; set; }
        public int IdBeneficio { get; set; }
        public int IdCategoriaDocumento { get; set; }
        public string DocumentoPdf { get; set; }

        public virtual Beneficios IdBeneficioNavigation { get; set; }
        public virtual CategoriasDocumentos IdCategoriaDocumentoNavigation { get; set; }
    }
}
