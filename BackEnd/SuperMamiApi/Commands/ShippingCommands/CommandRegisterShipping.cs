namespace SuperMamiApi.Commands.ShippingCommands
{
    public partial class CommandRegisterShipping
    {

        public int? IdShippingCompany { get; set; }
        public int? IdDeliveryOrder { get; set; }
        public int? IdUser { get; set; }
        // DETAIL        
        public string Weight { get; set; }
        public string Volume { get; set; }
        public int? BagsQuantity { get; set; }

    }
}
