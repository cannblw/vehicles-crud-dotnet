using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VehiclesCrud.Actions;
using VehiclesCrud.Database;
using VehiclesCrud.Details;
using VehiclesCrud.Domain;

namespace VehiclesCrud.Controllers
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
        public async Task<ActionResult<IEnumerable<VehicleDetails>>> GetVehicles()
        {
            _logger.LogInformation("Getting vehicles");
            
            var vehicles = await _context.Vehicles.ToListAsync();
            var vehicleDetails = _mapper.Map<IEnumerable<VehicleDetails>>(vehicles);
            
            return Ok(vehicleDetails);
        }
        
        [HttpPost]
        public async Task<ActionResult<VehicleDetails>> CreateVehicle([FromBody] CreateVehicleAction action)
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
            
            return Ok(vehicleDetails);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleDetails>> DeleteVehicle(int id)
        {
            _logger.LogInformation($"Creating vehicle with id {id.ToString()}");

            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            
            _context.Vehicles.Remove(vehicle);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleDetails>> UpdateVehicle([FromBody] UpdateVehicleAction action, int id)
        {
            _logger.LogInformation($"Updating vehicle with id {id.ToString()}");

            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.Model = action.Model;
            vehicle.Vin = action.Vin;
            vehicle.DeliveryDate = action.DeliveryDate;
            vehicle.LicencePlate = action.LicencePlate;
            vehicle.OrderNumber = action.OrderNumber;
            
            await _context.SaveChangesAsync();

            var vehicleDetails = _mapper.Map<VehicleDetails>(vehicle);

            return Ok(vehicleDetails);
        }
    }
}
