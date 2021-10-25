using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            ShippingDetails = new HashSet<ShippingDetail>();
        }

        public int IdShipping { get; set; }
        public int? IdShippingCompany { get; set; }
        public int? IdState { get; set; }
        public int? DeliveryOrderNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Phone { get; set; }
        public string Address { get; set; }
        public TimeSpan? Hour { get; set; }
        public DateTime? Day { get; set; }
        public int? IdZone { get; set; }
        public bool? IsOwner { get; set; }
        public int? IdUser { get; set; }

        public virtual ShippingCompany IdShippingCompanyNavigation { get; set; }
        public virtual State IdStateNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
        public virtual Zone IdZoneNavigation { get; set; }
        public virtual ICollection<ShippingDetail> ShippingDetails { get; set; }
    }
}
