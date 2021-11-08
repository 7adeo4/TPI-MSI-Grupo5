using System;

namespace SuperMamiApi.Commands.DeliveryOrderCommands

{
    public partial class CommandUpdateDeliveryOrder
    {
        public int IdDeliveryOrder { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int? IdBranch { get; set; }
    }
}
