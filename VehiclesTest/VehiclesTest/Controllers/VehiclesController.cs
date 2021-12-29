using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VehiclesTest.Actions;
using VehiclesTest.Database;
using VehiclesTest.Dto;
using VehiclesTest.Models;

namespace VehiclesTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VehiclesController(
            ILogger<VehiclesController> logger,
            AppDbContext context,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleDetails>> GetVehicles()
        {
            _logger.LogInformation("Getting vehicles");
            
            var vehicles = await _context.Vehicles.ToListAsync();
            var vehicleDetails = _mapper.Map<IEnumerable<VehicleDetails>>(vehicles);
            
            return vehicleDetails;
        }
        
        [HttpPost]
        public async Task<VehicleDetails> CreateVehicle([FromBody] CreateVehicleAction action)
        {
            _logger.LogInformation($"Creating vehicle with license plate {action.LicencePlate}");
            
            var vehicle = new Vehicle(
                action.OrderNumber,
                action.Vin,
                action.Model,
                action.LicencePlate,
                action.DeliveryDate);

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            var vehicleDetails = _mapper.Map<VehicleDetails>(vehicle);
            
            return vehicleDetails;
        }
        
        [HttpDelete("{id}")]
        public async Task<VehicleDetails> DeleteVehicle(int id)
        {
            _logger.LogInformation($"Creating vehicle with id {id.ToString()}");

            var vehicle = new Vehicle { Id = id };
            _context.Vehicles.Attach(vehicle);
            _context.Vehicles.Remove(vehicle);
            
            await _context.SaveChangesAsync();

            var vehicleDetails = _mapper.Map<VehicleDetails>(vehicle);
            
            return vehicleDetails;
        }
    }
}
