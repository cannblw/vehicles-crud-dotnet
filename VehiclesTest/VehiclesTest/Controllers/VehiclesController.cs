using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehiclesTest.Models;

namespace VehiclesTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;

        public VehiclesController(ILogger<VehiclesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return Array.Empty<Vehicle>();
        }
    }
}
