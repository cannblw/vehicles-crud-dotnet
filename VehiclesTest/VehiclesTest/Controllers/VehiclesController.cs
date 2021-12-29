using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VehiclesTest.Database;
using VehiclesTest.Dto;

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
    }
}
