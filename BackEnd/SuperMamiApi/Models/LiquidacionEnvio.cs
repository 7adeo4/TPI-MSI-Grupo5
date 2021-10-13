using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class LiquidacionEnvio
    {
        public int IdLiquidacion { get; set; }
        public int? IdDetalleEnvio { get; set; }
        public double? MontoTotal { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual DetalleEnvio IdDetalleEnvioNavigation { get; set; }
    }
}
