using System;

namespace VehiclesCrud.Details
{
    public class VehicleDetails
    {
        public int Id { get; set; }
        
        public string OrderNumber { get; set; }

        public string Vin { get; set; }
        
        public string Model { get; set; }
        
        public string LicencePlate { get; set; }
        
        public DateTimeOffset DeliveryDate { get; set; }
    }
}
