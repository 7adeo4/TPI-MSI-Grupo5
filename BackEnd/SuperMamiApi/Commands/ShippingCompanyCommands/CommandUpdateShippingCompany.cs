namespace SuperMamiApi.Commands.ShippingCompanyCommands
{
    public class CommandUpdateShippingCompany
    {
                
        public int IdShippingCompany { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Cuit { get; set; }
        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
        public int? IdShippingType { get; set; }
        
    }
} 