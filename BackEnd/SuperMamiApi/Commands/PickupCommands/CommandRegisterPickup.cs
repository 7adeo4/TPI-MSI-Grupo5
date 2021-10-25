


namespace SuperMamiApi.Commands.PickupCommands
{
    public partial class CommandRegisterPickup
    {
        
        public int? DeliveryOrderNumber { get; set; }
        public int? IdBranch { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public bool? IsOwner { get; set; }    

        public int? IdUser { get; set; }    
        
        public TimeSpan? Hour { get; set; }
        public DateTime? Day { get; set; }

    }
}
