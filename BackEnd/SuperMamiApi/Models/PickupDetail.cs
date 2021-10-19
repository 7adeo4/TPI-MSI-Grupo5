using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class PickupDetail
    {
        public int IdPickupDetail { get; set; }
        public int? IdPickup { get; set; }
        public double? Weight { get; set; }
        public double? Volume { get; set; }

        public virtual Pickup IdPickupNavigation { get; set; }
    }
}
