using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehiclesCrud.Actions;
using VehiclesCrud.Details;
using VehiclesCrud.Services;

namespace VehiclesCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;
        private readonly IMapper _mapper;
        private readonly IVehiclesService _vehiclesService;

        public VehiclesController(
            ILogger<VehiclesController> logger,
            IMapper mapper,
            IVehiclesService vehiclesService)
        {
            _logger = logger;
            _mapper = mapper;
            _vehiclesService = vehiclesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDetails>>> GetAllVehicles()
        {
            _logger.LogInformation("Getting vehicles");

            var vehicles = await _vehiclesService.GetAllVehicles();
            var vehicleDetails = _mapper.Map<IEnumerable<VehicleDetails>>(vehicles);
            
            return Ok(vehicleDetails);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleDetails>> GetVehicle(int id)
        {
            _logger.LogInformation("Getting vehicle with it {Id}", id.ToString());

            var vehicle = await _vehiclesService.GetVehicle(id);
            var vehicleDetails = _mapper.Map<VehicleDetails>(vehicle);
            
            return Ok(vehicleDetails);
        }
        
        [HttpPost]
        public async Task<ActionResult<VehicleDetails>> CreateVehicle([FromBody] CreateVehicleAction action)
        {
            _logger.LogInformation("Creating vehicle with license plate {LicencePlate}", action.LicencePlate);

            var vehicle = await _vehiclesService.CreateVehicle(
                action.OrderNumber,
                action.Vin,
                action.Model,
                action.LicencePlate,
                action.DeliveryDate);

            var vehicleDetails = _mapper.Map<VehicleDetails>(vehicle);
            
            return Ok(vehicleDetails);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleDetails>> DeleteVehicle(int id)
        {
            _logger.LogInformation("Deleting vehicle with id {Id}", id.ToString());

            await _vehiclesService.DeleteVehicle(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleDetails>> UpdateVehicle(int id, [FromBody] UpdateVehicleAction action)
        {
            _logger.LogInformation("Updating vehicle with id {Id}", id.ToString());

            var vehicle = await _vehiclesService.UpdateVehicle(
                id,
                action.OrderNumber,
                action.Vin,
                action.Model,
                action.LicencePlate,
                action.DeliveryDate);
                
            var vehicleDetails = _mapper.Map<VehicleDetails>(vehicle);

            return Ok(vehicleDetails);
        }
    }
}
