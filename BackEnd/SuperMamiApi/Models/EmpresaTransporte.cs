using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class EmpresaTransporte
    {
        public EmpresaTransporte()
        {
            Envios = new HashSet<Envio>();
        }

        public int IdEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string Calle { get; set; }
        public int? Numero { get; set; }
        public string Localidad { get; set; }
        public int? Telefono { get; set; }
        public string Email { get; set; }
        public int? Cuit { get; set; }
        public TimeSpan? Horario { get; set; }
        public int? IdTipoEnvio { get; set; }

        public virtual TipoEnvio IdTipoEnvioNavigation { get; set; }
        public virtual ICollection<Envio> Envios { get; set; }
    }
}
