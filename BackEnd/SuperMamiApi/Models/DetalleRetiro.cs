using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class DetalleRetiro
    {
        public int IdDetalleRetiro { get; set; }
        public int? IdRetiro { get; set; }
        public double? Peso { get; set; }
        public double? Volumen { get; set; }

        public virtual Retiro IdRetiroNavigation { get; set; }
    }
}
