using System;
using VehiclesTest.Actions;

namespace VehiclesTest.Dto
{
    public class VehicleDetails : Details
    {
        public string OrderNumber { get; set; }

        public string Vin { get; set; }
        
        public string Model { get; set; }
        
        public string LicencePlate { get; set; }
        
        public DateTimeOffset DeliveryDate { get; set; }
    }
}
