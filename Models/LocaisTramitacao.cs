using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class LocaisTramitacao
    {
        public LocaisTramitacao()
        {
            TramitacaoIdLocalTramitacaoDestinoNavigation = new HashSet<Tramitacao>();
            TramitacaoIdLocalTramitacaoOrigemNavigation = new HashSet<Tramitacao>();
        }

        public int IdLocalTramitacao { get; set; }
        public string DescricaoLocalTramitacao { get; set; }

        public virtual ICollection<Tramitacao> TramitacaoIdLocalTramitacaoDestinoNavigation { get; set; }
        public virtual ICollection<Tramitacao> TramitacaoIdLocalTramitacaoOrigemNavigation { get; set; }
    }
}
