using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Envios = new HashSet<Envio>();
            Retiros = new HashSet<Retiro>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int? IdRol { get; set; }
        public string Contrasenia { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<Envio> Envios { get; set; }
        public virtual ICollection<Retiro> Retiros { get; set; }
    }
}
