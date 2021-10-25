using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class ShippingDetail
    {
        public int IdShippingDetail { get; set; }
        public int? IdShipping { get; set; }
        public string Weight { get; set; }
        public string Volume { get; set; }
        public int? BagsQuantity { get; set; }

        public virtual Shipping IdShippingNavigation { get; set; }
    }
}
