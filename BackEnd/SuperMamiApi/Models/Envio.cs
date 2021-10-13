using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Envio
    {
        public Envio()
        {
            DetalleEnvios = new HashSet<DetalleEnvio>();
        }

        public int IdEnvio { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdEstado { get; set; }
        public int? NroOrdenEntrega { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Telefono { get; set; }
        public string Direccion { get; set; }
        public TimeSpan? Horario { get; set; }
        public DateTime? Dia { get; set; }
        public int? IdBarrio { get; set; }
        public bool? EsTitular { get; set; }
        public int? IdUsuario { get; set; }

        public virtual EmpresaTransporte IdEmpresaNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<DetalleEnvio> DetalleEnvios { get; set; }
    }
}
