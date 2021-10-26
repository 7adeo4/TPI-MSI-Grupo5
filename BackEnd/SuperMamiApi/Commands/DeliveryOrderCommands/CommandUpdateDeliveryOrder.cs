using System;

namespace SuperMamiApi.Models
{
    public partial class CommandUpdateDeliveryOrder
    {
        public int IdDeliveryOrder { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? IdBranch { get; set; }
    }
}
