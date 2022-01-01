using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiclesCrud.Domain;

namespace VehiclesCrud.Services
{
    public interface IVehiclesService
    {
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        
        Task<Vehicle> GetVehicle(int id);

        Task<Vehicle> CreateVehicle(string orderNumber, string vin, string model, string licencePlate,
            DateTimeOffset deliveryDate);

        Task DeleteVehicle(int id);

        Task<Vehicle> UpdateVehicle(int id, string orderNumber, string vin, string model, string licencePlate,
            DateTimeOffset deliveryDate);
    }
}
