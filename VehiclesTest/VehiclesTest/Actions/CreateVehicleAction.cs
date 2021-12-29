using System;

namespace VehiclesTest.Actions
{
    public class CreateVehicleAction
    {
        public string OrderNumber { get; set; }

        public string Vin { get; set; }
        
        public string Model { get; set; }
        
        public string LicencePlate { get; set; }
        
        public DateTimeOffset DeliveryDate { get; set; }
    }
}
