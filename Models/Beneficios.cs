using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Beneficios
    {
        public Beneficios()
        {
            DocumentosBeneficios = new HashSet<DocumentosBeneficios>();
            Tramitacao = new HashSet<Tramitacao>();
        }

        public int IdBeneficio { get; set; }
        public string DescricaoBeneficio { get; set; }
        public int Matricula { get; set; }

        public virtual Servidores MatriculaNavigation { get; set; }
        public virtual ICollection<DocumentosBeneficios> DocumentosBeneficios { get; set; }
        public virtual ICollection<Tramitacao> Tramitacao { get; set; }
    }
}
