using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class ShippingPayment
    {
        public int IdShippingPayment { get; set; }
        public int? IdShippingDetail { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? Date { get; set; }

        public virtual ShippingDetail IdShippingDetailNavigation { get; set; }
    }
}
