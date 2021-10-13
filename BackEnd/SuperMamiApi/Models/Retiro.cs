using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Retiro
    {
        public Retiro()
        {
            DetalleRetiros = new HashSet<DetalleRetiro>();
        }

        public int IdRetiro { get; set; }
        public int? NroOrdenEntrega { get; set; }
        public int? IdSucursal { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public bool? EsTitular { get; set; }
        public int? IdEstado { get; set; }
        public int? IdUsuario { get; set; }
        public TimeSpan? Horario { get; set; }
        public DateTime? Dia { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Sucursale IdSucursalNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetalleRetiro> DetalleRetiros { get; set; }
    }
}
