using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Commands.UserCommands
{
    public partial class CommandUpdateUsuario
    {        
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
    }
}