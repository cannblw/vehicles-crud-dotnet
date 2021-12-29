using System;

namespace VehiclesTest.Dto
{
    public class VehicleDetails
    {
        public string OrderNumber { get; set; }

        public string Vin { get; set; }
        
        public string Model { get; set; }
        
        public string LicencePlate { get; set; }
        
        public DateTimeOffset DeliveryDate { get; set; }
    }
}
