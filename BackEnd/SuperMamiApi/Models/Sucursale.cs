using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Sucursale
    {
        public Sucursale()
        {
            Retiros = new HashSet<Retiro>();
        }

        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string CodPostal { get; set; }
        public int? IdBarrio { get; set; }

        public virtual Barrio IdBarrioNavigation { get; set; }
        public virtual ICollection<Retiro> Retiros { get; set; }
    }
}
