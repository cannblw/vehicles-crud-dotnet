using System;

namespace VehiclesTest.Models
{
    public class Vehicle : Entity
    {
        public string OrderNumber { get; set; }

        public string Vin { get; set; }
        
        public string Model { get; set; }
        
        public string LicencePlate { get; set; }
        
        public DateTimeOffset DeliveryDate { get; set; }
        
        public Vehicle(string orderNumber, string vin, string model, string licencePlate, DateTimeOffset deliveryDate)
        {
            OrderNumber = orderNumber;
            Vin = vin;
            Model = model;
            LicencePlate = licencePlate;
            DeliveryDate = deliveryDate;
        }
    }
}
