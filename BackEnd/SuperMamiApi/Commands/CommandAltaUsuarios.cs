using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Commands
{
    public partial class CommandAltaUsuarios
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int? IdRol { get; set; }
        public string Contrasenia { get; set; }
    }
}
