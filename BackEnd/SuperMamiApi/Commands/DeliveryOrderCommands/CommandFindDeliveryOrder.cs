using System;

namespace SuperMamiApi.Models
{
    public partial class CommandFindDeliveryOrder
    {
        public int IdDeliveryOrder { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? IdZone { get; set; }
        public int? IdBranch { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsShipping { get; set; }
        public double? ShippingPrice { get; set; }
        public bool? IsFree { get; set; }
    }
}
