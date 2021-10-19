using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Pickup
    {
        public Pickup()
        {
            PickupDetails = new HashSet<PickupDetail>();
        }

        public int IdPickup { get; set; }
        public int? DeliveryOrderNumber { get; set; }
        public int? IdBranch { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public bool? IsOwner { get; set; }
        public int? IdState { get; set; }
        public int? IdUser { get; set; }
        public TimeSpan? Hour { get; set; }
        public DateTime? Day { get; set; }

        public virtual Branch IdBranchNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<PickupDetail> PickupDetails { get; set; }
    }
}
