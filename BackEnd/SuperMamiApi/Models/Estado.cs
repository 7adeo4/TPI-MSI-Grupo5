using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Envios = new HashSet<Envio>();
            Retiros = new HashSet<Retiro>();
        }

        public int IdEstado { get; set; }
        public string Estado1 { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
        public virtual ICollection<Retiro> Retiros { get; set; }
    }
}
