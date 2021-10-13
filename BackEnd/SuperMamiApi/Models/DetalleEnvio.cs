using System;
using System.Collections.Generic;
using System.Collections;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class DetalleEnvio
    {
        public DetalleEnvio()
        {
            LiquidacionEnvios = new HashSet<LiquidacionEnvio>();
        }

        public int IdDetalleEnvio { get; set; }
        public double? MontoEnvio { get; set; }
        public int? IdEnvio { get; set; }
        public double? Peso { get; set; }
        public double? Volumen { get; set; }
        public BitArray EsGratuito { get; set; }

        public virtual Envio IdEnvioNavigation { get; set; }
        public virtual ICollection<LiquidacionEnvio> LiquidacionEnvios { get; set; }
    }
}
