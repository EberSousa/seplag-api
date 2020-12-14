using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Servidores
    {
        public Servidores()
        {
            Beneficios = new HashSet<Beneficios>();
        }

        public int Matricula { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Orgao { get; set; }

        public virtual ICollection<Beneficios> Beneficios { get; set; }
    }
}
