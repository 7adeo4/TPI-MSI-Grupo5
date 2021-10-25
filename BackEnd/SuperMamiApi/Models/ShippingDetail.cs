using System;
using System.Collections.Generic;
using System.Collections;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class ShippingDetail
    {
        public ShippingDetail()
        {
            ShippingPayments = new HashSet<ShippingPayment>();
        }

        public int IdShippingDetail { get; set; }
        public double? ShippingPrice { get; set; }
        public int? IdShipping { get; set; }
        public double? Weight { get; set; }
        public double? Volume { get; set; }
        public BitArray IsFree { get; set; }

        public virtual Shipping IdShippingNavigation { get; set; }
        public virtual ICollection<ShippingPayment> ShippingPayments { get; set; }
    }
}
