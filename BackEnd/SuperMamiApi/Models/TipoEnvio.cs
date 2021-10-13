using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class TipoEnvio
    {
        public TipoEnvio()
        {
            EmpresaTransportes = new HashSet<EmpresaTransporte>();
        }

        public int IdTipoEnvio { get; set; }
        public string Descripcion { get; set; }
        public double? CapacidadPesoMax { get; set; }
        public string CapacidadVolumenMax { get; set; }
        public int? CantidadBolsasMax { get; set; }

        public virtual ICollection<EmpresaTransporte> EmpresaTransportes { get; set; }
    }
}
