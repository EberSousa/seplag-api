using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Tramitacao
    {
        public int IdTramitacao { get; set; }
        public int IdBeneficio { get; set; }
        public DateTime? DtTramitacao { get; set; }
        public int IdLocalTramitacaoOrigem { get; set; }
        public int IdLocalTramitacaoDestino { get; set; }

        public virtual Beneficios IdBeneficioNavigation { get; set; }
        public virtual LocaisTramitacao IdLocalTramitacaoDestinoNavigation { get; set; }
        public virtual LocaisTramitacao IdLocalTramitacaoOrigemNavigation { get; set; }
    }
}
