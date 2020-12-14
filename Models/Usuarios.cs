using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
