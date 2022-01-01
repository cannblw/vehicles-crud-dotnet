using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehiclesCrud.Database;
using VehiclesCrud.Domain;
using VehiclesCrud.Exceptions;

namespace VehiclesCrud.Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly AppDbContext _context;

        public VehiclesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                throw new EntityNotFoundException();
            }

            return vehicle;
        }

        public async Task<Vehicle> CreateVehicle(
            string orderNumber,
            string vin,
            string model,
            string licencePlate,
            DateTimeOffset deliveryDate)
        {
            var vehicle = new Vehicle(
                orderNumber,
                vin,
                model,
                licencePlate,
                deliveryDate);

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        public async Task DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                throw new EntityNotFoundException();
            }
            
            _context.Vehicles.Remove(vehicle);
            
            await _context.SaveChangesAsync();
        }

        public async Task<Vehicle> UpdateVehicle(
            int id,
            string orderNumber,
            string vin,
            string model,
            string licencePlate,
            DateTimeOffset deliveryDate)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                throw new EntityNotFoundException();
            }

            vehicle.Model = model;
            vehicle.Vin = vin;
            vehicle.DeliveryDate = deliveryDate;
            vehicle.LicencePlate = licencePlate;
            vehicle.OrderNumber = orderNumber;
            
            await _context.SaveChangesAsync();

            return vehicle;
        }
    }
}
