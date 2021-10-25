using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Branch
    {
        public Branch()
        {
            Pickups = new HashSet<Pickup>();
        }

        public int IdBranch { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int? IdZone { get; set; }

        public virtual Zone IdZoneNavigation { get; set; }
        public virtual ICollection<Pickup> Pickups { get; set; }
    }
}
