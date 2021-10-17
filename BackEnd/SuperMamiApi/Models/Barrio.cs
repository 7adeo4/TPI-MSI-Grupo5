using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Barrio
    {
        public Barrio()
        {
            Envios = new HashSet<Envio>();
            Sucursales = new HashSet<Sucursale>();
        }

        public int IdBarrio { get; set; }
        public string Barrio1 { get; set; }

        public virtual ICollection<Envio> Envios { get; set; }
        public virtual ICollection<Sucursale> Sucursales { get; set; }
    }
}
