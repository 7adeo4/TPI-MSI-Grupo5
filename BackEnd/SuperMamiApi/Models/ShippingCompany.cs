using System;
using System.Collections.Generic;

#nullable disable

namespace SuperMamiApi.Models
{
    public partial class ShippingCompany
    {
        public ShippingCompany()
        {
            Shippings = new HashSet<Shipping>();
        }

        public int IdShippingCompany { get; set; }
        public string BusinessName { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string Location { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public int? Cuit { get; set; }
        public TimeSpan? Shift { get; set; }
        public int? IdShippingType { get; set; }

        public virtual ShippingType IdShippingTypeNavigation { get; set; }
        public virtual ICollection<Shipping> Shippings { get; set; }
    }
}
