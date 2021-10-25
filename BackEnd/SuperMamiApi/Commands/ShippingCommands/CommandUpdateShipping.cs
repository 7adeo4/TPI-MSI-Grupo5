using System;

namespace SuperMamiApi.Commands.ShippingCommands
{
    public partial class CommandUpdateShipping
    {
        public int IdShipping { get; set; }
        public int? IdShippingCompany { get; set; }
        public int? IdState { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Phone { get; set; }
        public string Address { get; set; }
        public TimeSpan? Hour { get; set; }
        public DateTime? Day { get; set; }
        public int? IdZone { get; set; }
        public bool? IsOwner { get; set; }

    }
}
