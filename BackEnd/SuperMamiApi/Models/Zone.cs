using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Zone
    {
        public Zone()
        {
            Branches = new HashSet<Branch>();
            Shippings = new HashSet<Shipping>();
        }

        public int IdZone { get; set; }
        public string Zone1 { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
