using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoDocumento { get; set; }
        public string TipoDocumento1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
